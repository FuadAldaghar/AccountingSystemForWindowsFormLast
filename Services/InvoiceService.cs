
using System.Data;
using AccountingSystemForWindowsFormLast.Data;
using AccountingSystemForWindowsFormLast.Models;
using Microsoft.Data.SqlClient;

namespace AccountingSystemForWindowsFormLast.Services
{
    public class InvoiceService
    {
        public const string InventoryAccountNumber = "114";
        public const string SalesAccountNumber = "51";
        public const string CostOfGoodsAccountNumber = "41";
        public const string CustomersAccountNumber = "113";
        public const string SuppliersAccountNumber = "211";
        public const string CashAccountNumber = "111";

        public const string CashPaymentType = "نقد";
        public const string CreditPaymentType = "أجل";

        private readonly AccountService accountService;
        private readonly JournalService journalService;

        public InvoiceService()
        {
            accountService = new AccountService();
            journalService = new JournalService();
        }

        public string GetNextPurchaseInvoiceNumber()
        {
            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            const string sql = @"
                SELECT ISNULL(
                    MAX(TRY_CAST(InvoiceNumber AS INT)),
                    0
                ) + 1
                FROM PurchaseInvoices";

            using SqlCommand command = new SqlCommand(sql, connection);
            return Convert.ToInt32(command.ExecuteScalar()).ToString();
        }

        public string GetNextSalesInvoiceNumber()
        {
            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            const string sql = @"
                SELECT ISNULL(
                    MAX(TRY_CAST(InvoiceNumber AS INT)),
                    0
                ) + 1
                FROM SalesInvoices";

            using SqlCommand command = new SqlCommand(sql, connection);
            return Convert.ToInt32(command.ExecuteScalar()).ToString();
        }

        public decimal GetAvailableStock(int itemId, SqlConnection? connection = null, SqlTransaction? transaction = null)
        {
            bool ownsConnection = connection == null;
            connection ??= DatabaseConnection.GetConnection();

            if (ownsConnection)
                connection.Open();

            try
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

                using SqlCommand command = new SqlCommand(sql, connection, transaction);
                command.Parameters.Add("@ItemId", SqlDbType.Int).Value = itemId;

                object? result = command.ExecuteScalar();
                return result == null || result == DBNull.Value ? 0 : Convert.ToDecimal(result);
            }
            finally
            {
                if (ownsConnection)
                    connection.Dispose();
            }
        }

        public decimal GetAveragePurchaseCost(int itemId, SqlConnection? connection = null, SqlTransaction? transaction = null)
        {
            bool ownsConnection = connection == null;
            connection ??= DatabaseConnection.GetConnection();

            if (ownsConnection)
                connection.Open();

            try
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

                using SqlCommand command = new SqlCommand(sql, connection, transaction);
                command.Parameters.Add("@ItemId", SqlDbType.Int).Value = itemId;

                object? result = command.ExecuteScalar();
                return result == null || result == DBNull.Value ? 0 : Convert.ToDecimal(result);
            }
            finally
            {
                if (ownsConnection)
                    connection.Dispose();
            }
        }

        public int SavePurchaseInvoice(
            string invoiceNumber,
            DateTime invoiceDate,
            string paymentType,
            int accountId,
            IEnumerable<InvoiceItem> items)
        {
            List<InvoiceItem> invoiceItems = items.ToList();
            ValidateInvoice(invoiceNumber, paymentType, invoiceItems);

            decimal total = invoiceItems.Sum(x => x.Quantity * x.UnitPrice);

            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            using SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                int invoiceId = InsertPurchaseInvoice(connection, transaction, invoiceNumber, invoiceDate, paymentType, accountId);

                foreach (InvoiceItem item in invoiceItems)
                {
                    InsertPurchaseDetail(connection, transaction, invoiceId, item);
                }

                int counterpartAccountId = ResolveCounterpartAccountId(
                    connection,
                    transaction,
                    paymentType,
                    accountId,
                    paymentType == CashPaymentType ? "مدين" : "دائن",
                    SuppliersAccountNumber);

                int inventoryAccountId = GetRequiredAccountId(connection, transaction, InventoryAccountNumber);
                string description = $"فاتورة مشتريات رقم {invoiceNumber}";

                journalService.CreateJournalEntry(
                    connection,
                    transaction,
                    invoiceDate,
                    description,
                    new[]
                    {
                        new JournalLine
                        {
                            AccountId = inventoryAccountId,
                            Debit = total,
                            Credit = 0,
                            Description = "إضافة قيمة المشتريات إلى المخزون"
                        },
                        new JournalLine
                        {
                            AccountId = counterpartAccountId,
                            Debit = 0,
                            Credit = total,
                            Description = paymentType == CashPaymentType
                                ? "سداد قيمة المشتريات من الصندوق"
                                : "الحساب المقابل لفاتورة المشتريات"
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
            List<InvoiceItem> invoiceItems = items.ToList();
            ValidateInvoice(invoiceNumber, paymentType, invoiceItems);

            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            using SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                ValidateStock(connection, transaction, invoiceItems);

                int invoiceId = InsertSalesInvoice(connection, transaction, invoiceNumber, invoiceDate, paymentType, accountId);

                foreach (InvoiceItem item in invoiceItems)
                {
                    InsertSalesDetail(connection, transaction, invoiceId, item);
                }

                decimal salesTotal = invoiceItems.Sum(x => x.Quantity * x.UnitPrice);
                decimal costOfGoods = CalculateCostOfGoodsSold(connection, transaction, invoiceItems);

                int counterpartAccountId = ResolveCounterpartAccountId(
                    connection,
                    transaction,
                    paymentType,
                    accountId,
                    "مدين",
                    CustomersAccountNumber);

                int salesAccountId = GetRequiredAccountId(connection, transaction, SalesAccountNumber);
                int inventoryAccountId = GetRequiredAccountId(connection, transaction, InventoryAccountNumber);
                int costAccountId = GetRequiredAccountId(connection, transaction, CostOfGoodsAccountNumber);

                string description = $"فاتورة مبيعات رقم {invoiceNumber}";

                List<JournalLine> lines = new List<JournalLine>
                {
                    new JournalLine
                    {
                        AccountId = counterpartAccountId,
                        Debit = salesTotal,
                        Credit = 0,
                        Description = paymentType == CashPaymentType
                            ? "تحصيل قيمة المبيعات نقداً"
                            : "قيمة فاتورة المبيعات على العميل"
                    },
                    new JournalLine
                    {
                        AccountId = salesAccountId,
                        Debit = 0,
                        Credit = salesTotal,
                        Description = "إيراد المبيعات"
                    }
                };

                if (costOfGoods > 0)
                {
                    lines.Add(new JournalLine
                    {
                        AccountId = costAccountId,
                        Debit = costOfGoods,
                        Credit = 0,
                        Description = "تكلفة البضاعة المباعة"
                    });
                    lines.Add(new JournalLine
                    {
                        AccountId = inventoryAccountId,
                        Debit = 0,
                        Credit = costOfGoods,
                        Description = "إخراج تكلفة البضاعة من المخزون"
                    });
                }

                journalService.CreateJournalEntry(
                    connection,
                    transaction,
                    invoiceDate,
                    description,
                    lines);

                transaction.Commit();
                return invoiceId;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        private int ResolveCounterpartAccountId(
            SqlConnection connection,
            SqlTransaction transaction,
            string paymentType,
            int accountId,
            string requiredNature,
            string defaultAccountNumber)
        {
            int counterpartAccountId = accountId > 0
                ? accountId
                : GetRequiredAccountId(
                    connection,
                    transaction,
                    paymentType == CashPaymentType ? CashAccountNumber : defaultAccountNumber);

            ValidateCounterpartAccount(connection, transaction, counterpartAccountId, requiredNature);
            return counterpartAccountId;
        }

        private static void ValidateCounterpartAccount(
            SqlConnection connection,
            SqlTransaction transaction,
            int accountId,
            string requiredNature)
        {
            const string sql = @"
                SELECT AccountNumber, AccountName, AccountNature, IsGroup
                FROM Accounts
                WHERE AccountId = @AccountId";

            string accountNumber = "";
            string accountName = "";
            string nature = "";
            bool isGroup;

            using (SqlCommand command = new SqlCommand(sql, connection, transaction))
            {
                command.Parameters.Add("@AccountId", SqlDbType.Int).Value = accountId;

                using SqlDataReader reader = command.ExecuteReader();
                if (!reader.Read())
                    throw new InvalidOperationException("الحساب المحدد غير موجود في شجرة الحسابات.");

                accountNumber = reader["AccountNumber"]?.ToString() ?? "";
                accountName = reader["AccountName"]?.ToString() ?? "";
                nature = reader["AccountNature"]?.ToString() ?? "";
                isGroup = Convert.ToBoolean(reader["IsGroup"]);
            }

            string accountText = $"الحساب ({accountNumber} - {accountName})";

            if (isGroup)
            {
                throw new InvalidOperationException(
                    $"{accountText} حساب تجميعي ولا يمكن الترحيل عليه. يرجى اختيار حساب فرعي.");
            }

            if (!string.IsNullOrWhiteSpace(nature) && nature != requiredNature)
            {
                string requiredNatureText = requiredNature == "دائن" ? "دائناً (خصوم)" : "مديناً (أصول)";
                throw new InvalidOperationException(
                    $"{accountText} طبيعته {nature}، ويجب أن يكون {requiredNatureText} ليُستخدم كطرف مقابل في هذه الفاتورة.");
            }
        }

        private void ValidateStock(SqlConnection connection, SqlTransaction transaction, IEnumerable<InvoiceItem> items)
        {
            foreach (IGrouping<int, InvoiceItem> itemGroup in items.GroupBy(x => x.ItemId))
            {
                decimal requestedQuantity = itemGroup.Sum(x => x.Quantity);
                decimal available = GetAvailableStock(itemGroup.Key, connection, transaction);

                if (requestedQuantity > available)
                {
                    string itemName = itemGroup.First().ItemName;

                    throw new InvalidOperationException(
                        $"الصنف ({itemName}) لا يحتوي على كمية كافية بالمخزون.\n" +
                        $"المتاح: {available:N2}\n" +
                        $"المطلوب: {requestedQuantity:N2}");
                }
            }
        }

        private decimal CalculateCostOfGoodsSold(SqlConnection connection, SqlTransaction transaction, IEnumerable<InvoiceItem> items)
        {
            decimal totalCost = 0;
            foreach (InvoiceItem item in items)
            {
                decimal avgCost = GetAveragePurchaseCost(item.ItemId, connection, transaction);
                if (avgCost <= 0)
                {
                    // Fall back to unit price if no prior purchase
                    avgCost = item.UnitPrice;
                }
                totalCost += item.Quantity * avgCost;
            }
            return totalCost;
        }

        private static int InsertPurchaseInvoice(
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

            using SqlCommand command = new SqlCommand(sql, connection, transaction);
            command.Parameters.Add("@InvoiceNumber", SqlDbType.NVarChar, 50).Value = invoiceNumber.Trim();
            command.Parameters.Add("@InvoiceDate", SqlDbType.Date).Value = invoiceDate.Date;
            command.Parameters.Add("@PaymentType", SqlDbType.NVarChar, 20).Value = paymentType.Trim();
            command.Parameters.Add("@AccountId", SqlDbType.Int).Value = accountId;

            return Convert.ToInt32(command.ExecuteScalar());
        }

        private static int InsertSalesInvoice(
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

            using SqlCommand command = new SqlCommand(sql, connection, transaction);
            command.Parameters.Add("@InvoiceNumber", SqlDbType.NVarChar, 50).Value = invoiceNumber.Trim();
            command.Parameters.Add("@InvoiceDate", SqlDbType.Date).Value = invoiceDate.Date;
            command.Parameters.Add("@PaymentType", SqlDbType.NVarChar, 20).Value = paymentType.Trim();
            command.Parameters.Add("@AccountId", SqlDbType.Int).Value = accountId;

            return Convert.ToInt32(command.ExecuteScalar());
        }

        private static void InsertPurchaseDetail(
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

            using SqlCommand command = new SqlCommand(sql, connection, transaction);
            command.Parameters.Add("@InvoiceId", SqlDbType.Int).Value = invoiceId;
            command.Parameters.Add("@ItemId", SqlDbType.Int).Value = item.ItemId;
            command.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = item.Quantity;
            command.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = item.UnitPrice;

            command.ExecuteNonQuery();
        }

        private static void InsertSalesDetail(
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

            using SqlCommand command = new SqlCommand(sql, connection, transaction);
            command.Parameters.Add("@InvoiceId", SqlDbType.Int).Value = invoiceId;
            command.Parameters.Add("@ItemId", SqlDbType.Int).Value = item.ItemId;
            command.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = item.Quantity;
            command.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = item.UnitPrice;

            command.ExecuteNonQuery();
        }

        private int GetRequiredAccountId(SqlConnection connection, SqlTransaction transaction, string accountNumber)
        {
            int? accountId = accountService.GetIdByNumber(accountNumber, connection, transaction);
            if (!accountId.HasValue)
            {
                throw new InvalidOperationException($"الحساب رقم {accountNumber} غير موجود في شجرة الحسابات.");
            }
            return accountId.Value;
        }

        private static void ValidateInvoice(string invoiceNumber, string paymentType, List<InvoiceItem> items)
        {
            if (string.IsNullOrWhiteSpace(invoiceNumber))
                throw new ArgumentException("رقم الفاتورة مطلوب.");

            if (string.IsNullOrWhiteSpace(paymentType))
                throw new ArgumentException("نوع الدفع مطلوب.");

            if (items == null || items.Count == 0)
                throw new ArgumentException("يجب إضافة صنف واحد على الأقل في الفاتورة.");

            foreach (InvoiceItem item in items)
            {
                if (item.ItemId <= 0)
                    throw new ArgumentException("يوجد صنف غير صحيح في الجدول.");

                if (item.Quantity <= 0)
                    throw new ArgumentException($"الكمية للصنف ({item.ItemName}) يجب أن تكون أكبر من صفر.");

                if (item.UnitPrice < 0)
                    throw new ArgumentException($"سعر الوحدة للصنف ({item.ItemName}) لا يمكن أن يكون سالباً.");
            }
        }
    }
}
