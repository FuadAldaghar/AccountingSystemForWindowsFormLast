using System.Data;
using AccountingSystemForWindowsFormLast.Data;
using AccountingSystemForWindowsFormLast.Models;
using Microsoft.Data.SqlClient;

namespace AccountingSystemForWindowsFormLast.Services
{
    public class ItemService
    {
        public List<Item> GetAll()
        {
            const string sql = @"
                SELECT
                    ItemId,
                    ItemNumber,
                    ItemName,
                    Unit
                FROM Items
                ORDER BY ItemNumber";

            List<Item> items = new();

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            using SqlCommand command =
                new SqlCommand(sql, connection);

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                items.Add(MapItem(reader));
            }

            return items;
        }

        public Item? GetById(int itemId)
        {
            const string sql = @"
                SELECT
                    ItemId,
                    ItemNumber,
                    ItemName,
                    Unit
                FROM Items
                WHERE ItemId = @ItemId";

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            using SqlCommand command =
                new SqlCommand(sql, connection);

            command.Parameters.Add("@ItemId", SqlDbType.Int)
                .Value = itemId;

            using SqlDataReader reader =
                command.ExecuteReader();

            if (!reader.Read())
                return null;

            return MapItem(reader);
        }

        public string GetNextItemNumber()
        {
            const string sql = @"
                SELECT ISNULL(
                    MAX(TRY_CAST(ItemNumber AS INT)),
                    0
                ) + 1
                FROM Items";

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            using SqlCommand command =
                new SqlCommand(sql, connection);

            return Convert.ToInt32(
                command.ExecuteScalar()
            ).ToString();
        }

        public int Add(Item item)
        {
            const string sql = @"
                INSERT INTO Items
                (
                    ItemNumber,
                    ItemName,
                    Unit
                )
                VALUES
                (
                    @ItemNumber,
                    @ItemName,
                    @Unit
                );

                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            using SqlCommand command =
                new SqlCommand(sql, connection);

            AddParameters(command, item);

            return Convert.ToInt32(
                command.ExecuteScalar());
        }

        public void Update(Item item)
        {
            const string sql = @"
                UPDATE Items
                SET
                    ItemName = @ItemName,
                    Unit = @Unit
                WHERE ItemId = @ItemId";

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            using SqlCommand command =
                new SqlCommand(sql, connection);

            command.Parameters.Add("@ItemName", SqlDbType.NVarChar, 200)
                .Value = item.ItemName.Trim();

            command.Parameters.Add("@Unit", SqlDbType.NVarChar, 50)
                .Value = item.Unit.Trim();

            command.Parameters.Add("@ItemId", SqlDbType.Int)
                .Value = item.ItemId;

            command.ExecuteNonQuery();
        }

        public void Delete(int itemId)
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            if (IsUsedInPurchaseInvoices(itemId))
            {
                throw new InvalidOperationException(
                    "لا يمكن حذف الصنف لأنه مستخدم في فواتير المشتريات.");
            }

            if (IsUsedInSalesInvoices(itemId))
            {
                throw new InvalidOperationException(
                    "لا يمكن حذف الصنف لأنه مستخدم في فواتير المبيعات.");
            }

            const string sql = @"
                DELETE FROM Items
                WHERE ItemId = @ItemId";

            using SqlCommand command =
                new SqlCommand(sql, connection);

            command.Parameters.Add("@ItemId", SqlDbType.Int)
                .Value = itemId;

            command.ExecuteNonQuery();
        }

        public bool IsUsedInPurchaseInvoices(int itemId)
        {
            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            const string query = @"
        SELECT COUNT(*)
        FROM PurchaseInvoiceDetails
        WHERE ItemId = @ItemId";

            using SqlCommand command = new(query, connection);

            command.Parameters.Add("@ItemId", SqlDbType.Int)
                .Value = itemId;

            return Convert.ToInt32(command.ExecuteScalar()) > 0;
        }

        public bool IsUsedInSalesInvoices(int itemId)
        {
            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            const string query = @"
        SELECT COUNT(*)
        FROM SalesInvoiceDetails
        WHERE ItemId = @ItemId";

            using SqlCommand command = new(query, connection);

            command.Parameters.Add("@ItemId", SqlDbType.Int)
                .Value = itemId;

            return Convert.ToInt32(command.ExecuteScalar()) > 0;
        }

        private static Item MapItem(SqlDataReader reader)
        {
            return new Item
            {
                ItemId = Convert.ToInt32(reader["ItemId"]),
                ItemNumber = reader["ItemNumber"].ToString() ?? "",
                ItemName = reader["ItemName"].ToString() ?? "",
                Unit = reader["Unit"].ToString() ?? ""
            };
        }

        private static void AddParameters(
            SqlCommand command,
            Item item)
        {
            command.Parameters.Add(
                "@ItemNumber",
                SqlDbType.NVarChar,
                50).Value = item.ItemNumber.Trim();

            command.Parameters.Add(
                "@ItemName",
                SqlDbType.NVarChar,
                200).Value = item.ItemName.Trim();

            command.Parameters.Add(
                "@Unit",
                SqlDbType.NVarChar,
                50).Value = item.Unit.Trim();
        }
    }
}