
using System.Data;
using AccountingSystemForWindowsFormLast.Helpers;
using AccountingSystemForWindowsFormLast.Models;
using AccountingSystemForWindowsFormLast.Services;
namespace AccountingSystemForWindowsFormLast.Forms
{
    public partial class AccountsForm : Form
    {
        private readonly AccountService _accountService;
        private int? selectedAccountId = null;
        private bool isLoadingAccount = false;

        public AccountsForm()
        {
           
            InitializeComponent();
            _accountService = new AccountService();
            UiTheme.Apply(this);
            UiTheme.StyleButton(btnAdd, Accent.Primary);
            UiTheme.StyleButton(btnEdit, Accent.Warning);
            UiTheme.StyleButton(btnDelete, Accent.Danger);
            UiTheme.StyleButton(btnNew, Accent.Neutral);

            LoadAccounts();
            LoadAccountTree();
            LoadParentAccounts();

            ClearFields();
        }

        private void AccountsForm_Load(object sender, EventArgs e)
        {
          

          
            TopLevel = false;

            btnNew.Click += btnNew_Click;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;

            dgvAccounts.CellClick += dgvAccounts_CellClick;
            cmbParentAccount.SelectedIndexChanged += cmbParentAccount_SelectedIndexChanged;
            cmbAccountType.SelectedIndexChanged += cmbAccountType_SelectedIndexChanged;

        
            // Initial load completed in constructor
        }

        // =========================================
        // الحسابات - الجدول
        // =========================================
        private void LoadAccounts()
        {
            try
            {
                DataTable table = _accountService.GetDataTable();
                dgvAccounts.DataSource = table;

                if (dgvAccounts.Columns.Count == 0)
                    return;

                if (dgvAccounts.Columns["AccountId"] != null) dgvAccounts.Columns["AccountId"].Visible = false;
                if (dgvAccounts.Columns["ParentAccountId"] != null) dgvAccounts.Columns["ParentAccountId"].Visible = false;
                if (dgvAccounts.Columns["IsGroup"] != null) dgvAccounts.Columns["IsGroup"].Visible = false;
                if (dgvAccounts.Columns["IsSystem"] != null) dgvAccounts.Columns["IsSystem"].Visible = false;

                if (dgvAccounts.Columns["AccountNumber"] != null)
                {
                    dgvAccounts.Columns["AccountNumber"].HeaderText = "رقم الحساب";
                    dgvAccounts.Columns["AccountNumber"].DisplayIndex = 0;
                }

                if (dgvAccounts.Columns["AccountName"] != null)
                {
                    dgvAccounts.Columns["AccountName"].HeaderText = "اسم الحساب";
                    dgvAccounts.Columns["AccountName"].DisplayIndex = 1;
                }

                if (dgvAccounts.Columns["AccountType"] != null)
                {
                    dgvAccounts.Columns["AccountType"].HeaderText = "نوع الحساب";
                    dgvAccounts.Columns["AccountType"].DisplayIndex = 2;
                }

                if (dgvAccounts.Columns["AccountNature"] != null)
                {
                    dgvAccounts.Columns["AccountNature"].HeaderText = "طبيعة الحساب";
                    dgvAccounts.Columns["AccountNature"].DisplayIndex = 3;
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"خطأ في تحميل الحسابات:\n{ex.Message}", "خطأ");
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
                List<Account> accounts = _accountService.GetAll();

                var rootAccounts = accounts
                    .Where(a => a.ParentAccountId == null || a.ParentAccountId == 0)
                    .OrderBy(a => a.AccountNumber.Length)
                    .ThenBy(a => a.AccountNumber);

                foreach (var acc in rootAccounts)
                {
                    TreeNode rootNode = new TreeNode($"{acc.AccountNumber} - {acc.AccountName}")
                    {
                        Tag = acc.AccountId
                    };

                    AddChildNodes(rootNode, acc.AccountId, accounts);
                    treeAccounts.Nodes.Add(rootNode);
                }

                treeAccounts.CollapseAll();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"خطأ في تحميل شجرة الحسابات:\n{ex.Message}", "خطأ");
            }
        }

        private void AddChildNodes(TreeNode parentNode, int parentId, List<Account> accounts)
        {
            var children = accounts
                .Where(a => a.ParentAccountId == parentId)
                .OrderBy(a => a.AccountNumber.Length)
                .ThenBy(a => a.AccountNumber);

            foreach (var child in children)
            {
                TreeNode childNode = new TreeNode($"{child.AccountNumber} - {child.AccountName}")
                {
                    Tag = child.AccountId
                };

                AddChildNodes(childNode, child.AccountId, accounts);
                parentNode.Nodes.Add(childNode);
            }
        }

        private void treeAccounts_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null || e.Node.Tag == null)
                return;

            if (!int.TryParse(e.Node.Tag.ToString(), out int accountId))
                return;

            LoadAccountDetails(accountId);
        }

        private void LoadAccountDetails(int accountId)
        {
            try
            {
                isLoadingAccount = true;
                Account? acc = _accountService.GetById(accountId);

                if (acc == null)
                    return;

                selectedAccountId = acc.AccountId;
                txtAccountNumber.Text = acc.AccountNumber;
                txtAccountName.Text = acc.AccountName;
                cmbAccountType.Text = acc.AccountType;
                txtAccountNature.Text = string.IsNullOrWhiteSpace(acc.AccountNature)
                    ? _accountService.GetNatureByAccountType(acc.AccountType)
                    : acc.AccountNature;

                chkIsGroup.Checked = acc.IsGroup;

                if (acc.ParentAccountId.HasValue)
                {
                    cmbParentAccount.SelectedValue = acc.ParentAccountId.Value;
                }
                else
                {
                    cmbParentAccount.SelectedIndex = -1;
                }

                bool hasChildren = _accountService.HasChildren(accountId);
                chkIsGroup.Enabled = !hasChildren;
                cmbParentAccount.Enabled = !hasChildren;

                btnAdd.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = !acc.IsSystem;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"خطأ في تحميل تفاصيل الحساب:\n{ex.Message}", "خطأ");
            }
            finally
            {
                isLoadingAccount = false;
            }
        }

        // =========================================
        // الحساب الأب
        // =========================================
        private void LoadParentAccounts()
        {
            try
            {
                List<AccountItem> list = _accountService.GetParentAccounts();

                cmbParentAccount.DataSource = null;
                cmbParentAccount.DisplayMember = "DisplayText";
                cmbParentAccount.ValueMember = "AccountId";
                cmbParentAccount.DataSource = list;
                cmbParentAccount.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"خطأ في تحميل الحسابات الرئيسية:\n{ex.Message}", "خطأ");
            }
        }

        private void cmbParentAccount_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (isLoadingAccount)
                return;

            ApplyParentRules();

            int? parentId = null;
            if (cmbParentAccount.SelectedValue != null &&
                int.TryParse(cmbParentAccount.SelectedValue.ToString(), out int pid))
            {
                parentId = pid;
            }

            GenerateAndShowAccountNumber(parentId);
        }

        private void ApplyParentRules()
        {
            if (cmbParentAccount.SelectedValue == null ||
                !int.TryParse(cmbParentAccount.SelectedValue.ToString(), out int parentId))
            {
                cmbAccountType.Enabled = true;
                return;
            }

            Account? parent = _accountService.GetById(parentId);
            if (parent != null)
            {
                cmbAccountType.Text = parent.AccountType;
                txtAccountNature.Text = string.IsNullOrWhiteSpace(parent.AccountNature)
                    ? _accountService.GetNatureByAccountType(parent.AccountType)
                    : parent.AccountNature;

                cmbAccountType.Enabled = false;
            }
            else
            {
                cmbAccountType.Enabled = true;
            }
        }

        private void cmbAccountType_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (isLoadingAccount)
                return;

            string accountType = cmbAccountType.Text.Trim();
            txtAccountNature.Text = _accountService.GetNatureByAccountType(accountType);

            int? parentId = null;
            if (cmbParentAccount.SelectedValue != null &&
                int.TryParse(cmbParentAccount.SelectedValue.ToString(), out int pid))
            {
                parentId = pid;
            }

            GenerateAndShowAccountNumber(parentId);
        }

        private void GenerateAndShowAccountNumber(int? parentId)
        {
            if (selectedAccountId.HasValue)
                return;

            try
            {
                txtAccountNumber.Text = _accountService.GenerateAccountNumber(parentId);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"خطأ أثناء توليد رقم الحساب:\n{ex.Message}", "خطأ");
            }
        }

        // =========================================
        // أزرار العمليات
        // =========================================
        private void btnNew_Click(object? sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateAccount())
                return;

            try
            {
                int? parentId = null;
                if (cmbParentAccount.SelectedValue != null &&
                    int.TryParse(cmbParentAccount.SelectedValue.ToString(), out int pid))
                {
                    parentId = pid;
                }

                string accountType = cmbAccountType.Text.Trim();
                string accountNature = txtAccountNature.Text.Trim();
                if (string.IsNullOrWhiteSpace(accountNature))
                {
                    accountNature = _accountService.GetNatureByAccountType(accountType);
                }

                Account newAccount = new Account
                {
                    AccountNumber = txtAccountNumber.Text.Trim(),
                    AccountName = txtAccountName.Text.Trim(),
                    AccountType = accountType,
                    AccountNature = accountNature,
                    ParentAccountId = parentId,
                    IsGroup = chkIsGroup.Checked,
                    IsSystem = false
                };

                _accountService.Add(newAccount);

                MessageHelper.ShowInfo("تمت إضافة الحساب بنجاح.", "نجاح");
                RefreshAccounts();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"خطأ في إضافة الحساب:\n{ex.Message}", "خطأ");
            }
        }

        private void btnEdit_Click(object? sender, EventArgs e)
        {
            if (!selectedAccountId.HasValue)
            {
                MessageHelper.ShowWarning("يرجى اختيار حساب للتعديل.", "تنبيه");
                return;
            }

            if (!ValidateAccount())
                return;

            try
            {
                int? parentId = null;
                if (cmbParentAccount.SelectedValue != null &&
                    int.TryParse(cmbParentAccount.SelectedValue.ToString(), out int pid))
                {
                    parentId = pid;
                }

                string accountType = cmbAccountType.Text.Trim();
                string accountNature = txtAccountNature.Text.Trim();
                if (string.IsNullOrWhiteSpace(accountNature))
                {
                    accountNature = _accountService.GetNatureByAccountType(accountType);
                }

                Account account = new Account
                {
                    AccountId = selectedAccountId.Value,
                    AccountNumber = txtAccountNumber.Text.Trim(),
                    AccountName = txtAccountName.Text.Trim(),
                    AccountType = accountType,
                    AccountNature = accountNature,
                    ParentAccountId = parentId,
                    IsGroup = chkIsGroup.Checked
                };

                _accountService.Update(account);

                MessageHelper.ShowInfo("تم تعديل الحساب بنجاح.", "نجاح");
                RefreshAccounts();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"خطأ في تعديل الحساب:\n{ex.Message}", "خطأ");
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (!selectedAccountId.HasValue)
            {
                MessageHelper.ShowWarning("يرجى اختيار حساب للحذف.", "تنبيه");
                return;
            }

            if (!MessageHelper.Confirm("هل أنت متأكد من حذف هذا الحساب؟", "تأكيد الحذف"))
                return;

            try
            {
                _accountService.Delete(selectedAccountId.Value);

                MessageHelper.ShowInfo("تم حذف الحساب بنجاح.", "نجاح");
                RefreshAccounts();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message, "خطأ في الحذف");
            }
        }

        private void dgvAccounts_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvAccounts.Rows[e.RowIndex];
            object? val = row.Cells["AccountId"].Value;

            if (val != null && int.TryParse(val.ToString(), out int accountId))
            {
                LoadAccountDetails(accountId);
            }
        }

        private bool ValidateAccount()
        {
            if (string.IsNullOrWhiteSpace(txtAccountNumber.Text))
            {
                MessageHelper.ShowWarning("رقم الحساب مطلوب.", "تنبيه");
                txtAccountNumber.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAccountName.Text))
            {
                MessageHelper.ShowWarning("اسم الحساب مطلوب.", "تنبيه");
                txtAccountName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbAccountType.Text))
            {
                MessageHelper.ShowWarning("نوع الحساب مطلوب.", "تنبيه");
                cmbAccountType.Focus();
                return false;
            }

            if (cmbParentAccount.SelectedValue != null &&
                int.TryParse(cmbParentAccount.SelectedValue.ToString(), out int parentId))
            {
                if (selectedAccountId.HasValue && selectedAccountId.Value == parentId)
                {
                    MessageHelper.ShowWarning("لا يمكن أن يكون الحساب أباً لنفسه.", "تنبيه");
                    return false;
                }

                string? parentType = _accountService.GetParentAccountType(parentId);
                if (!string.IsNullOrEmpty(parentType) && parentType != cmbAccountType.Text.Trim())
                {
                    MessageHelper.ShowWarning($"نوع الحساب يجب أن يطابق نوع الحساب الأب ({parentType}).", "تنبيه");
                    return false;
                }
            }

            if (selectedAccountId.HasValue && !chkIsGroup.Checked)
            {
                if (_accountService.HasChildren(selectedAccountId.Value))
                {
                    MessageHelper.ShowWarning("لا يمكن تحويل هذا الحساب إلى حساب فرعي لأنه يحتوي على حسابات تابعة له.", "تنبيه");
                    return false;
                }
            }

            return true;
        }

        private void RefreshAccounts()
        {
            LoadAccounts();
            LoadAccountTree();
            LoadParentAccounts();
        }

        private void ClearFields()
        {
            selectedAccountId = null;
            isLoadingAccount = false;

            txtAccountNumber.Clear();
            txtAccountName.Clear();

            cmbParentAccount.SelectedIndex = -1;
            cmbAccountType.SelectedIndex = -1;
            txtAccountNature.Clear();

            chkIsGroup.Checked = false;
            chkIsGroup.Enabled = true;
            cmbParentAccount.Enabled = true;
            cmbAccountType.Enabled = true;

            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            if (treeAccounts.SelectedNode != null)
            {
                treeAccounts.SelectedNode = null;
            }

            GenerateAndShowAccountNumber(null);
        }

        private void grpAccountsList_Enter(object sender, EventArgs e)
        {

        }
    }
}
