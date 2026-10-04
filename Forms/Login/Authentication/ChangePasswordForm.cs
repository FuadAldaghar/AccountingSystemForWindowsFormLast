
using AccountingSystemForWindowsFormLast.Helpers;
using AccountingSystemForWindowsFormLast.Helpers.users;
using AccountingSystemForWindowsFormLast.Services;

namespace AccountingSystemForWindowsFormLast.Forms.Authentication
{
    public partial class ChangePasswordForm : Form
    {
        private readonly UserService _userService;

        public ChangePasswordForm()
        {
            InitializeComponent();
            UiTheme.Apply(this);
            _userService = new UserService();

            btnChangePassword.Click += btnChangePassword_Click;
            btnCancel.Click += btnCancel_Click;

            AcceptButton = btnChangePassword;
            CancelButton = btnCancel;

            btnCancel.BackColor = Color.Red;
            btnCancel.ForeColor = Color.White;
        }

        private void btnChangePassword_Click(object? sender, EventArgs e)
        {
            lblMessage.Text = "";

            string currentPassword =
                txtCurrentPassword.Text;

            string newPassword =
                txtNewPassword.Text;

            string confirmPassword =
                txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(currentPassword))
            {
                lblMessage.Text = "أدخل كلمة المرور الحالية.";
                txtCurrentPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                lblMessage.Text = "أدخل كلمة المرور الجديدة.";
                txtNewPassword.Focus();
                return;
            }

            if (newPassword.Length < 4)
            {
                lblMessage.Text =
                    "كلمة المرور الجديدة يجب أن تكون 4 أحرف على الأقل.";
                txtNewPassword.Focus();
                return;
            }

            if (newPassword != confirmPassword)
            {
                lblMessage.Text =
                    "تأكيد كلمة المرور غير مطابق.";
                txtConfirmPassword.SelectAll();
                txtConfirmPassword.Focus();
                return;
            }

            if (currentPassword == newPassword)
            {
                lblMessage.Text =
                    "كلمة المرور الجديدة يجب أن تكون مختلفة عن الحالية.";
                txtNewPassword.Focus();
                return;
            }

            try
            {
                bool changed =
                    _userService.ChangePassword(
                        CurrentUser.UserId,
                        currentPassword,
                        newPassword);

                if (!changed)
                {
                    lblMessage.Text =
                        "كلمة المرور الحالية غير صحيحة.";
                    txtCurrentPassword.SelectAll();
                    txtCurrentPassword.Focus();
                    return;
                }

                MessageBox.Show(
                    "تم تغيير كلمة المرور بنجاح.",
                    "نجاح",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تغيير كلمة المرور:\n\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}