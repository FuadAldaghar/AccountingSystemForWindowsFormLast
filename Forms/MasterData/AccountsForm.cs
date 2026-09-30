using System.Data;
using AccountingSystemForWindowsFormLast.Data;
using Microsoft.Data.SqlClient;

namespace AccountingSystemForWindowsFormLast.Forms
{
    public partial class AccountsForm : Form
    {
        private int? selectedAccountId = null;
        private bool isLoadingAccount = false;

        public AccountsForm()
        {
            InitializeComponent();

            TopLevel = false;

            btnNew.Click += btnNew_Click;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;

            dgvAccounts.CellClick += dgvAccounts_CellClick;
            cmbParentAccount.SelectedIndexChanged += cmbParentAccount_SelectedIndexChanged;
            cmbAccountType.SelectedIndexChanged += cmbAccountType_SelectedIndexChanged;

            LoadAccounts();
            LoadAccountTree();
            LoadParentAccounts();

            ClearFields();
        }

        // =========================================
        // الحسابات - الجدول
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
                        AccountNature,
                        ParentAccountId,
                        IsGroup,
                        IsSystem
                    FROM Accounts
                    ORDER BY
                        LEN(AccountNumber),
                        AccountNumber";

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
                dgvAccounts.Columns["AccountNature"].HeaderText = "طبيعة الحساب";

                dgvAccounts.Columns["AccountNumber"].DisplayIndex = 0;
                dgvAccounts.Columns["AccountName"].DisplayIndex = 1;
                dgvAccounts.Columns["AccountType"].DisplayIndex = 2;
                dgvAccounts.Columns["AccountNature"].DisplayIndex = 3;
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
        // شجرة الحسابات
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
                    ORDER BY LEN(AccountNumber), AccountNumber";

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
                {//دمج نص الرقم مع الاسم
                    TreeNode node = new($"{account.Number} - {account.Name}")
                    {
                        Tag = account.Id
                    };
                    //بناء الفروع الابناء
                    AddChildNodes(node, account.Id, accounts);
                    treeAccounts.Nodes.Add(node);
                }
                //فتح فروع الشجره
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
        //دالة لاضافة الابناء في الشجرة وتستخدم الاستدعاء الذاتي
        private void AddChildNodes( TreeNode parent,int parentId, List<AccountNode> accounts)
        {
            foreach (AccountNode account in accounts.Where(x => x.ParentId == parentId))
            {
                TreeNode node = new($"{account.Number} - {account.Name}")
                {
                    Tag = account.Id
                };
                //استدعاء ذاتي
                AddChildNodes(node, account.Id, accounts);
                parent.Nodes.Add(node);
            }
        }
        //بعد الضغط على عنصر في الشجره
        private void treeAccounts_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag == null)
                return;

            if (!int.TryParse(e.Node.Tag.ToString(), out int accountId))
                return;

            LoadAccountDetails(accountId);
        }

      //تحميل تفاصيل الحساب الى الحقول وصناديق الاختيار وضبطها
        private void LoadAccountDetails(int accountId)
        {
            try
            {
                isLoadingAccount = true;

                using SqlConnection con = DatabaseConnection.GetConnection();
                con.Open();

                string query = @"
                    SELECT
                        AccountId,
                        AccountNumber,
                        AccountName,
                        AccountType,
                        AccountNature,
                        ParentAccountId,
                        IsGroup,
                        IsSystem
                    FROM Accounts
                    WHERE AccountId = @Id";

                using SqlCommand cmd = new(query, con);
                //اعطاء قيمة للمتغير idالموجود في الاستعلام السابق
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

                txtAccountNature.Text =
                    reader["AccountNature"] == DBNull.Value
                        ? GetNatureByAccountType(cmbAccountType.Text)
                        : reader["AccountNature"].ToString() ?? "";

                chkIsGroup.Checked =
                    Convert.ToBoolean(reader["IsGroup"]);
                //ضبط صندوق اختيار الاب للحساب
                if (reader["ParentAccountId"] == DBNull.Value)
                {
                    cmbParentAccount.SelectedIndex = -1;
                    cmbParentAccount.Enabled = false;
                    cmbAccountType.Enabled = true;
                }
                else
                {
                    int parentId = Convert.ToInt32(reader["ParentAccountId"]);
                    cmbParentAccount.SelectedValue = parentId;

                    cmbParentAccount.Enabled = false;
                    cmbAccountType.Enabled = false;
                }

                txtAccountNumber.ReadOnly = true;
                txtAccountNature.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "خطأ في تحميل بيانات الحساب",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                isLoadingAccount = false;
            }
        }

        // =========================================
        // الحسابات التي يمكن أن تكون آباء
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
                    ORDER BY LEN(AccountNumber), AccountNumber";

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
        // تغيير الأب
        // =========================================

        private void cmbParentAccount_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (isLoadingAccount)
                return;

            if (selectedAccountId != null)
                return;
            //يعني هذي الداله تطبق في حين  تكون العمليه اضافه او تعديل
            ApplyParentRules();
        }
        //تطبيق الواعد في حال تم اختيار الحساب الاب

        private void ApplyParentRules()
        {
            if (cmbParentAccount.SelectedIndex == -1)
            {
                cmbAccountType.Enabled = true;
                txtAccountNature.Text =
                    GetNatureByAccountType(cmbAccountType.Text);

                GenerateAndShowAccountNumber(null);
                return;
            }

            if (!int.TryParse(
                    cmbParentAccount.SelectedValue?.ToString(),
                    out int parentId))
                return;

            string parentType = "";
            string parentNature = "";

            try
            {
                using SqlConnection con = DatabaseConnection.GetConnection();
                con.Open();

                string query = @"
                    SELECT AccountType, AccountNature
                    FROM Accounts
                    WHERE AccountId = @Id";

                using SqlCommand cmd = new(query, con);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = parentId;

                using SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                    return;

                parentType = reader["AccountType"]?.ToString() ?? "";
                parentNature = reader["AccountNature"]?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(parentNature))
                    parentNature = GetNatureByAccountType(parentType);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "خطأ في قراءة بيانات الحساب الأب",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            cmbAccountType.Text = parentType;
            cmbAccountType.Enabled = false;

            txtAccountNature.Text = parentNature;

            GenerateAndShowAccountNumber(parentId);
        }

        private void cmbAccountType_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (isLoadingAccount)
                return;

            if (cmbParentAccount.SelectedIndex != -1)
                return;

            txtAccountNature.Text =
                GetNatureByAccountType(cmbAccountType.Text);

            if (selectedAccountId == null)
                GenerateAndShowAccountNumber(null);
        }

   
        //عرض رقم الحساب تلقائيا
        private void GenerateAndShowAccountNumber(int? parentId)
        {
            try
            {
                using SqlConnection con = DatabaseConnection.GetConnection();
                con.Open();

                txtAccountNumber.Text =
                    GenerateAccountNumber(con, parentId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "خطأ في توليد رقم الحساب",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        //توليد رقم الحساب
        private string GenerateAccountNumber(SqlConnection con, int? parentId, int? excludeAccountId = null)

        {
            string prefix = "";

            if (parentId.HasValue)
            {
                string parentQuery = @"
                    SELECT AccountNumber
                    FROM Accounts
                    WHERE AccountId = @ParentId";

                using SqlCommand parentCmd = new(parentQuery, con);
                parentCmd.Parameters.Add("@ParentId", SqlDbType.Int)
                    .Value = parentId.Value;

                prefix = parentCmd.ExecuteScalar()?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(prefix))
                    throw new InvalidOperationException(
                        "تعذر قراءة رقم الحساب الأب.");
            }

            string query;

            if (parentId.HasValue)
            {
                query = @"
                    SELECT AccountNumber
                    FROM Accounts
                    WHERE ParentAccountId = @ParentId
                      AND LEN(AccountNumber) = LEN(@Prefix) + 1";

            }
            else
            {
                query = @"
                    SELECT AccountNumber
                    FROM Accounts
                    WHERE ParentAccountId IS NULL";
            }

            using SqlCommand cmd = new(query, con);

            if (parentId.HasValue)
            {
                cmd.Parameters.Add("@ParentId", SqlDbType.Int)
                    .Value = parentId.Value;

                cmd.Parameters.Add("@Prefix", SqlDbType.NVarChar, 50)
                    .Value = prefix;
            }

            List<int> usedNumbers = new();

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string number = reader["AccountNumber"]?.ToString() ?? "";

                if (parentId.HasValue)
                {
                    if (!number.StartsWith(prefix))
                        continue;

                    string suffix = number[prefix.Length..];

                    if (int.TryParse(suffix, out int value))
                        usedNumbers.Add(value);
                }
                else
                {
                    if (int.TryParse(number, out int value))
                        usedNumbers.Add(value);
                }
            }

            int next = usedNumbers.Count == 0
                ? 1
                : usedNumbers.Max() + 1;

            if (parentId.HasValue)
            {
                if (next > 9)
                    throw new InvalidOperationException(
                        "تم الوصول إلى الحد الأقصى للحسابات المباشرة تحت هذا الأب.");

                return prefix + next;
            }

            return next.ToString();
        }

        //توليد طبيعة الحساب بناءً على نوع الحساب
        private string GetNatureByAccountType(string accountType)
        {
            return accountType switch
            {
                "أصل" => "مدين",
                "مصروف" => "مدين",
                "خصم" => "دائن",
                "حقوق ملكية" => "دائن",
                "إيراد" => "دائن",
                _ => ""
            };
        }

        //زر جديد لإضافة حساب جديد

        private void btnNew_Click(object? sender, EventArgs e)
        {
            ClearFields();

            cmbParentAccount.Enabled = true;
            cmbAccountType.Enabled = true;
            txtAccountNumber.ReadOnly = true;
            txtAccountNature.ReadOnly = true;

            GenerateAndShowAccountNumber(null);

            txtAccountName.Focus();
        }

        //زر إضافة الحساب الجديد
        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateAccount())
                return;

            try
            {
                using SqlConnection con = DatabaseConnection.GetConnection();
                con.Open();

                int? parentId =
                    cmbParentAccount.SelectedIndex == -1
                        ? null
                        : Convert.ToInt32(cmbParentAccount.SelectedValue);

                string accountNumber =
                    GenerateAccountNumber(con, parentId);

                string accountType = cmbAccountType.Text.Trim();

                if (parentId.HasValue)
                {
                    accountType = GetParentAccountType(con, parentId.Value);

                    if (string.IsNullOrWhiteSpace(accountType))
                    {
                        MessageBox.Show("تعذر تحديد نوع الحساب الأب.");
                        return;
                    }
                }

                string accountNature =
                    GetNatureByAccountType(accountType);

                if (string.IsNullOrWhiteSpace(accountNature))
                {
                    MessageBox.Show("تعذر تحديد طبيعة الحساب.");
                    return;
                }

                string query = @"
                    INSERT INTO Accounts
                    (
                        AccountNumber,
                        AccountName,
                        AccountType,
                        AccountNature,
                        ParentAccountId,
                        IsGroup,
                        IsSystem
                    )
                    VALUES
                    (
                        @Number,
                        @Name,
                        @Type,
                        @Nature,
                        @Parent,
                        @Group,
                        0
                    )";

                using SqlCommand cmd = new(query, con);

                cmd.Parameters.Add("@Number", SqlDbType.NVarChar, 50)
                    .Value = accountNumber;

                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 200)
                    .Value = txtAccountName.Text.Trim();

                cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50)
                    .Value = accountType;

                cmd.Parameters.Add("@Nature", SqlDbType.NVarChar, 10)
                    .Value = accountNature;

                cmd.Parameters.Add("@Parent", SqlDbType.Int).Value =
                    parentId.HasValue
                        ? parentId.Value
                        : DBNull.Value;

                cmd.Parameters.Add("@Group", SqlDbType.Bit)
                    .Value = chkIsGroup.Checked;

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    $"تمت إضافة الحساب بنجاح\nرقم الحساب: {accountNumber}",
                    "نجاح",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                RefreshAccounts();
                ClearFields();
            }
            catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
            {
                MessageBox.Show(
                    "رقم الحساب موجود مسبقًا. أعد المحاولة.",
                    "رقم حساب مكرر",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
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
                MessageBox.Show("اختر حسابًا أولاً.");
                return;
            }

            if (!ValidateAccount())
                return;

            try
            {
                using SqlConnection con = DatabaseConnection.GetConnection();
                con.Open();

                string accountType = cmbAccountType.Text.Trim();
                string accountNature = GetNatureByAccountType(accountType);

                if (string.IsNullOrWhiteSpace(accountNature))
                {
                    MessageBox.Show("تعذر تحديد طبيعة الحساب.");
                    return;
                }

                string query = @"
                    UPDATE Accounts
                    SET
                        AccountName = @Name,
                        AccountType = @Type,
                        AccountNature = @Nature,
                        IsGroup = @Group
                    WHERE AccountId = @Id";

                using SqlCommand cmd = new(query, con);

                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 200)
                    .Value = txtAccountName.Text.Trim();

                cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50)
                    .Value = accountType;

                cmd.Parameters.Add("@Nature", SqlDbType.NVarChar, 10)
                    .Value = accountNature;

                cmd.Parameters.Add("@Group", SqlDbType.Bit)
                    .Value = chkIsGroup.Checked;

                cmd.Parameters.Add("@Id", SqlDbType.Int)
                    .Value = selectedAccountId.Value;

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "تم تعديل الحساب بنجاح.",
                    "نجاح",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                RefreshAccounts();

                int editedId = selectedAccountId.Value;
                LoadAccountDetails(editedId);
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
                MessageBox.Show("اختر حسابًا أولاً.");
                return;
            }

            try
            {
                using SqlConnection con = DatabaseConnection.GetConnection();
                con.Open();

                if (IsSystemAccount(con, selectedAccountId.Value))
                {
                    MessageBox.Show(
                        "لا يمكن حذف حساب نظام.",
                        "منع الحذف",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (HasChildren(con, selectedAccountId.Value))
                {
                    MessageBox.Show(
                        "لا يمكن حذف الحساب لأنه يحتوي على حسابات فرعية.\nاحذف الحسابات الفرعية أولاً.",
                        "منع الحذف",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (IsAccountUsed(con, selectedAccountId.Value))
                {
                    MessageBox.Show(
                        "لا يمكن حذف الحساب لأنه مستخدم في عمليات محاسبية.",
                        "منع الحذف",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DialogResult result = MessageBox.Show(
                    "هل أنت متأكد من حذف الحساب المحدد؟",
                    "تأكيد الحذف",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;

                string query = @"
                    DELETE FROM Accounts
                    WHERE AccountId = @Id";

                using SqlCommand cmd = new(query, con);
                cmd.Parameters.Add("@Id", SqlDbType.Int)
                    .Value = selectedAccountId.Value;

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "تم حذف الحساب بنجاح.",
                    "نجاح",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

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

        private bool IsSystemAccount(SqlConnection con, int accountId)
        {
            string query = @"
                SELECT COUNT(*)
                FROM Accounts
                WHERE AccountId = @Id
                  AND IsSystem = 1";

            using SqlCommand cmd = new(query, con);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = accountId;

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }
        //هل الحساب يحتوي على حسابات فرعية
        private bool HasChildren(SqlConnection con, int accountId)
        {
            string query = @"
                SELECT COUNT(*)
                FROM Accounts
                WHERE ParentAccountId = @Id";

            using SqlCommand cmd = new(query, con);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = accountId;

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        private bool IsAccountUsed(SqlConnection con, int accountId)
        {
            string query = @"
                SELECT
                    (
                        SELECT COUNT(*)
                        FROM JournalEntryDetails
                        WHERE AccountId = @Id
                    )
                    +
                    (
                        SELECT COUNT(*)
                        FROM PurchaseInvoices
                        WHERE AccountId = @Id
                    )
                    +
                    (
                        SELECT COUNT(*)
                        FROM SalesInvoices
                        WHERE AccountId = @Id
                    )
                    +
                    (
                        SELECT COUNT(*)
                        FROM PaymentVouchers
                        WHERE AccountId = @Id
                    )
                    +
                    (
                        SELECT COUNT(*)
                        FROM ReceiptVouchers
                        WHERE AccountId = @Id
                    )
                    +
                    (
                        SELECT COUNT(*)
                        FROM AccountTransactions
                        WHERE AccountId = @Id
                    )";

            using SqlCommand cmd = new(query, con);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = accountId;

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        // =========================================
        // اختيار من الجدول
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
                LoadAccountDetails(accountId);
        }

        // =========================================
        // التحقق
        // =========================================

        private bool ValidateAccount()
        {
            if (string.IsNullOrWhiteSpace(txtAccountName.Text))
            {
                MessageBox.Show(
                    "أدخل اسم الحساب.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtAccountName.Focus();
                return false;
            }

            if (cmbParentAccount.SelectedIndex == -1 &&
                cmbAccountType.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "اختر نوع الحساب الرئيسي.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbAccountType.Focus();
                return false;
            }

            if (selectedAccountId != null &&
                cmbParentAccount.SelectedValue != null &&
                cmbParentAccount.SelectedValue != DBNull.Value &&
                int.TryParse(
                    cmbParentAccount.SelectedValue.ToString(),
                    out int parentId) &&
                parentId == selectedAccountId.Value)
            {
                MessageBox.Show(
                    "لا يمكن أن يكون الحساب أبًا لنفسه.",
                    "بيانات غير صحيحة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (selectedAccountId != null &&
                HasChildrenForValidation(selectedAccountId.Value) &&
                !chkIsGroup.Checked)
            {
                MessageBox.Show(
                    "لا يمكن تحويل حساب يحتوي على حسابات فرعية إلى حساب عادي.",
                    "بيانات غير صحيحة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                chkIsGroup.Checked = true;
                return false;
            }

            return true;
        }

        private bool HasChildrenForValidation(int accountId)
        {
            try
            {
                using SqlConnection con = DatabaseConnection.GetConnection();
                con.Open();

                return HasChildren(con, accountId);
            }
            catch
            {
                return false;
            }
        }

        private string GetParentAccountType(SqlConnection con, int parentId)
        {
            string query = @"
                SELECT AccountType
                FROM Accounts
                WHERE AccountId = @Id";

            using SqlCommand cmd = new(query, con);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = parentId;

            return cmd.ExecuteScalar()?.ToString() ?? "";
        }

        // =========================================
        // تحديث البيانات
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
            isLoadingAccount = true;

            selectedAccountId = null;

            txtAccountNumber.Clear();
            txtAccountName.Clear();
            txtAccountNature.Clear();

            cmbAccountType.SelectedIndex = -1;
            cmbParentAccount.SelectedIndex = -1;

            cmbParentAccount.Enabled = true;
            cmbAccountType.Enabled = true;

            txtAccountNumber.ReadOnly = true;
            txtAccountNature.ReadOnly = true;

            chkIsGroup.Checked = false;
            chkIsGroup.Enabled = true;

            dgvAccounts.ClearSelection();
            treeAccounts.SelectedNode = null;

            isLoadingAccount = false;
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

        private class ParentAccountItem
        {
            public int Id { get; set; }
            public string Text { get; set; } = "";

            public override string ToString()
            {
                return Text;
            }
        }

        private void AccountsForm_Load(object sender, EventArgs e)
        {
            if (selectedAccountId == null)
                GenerateAndShowAccountNumber(null);
        }
    }
}
