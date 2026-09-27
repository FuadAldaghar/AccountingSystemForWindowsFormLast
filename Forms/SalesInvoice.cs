using System.Data;
using AccountingSystemForWindowsFormLast.Data;
using Microsoft.Data.SqlClient;

namespace AccountingSystemForWindowsFormLast.Forms
{
    public partial class SalesInvoice : Form
    {
        private int selectedRowIndex = -1;

        public SalesInvoice()
        {
            InitializeComponent();

            cmbItem.SelectedIndexChanged += cmbItem_SelectedIndexChanged;
            nudQuantity.ValueChanged += CalculateLineTotal;
            nudUnitPrice.ValueChanged += CalculateLineTotal;

            btnAddRow.Click += btnAddRow_Click;
            btnRemoveRow.Click += btnRemoveRow_Click;
            btnNew.Click += btnNew_Click;
            btnSave.Click += btnSave_Click;

            dgvDetails.CellClick += dgvDetails_CellClick;
        }

        private void SalesInvoice_Load(object? sender, EventArgs e)
        {
            cmbPaymentType.SelectedIndex = 0;

            LoadAccounts();
            LoadItems();

            GenerateInvoiceNumber();
            ClearInvoice();
        }

        private void LoadAccounts()
        {
            try
            {
                using SqlConnection connection = DatabaseConnection.GetConnection();
                connection.Open();

                const string sql = @"
                    SELECT AccountId, AccountNumber, AccountName
                    FROM Accounts
                    WHERE IsGroup = 0
                    ORDER BY AccountNumber";

                using SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();

                cmbAccount.Items.Clear();

                while (reader.Read())
                {
                    cmbAccount.Items.Add(new AccountItem
                    {
                        Id = Convert.ToInt32(reader["AccountId"]),
                        Number = reader["AccountNumber"].ToString() ?? "",
                        Name = reader["AccountName"].ToString() ?? ""
                    });
                }

                cmbAccount.DisplayMember = "DisplayText";
                cmbAccount.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تحميل الحسابات:\n" + ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadItems()
        {
            try
            {
                using SqlConnection connection = DatabaseConnection.GetConnection();
                connection.Open();

                const string sql = @"
                    SELECT ItemId, ItemNumber, ItemName, Unit
                    FROM Items
                    ORDER BY ItemNumber";

                using SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();

                cmbItem.Items.Clear();

                while (reader.Read())
                {
                    cmbItem.Items.Add(new ItemData
                    {
                        Id = Convert.ToInt32(reader["ItemId"]),
                        Number = reader["ItemNumber"].ToString() ?? "",
                        Name = reader["ItemName"].ToString() ?? "",
                        Unit = reader["Unit"].ToString() ?? ""
                    });
                }

                cmbItem.DisplayMember = "DisplayText";
                cmbItem.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تحميل الأصناف:\n" + ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void PrepareGrid()
        {
            dgvDetails.Columns.Clear();

            DataGridViewTextBoxColumn itemIdColumn =
                new DataGridViewTextBoxColumn();

            itemIdColumn.Name = "ItemId";
            itemIdColumn.HeaderText = "ItemId";
            itemIdColumn.Visible = false;

            dgvDetails.Columns.Add(itemIdColumn);

            dgvDetails.Columns.Add("ItemName", "الصنف");
            dgvDetails.Columns.Add("Unit", "الوحدة");
            dgvDetails.Columns.Add("Quantity", "الكمية");
            dgvDetails.Columns.Add("UnitPrice", "سعر البيع");
            dgvDetails.Columns.Add("Total", "الإجمالي");

            dgvDetails.Columns["ItemName"]!.FillWeight = 30;
            dgvDetails.Columns["Unit"]!.FillWeight = 15;
            dgvDetails.Columns["Quantity"]!.FillWeight = 15;
            dgvDetails.Columns["UnitPrice"]!.FillWeight = 20;
            dgvDetails.Columns["Total"]!.FillWeight = 20;
        }

        private void GenerateInvoiceNumber()
        {
            try
            {
                using SqlConnection connection = DatabaseConnection.GetConnection();
                connection.Open();

                const string sql = @"
                    SELECT ISNULL(
                        MAX(TRY_CAST(InvoiceNumber AS INT)), 0
                    ) + 1
                    FROM SalesInvoices";

                using SqlCommand command = new SqlCommand(sql, connection);

                object? result = command.ExecuteScalar();

                txtInvoiceNumber.Text =
                    Convert.ToInt32(result).ToString();
            }
            catch
            {
                txtInvoiceNumber.Text = "1";
            }
        }

        private void cmbItem_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbItem.SelectedItem is ItemData item)
            {
                txtUnit.Text = item.Unit;
            }
            else
            {
                txtUnit.Clear();
            }

            CalculateLineTotal(null, EventArgs.Empty);
        }

        private void CalculateLineTotal(object? sender, EventArgs e)
        {
            decimal quantity = nudQuantity.Value;
            decimal unitPrice = nudUnitPrice.Value;

            decimal total = quantity * unitPrice;

            txtLineTotal.Text = total.ToString("N2");
        }

        private void btnAddRow_Click(object? sender, EventArgs e)
        {
            if (cmbItem.SelectedItem is not ItemData item)
            {
                MessageBox.Show(
                    "اختر الصنف أولاً.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            decimal quantity = nudQuantity.Value;
            decimal unitPrice = nudUnitPrice.Value;

            if (quantity <= 0)
            {
                MessageBox.Show(
                    "الكمية يجب أن تكون أكبر من صفر.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (unitPrice <= 0)
            {
                MessageBox.Show(
                    "سعر البيع يجب أن يكون أكبر من صفر.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // منع تكرار نفس الصنف في الفاتورة
            foreach (DataGridViewRow row in dgvDetails.Rows)
            {
                if (row.Cells["ItemId"].Value != null &&
                    Convert.ToInt32(row.Cells["ItemId"].Value) == item.Id)
                {
                    MessageBox.Show(
                        "الصنف موجود بالفعل في الفاتورة.\nقم بتعديل الكمية أو احذف السطر ثم أضفه من جديد.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            decimal total = quantity * unitPrice;

            dgvDetails.Rows.Add(
                item.Id,
                item.Name,
                item.Unit,
                quantity.ToString("N2"),
                unitPrice.ToString("N2"),
                total.ToString("N2"));

            CalculateInvoiceTotal();

            cmbItem.SelectedIndex = -1;
            txtUnit.Clear();
            nudQuantity.Value = 0;
            nudUnitPrice.Value = 0;
            txtLineTotal.Clear();

            selectedRowIndex = -1;
        }

        private void btnRemoveRow_Click(object? sender, EventArgs e)
        {
            if (selectedRowIndex < 0 ||
                selectedRowIndex >= dgvDetails.Rows.Count)
            {
                MessageBox.Show(
                    "اختر سطرًا من الفاتورة أولاً.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            dgvDetails.Rows.RemoveAt(selectedRowIndex);

            selectedRowIndex = -1;

            CalculateInvoiceTotal();
        }

        private void dgvDetails_CellClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex;
            }
        }

        private decimal CalculateInvoiceTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvDetails.Rows)
            {
                if (row.Cells["Total"].Value != null)
                {
                    total += Convert.ToDecimal(
                        row.Cells["Total"].Value);
                }
            }

            lblTotalAmount.Text = total.ToString("N2");

            return total;
        }

        private void btnNew_Click(object? sender, EventArgs e)
        {
            ClearInvoice();
        }

        private void ClearInvoice()
        {
            GenerateInvoiceNumber();

            dtpInvoiceDate.Value = DateTime.Today;

            if (cmbPaymentType.Items.Count > 0)
                cmbPaymentType.SelectedIndex = 0;

            cmbAccount.SelectedIndex = -1;
            cmbItem.SelectedIndex = -1;

            txtUnit.Clear();
            nudQuantity.Value = 0;
            nudUnitPrice.Value = 0;
            txtLineTotal.Clear();

            dgvDetails.Rows.Clear();

            lblTotalAmount.Text = "0.00";

            selectedRowIndex = -1;

            if (dgvDetails.Columns.Count == 0)
                PrepareGrid();
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (cmbPaymentType.SelectedItem == null)
            {
                MessageBox.Show(
                    "اختر نوع البيع.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (cmbAccount.SelectedItem is not AccountItem account)
            {
                MessageBox.Show(
                    "اختر الحساب.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (dgvDetails.Rows.Count == 0)
            {
                MessageBox.Show(
                    "أضف صنفًا واحدًا على الأقل.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            decimal invoiceTotal = CalculateInvoiceTotal();

            if (invoiceTotal <= 0)
            {
                MessageBox.Show(
                    "إجمالي الفاتورة يجب أن يكون أكبر من صفر.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                using SqlConnection connection =
                    DatabaseConnection.GetConnection();

                connection.Open();

                using SqlTransaction transaction =
                    connection.BeginTransaction();

                try
                {
                    // ==========================================
                    // 1 - التأكد من توفر المخزون قبل أي تسجيل
                    // ==========================================
                    ValidateStock(connection, transaction);

                    // ==========================================
                    // 2 - إنشاء رأس الفاتورة
                    // ==========================================
                    int invoiceId = InsertInvoice(
                        connection,
                        transaction,
                        account.Id);

                    // ==========================================
                    // 3 - حفظ تفاصيل الفاتورة
                    // ==========================================
                    foreach (DataGridViewRow row in dgvDetails.Rows)
                    {
                        int itemId =
                            Convert.ToInt32(row.Cells["ItemId"].Value);

                        string unit =
                            row.Cells["Unit"].Value?.ToString() ?? "";

                        decimal quantity =
                            Convert.ToDecimal(row.Cells["Quantity"].Value);

                        decimal unitPrice =
                            Convert.ToDecimal(row.Cells["UnitPrice"].Value);

                        decimal total =
                            quantity * unitPrice;

                        const string sql = @"
                            INSERT INTO SalesInvoiceDetails
                            (
                                SalesInvoiceId,
                                ItemId,
                                Unit,
                                Quantity,
                                UnitPrice,
                                Total
                            )
                            VALUES
                            (
                                @SalesInvoiceId,
                                @ItemId,
                                @Unit,
                                @Quantity,
                                @UnitPrice,
                                @Total
                            )";

                        using SqlCommand command =
                            new SqlCommand(
                                sql,
                                connection,
                                transaction);

                        command.Parameters.AddWithValue(
                            "@SalesInvoiceId",
                            invoiceId);

                        command.Parameters.AddWithValue(
                            "@ItemId",
                            itemId);

                        command.Parameters.AddWithValue(
                            "@Unit",
                            unit);

                        command.Parameters.AddWithValue(
                            "@Quantity",
                            quantity);

                        command.Parameters.AddWithValue(
                            "@UnitPrice",
                            unitPrice);

                        command.Parameters.AddWithValue(
                            "@Total",
                            total);

                        command.ExecuteNonQuery();
                    }

                    // ==========================================
                    // 4 - إنشاء القيود المحاسبية
                    // ==========================================
                    CreateJournalEntry(
                        connection,
                        transaction,
                        account.Id,
                        invoiceTotal);

                    // ==========================================
                    // 5 - تثبيت العملية كاملة
                    // ==========================================
                    transaction.Commit();

                    MessageBox.Show(
                        "تم حفظ فاتورة المبيعات والقيد المحاسبي بنجاح.",
                        "نجاح",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearInvoice();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "تعذر حفظ فاتورة المبيعات:\n" + ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private int InsertInvoice(
            SqlConnection connection,
            SqlTransaction transaction,
            int accountId)
        {
            string paymentType =
                cmbPaymentType.SelectedItem?.ToString() ?? "نقد";

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

            command.Parameters.AddWithValue(
                "@InvoiceNumber",
                txtInvoiceNumber.Text);

            command.Parameters.AddWithValue(
                "@InvoiceDate",
                dtpInvoiceDate.Value.Date);

            command.Parameters.AddWithValue(
                "@PaymentType",
                paymentType);

            command.Parameters.AddWithValue(
                "@AccountId",
                accountId);

            return Convert.ToInt32(command.ExecuteScalar());
        }

        private void ValidateStock(
            SqlConnection connection,
            SqlTransaction transaction)
        {
            foreach (DataGridViewRow row in dgvDetails.Rows)
            {
                int itemId =
                    Convert.ToInt32(row.Cells["ItemId"].Value);

                decimal requiredQuantity =
                    Convert.ToDecimal(row.Cells["Quantity"].Value);

                decimal availableQuantity =
                    GetAvailableStock(
                        connection,
                        transaction,
                        itemId);

                if (requiredQuantity > availableQuantity)
                {
                    string itemName =
                        row.Cells["ItemName"].Value?.ToString() ?? "";

                    throw new Exception(
                        $"الصنف ({itemName}) لا يحتوي على كمية كافية.\n" +
                        $"المتاح: {availableQuantity:N2}\n" +
                        $"المطلوب: {requiredQuantity:N2}");
                }
            }
        }

        private decimal GetAvailableStock(
            SqlConnection connection,
            SqlTransaction transaction,
            int itemId)
        {
            const string sql = @"
                SELECT
                    ISNULL(
                        (
                            SELECT SUM(Quantity)
                            FROM PurchaseInvoiceDetails
                            WHERE ItemId = @ItemId
                        ), 0
                    )
                    -
                    ISNULL(
                        (
                            SELECT SUM(Quantity)
                            FROM SalesInvoiceDetails
                            WHERE ItemId = @ItemId
                        ), 0
                    )";

            using SqlCommand command =
                new SqlCommand(
                    sql,
                    connection,
                    transaction);

            command.Parameters.AddWithValue(
                "@ItemId",
                itemId);

            return Convert.ToDecimal(
                command.ExecuteScalar());
        }

        private void CreateJournalEntry(
            SqlConnection connection,
            SqlTransaction transaction,
            int accountId,
            decimal salesAmount)
        {
            // ==========================================
            // حسابات النظام الأساسية
            // ==========================================
            int salesAccountId =
                GetAccountId(
                    connection,
                    transaction,
                    "4100");

            int inventoryAccountId =
                GetAccountId(
                    connection,
                    transaction,
                    "1130");

            int costOfGoodsAccountId =
                GetAccountId(
                    connection,
                    transaction,
                    "5100");

            // ==========================================
            // حساب تكلفة البضاعة المباعة
            // ==========================================
            decimal costOfGoods =
                CalculateCostOfGoodsSold(
                    connection,
                    transaction);

            if (costOfGoods <= 0)
            {
                throw new Exception(
                    "تعذر تحديد تكلفة البضاعة المباعة لهذه الفاتورة.");
            }

            // ==========================================
            // رقم القيد
            // ==========================================
            string entryNumber =
                GenerateJournalEntryNumber(
                    connection,
                    transaction);

            // ==========================================
            // إنشاء رأس القيد
            // ==========================================
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
                command.Parameters.AddWithValue(
                    "@EntryNumber",
                    entryNumber);

                command.Parameters.AddWithValue(
                    "@EntryDate",
                    dtpInvoiceDate.Value.Date);

                command.Parameters.AddWithValue(
                    "@Description",
                    $"فاتورة مبيعات رقم {txtInvoiceNumber.Text}");

                journalEntryId =
                    Convert.ToInt32(command.ExecuteScalar());
            }

            // ==========================================
            // القيد الأول:
            //
            // مدين: العميل / الصندوق
            // دائن: المبيعات
            // ==========================================
            InsertJournalDetail(
                connection,
                transaction,
                journalEntryId,
                accountId,
                salesAmount,
                0,
                "قيمة فاتورة المبيعات");

            InsertJournalDetail(
                connection,
                transaction,
                journalEntryId,
                salesAccountId,
                0,
                salesAmount,
                "إيراد المبيعات");

            // ==========================================
            // القيد الثاني:
            //
            // مدين: تكلفة البضاعة المباعة
            // دائن: المخزون
            // ==========================================
            InsertJournalDetail(
                connection,
                transaction,
                journalEntryId,
                costOfGoodsAccountId,
                costOfGoods,
                0,
                "تكلفة البضاعة المباعة");

            InsertJournalDetail(
                connection,
                transaction,
                journalEntryId,
                inventoryAccountId,
                0,
                costOfGoods,
                "إخراج تكلفة البضاعة من المخزون");
        }

        private decimal CalculateCostOfGoodsSold(
            SqlConnection connection,
            SqlTransaction transaction)
        {
            decimal totalCost = 0;

            foreach (DataGridViewRow row in dgvDetails.Rows)
            {
                int itemId =
                    Convert.ToInt32(row.Cells["ItemId"].Value);

                decimal quantity =
                    Convert.ToDecimal(row.Cells["Quantity"].Value);

                decimal averageCost =
                    GetAveragePurchaseCost(
                        connection,
                        transaction,
                        itemId);

                totalCost += quantity * averageCost;
            }

            return totalCost;
        }

        private decimal GetAveragePurchaseCost(
            SqlConnection connection,
            SqlTransaction transaction,
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

            command.Parameters.AddWithValue(
                "@ItemId",
                itemId);

            return Convert.ToDecimal(
                command.ExecuteScalar());
        }

        private int GetAccountId(
            SqlConnection connection,
            SqlTransaction transaction,
            string accountNumber)
        {
            const string sql = @"
                SELECT AccountId
                FROM Accounts
                WHERE AccountNumber = @AccountNumber";

            using SqlCommand command =
                new SqlCommand(
                    sql,
                    connection,
                    transaction);

            command.Parameters.AddWithValue(
                "@AccountNumber",
                accountNumber);

            object? result =
                command.ExecuteScalar();

            if (result == null)
            {
                throw new Exception(
                    $"الحساب رقم {accountNumber} غير موجود في شجرة الحسابات.");
            }

            return Convert.ToInt32(result);
        }

        private string GenerateJournalEntryNumber(
            SqlConnection connection,
            SqlTransaction transaction)
        {
            const string sql = @"
                SELECT ISNULL(
                    MAX(TRY_CAST(EntryNumber AS INT)), 0
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

        private void InsertJournalDetail(
            SqlConnection connection,
            SqlTransaction transaction,
            int journalEntryId,
            int accountId,
            decimal debit,
            decimal credit,
            string description)
        {
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
                    @Description
                )";

            using SqlCommand command =
                new SqlCommand(
                    sql,
                    connection,
                    transaction);

            command.Parameters.AddWithValue(
                "@JournalEntryId",
                journalEntryId);

            command.Parameters.AddWithValue(
                "@AccountId",
                accountId);

            command.Parameters.AddWithValue(
                "@Debit",
                debit);

            command.Parameters.AddWithValue(
                "@Credit",
                credit);

            command.Parameters.AddWithValue(
                "@Description",
                description);

            command.ExecuteNonQuery();
        }

        private class AccountItem
        {
            public int Id { get; set; }
            public string Number { get; set; } = "";
            public string Name { get; set; } = "";

            public string DisplayText =>
                $"{Number} - {Name}";
        }

        private class ItemData
        {
            public int Id { get; set; }
            public string Number { get; set; } = "";
            public string Name { get; set; } = "";
            public string Unit { get; set; } = "";

            public string DisplayText =>
                $"{Number} - {Name}";
        }
    }
}