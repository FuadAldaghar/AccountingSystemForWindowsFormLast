using System;
using System.Data;
using System.Windows.Forms;
using AccountingSystemForWindowsFormLast.Helpers;
using AccountingSystemForWindowsFormLast.Models;
using AccountingSystemForWindowsFormLast.Services;

namespace AccountingSystemForWindowsFormLast.Forms
{
    public partial class PurchasesList : Form
    {
        private readonly ReportService _reportService;

        public PurchasesList()
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

        private void PurchasesList_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpToDate.Value = DateTime.Today;

            LoadPaymentTypes();
            LoadPurchases();
        }

        private void LoadPaymentTypes()
        {
            cmbPaymentType.Items.Clear();
            cmbPaymentType.Items.Add("الكل");
            cmbPaymentType.Items.Add(InvoiceService.CashPaymentType);
            cmbPaymentType.Items.Add(InvoiceService.CreditPaymentType);
            cmbPaymentType.SelectedIndex = 0;
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            LoadPurchases();
        }

        private void BtnShowAll_Click(object? sender, EventArgs e)
        {
            dtpFromDate.Value = new DateTime(2000, 1, 1);
            dtpToDate.Value = DateTime.Today;
            txtSearch.Text = string.Empty;
            cmbPaymentType.SelectedIndex = 0;

            LoadPurchases();
        }

        private void TxtSearch_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;
            LoadPurchases();
        }

        private void LoadPurchases()
        {
            try
            {
                InvoiceListFilter filter = BuildFilter();
                DataTable table = _reportService.GetPurchasesList(filter);

                dgvPurchases.DataSource = table;
                HideIdColumn();
                FormatGrid();
                CalculateTotals(table);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"حدث خطأ أثناء تحميل فواتير المشتريات:\n{ex.Message}", "خطأ");
            }
        }

        private InvoiceListFilter BuildFilter()
        {
            InvoiceListFilter filter = new InvoiceListFilter
            {
                FromDate = dtpFromDate.Value.Date,
                ToDate = dtpToDate.Value.Date,
                SearchText = txtSearch.Text
            };

            // الفهرس صفر يعني "الكل"، والحقيقية تعني تقييداً بنوع الدفع.
            if (cmbPaymentType.SelectedIndex > 0)
                filter.PaymentType = cmbPaymentType.SelectedItem?.ToString();

            return filter;
        }

        private void HideIdColumn()
        {
            if (dgvPurchases.Columns["المعرف"] != null)
                dgvPurchases.Columns["المعرف"].Visible = false;
        }

        private void FormatGrid()
        {
            SetWeight("رقم الفاتورة", 15);
            SetWeight("التاريخ", 15);
            SetWeight("نوع الدفع", 12);
            SetWeight("رقم الحساب", 12);
            SetWeight("اسم الحساب", 24);
            SetWeight("عدد الأصناف", 10);

            SetFormat("إجمالي الكمية", "N2", 12);
            SetFormat("إجمالي المبلغ", "N2", 15);
        }

        private void SetWeight(string columnName, int weight)
        {
            if (dgvPurchases.Columns[columnName] != null)
                dgvPurchases.Columns[columnName].FillWeight = weight;
        }

        private void SetFormat(string columnName, string format, int weight)
        {
            if (dgvPurchases.Columns[columnName] == null)
                return;

            dgvPurchases.Columns[columnName].DefaultCellStyle.Format = format;
            dgvPurchases.Columns[columnName].FillWeight = weight;
        }

        private void CalculateTotals(DataTable table)
        {
            decimal totalQuantity = 0;
            decimal totalAmount = 0;

            foreach (DataRow row in table.Rows)
            {
                totalQuantity += Convert.ToDecimal(row["إجمالي الكمية"]);
                totalAmount += Convert.ToDecimal(row["إجمالي المبلغ"]);
            }

            lblInvoicesCount.Text = $"عدد الفواتير: {table.Rows.Count}";
            lblTotalQuantity.Text = $"إجمالي الكمية: {totalQuantity:N2}";
            lblTotalAmount.Text = $"إجمالي المبلغ: {totalAmount:N2}";
        }
    }
}
