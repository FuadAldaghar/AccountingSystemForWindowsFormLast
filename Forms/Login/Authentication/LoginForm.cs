
using System;
using System.Windows.Forms;
using AccountingSystemForWindowsFormLast.Helpers.users;
using AccountingSystemForWindowsFormLast.Services;

namespace AccountingSystemForWindowsFormLast.Forms.Authentication
{
    public partial class LoginForm : Form
    {
        private readonly UserService _userService;

        public LoginForm()
        {
            InitializeComponent();

            _userService = new UserService();

            btnLogin.Click += btnLogin_Click;
            btnExit.Click += btnExit_Click;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;

            AcceptButton = btnLogin;
            CancelButton = btnExit;
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            lblMessage.Text = "";

            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(userName))
            {
                lblMessage.Text = "أدخل اسم المستخدم.";
                txtUserName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                lblMessage.Text = "أدخل كلمة المرور.";
                txtPassword.Focus();
                return;
            }

            try
            {
                UserSession? session =
                    _userService.Login(userName, password);

                if (session == null)
                {
                    lblMessage.Text = "اسم المستخدم أو كلمة المرور غير صحيحة.";
                    txtPassword.SelectAll();
                    txtPassword.Focus();
                    return;
                }

                CurrentUser.Login(session);

                //MessageBox.Show(
                // "Accounts = " + CurrentUser.HasPermission("Accounts") + "\n" +
                // "Items = " + CurrentUser.HasPermission("Items") + "\n" +
                // "Purchase = " + CurrentUser.HasPermission("Purchase") + "\n" +
                // "Sales = " + CurrentUser.HasPermission("Sales") + "\n" +
                // "Journal = " + CurrentUser.HasPermission("Journal") + "\n" +
                // "Receipt = " + CurrentUser.HasPermission("Receipt") + "\n" +
                // "Payment = " + CurrentUser.HasPermission("Payment") + "\n" +
                // "Reports = " + CurrentUser.HasPermission("Reports") + "\n" +
                // "Settings = " + CurrentUser.HasPermission("Settings"),
                // "CurrentUser Debug",
                // MessageBoxButtons.OK,
                // MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تسجيل الدخول:\n\n" + ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void chkShowPassword_CheckedChanged(
            object? sender,
            EventArgs e)
        {
            txtPassword.PasswordChar =
                chkShowPassword.Checked ? '\0' : '●';
        }

        private void btnExit_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {

        }
    }
}
