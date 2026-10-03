
using AccountingSystemForWindowsFormLast.Helpers;
using AccountingSystemForWindowsFormLast.Models;
using AccountingSystemForWindowsFormLast.Services;


namespace AccountingSystemForWindowsFormLast.Forms
{
    public partial class ReceiptVoucher : Form
    {
        private readonly VoucherService _voucherService;
        private readonly AccountService _accountService;

        public ReceiptVoucher()
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

        private void ReceiptVoucher_Load(object? sender, EventArgs e)
        {
            LoadAccounts();
            LoadCashAccounts();
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

        private void LoadCashAccounts()
        {
            try
            {
                List<AccountItem> accounts = _accountService.GetLeafAccounts();

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
                MessageHelper.ShowError($"حدث خطأ أثناء تحميل حسابات القبض:\n{ex.Message}", "خطأ");
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
                txtVoucherNumber.Text = _voucherService.GetNextReceiptVoucherNumber();
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
                MessageHelper.ShowWarning("اختر الحساب المستلم منه.", "تنبيه");
                cmbAccount.Focus();
                return;
            }

            if (cmbCashAccount.SelectedValue == null || Convert.ToInt32(cmbCashAccount.SelectedValue) <= 0)
            {
                MessageHelper.ShowWarning("اختر حساب القبض (الصندوق / البنك).", "تنبيه");
                cmbCashAccount.Focus();
                return;
            }

            int sourceAccountId = Convert.ToInt32(cmbAccount.SelectedValue);
            int receiptAccountId = Convert.ToInt32(cmbCashAccount.SelectedValue);

            if (sourceAccountId == receiptAccountId)
            {
                MessageHelper.ShowWarning("لا يمكن أن يكون حساب المستلم منه هو نفس حساب القبض.", "تنبيه");
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
                _voucherService.SaveReceiptVoucher(
                    txtVoucherNumber.Text.Trim(),
                    dtpVoucherDate.Value.Date,
                    amount,
                    sourceAccountId,
                    receiptAccountId,
                    txtNotes.Text.Trim());

                MessageHelper.ShowInfo("تم حفظ سند القبض والقيد المحاسبي بنجاح.", "نجاح");
                ClearVoucher();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"تعذر حفظ سند القبض:\n{ex.Message}", "خطأ");
            }
        }
    }
}