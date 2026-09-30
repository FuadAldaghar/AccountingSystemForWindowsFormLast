using System.Data;
using Microsoft.Data.SqlClient;
using AccountingSystemForWindowsFormLast.Data;

namespace AccountingSystemForWindowsFormLast.Forms
{
    public partial class ItemsForm : Form
    {
        private int selectedItemId = 0;

        public ItemsForm()
        {
            InitializeComponent();

            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;

            txtItemNumber.ReadOnly = true;

            dgvItems.CellClick += dgvItems_CellClick;

            txtItemName.TextChanged += InputFields_TextChanged;
            cmbUnit.SelectedIndexChanged += InputFields_TextChanged;

            UpdateButtonsState();
        }

        private void ItemsForm_Load(object sender, EventArgs e)
        {
            LoadItems();
            GenerateItemNumber();
            UpdateButtonsState();
        }

        // =========================
        // تحميل الأصناف
        // =========================
        private void LoadItems()
        {
            try
            {
                using SqlConnection connection = DatabaseConnection.GetConnection();

                string query = @"
                    SELECT 
                        ItemId,
                        ItemNumber,
                        ItemName,
                        Unit
                    FROM Items
                    ORDER BY ItemId DESC";

                using SqlCommand command = new SqlCommand(query, connection);

                DataTable table = new DataTable();

                connection.Open();

                using SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);

                dgvItems.DataSource = table;

                //BeginInvoke(new Action(() =>
                //{
                //    dgvItems.ClearSelection();
                //   // dgvItems.CurrentCell = null;
                //}));

                if (dgvItems.Columns["ItemId"] != null)
                    dgvItems.Columns["ItemId"].Visible = false;

                if (dgvItems.Columns["ItemNumber"] != null)
                {
                    dgvItems.Columns["ItemNumber"].HeaderText = "رقم الصنف";
                    dgvItems.Columns["ItemNumber"].Width = 150;
                }

                if (dgvItems.Columns["ItemName"] != null)
                {
                    dgvItems.Columns["ItemName"].HeaderText = "اسم الصنف";
                    dgvItems.Columns["ItemName"].Width = 400;
                }

                if (dgvItems.Columns["Unit"] != null)
                {
                    dgvItems.Columns["Unit"].HeaderText = "الوحدة";
                    dgvItems.Columns["Unit"].Width = 200;
                }

              dgvItems.ClearSelection();
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

        // =========================
        // توليد رقم الصنف تلقائياً
        // =========================
        private void GenerateItemNumber()
        {
            try
            {
                using SqlConnection connection = DatabaseConnection.GetConnection();

                string query = @"
                    SELECT ISNULL(MAX(TRY_CAST(ItemNumber AS INT)), 0) + 1
                    FROM Items";

                using SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                object result = command.ExecuteScalar();

                int nextNumber = Convert.ToInt32(result);

                txtItemNumber.Text = nextNumber.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء توليد رقم الصنف:\n" + ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // مراقبة الحقول
        // =========================
        private void InputFields_TextChanged(object? sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        // =========================
        // التحكم في حالة الأزرار
        // =========================
        private void UpdateButtonsState()
        {
            bool fieldsFilled =
                !string.IsNullOrWhiteSpace(txtItemName.Text) &&
                cmbUnit.SelectedIndex >= 0 &&
                !string.IsNullOrWhiteSpace(cmbUnit.Text);

            bool itemSelected = selectedItemId > 0;

            // الإضافة تحتاج تعبئة الحقول
            btnAdd.Enabled = fieldsFilled && !itemSelected;

            // التعديل والحذف يحتاجان تحديد سجل
            btnEdit.Enabled = itemSelected;
            btnDelete.Enabled = itemSelected;
        }

        // =========================
        // تحديد صنف من الجدول
        // =========================
        private void dgvItems_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvItems.Rows[e.RowIndex];

            if (row.Cells["ItemId"].Value == null)
                return;

            selectedItemId = Convert.ToInt32(row.Cells["ItemId"].Value);

            txtItemNumber.Text =
                row.Cells["ItemNumber"].Value?.ToString() ?? "";

            txtItemName.Text =
                row.Cells["ItemName"].Value?.ToString() ?? "";

            string unit =
                row.Cells["Unit"].Value?.ToString() ?? "";

            if (cmbUnit.Items.Contains(unit))
                cmbUnit.SelectedItem = unit;
            else
                cmbUnit.Text = unit;

            UpdateButtonsState();
        }

        // =========================
        // إضافة
        // =========================
        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageBox.Show(
                    "يرجى إدخال اسم الصنف.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtItemName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbUnit.Text))
            {
                MessageBox.Show(
                    "يرجى اختيار الوحدة.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbUnit.Focus();
                return;
            }

            try
            {
                using SqlConnection connection = DatabaseConnection.GetConnection();

                string query = @"
                    INSERT INTO Items
                    (
                        ItemNumber,
                        ItemName,
                        Unit
                    )
                    VALUES
                    (
                        @ItemNumber,
                        @ItemName,
                        @Unit
                    )";

                using SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue(
                    "@ItemNumber",
                    txtItemNumber.Text.Trim());

                command.Parameters.AddWithValue(
                    "@ItemName",
                    txtItemName.Text.Trim());

                command.Parameters.AddWithValue(
                    "@Unit",
                    cmbUnit.Text.Trim());

                connection.Open();
                command.ExecuteNonQuery();

                MessageBox.Show(
                    "تمت إضافة الصنف بنجاح.",
                    "نجاح",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearFields();
                LoadItems();
                GenerateItemNumber();
                UpdateButtonsState();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء إضافة الصنف:\n" + ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // تعديل
        // =========================
        private void btnEdit_Click(object? sender, EventArgs e)
        {
            if (selectedItemId <= 0)
                return;

            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageBox.Show(
                    "يرجى إدخال اسم الصنف.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtItemName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbUnit.Text))
            {
                MessageBox.Show(
                    "يرجى اختيار الوحدة.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbUnit.Focus();
                return;
            }

            try
            {
                using SqlConnection connection = DatabaseConnection.GetConnection();

                string query = @"
                    UPDATE Items
                    SET
                        ItemName = @ItemName,
                        Unit = @Unit
                    WHERE ItemId = @ItemId";

                using SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue(
                    "@ItemName",
                    txtItemName.Text.Trim());

                command.Parameters.AddWithValue(
                    "@Unit",
                    cmbUnit.Text.Trim());

                command.Parameters.AddWithValue(
                    "@ItemId",
                    selectedItemId);

                connection.Open();
                command.ExecuteNonQuery();

                MessageBox.Show(
                    "تم تعديل الصنف بنجاح.",
                    "نجاح",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearFields();
                LoadItems();
                GenerateItemNumber();
                UpdateButtonsState();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تعديل الصنف:\n" + ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // حذف
        // =========================
        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (selectedItemId <= 0)
                return;

            DialogResult result = MessageBox.Show(
                "هل أنت متأكد من حذف هذا الصنف؟",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using SqlConnection connection = DatabaseConnection.GetConnection();

                connection.Open();

                // التأكد أن الصنف غير مستخدم في فواتير المشتريات
                string purchaseCheck = @"
                    SELECT COUNT(*)
                    FROM PurchaseInvoiceDetails
                    WHERE ItemId = @ItemId";

                using SqlCommand purchaseCommand =
                    new SqlCommand(purchaseCheck, connection);

                purchaseCommand.Parameters.AddWithValue(
                    "@ItemId",
                    selectedItemId);

                int purchaseCount =
                    Convert.ToInt32(purchaseCommand.ExecuteScalar());

                if (purchaseCount > 0)
                {
                    MessageBox.Show(
                        "لا يمكن حذف الصنف لأنه مستخدم في فواتير المشتريات.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // التأكد أن الصنف غير مستخدم في فواتير المبيعات
                string salesCheck = @"
                    SELECT COUNT(*)
                    FROM SalesInvoiceDetails
                    WHERE ItemId = @ItemId";

                using SqlCommand salesCommand =
                    new SqlCommand(salesCheck, connection);

                salesCommand.Parameters.AddWithValue(
                    "@ItemId",
                    selectedItemId);

                int salesCount =
                    Convert.ToInt32(salesCommand.ExecuteScalar());

                if (salesCount > 0)
                {
                    MessageBox.Show(
                        "لا يمكن حذف الصنف لأنه مستخدم في فواتير المبيعات.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // الحذف
                string deleteQuery = @"
                    DELETE FROM Items
                    WHERE ItemId = @ItemId";

                using SqlCommand deleteCommand =
                    new SqlCommand(deleteQuery, connection);

                deleteCommand.Parameters.AddWithValue(
                    "@ItemId",
                    selectedItemId);

                deleteCommand.ExecuteNonQuery();

                MessageBox.Show(
                    "تم حذف الصنف بنجاح.",
                    "نجاح",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearFields();
                LoadItems();
                GenerateItemNumber();
                UpdateButtonsState();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء حذف الصنف:\n" + ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // تفريغ الحقول
        // =========================
        private void ClearFields()
        {
            selectedItemId = 0;

            txtItemName.Clear();
            cmbUnit.SelectedIndex = -1;
            cmbUnit.Text = "";

            dgvItems.ClearSelection();

            txtItemNumber.ReadOnly = true;
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}