using System.Data;
using AccountingSystemForWindowsFormLast.Data;
using Microsoft.Data.SqlClient;

namespace AccountingSystemForWindowsFormLast.Forms
{
    public partial class AccountsForm : Form
    {
        private int? selectedAccountId = null;

        public AccountsForm()
        {
            InitializeComponent();
            this.TopLevel = false;

            btnNew.Click += btnNew_Click;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;

            dgvAccounts.CellClick += dgvAccounts_CellClick;

            LoadAccounts();
            LoadAccountTree();
            LoadParentAccounts();

            ClearFields();
        }

        // =========================================
        // تحميل الحسابات في الجدول
        // =========================================

        private void LoadAccounts()
        {
            try
            {
                using SqlConnection con = DatabaseConnection.GetConnection();
                con.Open();

                string query = @"
                    SELECT 
                        AccountId,
                        AccountNumber,
                        AccountName,
                        AccountType,
                        ParentAccountId,
                        IsGroup,
                        IsSystem
                    FROM Accounts
                    ORDER BY AccountNumber";

                using SqlDataAdapter adapter = new(query, con);

                DataTable table = new();
                adapter.Fill(table);

                dgvAccounts.DataSource = table;

                if (dgvAccounts.Columns.Count == 0)
                    return;

                dgvAccounts.Columns["AccountId"].Visible = false;
                dgvAccounts.Columns["ParentAccountId"].Visible = false;
                dgvAccounts.Columns["IsGroup"].Visible = false;
                dgvAccounts.Columns["IsSystem"].Visible = false;

                dgvAccounts.Columns["AccountNumber"].HeaderText = "رقم الحساب";
                dgvAccounts.Columns["AccountName"].HeaderText = "اسم الحساب";
                dgvAccounts.Columns["AccountType"].HeaderText = "نوع الحساب";

                dgvAccounts.Columns["AccountNumber"].DisplayIndex = 0;
                dgvAccounts.Columns["AccountName"].DisplayIndex = 1;
                dgvAccounts.Columns["AccountType"].DisplayIndex = 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "خطأ في تحميل الحسابات",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================
        // تحميل شجرة الحسابات
        // =========================================

        private void LoadAccountTree()
        {
            try
            {
                treeAccounts.Nodes.Clear();

                using SqlConnection con = DatabaseConnection.GetConnection();
                con.Open();

                string query = @"
                    SELECT 
                        AccountId,
                        AccountNumber,
                        AccountName,
                        ParentAccountId
                    FROM Accounts
                    ORDER BY AccountNumber";

                using SqlCommand cmd = new(query, con);
                using SqlDataReader reader = cmd.ExecuteReader();

                List<AccountNode> accounts = new();

                while (reader.Read())
                {
                    accounts.Add(new AccountNode
                    {
                        Id = Convert.ToInt32(reader["AccountId"]),
                        Number = reader["AccountNumber"]?.ToString() ?? "",
                        Name = reader["AccountName"]?.ToString() ?? "",
                        ParentId = reader["ParentAccountId"] == DBNull.Value
                            ? null
                            : Convert.ToInt32(reader["ParentAccountId"])
                    });
                }

                foreach (AccountNode account in accounts.Where(x => x.ParentId == null))
                {
                    TreeNode node = new(
                        $"{account.Number} - {account.Name}");

                    node.Tag = account.Id;

                    AddChildNodes(
                        node,
                        account.Id,
                        accounts);

                    treeAccounts.Nodes.Add(node);
                }

                treeAccounts.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "خطأ في شجرة الحسابات",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void AddChildNodes(
            TreeNode parent,
            int parentId,
            List<AccountNode> accounts)
        {
            foreach (AccountNode account in accounts
                .Where(x => x.ParentId == parentId))
            {
                TreeNode node = new(
                    $"{account.Number} - {account.Name}");

                node.Tag = account.Id;

                AddChildNodes(
                    node,
                    account.Id,
                    accounts);

                parent.Nodes.Add(node);
            }
        }

        // =========================================
        // اختيار حساب من الشجرة
        // =========================================

        private void treeAccounts_AfterSelect(
            object sender,
            TreeViewEventArgs e)
        {
            if (e.Node?.Tag == null)
                return;

            if (!int.TryParse(e.Node.Tag.ToString(), out int accountId))
                return;

            LoadAccountDetails(accountId);
        }

        private void LoadAccountDetails(int accountId)
        {
            try
            {
                using SqlConnection con = DatabaseConnection.GetConnection();
                con.Open();

                string query = @"
                    SELECT
                        AccountId,
                        AccountNumber,
                        AccountName,
                        AccountType,
                        ParentAccountId,
                        IsGroup
                    FROM Accounts
                    WHERE AccountId = @Id";

                using SqlCommand cmd = new(query, con);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = accountId;

                using SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                    return;

                selectedAccountId = accountId;

                txtAccountNumber.Text =
                    reader["AccountNumber"]?.ToString() ?? "";

                txtAccountName.Text =
                    reader["AccountName"]?.ToString() ?? "";

                cmbAccountType.Text =
                    reader["AccountType"]?.ToString() ?? "";

                chkIsGroup.Checked =
                    Convert.ToBoolean(reader["IsGroup"]);

                if (reader["ParentAccountId"] == DBNull.Value)
                {
                    cmbParentAccount.SelectedIndex = -1;
                }
                else
                {
                    int parentId =
                        Convert.ToInt32(reader["ParentAccountId"]);

                    cmbParentAccount.SelectedValue = parentId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "خطأ في تحميل بيانات الحساب",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================
        // تحميل الحسابات التي يمكن أن تكون آباء
        // =========================================

        private void LoadParentAccounts()
        {
            try
            {
                using SqlConnection con = DatabaseConnection.GetConnection();
                con.Open();

                string query = @"
                    SELECT
                        AccountId,
                        AccountNumber,
                        AccountName
                    FROM Accounts
                    WHERE IsGroup = 1
                    ORDER BY AccountNumber";

                using SqlCommand cmd = new(query, con);
                using SqlDataReader reader = cmd.ExecuteReader();

                List<ParentAccountItem> items = new();

                while (reader.Read())
                {
                    items.Add(new ParentAccountItem
                    {
                        Id = Convert.ToInt32(reader["AccountId"]),
                        Text =
                            $"{reader["AccountNumber"]} - {reader["AccountName"]}"
                    });
                }

                cmbParentAccount.DisplayMember = "Text";
                cmbParentAccount.ValueMember = "Id";
                cmbParentAccount.DataSource = items;
                cmbParentAccount.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "خطأ في تحميل الحسابات الأب",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================
        // زر جديد
        // =========================================

        private void btnNew_Click(object? sender, EventArgs e)
        {
            ClearFields();
            txtAccountNumber.Focus();
        }

        // =========================================
        // إضافة حساب
        // =========================================

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateAccount())
                return;

            try
            {
                using SqlConnection con = DatabaseConnection.GetConnection();
                con.Open();

                string query = @"
                    INSERT INTO Accounts
                    (
                        AccountNumber,
                        AccountName,
                        AccountType,
                        ParentAccountId,
                        IsGroup,
                        IsSystem
                    )
                    VALUES
                    (
                        @Number,
                        @Name,
                        @Type,
                        @Parent,
                        @Group,
                        0
                    )";

                using SqlCommand cmd = new(query, con);

                cmd.Parameters.Add("@Number", SqlDbType.NVarChar)
                    .Value = txtAccountNumber.Text.Trim();

                cmd.Parameters.Add("@Name", SqlDbType.NVarChar)
                    .Value = txtAccountName.Text.Trim();

                cmd.Parameters.Add("@Type", SqlDbType.NVarChar)
                    .Value = cmbAccountType.Text.Trim();

                cmd.Parameters.Add("@Parent", SqlDbType.Int).Value =
                    cmbParentAccount.SelectedIndex == -1
                        ? DBNull.Value
                        : cmbParentAccount.SelectedValue;

                cmd.Parameters.Add("@Group", SqlDbType.Bit)
                    .Value = chkIsGroup.Checked;

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "تمت إضافة الحساب بنجاح",
                    "نجاح",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                RefreshAccounts();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "خطأ في إضافة الحساب",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================
        // تعديل الحساب
        // =========================================

        private void btnEdit_Click(object? sender, EventArgs e)
        {
            if (selectedAccountId == null)
            {
                MessageBox.Show("اختر حساباً أولاً");
                return;
            }

            if (!ValidateAccount())
                return;

            try
            {
                using SqlConnection con = DatabaseConnection.GetConnection();
                con.Open();

                string query = @"
                    UPDATE Accounts
                    SET
                        AccountNumber = @Number,
                        AccountName = @Name,
                        AccountType = @Type,
                        ParentAccountId = @Parent,
                        IsGroup = @Group
                    WHERE AccountId = @Id";

                using SqlCommand cmd = new(query, con);

                cmd.Parameters.Add("@Number", SqlDbType.NVarChar)
                    .Value = txtAccountNumber.Text.Trim();

                cmd.Parameters.Add("@Name", SqlDbType.NVarChar)
                    .Value = txtAccountName.Text.Trim();

                cmd.Parameters.Add("@Type", SqlDbType.NVarChar)
                    .Value = cmbAccountType.Text.Trim();

                cmd.Parameters.Add("@Parent", SqlDbType.Int).Value =
                    cmbParentAccount.SelectedIndex == -1
                        ? DBNull.Value
                        : cmbParentAccount.SelectedValue;

                cmd.Parameters.Add("@Group", SqlDbType.Bit)
                    .Value = chkIsGroup.Checked;

                cmd.Parameters.Add("@Id", SqlDbType.Int)
                    .Value = selectedAccountId.Value;

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "تم تعديل الحساب بنجاح",
                    "نجاح",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                RefreshAccounts();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "خطأ في تعديل الحساب",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================
        // حذف الحساب
        // =========================================

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (selectedAccountId == null)
            {
                MessageBox.Show("اختر حساباً أولاً");
                return;
            }

            DialogResult result = MessageBox.Show(
                "هل أنت متأكد من حذف الحساب المحدد؟",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using SqlConnection con = DatabaseConnection.GetConnection();
                con.Open();

                string query = @"
                    DELETE FROM Accounts
                    WHERE AccountId = @Id";

                using SqlCommand cmd = new(query, con);

                cmd.Parameters.Add("@Id", SqlDbType.Int)
                    .Value = selectedAccountId.Value;

                cmd.ExecuteNonQuery();

                MessageBox.Show("تم حذف الحساب بنجاح");

                RefreshAccounts();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "تعذر حذف الحساب.\n\n" + ex.Message,
                    "خطأ في الحذف",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================
        // اختيار حساب من الجدول
        // =========================================

        private void dgvAccounts_CellClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            object value =
                dgvAccounts.Rows[e.RowIndex]
                .Cells["AccountId"]
                .Value;

            if (value == null || value == DBNull.Value)
                return;

            if (int.TryParse(value.ToString(), out int accountId))
            {
                LoadAccountDetails(accountId);
            }
        }

        // =========================================
        // التحقق من بيانات الحساب
        // =========================================

        private bool ValidateAccount()
        {
            if (string.IsNullOrWhiteSpace(txtAccountNumber.Text))
            {
                MessageBox.Show("أدخل رقم الحساب");
                txtAccountNumber.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAccountName.Text))
            {
                MessageBox.Show("أدخل اسم الحساب");
                txtAccountName.Focus();
                return false;
            }

            if (cmbAccountType.SelectedIndex == -1)
            {
                MessageBox.Show("اختر نوع الحساب");
                cmbAccountType.Focus();
                return false;
            }

            // منع الحساب من أن يكون أباً لنفسه
            if (selectedAccountId != null &&
                cmbParentAccount.SelectedValue != null &&
                cmbParentAccount.SelectedValue != DBNull.Value)
            {
                if (int.TryParse(
                    cmbParentAccount.SelectedValue.ToString(),
                    out int parentId))
                {
                    if (parentId == selectedAccountId.Value)
                    {
                        MessageBox.Show(
                            "لا يمكن أن يكون الحساب أباً لنفسه.");

                        return false;
                    }
                }
            }

            return true;
        }

        // =========================================
        // إعادة تحميل البيانات
        // =========================================

        private void RefreshAccounts()
        {
            LoadAccounts();
            LoadAccountTree();
            LoadParentAccounts();
        }

        // =========================================
        // تنظيف الحقول
        // =========================================

        private void ClearFields()
        {
            selectedAccountId = null;

            txtAccountNumber.Clear();
            txtAccountName.Clear();

            cmbAccountType.SelectedIndex = -1;
            cmbParentAccount.SelectedIndex = -1;

            chkIsGroup.Checked = false;

            dgvAccounts.ClearSelection();
            treeAccounts.SelectedNode = null;
        }

        // =========================================
        // بيانات الشجرة
        // =========================================

        private class AccountNode
        {
            public int Id { get; set; }

            public string Number { get; set; } = "";

            public string Name { get; set; } = "";

            public int? ParentId { get; set; }
        }

        // =========================================
        // بيانات الحساب الأب
        // =========================================

        private class ParentAccountItem
        {
            public int Id { get; set; }

            public string Text { get; set; } = "";

            public override string ToString()
            {
                return Text;
            }
        }
    }
}