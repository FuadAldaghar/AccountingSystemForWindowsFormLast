using AccountingSystemForWindowsFormLast.Data;
using AccountingSystemForWindowsFormLast.Models;
using Microsoft.Data.SqlClient;

namespace AccountingSystemForWindowsFormLast.Services
{
    public class InvoiceService
    {
        private const string InventoryAccountNumber = "114";
        private const string SalesAccountNumber = "41";
        private const string SalesInventoryAccountNumber = "31";
        private const string CostOfGoodsAccountNumber = "51";

        private readonly AccountService accountService;
        private readonly JournalService journalService;

        public InvoiceService()
        {
            accountService = new AccountService();
            journalService = new JournalService();
        }

        public int SavePurchaseInvoice(
            string invoiceNumber,
            DateTime invoiceDate,
            string paymentType,
            int accountId,
            IEnumerable<InvoiceItem> items)
        {
            List<InvoiceItem> invoiceItems =
                items.ToList();

            ValidateInvoice(
                invoiceNumber,
                paymentType,
                accountId,
                invoiceItems);

            decimal total =
                invoiceItems.Sum(x =>
                    x.Quantity * x.UnitPrice);

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            using SqlTransaction transaction =
                connection.BeginTransaction();

            try
            {
                int invoiceId =
                    InsertPurchaseInvoice(
                        connection,
                        transaction,
                        invoiceNumber,
                        invoiceDate,
                        paymentType,
                        accountId);

                foreach (InvoiceItem item in invoiceItems)
                {
                    InsertPurchaseDetail(
                        connection,
                        transaction,
                        invoiceId,
                        item);
                }

                int inventoryAccountId =
                    GetRequiredAccountId(
                        connection,
                        transaction,
                        InventoryAccountNumber);

                string description =
                    $"فاتورة مشتريات رقم {invoiceNumber}";

                journalService.CreateJournalEntry(
                    connection,
                    transaction,
                    invoiceDate,
                    description,
                    new[]
                    {
                        new JournalService.JournalLine
                        {
                            AccountId = inventoryAccountId,
                            Debit = total,
                            Credit = 0,
                            Description = "إضافة قيمة المشتريات إلى المخزون"
                        },
                        new JournalService.JournalLine
                        {
                            AccountId = accountId,
                            Debit = 0,
                            Credit = total,
                            Description = "الحساب المقابل لفاتورة المشتريات"
                        }
                    });

                transaction.Commit();

                return invoiceId;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public int SaveSalesInvoice(
            string invoiceNumber,
            DateTime invoiceDate,
            string paymentType,
            int accountId,
            IEnumerable<InvoiceItem> items)
        {
            List<InvoiceItem> invoiceItems =
                items.ToList();

            ValidateInvoice(
                invoiceNumber,
                paymentType,
                accountId,
                invoiceItems);

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            using SqlTransaction transaction =
                connection.BeginTransaction();

            try
            {
                ValidateStock(
                    connection,
                    transaction,
                    invoiceItems);

                int invoiceId =
                    InsertSalesInvoice(
                        connection,
                        transaction,
                        invoiceNumber,
                        invoiceDate,
                        paymentType,
                        accountId);

                foreach (InvoiceItem item in invoiceItems)
                {
                    InsertSalesDetail(
                        connection,
                        transaction,
                        invoiceId,
                        item);
                }

                decimal salesTotal =
                    invoiceItems.Sum(x =>
                        x.Quantity * x.UnitPrice);

                decimal costOfGoods =
                    CalculateCostOfGoodsSold(
                        connection,
                        transaction,
                        invoiceItems);

                int salesAccountId =
                    GetRequiredAccountId(
                        connection,
                        transaction,
                        SalesAccountNumber);

                int inventoryAccountId =
                    GetRequiredAccountId(
                        connection,
                        transaction,
                        SalesInventoryAccountNumber);

                int costAccountId =
                    GetRequiredAccountId(
                        connection,
                        transaction,
                        CostOfGoodsAccountNumber);

                string description =
                    $"فاتورة مبيعات رقم {invoiceNumber}";

                journalService.CreateJournalEntry(
                    connection,
                    transaction,
                    invoiceDate,
                    description,
                    new[]
                    {
                        new JournalService.JournalLine
                        {
                            AccountId = accountId,
                            Debit = salesTotal,
                            Credit = 0,
                            Description = "قيمة فاتورة المبيعات"
                        },
                        new JournalService.JournalLine
                        {
                            AccountId = salesAccountId,
                            Debit = 0,
                            Credit = salesTotal,
                            Description = "إيراد المبيعات"
                        },
                        new JournalService.JournalLine
                        {
                            AccountId = costAccountId,
                            Debit = costOfGoods,
                            Credit = 0,
                            Description = "تكلفة البضاعة المباعة"
                        },
                        new JournalService.JournalLine
                        {
                            AccountId = inventoryAccountId,
                            Debit = 0,
                            Credit = costOfGoods,
                            Description = "إخراج تكلفة البضاعة من المخزون"
                        }
                    });

                transaction.Commit();

                return invoiceId;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public decimal GetAvailableStock(
            int itemId)
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            return GetAvailableStock(
                connection,
                null,
                itemId);
        }

        public decimal GetAvailableStock(
            SqlConnection connection,
            SqlTransaction? transaction,
            int itemId)
        {
            const string sql = @"
                SELECT
                    ISNULL(
                        (
                            SELECT SUM(Quantity)
                            FROM PurchaseInvoiceDetails
                            WHERE ItemId = @ItemId
                        ),
                        0
                    )
                    -
                    ISNULL(
                        (
                            SELECT SUM(Quantity)
                            FROM SalesInvoiceDetails
                            WHERE ItemId = @ItemId
                        ),
                        0
                    )";

            using SqlCommand command =
                new SqlCommand(
                    sql,
                    connection,
                    transaction);

            command.Parameters.Add(
                "@ItemId",
                System.Data.SqlDbType.Int).Value =
                itemId;

            return Convert.ToDecimal(
                command.ExecuteScalar());
        }

        public decimal GetAveragePurchaseCost(
            int itemId)
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            return GetAveragePurchaseCost(
                connection,
                null,
                itemId);
        }

        public decimal GetAveragePurchaseCost(
            SqlConnection connection,
            SqlTransaction? transaction,
            int itemId)
        {
            const string sql = @"
                SELECT
                    CASE
                        WHEN ISNULL(SUM(Quantity), 0) = 0
                            THEN 0
                        ELSE
                            SUM(Quantity * UnitPrice)
                            / SUM(Quantity)
                    END
                FROM PurchaseInvoiceDetails
                WHERE ItemId = @ItemId";

            using SqlCommand command =
                new SqlCommand(
                    sql,
                    connection,
                    transaction);

            command.Parameters.Add(
                "@ItemId",
                System.Data.SqlDbType.Int).Value =
                itemId;

            return Convert.ToDecimal(
                command.ExecuteScalar());
        }

        private void ValidateStock(
            SqlConnection connection,
            SqlTransaction transaction,
            IEnumerable<InvoiceItem> items)
        {
            foreach (InvoiceItem item in items)
            {
                decimal available =
                    GetAvailableStock(
                        connection,
                        transaction,
                        item.ItemId);

                if (item.Quantity > available)
                {
                    throw new InvalidOperationException(
                        $"الصنف ({item.ItemName}) لا يحتوي على كمية كافية.\n" +
                        $"المتاح: {available:N2}\n" +
                        $"المطلوب: {item.Quantity:N2}");
                }
            }
        }

        private decimal CalculateCostOfGoodsSold(
            SqlConnection connection,
            SqlTransaction transaction,
            IEnumerable<InvoiceItem> items)
        {
            decimal totalCost = 0;

            foreach (InvoiceItem item in items)
            {
                decimal averageCost =
                    GetAveragePurchaseCost(
                        connection,
                        transaction,
                        item.ItemId);

                if (averageCost <= 0)
                {
                    throw new InvalidOperationException(
                        $"تعذر تحديد تكلفة الصنف: {item.ItemName}");
                }

                totalCost +=
                    item.Quantity * averageCost;
            }

            return totalCost;
        }

        private int InsertPurchaseInvoice(
            SqlConnection connection,
            SqlTransaction transaction,
            string invoiceNumber,
            DateTime invoiceDate,
            string paymentType,
            int accountId)
        {
            const string sql = @"
                INSERT INTO PurchaseInvoices
                (
                    InvoiceNumber,
                    InvoiceDate,
                    PaymentType,
                    AccountId
                )
                VALUES
                (
                    @InvoiceNumber,
                    @InvoiceDate,
                    @PaymentType,
                    @AccountId
                );

                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using SqlCommand command =
                new SqlCommand(
                    sql,
                    connection,
                    transaction);

            AddInvoiceParameters(
                command,
                invoiceNumber,
                invoiceDate,
                paymentType,
                accountId);

            return Convert.ToInt32(
                command.ExecuteScalar());
        }

        private int InsertSalesInvoice(
            SqlConnection connection,
            SqlTransaction transaction,
            string invoiceNumber,
            DateTime invoiceDate,
            string paymentType,
            int accountId)
        {
            const string sql = @"
                INSERT INTO SalesInvoices
                (
                    InvoiceNumber,
                    InvoiceDate,
                    PaymentType,
                    AccountId
                )
                VALUES
                (
                    @InvoiceNumber,
                    @InvoiceDate,
                    @PaymentType,
                    @AccountId
                );

                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using SqlCommand command =
                new SqlCommand(
                    sql,
                    connection,
                    transaction);

            AddInvoiceParameters(
                command,
                invoiceNumber,
                invoiceDate,
                paymentType,
                accountId);

            return Convert.ToInt32(
                command.ExecuteScalar());
        }

        private void InsertPurchaseDetail(
            SqlConnection connection,
            SqlTransaction transaction,
            int invoiceId,
            InvoiceItem item)
        {
            const string sql = @"
                INSERT INTO PurchaseInvoiceDetails
                (
                    PurchaseInvoiceId,
                    ItemId,
                    Quantity,
                    UnitPrice
                )
                VALUES
                (
                    @InvoiceId,
                    @ItemId,
                    @Quantity,
                    @UnitPrice)";

            using SqlCommand command =
                new SqlCommand(
                    sql,
                    connection,
                    transaction);

            AddDetailParameters(
                command,
                "@InvoiceId",
                invoiceId,
                item);

            command.ExecuteNonQuery();
        }

        private void InsertSalesDetail(
            SqlConnection connection,
            SqlTransaction transaction,
            int invoiceId,
            InvoiceItem item)
        {
            const string sql = @"
                INSERT INTO SalesInvoiceDetails
                (
                    SalesInvoiceId,
                    ItemId,
                    Quantity,
                    UnitPrice
                )
                VALUES
                (
                    @InvoiceId,
                    @ItemId,
                    @Quantity,
                    @UnitPrice)";

            using SqlCommand command =
                new SqlCommand(
                    sql,
                    connection,
                    transaction);

            AddDetailParameters(
                command,
                "@InvoiceId",
                invoiceId,
                item);

            command.ExecuteNonQuery();
        }

        private int GetRequiredAccountId(
            SqlConnection connection,
            SqlTransaction transaction,
            string accountNumber)
        {
            int? accountId =
                accountService.GetIdByNumber(
                    accountNumber,
                    connection,
                    transaction);

            if (!accountId.HasValue)
            {
                throw new InvalidOperationException(
                    $"الحساب رقم {accountNumber} غير موجود في شجرة الحسابات.");
            }

            return accountId.Value;
        }

        private static void ValidateInvoice(
            string invoiceNumber,
            string paymentType,
            int accountId,
            List<InvoiceItem> items)
        {
            if (string.IsNullOrWhiteSpace(invoiceNumber))
                throw new ArgumentException(
                    "رقم الفاتورة مطلوب.");

            if (string.IsNullOrWhiteSpace(paymentType))
                throw new ArgumentException(
                    "نوع الدفع مطلوب.");

            if (accountId <= 0)
                throw new ArgumentException(
                    "الحساب غير صحيح.");

            if (items.Count == 0)
                throw new ArgumentException(
                    "يجب إضافة صنف واحد على الأقل.");

            foreach (InvoiceItem item in items)
            {
                if (item.ItemId <= 0)
                    throw new ArgumentException(
                        "يوجد صنف غير صحيح.");

                if (item.Quantity <= 0)
                    throw new ArgumentException(
                        "الكمية يجب أن تكون أكبر من صفر.");

                if (item.UnitPrice < 0)
                    throw new ArgumentException(
                        "سعر الوحدة لا يمكن أن يكون سالباً.");
            }
        }

        private static void AddInvoiceParameters(
            SqlCommand command,
            string invoiceNumber,
            DateTime invoiceDate,
            string paymentType,
            int accountId)
        {
            command.Parameters.Add(
                "@InvoiceNumber",
                System.Data.SqlDbType.NVarChar,
                50).Value =
                invoiceNumber.Trim();

            command.Parameters.Add(
                "@InvoiceDate",
                System.Data.SqlDbType.DateTime2).Value =
                invoiceDate;

            command.Parameters.Add(
                "@PaymentType",
                System.Data.SqlDbType.NVarChar,
                20).Value =
                paymentType.Trim();

            command.Parameters.Add(
                "@AccountId",
                System.Data.SqlDbType.Int).Value =
                accountId;
        }

        private static void AddDetailParameters(
            SqlCommand command,
            string invoiceParameterName,
            int invoiceId,
            InvoiceItem item)
        {
            command.Parameters.Add(
                invoiceParameterName,
                System.Data.SqlDbType.Int).Value =
                invoiceId;

            command.Parameters.Add(
                "@ItemId",
                System.Data.SqlDbType.Int).Value =
                item.ItemId;

            command.Parameters.Add(
                "@Quantity",
                System.Data.SqlDbType.Decimal).Value =
                item.Quantity;

            command.Parameters.Add(
                "@UnitPrice",
                System.Data.SqlDbType.Decimal).Value =
                item.UnitPrice;
        }
    }
}