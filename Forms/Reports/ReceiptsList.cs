
using System.Data;
using AccountingSystemForWindowsFormLast.Helpers;
using AccountingSystemForWindowsFormLast.Models;
using AccountingSystemForWindowsFormLast.Services;

namespace AccountingSystemForWindowsFormLast.Forms
{
    public partial class ReceiptsList : Form
    {
        private readonly ReportService _reportService;

        public ReceiptsList()
        {
            InitializeComponent();

            UiTheme.Apply(this);
            UiTheme.StyleButton(btnSearch, Accent.Primary);
            UiTheme.StyleButton(btnShowAll, Accent.Neutral);

            _reportService = new ReportService();

            btnSearch.Click += BtnSearch_Click;
            btnShowAll.Click += BtnShowAll_Click;
            txtSearch.KeyDown += TxtSearch_KeyDown;
        }

        private void ReceiptsList_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpToDate.Value = DateTime.Today;

            LoadReceipts();
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            LoadReceipts();
        }

        private void BtnShowAll_Click(object? sender, EventArgs e)
        {
            dtpFromDate.Value = new DateTime(2000, 1, 1);
            dtpToDate.Value = DateTime.Today;
            txtSearch.Text = string.Empty;
            nudMinAmount.Value = 0;
            nudMaxAmount.Value = 0;

            LoadReceipts();
        }

        private void TxtSearch_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;
            LoadReceipts();
        }

        private void LoadReceipts()
        {
            try
            {
                VoucherListFilter filter = BuildFilter();
                DataTable table = _reportService.GetReceiptsList(filter);

                dgvReceipts.DataSource = table;
                HideIdColumn();
                FormatGrid();
                CalculateTotals(table);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"حدث خطأ أثناء تحميل سندات القبض:\n{ex.Message}", "خطأ");
            }
        }

        private VoucherListFilter BuildFilter()
        {
            VoucherListFilter filter = new VoucherListFilter
            {
                FromDate = dtpFromDate.Value.Date,
                ToDate = dtpToDate.Value.Date,
                SearchText = txtSearch.Text
            };

            // الصفر يعني "بلا حد" لأن المبالغ في النظام أكبر من صفر دائماً.
            if (nudMinAmount.Value > 0)
                filter.MinAmount = nudMinAmount.Value;

            if (nudMaxAmount.Value > 0)
                filter.MaxAmount = nudMaxAmount.Value;

            return filter;
        }

        private void HideIdColumn()
        {
            if (dgvReceipts.Columns["المعرف"] != null)
                dgvReceipts.Columns["المعرف"].Visible = false;
        }

        private void FormatGrid()
        {
            SetWeight("رقم السند", 15);
            SetWeight("التاريخ", 15);
            SetWeight("رقم الحساب", 12);
            SetWeight("اسم الحساب", 24);
            SetWeight("الملاحظات", 30);

            if (dgvReceipts.Columns["المبلغ"] != null)
            {
                dgvReceipts.Columns["المبلغ"].DefaultCellStyle.Format = "N2";
                dgvReceipts.Columns["المبلغ"].FillWeight = 18;
            }
        }

        private void SetWeight(string columnName, int weight)
        {
            if (dgvReceipts.Columns[columnName] != null)
                dgvReceipts.Columns[columnName].FillWeight = weight;
        }

        private void CalculateTotals(DataTable table)
        {
            decimal totalAmount = 0;

            foreach (DataRow row in table.Rows)
            {
                totalAmount += Convert.ToDecimal(row["المبلغ"]);
            }

            decimal average = table.Rows.Count > 0
                ? totalAmount / table.Rows.Count
                : 0;

            lblVouchersCount.Text = $"عدد السندات: {table.Rows.Count}";
            lblTotalAmount.Text = $"إجمالي المبلغ: {totalAmount:N2}";
            lblAverageAmount.Text = $"متوسط السند: {average:N2}";
        }
    }
}