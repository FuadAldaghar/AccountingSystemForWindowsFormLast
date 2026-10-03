
using System.Data;
using AccountingSystemForWindowsFormLast.Data;
using AccountingSystemForWindowsFormLast.Models;
using Microsoft.Data.SqlClient;

namespace AccountingSystemForWindowsFormLast.Services
{
    public class ReportService
    {
        public DataTable GetAccountStatement(int accountId, DateTime fromDate, DateTime toDate)
        {
            if (fromDate.Date > toDate.Date)
                throw new ArgumentException("تاريخ البداية يجب أن يكون قبل تاريخ النهاية.");

            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            string nature = GetAccountNature(connection, accountId);
            decimal openingBalance = GetOpeningBalance(connection, accountId, fromDate, nature);

            const string sql = @"
                SELECT
                    je.EntryDate AS [التاريخ],
                    je.EntryNumber AS [رقم القيد],
                    je.Description AS [البيان],
                    jed.Debit AS [مدين],
                    jed.Credit AS [دائن]
                FROM JournalEntryDetails jed
                INNER JOIN JournalEntries je
                    ON je.JournalEntryId = jed.JournalEntryId
                WHERE jed.AccountId = @AccountId
                  AND je.EntryDate >= @FromDate
                  AND je.EntryDate < DATEADD(DAY, 1, @ToDate)
                ORDER BY
                    je.EntryDate,
                    je.JournalEntryId,
                    jed.JournalEntryDetailId";

            using SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add("@AccountId", SqlDbType.Int).Value = accountId;
            command.Parameters.Add("@FromDate", SqlDbType.Date).Value = fromDate.Date;
            command.Parameters.Add("@ToDate", SqlDbType.Date).Value = toDate.Date;

            DataTable table = new DataTable();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                table.Load(reader);
            }

            table.Columns.Add("الرصيد", typeof(decimal));

            decimal runningBalance = openingBalance;
            foreach (DataRow row in table.Rows)
            {
                decimal debit = Convert.ToDecimal(row["مدين"]);
                decimal credit = Convert.ToDecimal(row["دائن"]);

                runningBalance = nature == "دائن"
                    ? runningBalance + credit - debit
                    : runningBalance + debit - credit;

                row["الرصيد"] = runningBalance;
            }

            return table;
        }

        public decimal GetAccountOpeningBalance(int accountId, DateTime fromDate)
        {
            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            string nature = GetAccountNature(connection, accountId);
            return GetOpeningBalance(connection, accountId, fromDate, nature);
        }

        public string GetAccountNature(SqlConnection connection, int accountId)
        {
            const string sql = "SELECT AccountNature FROM Accounts WHERE AccountId = @AccountId";
            using SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add("@AccountId", SqlDbType.Int).Value = accountId;

            object? result = command.ExecuteScalar();
            if (result == null || result == DBNull.Value || string.IsNullOrWhiteSpace(result.ToString()))
                return "مدين";

            return result.ToString()!;
        }

        private static decimal GetOpeningBalance(
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
                    ON je.JournalEntryId = jed.JournalEntryId
                WHERE jed.AccountId = @AccountId
                  AND je.EntryDate < @FromDate";

            using SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add("@AccountId", SqlDbType.Int).Value = accountId;
            command.Parameters.Add("@FromDate", SqlDbType.Date).Value = fromDate.Date;

            using SqlDataReader reader = command.ExecuteReader();
            if (!reader.Read())
                return 0;

            decimal debit = Convert.ToDecimal(reader.GetValue(0));
            decimal credit = Convert.ToDecimal(reader.GetValue(1));

            return nature == "دائن" ? credit - debit : debit - credit;
        }

        /// <summary>
        /// كشف فواتير المشتريات مع إجماليات كل فاتورة، مع دعم البحث الحر
        /// برقم الفاتورة أو باسم الحساب أو باسم صنف داخل الفاتورة.
        /// </summary>
        public DataTable GetPurchasesList(InvoiceListFilter filter)
        {
            filter.Validate();

            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            const string sql = @"
                SELECT
                    pi.PurchaseInvoiceId AS [المعرف],
                    pi.InvoiceNumber AS [رقم الفاتورة],
                    pi.InvoiceDate AS [التاريخ],
                    pi.PaymentType AS [نوع الدفع],
                    a.AccountNumber AS [رقم الحساب],
                    a.AccountName AS [اسم الحساب],
                    ISNULL(agg.ItemCount, 0) AS [عدد الأصناف],
                    ISNULL(agg.TotalQuantity, 0) AS [إجمالي الكمية],
                    ISNULL(agg.TotalAmount, 0) AS [إجمالي المبلغ]
                FROM PurchaseInvoices pi
                LEFT JOIN Accounts a
                    ON a.AccountId = pi.AccountId
                OUTER APPLY
                (
                    SELECT
                        COUNT(*) AS ItemCount,
                        SUM(pid.Quantity) AS TotalQuantity,
                        SUM(pid.Quantity * pid.UnitPrice) AS TotalAmount
                    FROM PurchaseInvoiceDetails pid
                    WHERE pid.PurchaseInvoiceId = pi.PurchaseInvoiceId
                ) agg
                WHERE pi.InvoiceDate >= @FromDate
                  AND pi.InvoiceDate < DATEADD(DAY, 1, @ToDate)
                  AND (@PaymentType IS NULL OR pi.PaymentType = @PaymentType)
                  AND
                  (
                      @Search IS NULL
                      OR pi.InvoiceNumber LIKE @Search
                      OR a.AccountName LIKE @Search
                      OR EXISTS
                      (
                          SELECT 1
                          FROM PurchaseInvoiceDetails sid
                          INNER JOIN Items si
                              ON si.ItemId = sid.ItemId
                          WHERE sid.PurchaseInvoiceId = pi.PurchaseInvoiceId
                            AND (si.ItemName LIKE @Search OR si.ItemNumber LIKE @Search)
                      )
                  )
                ORDER BY pi.InvoiceDate DESC, pi.PurchaseInvoiceId DESC";

            return ExecuteInvoiceListQuery(connection, sql, filter);
        }

        /// <summary>
        /// كشف فواتير المبيعات مع إجماليات كل فاتورة، مع دعم البحث الحر
        /// برقم الفاتورة أو باسم الحساب أو باسم صنف داخل الفاتورة.
        /// </summary>
        public DataTable GetSalesList(InvoiceListFilter filter)
        {
            filter.Validate();

            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            const string sql = @"
                SELECT
                    si.SalesInvoiceId AS [المعرف],
                    si.InvoiceNumber AS [رقم الفاتورة],
                    si.InvoiceDate AS [التاريخ],
                    si.PaymentType AS [نوع الدفع],
                    a.AccountNumber AS [رقم الحساب],
                    a.AccountName AS [اسم الحساب],
                    ISNULL(agg.ItemCount, 0) AS [عدد الأصناف],
                    ISNULL(agg.TotalQuantity, 0) AS [إجمالي الكمية],
                    ISNULL(agg.TotalAmount, 0) AS [إجمالي المبلغ]
                FROM SalesInvoices si
                LEFT JOIN Accounts a
                    ON a.AccountId = si.AccountId
                OUTER APPLY
                (
                    SELECT
                        COUNT(*) AS ItemCount,
                        SUM(sid.Quantity) AS TotalQuantity,
                        SUM(sid.Quantity * sid.UnitPrice) AS TotalAmount
                    FROM SalesInvoiceDetails sid
                    WHERE sid.SalesInvoiceId = si.SalesInvoiceId
                ) agg
                WHERE si.InvoiceDate >= @FromDate
                  AND si.InvoiceDate < DATEADD(DAY, 1, @ToDate)
                  AND (@PaymentType IS NULL OR si.PaymentType = @PaymentType)
                  AND
                  (
                      @Search IS NULL
                      OR si.InvoiceNumber LIKE @Search
                      OR a.AccountName LIKE @Search
                      OR EXISTS
                      (
                          SELECT 1
                          FROM SalesInvoiceDetails sd
                          INNER JOIN Items sitem
                              ON sitem.ItemId = sd.ItemId
                          WHERE sd.SalesInvoiceId = si.SalesInvoiceId
                            AND (sitem.ItemName LIKE @Search OR sitem.ItemNumber LIKE @Search)
                      )
                  )
                ORDER BY si.InvoiceDate DESC, si.SalesInvoiceId DESC";

            return ExecuteInvoiceListQuery(connection, sql, filter);
        }

        private static DataTable ExecuteInvoiceListQuery(
            SqlConnection connection,
            string sql,
            InvoiceListFilter filter)
        {
            using SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add("@FromDate", SqlDbType.Date).Value = filter.FromDate.Date;
            command.Parameters.Add("@ToDate", SqlDbType.Date).Value = filter.ToDate.Date;
            command.Parameters.Add("@PaymentType", SqlDbType.NVarChar, 20).Value =
                (string.IsNullOrWhiteSpace(filter.PaymentType) ? DBNull.Value : (object)filter.PaymentType);
            command.Parameters.Add("@Search", SqlDbType.NVarChar, 210).Value =
                (object?)filter.GetSearchPattern() ?? DBNull.Value;

            DataTable table = new DataTable();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                table.Load(reader);
            }

            return table;
        }

        /// <summary>
        /// كشف سندات القبض مع البحث برقم السند أو باسم الحساب أو بالملاحظات،
        /// مع إمكانية تقييد المبلغ بين حد أدنى وحد أعلى.
        /// </summary>
        public DataTable GetReceiptsList(VoucherListFilter filter)
        {
            filter.Validate();

            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            const string sql = @"
                SELECT
                    rv.ReceiptVoucherId AS [المعرف],
                    rv.VoucherNumber AS [رقم السند],
                    rv.VoucherDate AS [التاريخ],
                    ISNULL(a.AccountNumber, '') AS [رقم الحساب],
                    ISNULL(a.AccountName, '') AS [اسم الحساب],
                    rv.Amount AS [المبلغ],
                    ISNULL(rv.Notes, '') AS [الملاحظات]
                FROM ReceiptVouchers rv
                LEFT JOIN Accounts a
                    ON a.AccountId = rv.AccountId
                WHERE rv.VoucherDate >= @FromDate
                  AND rv.VoucherDate < DATEADD(DAY, 1, @ToDate)
                  AND (@MinAmount IS NULL OR rv.Amount >= @MinAmount)
                  AND (@MaxAmount IS NULL OR rv.Amount <= @MaxAmount)
                  AND
                  (
                      @Search IS NULL
                      OR rv.VoucherNumber LIKE @Search
                      OR a.AccountName LIKE @Search
                      OR rv.Notes LIKE @Search
                  )
                ORDER BY rv.VoucherDate DESC, rv.ReceiptVoucherId DESC";

            return ExecuteVoucherListQuery(connection, sql, filter);
        }

        /// <summary>
        /// كشف سندات الصرف مع البحث برقم السند أو باسم الحساب أو بالملاحظات،
        /// مع إمكانية تقييد المبلغ بين حد أدنى وحد أعلى.
        /// </summary>
        public DataTable GetPaymentsList(VoucherListFilter filter)
        {
            filter.Validate();

            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            const string sql = @"
                SELECT
                    pv.PaymentVoucherId AS [المعرف],
                    pv.VoucherNumber AS [رقم السند],
                    pv.VoucherDate AS [التاريخ],
                    ISNULL(a.AccountNumber, '') AS [رقم الحساب],
                    ISNULL(a.AccountName, '') AS [اسم الحساب],
                    pv.Amount AS [المبلغ],
                    ISNULL(pv.Notes, '') AS [الملاحظات]
                FROM PaymentVouchers pv
                LEFT JOIN Accounts a
                    ON a.AccountId = pv.AccountId
                WHERE pv.VoucherDate >= @FromDate
                  AND pv.VoucherDate < DATEADD(DAY, 1, @ToDate)
                  AND (@MinAmount IS NULL OR pv.Amount >= @MinAmount)
                  AND (@MaxAmount IS NULL OR pv.Amount <= @MaxAmount)
                  AND
                  (
                      @Search IS NULL
                      OR pv.VoucherNumber LIKE @Search
                      OR a.AccountName LIKE @Search
                      OR pv.Notes LIKE @Search
                  )
                ORDER BY pv.VoucherDate DESC, pv.PaymentVoucherId DESC";

            return ExecuteVoucherListQuery(connection, sql, filter);
        }

        private static DataTable ExecuteVoucherListQuery(
            SqlConnection connection,
            string sql,
            VoucherListFilter filter)
        {
            using SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add("@FromDate", SqlDbType.Date).Value = filter.FromDate.Date;
            command.Parameters.Add("@ToDate", SqlDbType.Date).Value = filter.ToDate.Date;
            command.Parameters.Add("@Search", SqlDbType.NVarChar, 210).Value =
                (object?)filter.GetSearchPattern() ?? DBNull.Value;
            command.Parameters.Add("@MinAmount", SqlDbType.Decimal).Value =
                (object?)filter.MinAmount ?? DBNull.Value;
            command.Parameters.Add("@MaxAmount", SqlDbType.Decimal).Value =
                (object?)filter.MaxAmount ?? DBNull.Value;

            DataTable table = new DataTable();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                table.Load(reader);
            }

            return table;
        }

        public DataTable GetStockReport(int? itemId, DateTime fromDate, DateTime toDate)
        {
            if (fromDate.Date > toDate.Date)
                throw new ArgumentException("تاريخ البداية يجب أن يكون قبل تاريخ النهاية.");

            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            const string query = @"
                SELECT
                    i.ItemId,
                    i.ItemNumber AS [رقم الصنف],
                    i.ItemName AS [اسم الصنف],
                    i.Unit AS [الوحدة],

                    ISNULL((
                        SELECT SUM(pid.Quantity)
                        FROM PurchaseInvoiceDetails pid
                        INNER JOIN PurchaseInvoices pi
                            ON pi.PurchaseInvoiceId = pid.PurchaseInvoiceId
                        WHERE pid.ItemId = i.ItemId
                          AND pi.InvoiceDate < @FromDate
                    ), 0)
                    -
                    ISNULL((
                        SELECT SUM(sid.Quantity)
                        FROM SalesInvoiceDetails sid
                        INNER JOIN SalesInvoices si
                            ON si.SalesInvoiceId = sid.SalesInvoiceId
                        WHERE sid.ItemId = i.ItemId
                          AND si.InvoiceDate < @FromDate
                    ), 0) AS [رصيد أول المدة],

                    ISNULL((
                        SELECT SUM(pid.Quantity)
                        FROM PurchaseInvoiceDetails pid
                        INNER JOIN PurchaseInvoices pi
                            ON pi.PurchaseInvoiceId = pid.PurchaseInvoiceId
                        WHERE pid.ItemId = i.ItemId
                          AND pi.InvoiceDate >= @FromDate
                          AND pi.InvoiceDate < DATEADD(DAY, 1, @ToDate)
                    ), 0) AS [إجمالي المشتريات],

                    ISNULL((
                        SELECT SUM(sid.Quantity)
                        FROM SalesInvoiceDetails sid
                        INNER JOIN SalesInvoices si
                            ON si.SalesInvoiceId = sid.SalesInvoiceId
                        WHERE sid.ItemId = i.ItemId
                          AND si.InvoiceDate >= @FromDate
                          AND si.InvoiceDate < DATEADD(DAY, 1, @ToDate)
                    ), 0) AS [إجمالي المبيعات]

                FROM Items i
                WHERE (@ItemId IS NULL OR @ItemId = 0 OR i.ItemId = @ItemId)
                ORDER BY i.ItemNumber";

            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@FromDate", SqlDbType.Date).Value = fromDate.Date;
            command.Parameters.Add("@ToDate", SqlDbType.Date).Value = toDate.Date;
            command.Parameters.Add("@ItemId", SqlDbType.Int).Value =
                (itemId.HasValue && itemId.Value > 0) ? itemId.Value : DBNull.Value;

            DataTable table = new DataTable();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                table.Load(reader);
            }

            table.Columns.Add("الرصيد", typeof(decimal));

            foreach (DataRow row in table.Rows)
            {
                decimal opening = Convert.ToDecimal(row["رصيد أول المدة"]);
                decimal purchases = Convert.ToDecimal(row["إجمالي المشتريات"]);
                decimal sales = Convert.ToDecimal(row["إجمالي المبيعات"]);

                row["الرصيد"] = opening + purchases - sales;
            }

            return table;
        }
    }
}
