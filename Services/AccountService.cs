using System.Data;
using AccountingSystemForWindowsFormLast.Data;
using AccountingSystemForWindowsFormLast.Models;
using Microsoft.Data.SqlClient;

namespace AccountingSystemForWindowsFormLast.Services
{
    public class AccountService
    {
        public List<Account> GetAll()
        {
            const string sql = @"
                SELECT
                    AccountId,
                    AccountNumber,
                    AccountName,
                    AccountType,
                    ParentAccountId,
                    IsGroup,
                    IsSystem,
                    AccountNature
                FROM Accounts
                ORDER BY AccountNumber";

            List<Account> accounts = new();

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            using SqlCommand command =
                new SqlCommand(sql, connection);

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                accounts.Add(MapAccount(reader));
            }

            return accounts;
        }

        public List<Account> GetLeafAccounts()
        {
            const string sql = @"
                SELECT
                    AccountId,
                    AccountNumber,
                    AccountName,
                    AccountType,
                    ParentAccountId,
                    IsGroup,
                    IsSystem,
                    AccountNature
                FROM Accounts
                WHERE IsGroup = 0
                ORDER BY AccountNumber";

            return ExecuteList(sql);
        }

        public List<Account> GetGroupAccounts()
        {
            const string sql = @"
                SELECT
                    AccountId,
                    AccountNumber,
                    AccountName,
                    AccountType,
                    ParentAccountId,
                    IsGroup,
                    IsSystem,
                    AccountNature
                FROM Accounts
                WHERE IsGroup = 1
                ORDER BY AccountNumber";

            return ExecuteList(sql);
        }

        public Account? GetById(int accountId)
        {
            const string sql = @"
                SELECT
                    AccountId,
                    AccountNumber,
                    AccountName,
                    AccountType,
                    ParentAccountId,
                    IsGroup,
                    IsSystem,
                    AccountNature
                FROM Accounts
                WHERE AccountId = @AccountId";

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            using SqlCommand command =
                new SqlCommand(sql, connection);

            command.Parameters.Add("@AccountId", SqlDbType.Int)
                .Value = accountId;

            using SqlDataReader reader =
                command.ExecuteReader();

            if (!reader.Read())
                return null;

            return MapAccount(reader);
        }

        public List<AccountItem> GetAccountItems(bool onlyLeafAccounts = true)
        {
            const string sql = @"
                SELECT
                    AccountId,
                    AccountNumber,
                    AccountName
                FROM Accounts
                WHERE (@OnlyLeaf = 0 OR IsGroup = 0)
                ORDER BY AccountNumber";

            List<AccountItem> accounts = new();

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            using SqlCommand command =
                new SqlCommand(sql, connection);

            command.Parameters.Add("@OnlyLeaf", SqlDbType.Bit)
                .Value = onlyLeafAccounts;

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                accounts.Add(new AccountItem
                {
                    AccountId = Convert.ToInt32(reader["AccountId"]),
                    AccountNumber = reader["AccountNumber"].ToString() ?? "",
                    AccountName = reader["AccountName"].ToString() ?? ""
                });
            }

            return accounts;
        }

        public int? GetIdByNumber(
            string accountNumber,
            SqlConnection? connection = null,
            SqlTransaction? transaction = null)
        {
            const string sql = @"
                SELECT AccountId
                FROM Accounts
                WHERE AccountNumber = @AccountNumber";

            bool ownsConnection = connection == null;

            connection ??= DatabaseConnection.GetConnection();

            if (ownsConnection)
                connection.Open();

            using SqlCommand command =
                new SqlCommand(sql, connection, transaction);

            command.Parameters.Add("@AccountNumber", SqlDbType.NVarChar, 50)
                .Value = accountNumber;

            object? result = command.ExecuteScalar();

            if (ownsConnection)
                connection.Dispose();

            return result == null || result == DBNull.Value
                ? null
                : Convert.ToInt32(result);
        }

        public int Add(Account account)
        {
            const string sql = @"
                INSERT INTO Accounts
                (
                    AccountNumber,
                    AccountName,
                    AccountType,
                    ParentAccountId,
                    IsGroup,
                    IsSystem,
                    AccountNature
                )
                VALUES
                (
                    @AccountNumber,
                    @AccountName,
                    @AccountType,
                    @ParentAccountId,
                    @IsGroup,
                    @IsSystem,
                    @AccountNature
                );

                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            using SqlCommand command =
                new SqlCommand(sql, connection);

            AddParameters(command, account);

            return Convert.ToInt32(command.ExecuteScalar());
        }

        public void Update(Account account)
        {
            const string sql = @"
                UPDATE Accounts
                SET
                    AccountNumber = @AccountNumber,
                    AccountName = @AccountName,
                    AccountType = @AccountType,
                    ParentAccountId = @ParentAccountId,
                    IsGroup = @IsGroup,
                    AccountNature = @AccountNature
                WHERE AccountId = @AccountId";

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            using SqlCommand command =
                new SqlCommand(sql, connection);

            AddParameters(command, account);

            command.Parameters.Add("@AccountId", SqlDbType.Int)
                .Value = account.AccountId;

            command.ExecuteNonQuery();
        }

        public void Delete(int accountId)
        {
            const string sql = @"
                DELETE FROM Accounts
                WHERE AccountId = @AccountId";

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            using SqlCommand command =
                new SqlCommand(sql, connection);

            command.Parameters.Add("@AccountId", SqlDbType.Int)
                .Value = accountId;

            command.ExecuteNonQuery();
        }

        private List<Account> ExecuteList(string sql)
        {
            List<Account> accounts = new();

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            using SqlCommand command =
                new SqlCommand(sql, connection);

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                accounts.Add(MapAccount(reader));
            }

            return accounts;
        }

        private static Account MapAccount(SqlDataReader reader)
        {
            return new Account
            {
                AccountId = Convert.ToInt32(reader["AccountId"]),
                AccountNumber = reader["AccountNumber"].ToString() ?? "",
                AccountName = reader["AccountName"].ToString() ?? "",
                AccountType = reader["AccountType"].ToString() ?? "",
                ParentAccountId =
                    reader["ParentAccountId"] == DBNull.Value
                        ? null
                        : Convert.ToInt32(reader["ParentAccountId"]),
                IsGroup = Convert.ToBoolean(reader["IsGroup"]),
                IsSystem = Convert.ToBoolean(reader["IsSystem"]),
                AccountNature =
                    reader["AccountNature"] == DBNull.Value
                        ? ""
                        : reader["AccountNature"].ToString() ?? ""
            };
        }

        private static void AddParameters(
            SqlCommand command,
            Account account)
        {
            command.Parameters.Add("@AccountNumber", SqlDbType.NVarChar, 50)
                .Value = account.AccountNumber.Trim();

            command.Parameters.Add("@AccountName", SqlDbType.NVarChar, 200)
                .Value = account.AccountName.Trim();

            command.Parameters.Add("@AccountType", SqlDbType.NVarChar, 50)
                .Value = account.AccountType.Trim();

            command.Parameters.Add("@ParentAccountId", SqlDbType.Int)
                .Value = account.ParentAccountId.HasValue
                    ? account.ParentAccountId.Value
                    : DBNull.Value;

            command.Parameters.Add("@IsGroup", SqlDbType.Bit)
                .Value = account.IsGroup;

            command.Parameters.Add("@IsSystem", SqlDbType.Bit)
                .Value = account.IsSystem;

            command.Parameters.Add("@AccountNature", SqlDbType.NVarChar, 10)
                .Value = string.IsNullOrWhiteSpace(account.AccountNature)
                    ? DBNull.Value
                    : account.AccountNature.Trim();
        }
    }
}