
using AccountingSystemForWindowsFormLast.Helpers;
using AccountingSystemForWindowsFormLast.Models;
using AccountingSystemForWindowsFormLast.Services;


namespace AccountingSystemForWindowsFormLast.Forms
{
    public partial class PaymentVoucher : Form
    {
        private readonly VoucherService _voucherService;
        private readonly AccountService _accountService;

        public PaymentVoucher()
        {
            InitializeComponent();

            //UiTheme.Apply(this);
            UiTheme.StyleButton(btnSave, Accent.Primary);
            UiTheme.StyleButton(btnNew, Accent.Neutral);

            _voucherService = new VoucherService();
            _accountService = new AccountService();

            btnNew.Click += btnNew_Click;
            btnSave.Click += btnSave_Click;
        }

        private void PaymentVoucher_Load(object? sender, EventArgs e)
        {
            LoadAccounts();
            LoadPaymentAccounts();
            ClearVoucher();
        }

        private void LoadAccounts()
        {
            try
            {
                List<AccountItem> accounts = _accountService.GetLeafAccounts();

                cmbAccount.DataSource = null;
                cmbAccount.DisplayMember = "DisplayText";
                cmbAccount.ValueMember = "AccountId";
                cmbAccount.DataSource = accounts;
                cmbAccount.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"حدث خطأ أثناء تحميل الحسابات:\n{ex.Message}", "خطأ");
            }
        }

        private void LoadPaymentAccounts()
        {
            try
            {
                List<AccountItem> accounts = _accountService.GetLeafAccounts();

                // Prefer accounts starting with 111 (Cash) or 112 (Bank), or all leaf accounts
                var cashOrBank = accounts
                    .Where(a => a.AccountNumber.StartsWith("111") || a.AccountNumber.StartsWith("112") || a.AccountName.Contains("صندوق") || a.AccountName.Contains("بنك"))
                    .ToList();

                if (cashOrBank.Count == 0)
                    cashOrBank = accounts;

                cmbCashAccount.DataSource = null;
                cmbCashAccount.DisplayMember = "DisplayText";
                cmbCashAccount.ValueMember = "AccountId";
                cmbCashAccount.DataSource = cashOrBank;
                cmbCashAccount.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"حدث خطأ أثناء تحميل حسابات الدفع:\n{ex.Message}", "خطأ");
            }
        }

        private void btnNew_Click(object? sender, EventArgs e)
        {
            ClearVoucher();
        }

        private void ClearVoucher()
        {
            try
            {
                txtVoucherNumber.Text = _voucherService.GetNextPaymentVoucherNumber();
            }
            catch
            {
                txtVoucherNumber.Text = "1";
            }

            dtpVoucherDate.Value = DateTime.Today;
            cmbAccount.SelectedIndex = -1;
            cmbCashAccount.SelectedIndex = -1;
            nudAmount.Value = 0;
            txtNotes.Clear();
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (cmbAccount.SelectedValue == null || Convert.ToInt32(cmbAccount.SelectedValue) <= 0)
            {
                MessageHelper.ShowWarning("اختر الحساب المستفيد.", "تنبيه");
                cmbAccount.Focus();
                return;
            }

            if (cmbCashAccount.SelectedValue == null || Convert.ToInt32(cmbCashAccount.SelectedValue) <= 0)
            {
                MessageHelper.ShowWarning("اختر حساب الدفع.", "تنبيه");
                cmbCashAccount.Focus();
                return;
            }

            int beneficiaryId = Convert.ToInt32(cmbAccount.SelectedValue);
            int paymentId = Convert.ToInt32(cmbCashAccount.SelectedValue);

            if (beneficiaryId == paymentId)
            {
                MessageHelper.ShowWarning("لا يمكن أن يكون الحساب المستفيد هو نفس حساب الدفع.", "تنبيه");
                return;
            }

            decimal amount = nudAmount.Value;
            if (amount <= 0)
            {
                MessageHelper.ShowWarning("المبلغ يجب أن يكون أكبر من صفر.", "تنبيه");
                nudAmount.Focus();
                return;
            }

            try
            {
                _voucherService.SavePaymentVoucher(
                    txtVoucherNumber.Text.Trim(),
                    dtpVoucherDate.Value.Date,
                    amount,
                    beneficiaryId,
                    paymentId,
                    txtNotes.Text.Trim());

                MessageHelper.ShowInfo("تم حفظ سند الصرف والقيد المحاسبي بنجاح.", "نجاح");
                ClearVoucher();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"تعذر حفظ سند الصرف:\n{ex.Message}", "خطأ");
            }
        }
    }
}