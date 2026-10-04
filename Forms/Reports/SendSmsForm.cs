using AccountingSystemForWindowsFormLast.Helpers;
using AccountingSystemForWindowsFormLast.Models;
using AccountingSystemForWindowsFormLast.Services;

namespace AccountingSystemForWindowsFormLast.Forms
{
    public partial class SendSmsForm : Form
    {
        private readonly SmsService _smsService;

        private readonly int _accountId;
        private readonly string _accountName;
        private readonly string _accountNature;
        private readonly decimal _balance;
        private readonly decimal _debitAmount;
        private readonly decimal _creditAmount;
        private readonly DateTime? _fromDate;
        private readonly DateTime? _toDate;

        public SendSmsForm(
            int accountId,
            string accountName,
            string accountNature,
            decimal balance,
            decimal debitAmount,
            decimal creditAmount,
            DateTime? fromDate,
            DateTime? toDate)
        {
            _accountId = accountId;
            _accountName = accountName;
            _accountNature = accountNature;
            _balance = balance;
            _debitAmount = debitAmount;
            _creditAmount = creditAmount;
            _fromDate = fromDate;
            _toDate = toDate;

            _smsService = new SmsService();

            InitializeComponent();
            LoadValues();
        }

        private void LoadValues()
        {
            txtAccountName.Text = _accountName;
            txtBalance.Text = Math.Abs(_balance).ToString("N2") + " ريال";
            txtDebit.Text = _debitAmount.ToString("N2") + " ريال";
            txtCredit.Text = _creditAmount.ToString("N2") + " ريال";

            bool isOwedByCustomer = _debitAmount > 0 && _creditAmount == 0;
            bool isOwedToCustomer = _creditAmount > 0 && _debitAmount == 0;

            lblDirection.Text = isOwedByCustomer
                ? "على الحساب: مبلغ مستحق لنا"
                : isOwedToCustomer
                    ? "لصاحب الحساب: مبلغ مستحق له"
                    : "الرصيد متوازن";

            lblDirection.ForeColor = isOwedByCustomer
                ? UiTheme.Danger
                : isOwedToCustomer
                    ? UiTheme.Success
                    : UiTheme.TextMuted;

            txtMessage.Text = BuildDefaultMessage();
            txtPhone.Focus();
        }

        private string BuildDefaultMessage()
        {
            string due = _debitAmount.ToString("N2");
            string owed = _creditAmount.ToString("N2");

            return
                $"الأستاذ {_accountName} المحترم،{Environment.NewLine}" +
                $"{Environment.NewLine}" +
                $"عليك مبلغ {due} ريال، ولك مبلغ {owed} ريال.{Environment.NewLine}" +
                $"الرصيد: {Math.Abs(_balance):N2} ريال.{Environment.NewLine}" +
                $"{Environment.NewLine}" +
                $"مع تحياتنا.";
        }

        private async void BtnSend_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageHelper.ShowWarning("أدخل رقم الجوال أولاً.", "تنبيه");
                txtPhone.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageHelper.ShowWarning("نص الرسالة لا يمكن أن يكون فارغًا.", "تنبيه");
                txtMessage.Focus();
                return;
            }

            string normalizedPhone;

            try
            {
                normalizedPhone = SmsService.NormalizeYemenPhone(txtPhone.Text);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowWarning(ex.Message, "رقم الجوال");
                txtPhone.Focus();
                return;
            }

            SmsMessage message = new SmsMessage
            {
                AccountId = _accountId,
                AccountName = _accountName,
                AccountNature = _accountNature,
                PhoneNumber = normalizedPhone,
                StatementFromDate = _fromDate,
                StatementToDate = _toDate,
                Balance = _balance,
                DebitAmount = _debitAmount,
                CreditAmount = _creditAmount,
                MessageText = txtMessage.Text.Trim()
            };

            try
            {
                ToggleSending(true);

                await _smsService.SendAsync(message);

                MessageHelper.ShowInfo(
                    "تم إرسال الرسالة وتسجيلها في سجل SMS بنجاح.",
                    "SMS");

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(
                    "تعذر إرسال الرسالة، وتم تسجيل محاولة الإرسال في سجل SMS بحالة فشل.\n\n" +
                    ex.Message,
                    "فشل الإرسال");
            }
            finally
            {
                ToggleSending(false);
            }
        }

        private void ToggleSending(bool sending)
        {
            btnSend.Enabled = !sending;
            btnCancel.Enabled = !sending;
            txtPhone.Enabled = !sending;
            txtMessage.Enabled = !sending;
            btnSend.Text = sending ? "جاري الإرسال..." : "إرسال SMS";
            Cursor = sending ? Cursors.WaitCursor : Cursors.Default;
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
