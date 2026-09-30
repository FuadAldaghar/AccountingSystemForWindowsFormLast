using System.Data;
using Microsoft.Data.SqlClient;
using AccountingSystemForWindowsFormLast.Data;

namespace AccountingSystemForWindowsFormLast.Forms
{
    public partial class PurchaseInvoice : Form
    {
        private int selectedDetailRow = -1;

        public PurchaseInvoice()
        {
            InitializeComponent();

            btnNew.Click += btnNew_Click;
            btnSave.Click += btnSave_Click;

            btnAddRow.Click += btnAddRow_Click;
            btnRemoveRow.Click += btnRemoveRow_Click;

            cmbItem.SelectedIndexChanged += cmbItem_SelectedIndexChanged;

            nudQuantity.ValueChanged += CalculateLineTotal;
            nudUnitPrice.ValueChanged += CalculateLineTotal;

            dgvDetails.CellClick += dgvDetails_CellClick;
        }

        // =========================================================
        // تحميل الفورم
        // =========================================================
        private void PurchaseInvoice_Load(object sender, EventArgs e)
        {
            LoadAccounts();
            LoadItems();

            PrepareGrid();

            NewInvoice();
        }

        // =========================================================
        // تجهيز الجدول
        // =========================================================
        private void PrepareGrid()
        {
            dgvDetails.Columns.Clear();

            dgvDetails.Columns.Add("ItemId", "ItemId");
            dgvDetails.Columns.Add("ItemName", "الصنف");
            dgvDetails.Columns.Add("Unit", "الوحدة");
            dgvDetails.Columns.Add("Quantity", "الكمية");
            dgvDetails.Columns.Add("UnitPrice", "سعر الوحدة");
            dgvDetails.Columns.Add("Total", "الإجمالي");

            dgvDetails.Columns["ItemId"].Visible = false;

            dgvDetails.Columns["ItemName"].FillWeight = 35;
            dgvDetails.Columns["Unit"].FillWeight = 15;
            dgvDetails.Columns["Quantity"].FillWeight = 15;
            dgvDetails.Columns["UnitPrice"].FillWeight = 17;
            dgvDetails.Columns["Total"].FillWeight = 18;
        }

        // =========================================================
        // تحميل الحسابات
        // =========================================================
        private void LoadAccounts()
        {
            try
            {
                using SqlConnection connection =
                    DatabaseConnection.GetConnection();

                string query = @"
                    SELECT
                        AccountId,
                        AccountNumber,
                        AccountName
                    FROM Accounts
                    WHERE IsGroup = 0
                    ORDER BY AccountNumber";

                using SqlCommand command =
                    new SqlCommand(query, connection);

                DataTable table = new DataTable();

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();

                table.Load(reader);

                cmbAccount.DataSource = table;
                cmbAccount.DisplayMember = "AccountName";
                cmbAccount.ValueMember = "AccountId";
                cmbAccount.SelectedIndex = -1;
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

        // =========================================================
        // تحميل الأصناف
        // =========================================================
        private void LoadItems()
        {
            try
            {
                using SqlConnection connection =
                    DatabaseConnection.GetConnection();

                string query = @"
                    SELECT
                        ItemId,
                        ItemNumber,
                        ItemName,
                        Unit
                    FROM Items
                    ORDER BY ItemNumber";

                using SqlCommand command =
                    new SqlCommand(query, connection);

                DataTable table = new DataTable();

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();

                table.Load(reader);

                cmbItem.DataSource = table;
                cmbItem.DisplayMember = "ItemName";
                cmbItem.ValueMember = "ItemId";
                cmbItem.SelectedIndex = -1;
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

        // =========================================================
        // عند اختيار الصنف
        // =========================================================
        private void cmbItem_SelectedIndexChanged(
            object? sender,
            EventArgs e)
        {
            if (cmbItem.SelectedIndex < 0)
            {
                txtUnit.Clear();
                return;
            }

            if (cmbItem.SelectedItem is DataRowView row)
            {
                txtUnit.Text = row["Unit"]?.ToString() ?? "";
            }

            CalculateLineTotal(null, EventArgs.Empty);
        }

        // =========================================================
        // حساب إجمالي السطر
        // =========================================================
        private void CalculateLineTotal(
            object? sender,
            EventArgs e)
        {
            decimal quantity = nudQuantity.Value;
            decimal unitPrice = nudUnitPrice.Value;

            decimal total = quantity * unitPrice;

            txtLineTotal.Text = total.ToString("N2");
        }

        // =========================================================
        // إضافة سطر
        // =========================================================
        private void btnAddRow_Click(object? sender, EventArgs e)
        {
            if (cmbItem.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "يرجى اختيار الصنف.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbItem.Focus();
                return;
            }

            if (nudQuantity.Value <= 0)
            {
                MessageBox.Show(
                    "الكمية يجب أن تكون أكبر من صفر.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (nudUnitPrice.Value < 0)
            {
                MessageBox.Show(
                    "سعر الوحدة غير صحيح.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int itemId = Convert.ToInt32(cmbItem.SelectedValue);

            string itemName = cmbItem.Text;
            string unit = txtUnit.Text;

            decimal quantity = nudQuantity.Value;
            decimal unitPrice = nudUnitPrice.Value;

            decimal total = quantity * unitPrice;

            dgvDetails.Rows.Add(
                itemId,
                itemName,
                unit,
                quantity.ToString("N2"),
                unitPrice.ToString("N2"),
                total.ToString("N2"));

            CalculateInvoiceTotal();

            ClearDetailFields();
        }

        // =========================================================
        // حذف سطر
        // =========================================================
        private void btnRemoveRow_Click(object? sender, EventArgs e)
        {
            if (selectedDetailRow < 0 ||
                selectedDetailRow >= dgvDetails.Rows.Count)
            {
                MessageBox.Show(
                    "يرجى تحديد السطر المراد حذفه.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            dgvDetails.Rows.RemoveAt(selectedDetailRow);

            selectedDetailRow = -1;

            CalculateInvoiceTotal();
        }

        // =========================================================
        // تحديد سطر
        // =========================================================
        private void dgvDetails_CellClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            selectedDetailRow = e.RowIndex;
        }

        // =========================================================
        // حساب إجمالي الفاتورة
        // =========================================================
        private void CalculateInvoiceTotal()
        {
            decimal invoiceTotal = 0;

            foreach (DataGridViewRow row in dgvDetails.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (decimal.TryParse(
                    row.Cells["Total"].Value?.ToString(),
                    out decimal lineTotal))
                {
                    invoiceTotal += lineTotal;
                }
            }

            lblTotalAmount.Text = invoiceTotal.ToString("N2");
        }

        // =========================================================
        // حساب إجمالي الفاتورة كرقم
        // =========================================================
        private decimal GetInvoiceTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvDetails.Rows)
            {
                if (row.IsNewRow)
                    continue;

                decimal.TryParse(
                    row.Cells["Total"].Value?.ToString(),
                    out decimal lineTotal);

                total += lineTotal;
            }

            return total;
        }

        // =========================================================
        // حفظ الفاتورة
        // =========================================================
        private void btnSave_Click(object? sender, EventArgs e)
        {//التحقق من صحة الفاتورة قبل الحفظ
            if (!ValidateInvoice())
                return;
            // الحصول على إجمالي الفاتورة
            decimal invoiceTotal = GetInvoiceTotal();
            // الحصول على معرف الحساب ونوع الدفع
            int accountId =
                Convert.ToInt32(cmbAccount.SelectedValue);

            string paymentType = cmbPaymentType.Text;
            ///

            try
            {
                using SqlConnection connection =
                    DatabaseConnection.GetConnection();

                connection.Open();
                // بدء معاملة قاعدة البيانات
                using SqlTransaction transaction =
                    connection.BeginTransaction();

                try
                {
                    // =================================================
                    // 1. حفظ رأس الفاتورة
                    // =================================================
                    string invoiceQuery = @"
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

                        SELECT SCOPE_IDENTITY();";
                    // تنفيذ الاستعلام والحصول على معرف الفاتورة الجديدة
                    int invoiceId;

                    using (SqlCommand command =
                        new SqlCommand(
                            invoiceQuery,
                            connection,
                            transaction))
                    {
                        command.Parameters.AddWithValue(
                            "@InvoiceNumber",
                            txtInvoiceNumber.Text.Trim());

                        command.Parameters.AddWithValue(
                            "@InvoiceDate",
                            dtpInvoiceDate.Value.Date);

                        command.Parameters.AddWithValue(
                            "@PaymentType",
                            paymentType);

                        command.Parameters.AddWithValue(
                            "@AccountId",
                            accountId);

                        invoiceId =
                            Convert.ToInt32(command.ExecuteScalar());
                    }

                    // =================================================
                    // 2. حفظ تفاصيل الفاتورة
                    // =================================================
                    foreach (DataGridViewRow row in dgvDetails.Rows)
                    {
                        if (row.IsNewRow)
                            continue;

                        int itemId =
                            Convert.ToInt32(
                                row.Cells["ItemId"].Value);

                        string unit =
                            row.Cells["Unit"].Value?.ToString() ?? "";

                        decimal quantity =
                            Convert.ToDecimal(
                                row.Cells["Quantity"].Value);

                        decimal unitPrice =
                            Convert.ToDecimal(
                                row.Cells["UnitPrice"].Value);

                        decimal total =
                            quantity * unitPrice;

                        //string detailQuery = @"
                        //    INSERT INTO PurchaseInvoiceDetails
                        //    (
                        //        PurchaseInvoiceId,
                        //        ItemId,
                        //        Unit,
                        //        Quantity,
                        //        UnitPrice,
                        //        Total
                        //    )
                        //    VALUES
                        //    (
                        //        @PurchaseInvoiceId,
                        //        @ItemId,
                        //        @Unit,
                        //        @Quantity,
                        //        @UnitPrice,
                        //        @Total
                        //    )";

                        string detailQuery = @"
    INSERT INTO PurchaseInvoiceDetails
    (
        PurchaseInvoiceId,
        ItemId,
        Quantity,
        UnitPrice
    )
    VALUES
    (
        @PurchaseInvoiceId,
        @ItemId,
        @Quantity,
        @UnitPrice)";
                        using SqlCommand detailCommand =
                            new SqlCommand(
                                detailQuery,
                                connection,
                                transaction);

                        detailCommand.Parameters.AddWithValue(
                            "@PurchaseInvoiceId",
                            invoiceId);

                        detailCommand.Parameters.AddWithValue(
                            "@ItemId",
                            itemId);

                        //detailCommand.Parameters.AddWithValue(
                        //    "@Unit",
                        //    unit);

                        detailCommand.Parameters.AddWithValue(
                            "@Quantity",
                            quantity);

                        detailCommand.Parameters.AddWithValue(
                            "@UnitPrice",
                            unitPrice);

                        detailCommand.Parameters.AddWithValue(
                            "@Total",
                            total);

                        detailCommand.ExecuteNonQuery();
                    }

                    // =================================================
                    // 3. القيد المحاسبي
                    // =================================================
                    CreateJournalEntry(
                        connection,
                        transaction,
                        invoiceId,
                        invoiceTotal,
                        accountId,
                        paymentType);

                    // =================================================
                    // نجاح العملية
                    // =================================================
                    transaction.Commit();

                    MessageBox.Show(
                        "تم حفظ فاتورة المشتريات وترحيل القيد المحاسبي بنجاح.",
                        "نجاح",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    NewInvoice();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "حدث خطأ في قاعدة البيانات:\n" + ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء حفظ الفاتورة:\n" + ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // إنشاء القيد المحاسبي
        // =========================================================
        private void CreateJournalEntry(
            SqlConnection connection,
            SqlTransaction transaction,
            int invoiceId,
            decimal amount,
            int accountId,
            string paymentType)
        {
            /*
             * فاتورة شراء:
             *
             * مدين  = المخزون
             * دائن   = الحساب المقابل
             *
             * نقد:
             * الحساب المقابل = الحساب المختار
             *
             * أجل:
             * الحساب المختار = حساب المورد
             *
             * مثال:
             * شراء بقيمة 100,000 آجل
             *
             * المخزون      مدين 100,000
             * المورد       دائن 100,000
             */

            int inventoryAccountId =
                GetInventoryAccountId(
                    connection,
                    transaction);

            string entryNumber =
                GetNextJournalEntryNumber(
                    connection,
                    transaction);

            string description =
                $"فاتورة مشتريات رقم {txtInvoiceNumber.Text}";

            // ---------------------------------------------------------
            // رأس القيد
            // ---------------------------------------------------------
            string entryQuery = @"
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

                SELECT SCOPE_IDENTITY();";

            int journalEntryId;

            using (SqlCommand command =
                new SqlCommand(
                    entryQuery,
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
                    description);

                journalEntryId =
                    Convert.ToInt32(command.ExecuteScalar());
            }

            // ---------------------------------------------------------
            // مدين: المخزون
            // ---------------------------------------------------------
            InsertJournalDetail(
                connection,
                transaction,
                journalEntryId,
                inventoryAccountId,
                amount,
                0,
                description);

            // ---------------------------------------------------------
            // دائن: الحساب المقابل
            // ---------------------------------------------------------
            InsertJournalDetail(
                connection,
                transaction,
                journalEntryId,
                accountId,
                0,
                amount,
                description);
        }

        // =========================================================
        // إضافة تفاصيل القيد
        // =========================================================
        private void InsertJournalDetail(
            SqlConnection connection,
            SqlTransaction transaction,
            int journalEntryId,
            int accountId,
            decimal debit,
            decimal credit,
            string description)
        {
            string query = @"
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
                    query,
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

        // =========================================================
        // الحصول على حساب المخزون
        // =========================================================
        private int GetInventoryAccountId(
     SqlConnection connection,
     SqlTransaction transaction)
        {
            string query = @"
        SELECT TOP 1 AccountId
        FROM Accounts
        WHERE AccountNumber = N'114'
          AND AccountName = N'المخزون'
          AND IsGroup = 0";

            using SqlCommand command =
                new SqlCommand(
                    query,
                    connection,
                    transaction);

            object? result = command.ExecuteScalar();

            if (result == null)
            {
                throw new Exception(
                    "لم يتم العثور على حساب المخزون 114.");
            }

            return Convert.ToInt32(result);
        }

        // =========================================================
        // رقم القيد التالي
        // =========================================================
        private string GetNextJournalEntryNumber(
            SqlConnection connection,
            SqlTransaction transaction)
        {
            string query = @"
                SELECT
                    ISNULL(
                        MAX(
                            TRY_CAST(EntryNumber AS INT)
                        ),
                        0
                    ) + 1
                FROM JournalEntries";

            using SqlCommand command =
                new SqlCommand(
                    query,
                    connection,
                    transaction);

            int nextNumber =
                Convert.ToInt32(command.ExecuteScalar());

            return nextNumber.ToString();
        }

        // =========================================================
        // التحقق من الفاتورة
        // =========================================================
        private bool ValidateInvoice()
        {
            if (string.IsNullOrWhiteSpace(txtInvoiceNumber.Text))
            {
                MessageBox.Show(
                    "رقم الفاتورة غير موجود.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (cmbPaymentType.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "يرجى اختيار نوع الدفع: نقد أو أجل.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbPaymentType.Focus();

                return false;
            }

            if (cmbAccount.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "يرجى اختيار الحساب.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbAccount.Focus();

                return false;
            }

            if (dgvDetails.Rows.Count == 0)
            {
                MessageBox.Show(
                    "لا يمكن حفظ الفاتورة بدون أصناف.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            decimal total = GetInvoiceTotal();

            if (total <= 0)
            {
                MessageBox.Show(
                    "إجمالي الفاتورة يجب أن يكون أكبر من صفر.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        // =========================================================
        // فاتورة جديدة
        // =========================================================
        private void btnNew_Click(object? sender, EventArgs e)
        {
            NewInvoice();
        }

        private void NewInvoice()
        {
            txtInvoiceNumber.Text =
                GenerateInvoiceNumber();

            dtpInvoiceDate.Value =
                DateTime.Today;

            cmbPaymentType.SelectedIndex = -1;
            cmbAccount.SelectedIndex = -1;

            dgvDetails.Rows.Clear();

            selectedDetailRow = -1;

            ClearDetailFields();

            CalculateInvoiceTotal();
        }

        // =========================================================
        // توليد رقم الفاتورة
        // =========================================================
        private string GenerateInvoiceNumber()
        {
            try
            {
                using SqlConnection connection =
                    DatabaseConnection.GetConnection();

                string query = @"
                    SELECT
                        ISNULL(
                            MAX(
                                TRY_CAST(InvoiceNumber AS INT)
                            ),
                            0
                        ) + 1
                    FROM PurchaseInvoices";

                using SqlCommand command =
                    new SqlCommand(query, connection);

                connection.Open();

                int nextNumber =
                    Convert.ToInt32(command.ExecuteScalar());

                return nextNumber.ToString();
            }
            catch
            {
                return "1";
            }
        }

        // =========================================================
        // تنظيف حقول السطر
        // =========================================================
        private void ClearDetailFields()
        {
            cmbItem.SelectedIndex = -1;
            txtUnit.Clear();

            nudQuantity.Value = 1;
            nudUnitPrice.Value = 0;

            txtLineTotal.Text = "0.00";

            selectedDetailRow = -1;

            dgvDetails.ClearSelection();
        }

        private void cmbPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}