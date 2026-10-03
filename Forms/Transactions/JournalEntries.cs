using System.Data;
using Microsoft.Data.SqlClient;
using AccountingSystemForWindowsFormLast.Data;

namespace AccountingSystemForWindowsFormLast.Forms
{
    public partial class JournalEntries : Form
    {
        private int selectedEntryId = 0;

        public JournalEntries()
        {
            MessageBox.Show("الواجهة غير مكتمله بشكل مثالي");
            InitializeComponent();

            LoadAccounts();
            LoadEntries();

            btnNew.Click += btnNew_Click;
            btnSave.Click += btnSave_Click;
            btnDelete.Click += btnDelete_Click;
            btnAddRow.Click += btnAddRow_Click;
            btnRemoveRow.Click += btnRemoveRow_Click;

            dgvDetails.CellValueChanged += dgvDetails_CellValueChanged;
            dgvEntries.CellClick += dgvEntries_CellClick;

            txtEntryNumber.Text = GenerateEntryNumber();
        }

        private void JournalEntries_Load(object? sender, EventArgs e)
        {
            // Ensure dgvDetails columns have expected names
            if (dgvDetails.Columns.Count == 5)
            {
                dgvDetails.Columns[0].Name = "رقم الحساب";
                dgvDetails.Columns[1].Name = "اسم الحساب";
                dgvDetails.Columns[2].Name = "مدين";
                dgvDetails.Columns[3].Name = "دائن";
                dgvDetails.Columns[4].Name = "الوصف";
                dgvDetails.Columns[0].Visible = false;
            }

            UpdateTotals();
        }

        // =========================
        // تحميل القيود
        // =========================
        private void LoadEntries()
        {
            try
            {
                using SqlConnection connection =
                    DatabaseConnection.GetConnection();

                connection.Open();

                string query = @"
                    SELECT
                        JournalEntryId,
                        EntryNumber,
                        EntryDate,
                        Description
                    FROM JournalEntries
                    ORDER BY JournalEntryId DESC";

                using SqlDataAdapter adapter =
                    new(query, connection);

                DataTable table = new();
                adapter.Fill(table);

                dgvEntries.DataSource = table;

                if (dgvEntries.Columns.Count > 0)
                {
                    dgvEntries.Columns["JournalEntryId"].Visible = false;

                    dgvEntries.Columns["EntryNumber"].HeaderText =
                        "رقم القيد";

                    dgvEntries.Columns["EntryDate"].HeaderText =
                        "التاريخ";

                    dgvEntries.Columns["Description"].HeaderText =
                        "البيان";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تحميل القيود:\n" + ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // تحميل الحسابات
        // =========================
        private void LoadAccounts()
        {
            try
            {
                using SqlConnection connection =
                    DatabaseConnection.GetConnection();

                connection.Open();

                string query = @"
                    SELECT
                        AccountId,
                        AccountNumber,
                        AccountName
                    FROM Accounts
                    WHERE IsGroup = 0
                    ORDER BY AccountNumber";

                using SqlCommand command =
                    new(query, connection);

                using SqlDataReader reader =
                    command.ExecuteReader();

                DataTable table = new();
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

        // =========================
        // توليد رقم القيد
        // =========================
        private string GenerateEntryNumber()
        {
            try
            {
                using SqlConnection connection =
                    DatabaseConnection.GetConnection();

                connection.Open();

                string query = @"
                    SELECT ISNULL(MAX(TRY_CAST(EntryNumber AS INT)), 0) + 1
                    FROM JournalEntries";

                using SqlCommand command =
                    new(query, connection);

                object? result = command.ExecuteScalar();

                return Convert.ToString(result) ?? "1";
            }
            catch
            {
                return "1";
            }
        }

        // =========================
        // جديد
        // =========================
        private void btnNew_Click(
            object? sender,
            EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            selectedEntryId = 0;

            txtEntryNumber.Text =
                GenerateEntryNumber();

            dtpEntryDate.Value =
                DateTime.Today;

            txtDescription.Clear();

            dgvDetails.Rows.Clear();

            cmbAccount.SelectedIndex = -1;

            UpdateTotals();
        }

        // =========================
        // إضافة سطر
        // =========================
        private void btnAddRow_Click(
            object? sender,
            EventArgs e)
        {
            if (cmbAccount.SelectedValue == null)
            {
                MessageBox.Show(
                    "اختر الحساب أولاً.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int accountId =
                Convert.ToInt32(cmbAccount.SelectedValue);

            DataRowView? selectedAccount =
                cmbAccount.SelectedItem as DataRowView;

            string accountName =
                selectedAccount?["AccountName"]?.ToString() ?? "";

            dgvDetails.Rows.Add(
                accountId,
                accountName,
                0,
                0,
                ""
            );

            cmbAccount.SelectedIndex = -1;
        }

        // =========================
        // حذف سطر
        // =========================
        private void btnRemoveRow_Click(
            object? sender,
            EventArgs e)
        {
            if (dgvDetails.CurrentRow != null &&
                !dgvDetails.CurrentRow.IsNewRow)
            {
                dgvDetails.Rows.Remove(
                    dgvDetails.CurrentRow);

                UpdateTotals();
            }
        }

        // =========================
        // حساب الإجماليات
        // =========================
        private void dgvDetails_CellValueChanged(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                UpdateTotals();
        }

        private void UpdateTotals()
        {
            decimal totalDebit = 0;
            decimal totalCredit = 0;

            foreach (DataGridViewRow row
                in dgvDetails.Rows)
            {
                if (row.IsNewRow)
                    continue;

                decimal.TryParse(
                    row.Cells["Debit"].Value?.ToString(),
                    out decimal debit);

                decimal.TryParse(
                    row.Cells["Credit"].Value?.ToString(),
                    out decimal credit);

                totalDebit += debit;
                totalCredit += credit;
            }

            lblTotalDebit.Text =
                $"إجمالي المدين: {totalDebit:N2}";

            lblTotalCredit.Text =
                $"إجمالي الدائن: {totalCredit:N2}";

            lblDifference.Text =
                $"الفرق: {(totalDebit - totalCredit):N2}";
        }

        // =========================
        // التحقق من القيد
        // =========================
        private bool ValidateEntry()
        {
            if (string.IsNullOrWhiteSpace(
                txtEntryNumber.Text))
            {
                MessageBox.Show("رقم القيد مطلوب.");
                return false;
            }

            if (dgvDetails.Rows.Count < 2)
            {
                MessageBox.Show(
                    "يجب إضافة حسابين على الأقل.");
                return false;
            }

            decimal totalDebit = 0;
            decimal totalCredit = 0;

            int validRows = 0;

            foreach (DataGridViewRow row
                in dgvDetails.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (row.Cells["AccountId"].Value == null)
                {
                    MessageBox.Show(
                        "يوجد سطر بدون حساب.");

                    return false;
                }

                decimal.TryParse(
                    row.Cells["Debit"].Value?.ToString(),
                    out decimal debit);

                decimal.TryParse(
                    row.Cells["Credit"].Value?.ToString(),
                    out decimal credit);

                if (debit < 0 || credit < 0)
                {
                    MessageBox.Show(
                        "لا يمكن إدخال مبلغ سالب.");

                    return false;
                }

                if (debit > 0 && credit > 0)
                {
                    MessageBox.Show(
                        "لا يمكن أن يكون الحساب مديناً ودائناً في نفس السطر.");

                    return false;
                }

                if (debit == 0 && credit == 0)
                {
                    MessageBox.Show(
                        "يوجد سطر بدون مبلغ.");

                    return false;
                }

                totalDebit += debit;
                totalCredit += credit;

                validRows++;
            }

            if (validRows < 2)
            {
                MessageBox.Show(
                    "القيد يجب أن يحتوي على حسابين على الأقل.");

                return false;
            }

            if (totalDebit != totalCredit)
            {
                MessageBox.Show(
                    $"القيد غير متوازن.\n\n" +
                    $"المدين: {totalDebit:N2}\n" +
                    $"الدائن: {totalCredit:N2}\n" +
                    $"الفرق: {(totalDebit - totalCredit):N2}");

                return false;
            }

            return true;
        }

        // =========================
        // حفظ القيد
        // =========================
        private void btnSave_Click(
            object? sender,
            EventArgs e)
        {
            if (!ValidateEntry())
                return;

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            using SqlTransaction transaction =
                connection.BeginTransaction();

            try
            {
                int entryId;

                // =========================
                // إضافة قيد جديد
                // =========================
                if (selectedEntryId == 0)
                {
                    string query = @"
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

                    using SqlCommand command =
                        new(query, connection, transaction);

                    command.Parameters.AddWithValue(
                        "@EntryNumber",
                        txtEntryNumber.Text.Trim());

                    command.Parameters.AddWithValue(
                        "@EntryDate",
                        dtpEntryDate.Value.Date);

                    command.Parameters.AddWithValue(
                        "@Description",
                        txtDescription.Text.Trim());

                    entryId =
                        Convert.ToInt32(
                            command.ExecuteScalar());
                }
                else
                {
                    // =========================
                    // تعديل القيد
                    // =========================
                    entryId = selectedEntryId;

                    string query = @"
                        UPDATE JournalEntries
                        SET
                            EntryNumber = @EntryNumber,
                            EntryDate = @EntryDate,
                            Description = @Description
                        WHERE JournalEntryId = @JournalEntryId";

                    using SqlCommand command =
                        new(query, connection, transaction);

                    command.Parameters.AddWithValue(
                        "@EntryNumber",
                        txtEntryNumber.Text.Trim());

                    command.Parameters.AddWithValue(
                        "@EntryDate",
                        dtpEntryDate.Value.Date);

                    command.Parameters.AddWithValue(
                        "@Description",
                        txtDescription.Text.Trim());

                    command.Parameters.AddWithValue(
                        "@JournalEntryId",
                        entryId);

                    command.ExecuteNonQuery();

                    // حذف التفاصيل القديمة
                    string deleteQuery = @"
                        DELETE FROM JournalEntryDetails
                        WHERE JournalEntryId =
                        @JournalEntryId";

                    using SqlCommand deleteCommand =
                        new(
                            deleteQuery,
                            connection,
                            transaction);

                    deleteCommand.Parameters.AddWithValue(
                        "@JournalEntryId",
                        entryId);

                    deleteCommand.ExecuteNonQuery();
                }

                // =========================
                // حفظ التفاصيل
                // =========================
                foreach (DataGridViewRow row
                    in dgvDetails.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    int accountId =
                        Convert.ToInt32(
                            row.Cells["AccountId"].Value);

                    decimal.TryParse(
                        row.Cells["Debit"].Value?.ToString(),
                        out decimal debit);

                    decimal.TryParse(
                        row.Cells["Credit"].Value?.ToString(),
                        out decimal credit);

                    string description =
                        row.Cells["LineDescription"]
                            .Value?.ToString() ?? "";

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
                        new(
                            query,
                            connection,
                            transaction);

                    command.Parameters.AddWithValue(
                        "@JournalEntryId",
                        entryId);

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

                transaction.Commit();

                MessageBox.Show(
                    "تم حفظ القيد بنجاح.",
                    "نجاح",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadEntries();
                ClearForm();
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                MessageBox.Show(
                    "حدث خطأ أثناء حفظ القيد:\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // اختيار قيد
        // =========================
        private void dgvEntries_CellClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                dgvEntries.Rows[e.RowIndex];

            selectedEntryId =
                Convert.ToInt32(
                    row.Cells["JournalEntryId"].Value);

            txtEntryNumber.Text =
                row.Cells["EntryNumber"].Value?.ToString()
                ?? "";

            dtpEntryDate.Value =
                Convert.ToDateTime(
                    row.Cells["EntryDate"].Value);

            txtDescription.Text =
                row.Cells["Description"].Value?.ToString()
                ?? "";

            LoadEntryDetails(selectedEntryId);
        }

        // =========================
        // تحميل تفاصيل القيد
        // =========================
        private void LoadEntryDetails(int entryId)
        {
            try
            {
                using SqlConnection connection =
                    DatabaseConnection.GetConnection();

                connection.Open();

                string query = @"
                    SELECT
                        d.AccountId,
                        a.AccountName,
                        d.Debit,
                        d.Credit,
                        d.Description
                    FROM JournalEntryDetails d
                    INNER JOIN Accounts a
                        ON d.AccountId = a.AccountId
                    WHERE d.JournalEntryId =
                        @JournalEntryId
                    ORDER BY d.JournalEntryDetailId";

                using SqlCommand command =
                    new(query, connection);

                command.Parameters.AddWithValue(
                    "@JournalEntryId",
                    entryId);

                using SqlDataReader reader =
                    command.ExecuteReader();

                dgvDetails.Rows.Clear();

                while (reader.Read())
                {
                    dgvDetails.Rows.Add(
                        reader["AccountId"],
                        reader["AccountName"],
                        reader["Debit"],
                        reader["Credit"],
                        reader["Description"]);
                }

                UpdateTotals();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تحميل تفاصيل القيد:\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // حذف القيد
        // =========================
        private void btnDelete_Click(
            object? sender,
            EventArgs e)
        {
            if (selectedEntryId == 0)
            {
                MessageBox.Show(
                    "اختر قيداً للحذف.");

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "هل تريد حذف القيد المحدد؟",
                    "تأكيد الحذف",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            using SqlTransaction transaction =
                connection.BeginTransaction();

            try
            {
                string deleteDetails = @"
                    DELETE FROM JournalEntryDetails
                    WHERE JournalEntryId =
                        @JournalEntryId";

                using SqlCommand detailCommand =
                    new(
                        deleteDetails,
                        connection,
                        transaction);

                detailCommand.Parameters.AddWithValue(
                    "@JournalEntryId",
                    selectedEntryId);

                detailCommand.ExecuteNonQuery();

                string deleteHeader = @"
                    DELETE FROM JournalEntries
                    WHERE JournalEntryId =
                        @JournalEntryId";

                using SqlCommand headerCommand =
                    new(
                        deleteHeader,
                        connection,
                        transaction);

                headerCommand.Parameters.AddWithValue(
                    "@JournalEntryId",
                    selectedEntryId);

                headerCommand.ExecuteNonQuery();

                transaction.Commit();

                MessageBox.Show(
                    "تم حذف القيد بنجاح.",
                    "نجاح",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadEntries();
                ClearForm();
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                MessageBox.Show(
                    "حدث خطأ أثناء حذف القيد:\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}