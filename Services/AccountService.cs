
using System.Data;
using AccountingSystemForWindowsFormLast.Data;
using AccountingSystemForWindowsFormLast.Models;

using Microsoft.Data.SqlClient;

namespace AccountingSystemForWindowsFormLast.Services
{
    public class AccountService
    {
        public DataTable GetDataTable()
        {
            using SqlConnection con = DatabaseConnection.GetConnection();
            con.Open();

            const string query = @"
                SELECT
                    AccountId,
                    AccountNumber,
                    AccountName,
                    AccountType,
                    AccountNature,
                    ParentAccountId,
                    IsGroup,
                    IsSystem
                FROM Accounts
                ORDER BY
                    LEN(AccountNumber),
                    AccountNumber";

            using SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public List<Account> GetAll()
        {
            List<Account> list = new List<Account>();
            using SqlConnection con = DatabaseConnection.GetConnection();
            con.Open();

            const string query = @"
                SELECT
                    AccountId,
                    AccountNumber,
                    AccountName,
                    AccountType,
                    AccountNature,
                    ParentAccountId,
                    IsGroup,
                    IsSystem
                FROM Accounts
                ORDER BY
                    LEN(AccountNumber),
                    AccountNumber";

            using SqlCommand cmd = new SqlCommand(query, con);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(MapAccount(reader));
            }

            return list;
        }

        public List<AccountItem> GetLeafAccounts()
        {
            List<AccountItem> list = new List<AccountItem>();
            using SqlConnection con = DatabaseConnection.GetConnection();
            con.Open();

            const string query = @"
                SELECT
                    AccountId,
                    AccountNumber,
                    AccountName,
                    AccountNature
                FROM Accounts
                WHERE IsGroup = 0
                ORDER BY AccountNumber";

            using SqlCommand cmd = new SqlCommand(query, con);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new AccountItem
                {
                    AccountId = Convert.ToInt32(reader["AccountId"]),
                    AccountNumber = reader["AccountNumber"]?.ToString() ?? "",
                    AccountName = reader["AccountName"]?.ToString() ?? "",
                    AccountNature = reader["AccountNature"]?.ToString() ?? ""
                });
            }

            return list;
        }

        public List<AccountItem> GetParentAccounts()
        {
            List<AccountItem> list = new List<AccountItem>();
            using SqlConnection con = DatabaseConnection.GetConnection();
            con.Open();

            const string query = @"
                SELECT
                    AccountId,
                    AccountNumber,
                    AccountName,
                    AccountNature
                FROM Accounts
                WHERE IsGroup = 1
                ORDER BY
                    LEN(AccountNumber),
                    AccountNumber";

            using SqlCommand cmd = new SqlCommand(query, con);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new AccountItem
                {
                    AccountId = Convert.ToInt32(reader["AccountId"]),
                    AccountNumber = reader["AccountNumber"]?.ToString() ?? "",
                    AccountName = reader["AccountName"]?.ToString() ?? "",
                    AccountNature = reader["AccountNature"]?.ToString() ?? ""
                });
            }

            return list;
        }

        public Account? GetById(int accountId)
        {
            using SqlConnection con = DatabaseConnection.GetConnection();
            con.Open();

            const string query = @"
                SELECT
                    AccountId,
                    AccountNumber,
                    AccountName,
                    AccountType,
                    AccountNature,
                    ParentAccountId,
                    IsGroup,
                    IsSystem
                FROM Accounts
                WHERE AccountId = @AccountId";

            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@AccountId", SqlDbType.Int).Value = accountId;

            using SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
                return null;

            return MapAccount(reader);
        }

        public int? GetIdByNumber(
            string accountNumber,
            SqlConnection? connection = null,
            SqlTransaction? transaction = null)
        {
            const string sql = @"
                SELECT TOP 1 AccountId
                FROM Accounts
                WHERE AccountNumber = @AccountNumber";

            bool ownsConnection = connection == null;
            connection ??= DatabaseConnection.GetConnection();

            if (ownsConnection)
                connection.Open();

            try
            {
                using SqlCommand command = new SqlCommand(sql, connection, transaction);
                command.Parameters.Add("@AccountNumber", SqlDbType.NVarChar, 50).Value = accountNumber.Trim();

                object? result = command.ExecuteScalar();
                return result == null || result == DBNull.Value ? null : Convert.ToInt32(result);
            }
            finally
            {
                if (ownsConnection)
                    connection.Dispose();
            }
        }

        public string GetNatureByAccountType(string accountType)
        {
            return accountType switch
            {
                "أصول" => "مدين",
                "مصروفات" => "مدين",
                "خصوم" => "دائن",
                "حقوق ملكية" => "دائن",
                "إيرادات" => "دائن",
                _ => "مدين"
            };
        }

        public string GenerateAccountNumber(int? parentId, int? excludeAccountId = null)
        {
            using SqlConnection con = DatabaseConnection.GetConnection();
            con.Open();

            string prefix = "";

            if (parentId.HasValue && parentId.Value > 0)
            {
                const string parentQuery = "SELECT AccountNumber FROM Accounts WHERE AccountId = @ParentAccountId";
                using SqlCommand parentCmd = new SqlCommand(parentQuery, con);
                parentCmd.Parameters.Add("@ParentAccountId", SqlDbType.Int).Value = parentId.Value;

                object? parentResult = parentCmd.ExecuteScalar();
                if (parentResult != null && parentResult != DBNull.Value)
                {
                    prefix = parentResult.ToString()?.Trim() ?? "";
                }
            }

            string query;
            if (string.IsNullOrEmpty(prefix))
            {
                query = @"
                    SELECT AccountNumber
                    FROM Accounts
                    WHERE ParentAccountId IS NULL
                      AND (@ExcludeAccountId IS NULL OR AccountId <> @ExcludeAccountId)";
            }
            else
            {
                query = @"
                    SELECT AccountNumber
                    FROM Accounts
                    WHERE ParentAccountId = @ParentAccountId
                      AND (@ExcludeAccountId IS NULL OR AccountId <> @ExcludeAccountId)";
            }

            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@ExcludeAccountId", SqlDbType.Int).Value =
                excludeAccountId.HasValue ? excludeAccountId.Value : DBNull.Value;

            if (!string.IsNullOrEmpty(prefix))
            {
                cmd.Parameters.Add("@ParentAccountId", SqlDbType.Int).Value = parentId!.Value;
            }

            HashSet<int> usedNumbers = new HashSet<int>();
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string number = reader["AccountNumber"]?.ToString() ?? "";
                if (string.IsNullOrEmpty(prefix))
                {
                    if (int.TryParse(number, out int val))
                        usedNumbers.Add(val);
                }
                else
                {
                    if (number.StartsWith(prefix) && number.Length > prefix.Length)
                    {
                        string suffix = number[prefix.Length..];
                        if (int.TryParse(suffix, out int val))
                            usedNumbers.Add(val);
                    }
                }
            }

            int next = 1;
            while (usedNumbers.Contains(next))
            {
                next++;
            }

            return prefix + next;
        }

        public int Add(Account account)
        {
            if (string.IsNullOrWhiteSpace(account.AccountNature))
            {
                account.AccountNature = GetNatureByAccountType(account.AccountType);
            }

            const string sql = @"
                INSERT INTO Accounts
                (
                    AccountNumber,
                    AccountName,
                    AccountType,
                    AccountNature,
                    ParentAccountId,
                    IsGroup,
                    IsSystem
                )
                VALUES
                (
                    @AccountNumber,
                    @AccountName,
                    @AccountType,
                    @AccountNature,
                    @ParentAccountId,
                    @IsGroup,
                    @IsSystem
                );

                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            using SqlCommand command = new SqlCommand(sql, connection);
            AddParameters(command, account);

            return Convert.ToInt32(command.ExecuteScalar());
        }

        public void Update(Account account)
        {
            if (string.IsNullOrWhiteSpace(account.AccountNature))
            {
                account.AccountNature = GetNatureByAccountType(account.AccountType);
            }

            const string sql = @"
                UPDATE Accounts
                SET
                    AccountNumber = @AccountNumber,
                    AccountName = @AccountName,
                    AccountType = @AccountType,
                    AccountNature = @AccountNature,
                    ParentAccountId = @ParentAccountId,
                    IsGroup = @IsGroup
                WHERE AccountId = @AccountId";

            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            using SqlCommand command = new SqlCommand(sql, connection);
            AddParameters(command, account);
            command.Parameters.Add("@AccountId", SqlDbType.Int).Value = account.AccountId;

            command.ExecuteNonQuery();
        }

        public void Delete(int accountId)
        {
            using SqlConnection con = DatabaseConnection.GetConnection();
            con.Open();

            if (IsSystemAccount(con, accountId))
            {
                throw new InvalidOperationException("لا يمكن حذف حساب نظام أساسي.");
            }

            if (HasChildren(con, accountId))
            {
                throw new InvalidOperationException("لا يمكن حذف هذا الحساب لأنه يحتوي على حسابات فرعية.");
            }

            if (IsAccountUsed(con, accountId))
            {
                throw new InvalidOperationException("لا يمكن حذف هذا الحساب لأنه مرتبط بعمليات مالية سابقة (قيود، فواتير، أو سندات).");
            }

            const string query = "DELETE FROM Accounts WHERE AccountId = @AccountId";
            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@AccountId", SqlDbType.Int).Value = accountId;
            cmd.ExecuteNonQuery();
        }

        public bool IsSystemAccount(int accountId)
        {
            using SqlConnection con = DatabaseConnection.GetConnection();
            con.Open();
            return IsSystemAccount(con, accountId);
        }

        private static bool IsSystemAccount(SqlConnection con, int accountId)
        {
            const string query = "SELECT IsSystem FROM Accounts WHERE AccountId = @AccountId";
            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@AccountId", SqlDbType.Int).Value = accountId;
            object? result = cmd.ExecuteScalar();
            return result != null && result != DBNull.Value && Convert.ToBoolean(result);
        }

        public bool HasChildren(int accountId)
        {
            using SqlConnection con = DatabaseConnection.GetConnection();
            con.Open();
            return HasChildren(con, accountId);
        }

        private static bool HasChildren(SqlConnection con, int accountId)
        {
            const string query = "SELECT COUNT(*) FROM Accounts WHERE ParentAccountId = @AccountId";
            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@AccountId", SqlDbType.Int).Value = accountId;
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public bool IsAccountUsed(int accountId)
        {
            using SqlConnection con = DatabaseConnection.GetConnection();
            con.Open();
            return IsAccountUsed(con, accountId);
        }

        private static bool IsAccountUsed(SqlConnection con, int accountId)
        {
            const string query = @"
                SELECT
                    (SELECT COUNT(*) FROM JournalEntryDetails WHERE AccountId = @AccountId) +
                    (SELECT COUNT(*) FROM PurchaseInvoices WHERE AccountId = @AccountId) +
                    (SELECT COUNT(*) FROM SalesInvoices WHERE AccountId = @AccountId) +
                    (SELECT COUNT(*) FROM PaymentVouchers WHERE AccountId = @AccountId) +
                    (SELECT COUNT(*) FROM ReceiptVouchers WHERE AccountId = @AccountId)";

            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@AccountId", SqlDbType.Int).Value = accountId;
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public string? GetParentAccountType(int parentId)
        {
            using SqlConnection con = DatabaseConnection.GetConnection();
            con.Open();

            const string query = "SELECT AccountType FROM Accounts WHERE AccountId = @AccountId";
            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@AccountId", SqlDbType.Int).Value = parentId;
            object? result = cmd.ExecuteScalar();
            return result?.ToString();
        }

        private static Account MapAccount(SqlDataReader reader)
        {
            return new Account
            {
                AccountId = Convert.ToInt32(reader["AccountId"]),
                AccountNumber = reader["AccountNumber"]?.ToString() ?? "",
                AccountName = reader["AccountName"]?.ToString() ?? "",
                AccountType = reader["AccountType"]?.ToString() ?? "",
                AccountNature = reader["AccountNature"] == DBNull.Value ? "" : reader["AccountNature"]?.ToString() ?? "",
                ParentAccountId = reader["ParentAccountId"] == DBNull.Value ? null : Convert.ToInt32(reader["ParentAccountId"]),
                IsGroup = Convert.ToBoolean(reader["IsGroup"]),
                IsSystem = Convert.ToBoolean(reader["IsSystem"])
            };
        }

        private static void AddParameters(SqlCommand command, Account account)
        {
            command.Parameters.Add("@AccountNumber", SqlDbType.NVarChar, 50).Value = account.AccountNumber.Trim();
            command.Parameters.Add("@AccountName", SqlDbType.NVarChar, 200).Value = account.AccountName.Trim();
            command.Parameters.Add("@AccountType", SqlDbType.NVarChar, 50).Value = account.AccountType.Trim();
            command.Parameters.Add("@AccountNature", SqlDbType.NVarChar, 20).Value =
                string.IsNullOrWhiteSpace(account.AccountNature) ? DBNull.Value : account.AccountNature.Trim();
            command.Parameters.Add("@ParentAccountId", SqlDbType.Int).Value =
                account.ParentAccountId.HasValue ? account.ParentAccountId.Value : DBNull.Value;
            command.Parameters.Add("@IsGroup", SqlDbType.Bit).Value = account.IsGroup;
            command.Parameters.Add("@IsSystem", SqlDbType.Bit).Value = account.IsSystem;
        }
    }
}
