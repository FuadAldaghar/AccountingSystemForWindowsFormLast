using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AccountingSystemForWindowsFormLast.Helpers;
using AccountingSystemForWindowsFormLast.Services;

namespace AccountingSystemForWindowsFormLast.Forms.Authentication
{
    public partial class AddUserForm : Form
    {
        private readonly UserService _userService;

        public AddUserForm()
        {
            InitializeComponent();
            UiTheme.Apply(this);
            _userService = new UserService();

            LoadRoles();

            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;

            AcceptButton = btnSave;
            CancelButton = btnCancel;

            btnCancel.BackColor = Color.Red;
            btnCancel.ForeColor = Color.White;
        }


        // =========================================================
        // تحميل الأدوار
        // =========================================================
        private void LoadRoles()
        {
            try
            {
                List<RoleItem> roles =
                    _userService.GetRoles();

                cmbRole.DataSource = null;
                cmbRole.DisplayMember = "RoleName";
                cmbRole.ValueMember = "RoleId";
                cmbRole.DataSource = roles;

                if (cmbRole.Items.Count > 0)
                {
                    cmbRole.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تحميل الأدوار:\n\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                btnSave.Enabled = false;
            }
        }


        // =========================================================
        // حفظ المستخدم
        // =========================================================
        private void btnSave_Click(
            object? sender,
            EventArgs e)
        {
            lblMessage.Text = "";

            string userName =
                txtUserName.Text.Trim();

            string password =
                txtPassword.Text;

            string confirmPassword =
                txtConfirmPassword.Text;


            // -----------------------------------------------------
            // التحقق من اسم المستخدم
            // -----------------------------------------------------
            if (string.IsNullOrWhiteSpace(userName))
            {
                lblMessage.Text =
                    "أدخل اسم المستخدم.";

                txtUserName.Focus();

                return;
            }


            // -----------------------------------------------------
            // التحقق من كلمة المرور
            // -----------------------------------------------------
            if (string.IsNullOrWhiteSpace(password))
            {
                lblMessage.Text =
                    "أدخل كلمة المرور.";

                txtPassword.Focus();

                return;
            }


            if (password.Length < 4)
            {
                lblMessage.Text =
                    "كلمة المرور يجب أن تكون 4 أحرف على الأقل.";

                txtPassword.Focus();

                return;
            }


            // -----------------------------------------------------
            // التحقق من تأكيد كلمة المرور
            // -----------------------------------------------------
            if (password != confirmPassword)
            {
                lblMessage.Text =
                    "تأكيد كلمة المرور غير مطابق.";

                txtConfirmPassword.SelectAll();
                txtConfirmPassword.Focus();

                return;
            }


            // -----------------------------------------------------
            // التحقق من اختيار الدور
            // -----------------------------------------------------
            if (cmbRole.SelectedValue == null)
            {
                lblMessage.Text =
                    "اختر دور المستخدم.";

                cmbRole.Focus();

                return;
            }


            try
            {
                // -------------------------------------------------
                // التحقق من عدم تكرار اسم المستخدم
                // -------------------------------------------------
                if (_userService.UserNameExists(userName))
                {
                    lblMessage.Text =
                        "اسم المستخدم موجود مسبقاً.";

                    txtUserName.SelectAll();
                    txtUserName.Focus();

                    return;
                }


                int roleId =
                    Convert.ToInt32(cmbRole.SelectedValue);

                bool isActive =
                    chkIsActive.Checked;


                // -------------------------------------------------
                // إنشاء المستخدم
                // -------------------------------------------------
                bool created =
                    _userService.CreateUser(
                        userName,
                        password,
                        roleId,
                        isActive);


                if (!created)
                {
                    lblMessage.Text =
                        "تعذر إنشاء المستخدم.";

                    return;
                }


                MessageBox.Show(
                    "تم إنشاء المستخدم بنجاح.",
                    "نجاح",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                DialogResult =
                    DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء إنشاء المستخدم:\n\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // إلغاء
        // =========================================================
        private void btnCancel_Click(
            object? sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.Cancel;

            Close();
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {

        }
    }
}