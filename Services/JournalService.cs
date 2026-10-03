
using System.Data;
using AccountingSystemForWindowsFormLast.Data;
using AccountingSystemForWindowsFormLast.Models;
using Microsoft.Data.SqlClient;

namespace AccountingSystemForWindowsFormLast.Services
{
    public class JournalService
    {
        public string GetNextEntryNumber(SqlConnection? connection = null, SqlTransaction? transaction = null)
        {
            bool ownsConnection = connection == null;
            connection ??= DatabaseConnection.GetConnection();

            if (ownsConnection)
                connection.Open();

            try
            {
                const string sql = @"
                    SELECT ISNULL(
                        MAX(TRY_CAST(EntryNumber AS INT)),
                        0
                    ) + 1
                    FROM JournalEntries";

                using SqlCommand command = new SqlCommand(sql, connection, transaction);
                return Convert.ToInt32(command.ExecuteScalar()).ToString();
            }
            finally
            {
                if (ownsConnection)
                    connection.Dispose();
            }
        }

        public DataTable GetEntriesTable()
        {
            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            const string sql = @"
                SELECT
                    JournalEntryId,
                    EntryNumber,
                    EntryDate,
                    Description
                FROM JournalEntries
                ORDER BY JournalEntryId DESC";

            using SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public List<JournalLine> GetEntryDetails(int journalEntryId)
        {
            List<JournalLine> lines = new List<JournalLine>();
            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            const string sql = @"
                SELECT
                    jed.JournalEntryDetailId,
                    jed.AccountId,
                    a.AccountNumber,
                    a.AccountName,
                    jed.Debit,
                    jed.Credit,
                    jed.Description
                FROM JournalEntryDetails jed
                INNER JOIN Accounts a
                    ON a.AccountId = jed.AccountId
                WHERE jed.JournalEntryId = @JournalEntryId
                ORDER BY jed.JournalEntryDetailId";

            using SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add("@JournalEntryId", SqlDbType.Int).Value = journalEntryId;

            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string accNum = reader["AccountNumber"]?.ToString() ?? "";
                string accName = reader["AccountName"]?.ToString() ?? "";
                lines.Add(new JournalLine
                {
                    JournalEntryDetailId = Convert.ToInt32(reader["JournalEntryDetailId"]),
                    AccountId = Convert.ToInt32(reader["AccountId"]),
                    AccountName = $"{accNum} - {accName}",
                    Debit = Convert.ToDecimal(reader["Debit"]),
                    Credit = Convert.ToDecimal(reader["Credit"]),
                    Description = reader["Description"]?.ToString() ?? ""
                });
            }

            return lines;
        }

        public int CreateJournalEntry(
            DateTime entryDate,
            string description,
            IEnumerable<JournalLine> lines)
        {
            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            using SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                int id = CreateJournalEntry(connection, transaction, entryDate, description, lines);
                transaction.Commit();
                return id;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public int CreateJournalEntry(
            SqlConnection connection,
            SqlTransaction transaction,
            DateTime entryDate,
            string description,
            IEnumerable<JournalLine> lines)
        {
            List<JournalLine> journalLines = lines.ToList();
            ValidateLines(journalLines);

            string entryNumber = GetNextEntryNumber(connection, transaction);

            const string headerSql = @"
                INSERT INTO JournalEntries
                (
                    EntryNumber,
                    EntryDate,
                    Description
                )
                VALUES
                (
                    @EntryNumber,
                    @EntryDate,
                    @Description
                );

                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            int journalEntryId;
            using (SqlCommand command = new SqlCommand(headerSql, connection, transaction))
            {
                command.Parameters.Add("@EntryNumber", SqlDbType.NVarChar, 50).Value = entryNumber;
                command.Parameters.Add("@EntryDate", SqlDbType.Date).Value = entryDate.Date;
                command.Parameters.Add("@Description", SqlDbType.NVarChar, 500).Value =
                    string.IsNullOrWhiteSpace(description) ? DBNull.Value : description.Trim();

                journalEntryId = Convert.ToInt32(command.ExecuteScalar());
            }

            foreach (JournalLine line in journalLines)
            {
                InsertJournalDetail(connection, transaction, journalEntryId, line);
            }

            return journalEntryId;
        }

        public void UpdateJournalEntry(
            int journalEntryId,
            string entryNumber,
            DateTime entryDate,
            string description,
            IEnumerable<JournalLine> lines)
        {
            List<JournalLine> journalLines = lines.ToList();
            ValidateLines(journalLines);

            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            using SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                const string updateHeaderSql = @"
                    UPDATE JournalEntries
                    SET
                        EntryNumber = @EntryNumber,
                        EntryDate = @EntryDate,
                        Description = @Description
                    WHERE JournalEntryId = @JournalEntryId";

                using (SqlCommand command = new SqlCommand(updateHeaderSql, connection, transaction))
                {
                    command.Parameters.Add("@EntryNumber", SqlDbType.NVarChar, 50).Value = entryNumber.Trim();
                    command.Parameters.Add("@EntryDate", SqlDbType.Date).Value = entryDate.Date;
                    command.Parameters.Add("@Description", SqlDbType.NVarChar, 500).Value =
                        string.IsNullOrWhiteSpace(description) ? DBNull.Value : description.Trim();
                    command.Parameters.Add("@JournalEntryId", SqlDbType.Int).Value = journalEntryId;

                    command.ExecuteNonQuery();
                }

                const string deleteDetailsSql = "DELETE FROM JournalEntryDetails WHERE JournalEntryId = @JournalEntryId";
                using (SqlCommand delCmd = new SqlCommand(deleteDetailsSql, connection, transaction))
                {
                    delCmd.Parameters.Add("@JournalEntryId", SqlDbType.Int).Value = journalEntryId;
                    delCmd.ExecuteNonQuery();
                }

                foreach (JournalLine line in journalLines)
                {
                    InsertJournalDetail(connection, transaction, journalEntryId, line);
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void DeleteJournalEntry(int journalEntryId)
        {
            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            using SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                const string deleteDetailsSql = "DELETE FROM JournalEntryDetails WHERE JournalEntryId = @JournalEntryId";
                using (SqlCommand delCmd = new SqlCommand(deleteDetailsSql, connection, transaction))
                {
                    delCmd.Parameters.Add("@JournalEntryId", SqlDbType.Int).Value = journalEntryId;
                    delCmd.ExecuteNonQuery();
                }

                const string deleteHeaderSql = "DELETE FROM JournalEntries WHERE JournalEntryId = @JournalEntryId";
                using (SqlCommand delCmd = new SqlCommand(deleteHeaderSql, connection, transaction))
                {
                    delCmd.Parameters.Add("@JournalEntryId", SqlDbType.Int).Value = journalEntryId;
                    delCmd.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void InsertJournalDetail(
            SqlConnection connection,
            SqlTransaction transaction,
            int journalEntryId,
            JournalLine line)
        {
            ValidateLine(line);

            const string sql = @"
                INSERT INTO JournalEntryDetails
                (
                    JournalEntryId,
                    AccountId,
                    Debit,
                    Credit,
                    Description
                )
                VALUES
                (
                    @JournalEntryId,
                    @AccountId,
                    @Debit,
                    @Credit,
                    @Description)";

            using SqlCommand command = new SqlCommand(sql, connection, transaction);
            command.Parameters.Add("@JournalEntryId", SqlDbType.Int).Value = journalEntryId;
            command.Parameters.Add("@AccountId", SqlDbType.Int).Value = line.AccountId;
            command.Parameters.Add("@Debit", SqlDbType.Decimal).Value = line.Debit;
            command.Parameters.Add("@Credit", SqlDbType.Decimal).Value = line.Credit;
            command.Parameters.Add("@Description", SqlDbType.NVarChar, 500).Value =
                string.IsNullOrWhiteSpace(line.Description) ? DBNull.Value : line.Description.Trim();

            command.ExecuteNonQuery();
        }

        public static void ValidateLines(List<JournalLine> lines)
        {
            if (lines == null || lines.Count < 2)
                throw new InvalidOperationException("القيد يجب أن يحتوي على طرفين (حسابين) على الأقل.");

            decimal totalDebit = lines.Sum(x => x.Debit);
            decimal totalCredit = lines.Sum(x => x.Credit);

            if (totalDebit <= 0 || totalCredit <= 0)
                throw new InvalidOperationException("القيد يجب أن يحتوي على مدين ودائن.");

            if (totalDebit != totalCredit)
                throw new InvalidOperationException($"القيد غير متوازن.\nالمدين: {totalDebit:N2}\nالدائن: {totalCredit:N2}\nالفرق: {(totalDebit - totalCredit):N2}");

            foreach (JournalLine line in lines)
            {
                ValidateLine(line);
            }
        }

        public static void ValidateLine(JournalLine line)
        {
            if (line.AccountId <= 0)
                throw new ArgumentException("رقم الحساب غير صحيح.");

            if (line.Debit < 0 || line.Credit < 0)
                throw new ArgumentException("لا يمكن أن تكون قيمة المدين أو الدائن سالبة.");

            if (line.Debit > 0 && line.Credit > 0)
                throw new ArgumentException("لا يجوز أن يحتوي سطر القيد على مدين ودائن معاً.");

            if (line.Debit == 0 && line.Credit == 0)
                throw new ArgumentException("يجب أن يحتوي سطر القيد على مبلغ.");
        }
    }
}
