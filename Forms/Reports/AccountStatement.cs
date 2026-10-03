
using System.Data;
using AccountingSystemForWindowsFormLast.Helpers;
using AccountingSystemForWindowsFormLast.Models;
using AccountingSystemForWindowsFormLast.Services;
namespace AccountingSystemForWindowsFormLast.Forms
{
    public partial class AccountStatement : Form
    {
        private readonly ReportService _reportService;
        private readonly AccountService _accountService;

        public AccountStatement()
        {
            InitializeComponent();

            //UiTheme.Apply(this);
            UiTheme.Apply(panelHeader);
            UiTheme.Apply(dgvStatement);
            UiTheme.StyleButton(btnSearch, Accent.Primary);
            UiTheme.StyleButton(btnShowAll, Accent.Neutral);

            _reportService = new ReportService();
            _accountService = new AccountService();

            btnSearch.Click += BtnSearch_Click;
            btnShowAll.Click += BtnShowAll_Click;
        }

        private void AccountStatement_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpToDate.Value = DateTime.Today;

            LoadAccounts();
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

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            LoadStatement();
        }

        private void BtnShowAll_Click(object? sender, EventArgs e)
        {
            dtpFromDate.Value = new DateTime(2000, 1, 1);
            dtpToDate.Value = DateTime.Today;
            LoadStatement();
        }

        private void LoadStatement()
        {
            if (cmbAccount.SelectedValue == null || Convert.ToInt32(cmbAccount.SelectedValue) <= 0)
            {
                MessageHelper.ShowWarning("اختر الحساب أولاً.", "تنبيه");
                cmbAccount.Focus();
                return;
            }

            if (dtpFromDate.Value.Date > dtpToDate.Value.Date)
            {
                MessageHelper.ShowWarning("تاريخ البداية يجب أن يكون قبل تاريخ النهاية.", "تنبيه");
                return;
            }

            int accountId = Convert.ToInt32(cmbAccount.SelectedValue);
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;

            try
            {
                DataTable table = _reportService.GetAccountStatement(accountId, fromDate, toDate);
                dgvStatement.DataSource = table;

                FormatGrid();
                CalculateSummary(accountId, fromDate, table);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"حدث خطأ أثناء تحميل كشف الحساب:\n{ex.Message}", "خطأ");
            }
        }

        private void FormatGrid()
        {
            if (dgvStatement.Columns["التاريخ"] != null)
            {
                dgvStatement.Columns["التاريخ"].DefaultCellStyle.Format = "yyyy-MM-dd";
                dgvStatement.Columns["التاريخ"].FillWeight = 15;
            }

            if (dgvStatement.Columns["رقم القيد"] != null)
                dgvStatement.Columns["رقم القيد"].FillWeight = 15;

            if (dgvStatement.Columns["البيان"] != null)
                dgvStatement.Columns["البيان"].FillWeight = 35;

            if (dgvStatement.Columns["مدين"] != null)
            {
                dgvStatement.Columns["مدين"].DefaultCellStyle.Format = "N2";
                dgvStatement.Columns["مدين"].FillWeight = 12;
            }

            if (dgvStatement.Columns["دائن"] != null)
            {
                dgvStatement.Columns["دائن"].DefaultCellStyle.Format = "N2";
                dgvStatement.Columns["دائن"].FillWeight = 12;
            }

            if (dgvStatement.Columns["الرصيد"] != null)
            {
                dgvStatement.Columns["الرصيد"].DefaultCellStyle.Format = "N2";
                dgvStatement.Columns["الرصيد"].FillWeight = 15;
            }
        }

        private void CalculateSummary(int accountId, DateTime fromDate, DataTable table)
        {
            decimal openingBalance = _reportService.GetAccountOpeningBalance(accountId, fromDate);
            decimal totalDebit = 0;
            decimal totalCredit = 0;

            foreach (DataRow row in table.Rows)
            {
                totalDebit += Convert.ToDecimal(row["مدين"]);
                totalCredit += Convert.ToDecimal(row["دائن"]);
            }

            decimal finalBalance = 0;
            if (table.Rows.Count > 0)
            {
                finalBalance = Convert.ToDecimal(table.Rows[^1]["الرصيد"]);
            }
            else
            {
                finalBalance = openingBalance;
            }

            //lblOpeningBalance.Text = openingBalance.ToString("N2");
            //lblDebitTotal.Text = totalDebit.ToString("N2");
            //lblCreditTotal.Text = totalCredit.ToString("N2");
            //lblFinalBalance.Text = finalBalance.ToString("N2");


            lblOpeningBalance.Text = openingBalance.ToString("N2");
            lblDebitTotal.Text = finalBalance.ToString("N2");//totalDebit.ToString("N2");
            lblCreditTotal.Text = totalCredit.ToString("N2");
            lblFinalBalance.Text = finalBalance.ToString("N2");
        }

        private void lblDebitTotal_Click(object sender, EventArgs e)
        {

        }
    }
}