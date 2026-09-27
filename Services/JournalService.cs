using System.Data;
using AccountingSystemForWindowsFormLast.Data;
using Microsoft.Data.SqlClient;

namespace AccountingSystemForWindowsFormLast.Services
{
    public class JournalService
    {
        public class JournalLine
        {
            public int AccountId { get; set; }
            public decimal Debit { get; set; }
            public decimal Credit { get; set; }
            public string Description { get; set; } = "";
        }

        public string GetNextEntryNumber()
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            return GetNextEntryNumber(
                connection,
                null);
        }

        public string GetNextEntryNumber(
            SqlConnection connection,
            SqlTransaction? transaction)
        {
            const string sql = @"
                SELECT ISNULL(
                    MAX(TRY_CAST(EntryNumber AS INT)),
                    0
                ) + 1
                FROM JournalEntries";

            using SqlCommand command =
                new SqlCommand(
                    sql,
                    connection,
                    transaction);

            return Convert.ToInt32(
                command.ExecuteScalar()).ToString();
        }

        public int CreateJournalEntry(
            DateTime entryDate,
            string description,
            IEnumerable<JournalLine> lines)
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            using SqlTransaction transaction =
                connection.BeginTransaction();

            try
            {
                int id = CreateJournalEntry(
                    connection,
                    transaction,
                    entryDate,
                    description,
                    lines);

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
            List<JournalLine> journalLines =
                lines.ToList();

            ValidateLines(journalLines);

            string entryNumber =
                GetNextEntryNumber(
                    connection,
                    transaction);

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

            using (SqlCommand command =
                new SqlCommand(
                    headerSql,
                    connection,
                    transaction))
            {
                command.Parameters.Add(
                    "@EntryNumber",
                    SqlDbType.NVarChar,
                    50).Value = entryNumber;

                command.Parameters.Add(
                    "@EntryDate",
                    SqlDbType.Date).Value =
                    entryDate.Date;

                command.Parameters.Add(
                    "@Description",
                    SqlDbType.NVarChar,
                    500).Value =
                    string.IsNullOrWhiteSpace(description)
                        ? DBNull.Value
                        : description.Trim();

                journalEntryId =
                    Convert.ToInt32(
                        command.ExecuteScalar());
            }

            foreach (JournalLine line in journalLines)
            {
                InsertJournalDetail(
                    connection,
                    transaction,
                    journalEntryId,
                    line);
            }

            return journalEntryId;
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

            using SqlCommand command =
                new SqlCommand(
                    sql,
                    connection,
                    transaction);

            command.Parameters.Add(
                "@JournalEntryId",
                SqlDbType.Int).Value =
                journalEntryId;

            command.Parameters.Add(
                "@AccountId",
                SqlDbType.Int).Value =
                line.AccountId;

            command.Parameters.Add(
                "@Debit",
                SqlDbType.Decimal).Value =
                line.Debit;

            command.Parameters.Add(
                "@Credit",
                SqlDbType.Decimal).Value =
                line.Credit;

            command.Parameters.Add(
                "@Description",
                SqlDbType.NVarChar,
                500).Value =
                string.IsNullOrWhiteSpace(line.Description)
                    ? DBNull.Value
                    : line.Description.Trim();

            command.ExecuteNonQuery();
        }

        public DataTable GetEntries()
        {
            const string sql = @"
                SELECT
                    JournalEntryId,
                    EntryNumber,
                    EntryDate,
                    Description
                FROM JournalEntries
                ORDER BY JournalEntryId DESC";

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            using SqlDataAdapter adapter =
                new SqlDataAdapter(sql, connection);

            DataTable table = new();

            adapter.Fill(table);

            return table;
        }

        public DataTable GetAccountStatement(
            int accountId,
            DateTime fromDate,
            DateTime toDate)
        {
            if (fromDate.Date > toDate.Date)
                throw new ArgumentException(
                    "تاريخ البداية يجب أن يكون قبل تاريخ النهاية.");

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            string nature = GetAccountNature(
                connection,
                accountId);

            decimal openingBalance =
                GetOpeningBalance(
                    connection,
                    accountId,
                    fromDate,
                    nature);

            const string sql = @"
                SELECT
                    je.EntryDate AS [التاريخ],
                    je.EntryNumber AS [رقم القيد],
                    je.Description AS [البيان],
                    jed.Debit AS [مدين],
                    jed.Credit AS [دائن]
                FROM JournalEntryDetails jed
                INNER JOIN JournalEntries je
                    ON je.JournalEntryId =
                       jed.JournalEntryId
                WHERE jed.AccountId = @AccountId
                  AND je.EntryDate >= @FromDate
                  AND je.EntryDate < DATEADD(DAY, 1, @ToDate)
                ORDER BY
                    je.EntryDate,
                    je.JournalEntryId,
                    jed.JournalEntryDetailId";

            using SqlCommand command =
                new SqlCommand(sql, connection);

            command.Parameters.Add(
                "@AccountId",
                SqlDbType.Int).Value = accountId;

            command.Parameters.Add(
                "@FromDate",
                SqlDbType.Date).Value = fromDate.Date;

            command.Parameters.Add(
                "@ToDate",
                SqlDbType.Date).Value = toDate.Date;

            using SqlDataReader reader =
                command.ExecuteReader();

            DataTable table = new();

            table.Load(reader);

            table.Columns.Add(
                "الرصيد",
                typeof(decimal));

            decimal runningBalance =
                openingBalance;

            foreach (DataRow row in table.Rows)
            {
                decimal debit =
                    Convert.ToDecimal(row["مدين"]);

                decimal credit =
                    Convert.ToDecimal(row["دائن"]);

                runningBalance =
                    nature == "دائن"
                        ? runningBalance + credit - debit
                        : runningBalance + debit - credit;

                row["الرصيد"] = runningBalance;
            }

            return table;
        }

        private string GetAccountNature(
            SqlConnection connection,
            int accountId)
        {
            const string sql = @"
                SELECT AccountNature
                FROM Accounts
                WHERE AccountId = @AccountId";

            using SqlCommand command =
                new SqlCommand(sql, connection);

            command.Parameters.Add(
                "@AccountId",
                SqlDbType.Int).Value =
                accountId;

            object? result =
                command.ExecuteScalar();

            if (result == null || result == DBNull.Value)
                return "مدين";

            return result.ToString() ?? "مدين";
        }

        private decimal GetOpeningBalance(
            SqlConnection connection,
            int accountId,
            DateTime fromDate,
            string nature)
        {
            const string sql = @"
                SELECT
                    ISNULL(SUM(Debit), 0),
                    ISNULL(SUM(Credit), 0)
                FROM JournalEntryDetails jed
                INNER JOIN JournalEntries je
                    ON je.JournalEntryId =
                       jed.JournalEntryId
                WHERE jed.AccountId = @AccountId
                  AND je.EntryDate < @FromDate";

            using SqlCommand command =
                new SqlCommand(sql, connection);

            command.Parameters.Add(
                "@AccountId",
                SqlDbType.Int).Value =
                accountId;

            command.Parameters.Add(
                "@FromDate",
                SqlDbType.Date).Value =
                fromDate.Date;

            using SqlDataReader reader =
                command.ExecuteReader();

            if (!reader.Read())
                return 0;

            decimal debit =
                Convert.ToDecimal(reader.GetValue(0));

            decimal credit =
                Convert.ToDecimal(reader.GetValue(1));

            return nature == "دائن"
                ? credit - debit
                : debit - credit;
        }

        private static void ValidateLines(
            List<JournalLine> lines)
        {
            if (lines.Count < 2)
                throw new InvalidOperationException(
                    "القيد يجب أن يحتوي على طرفين على الأقل.");

            decimal totalDebit =
                lines.Sum(x => x.Debit);

            decimal totalCredit =
                lines.Sum(x => x.Credit);

            if (totalDebit <= 0 ||
                totalCredit <= 0)
            {
                throw new InvalidOperationException(
                    "القيد يجب أن يحتوي على مدين ودائن.");
            }

            if (totalDebit != totalCredit)
            {
                throw new InvalidOperationException(
                    $"القيد غير متوازن. المدين: {totalDebit:N2} - الدائن: {totalCredit:N2}");
            }

            foreach (JournalLine line in lines)
            {
                ValidateLine(line);
            }
        }

        private static void ValidateLine(
            JournalLine line)
        {
            if (line.AccountId <= 0)
                throw new ArgumentException(
                    "رقم الحساب غير صحيح.");

            if (line.Debit < 0 ||
                line.Credit < 0)
                throw new ArgumentException(
                    "لا يمكن أن تكون قيمة المدين أو الدائن سالبة.");

            if (line.Debit > 0 &&
                line.Credit > 0)
                throw new ArgumentException(
                    "لا يجوز أن يحتوي سطر القيد على مدين ودائن معاً.");

            if (line.Debit == 0 &&
                line.Credit == 0)
                throw new ArgumentException(
                    "يجب أن يحتوي سطر القيد على مبلغ.");
        }
    }
}