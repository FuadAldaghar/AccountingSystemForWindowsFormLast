
using System.Data;
using AccountingSystemForWindowsFormLast.Helpers;
using AccountingSystemForWindowsFormLast.Services;
using AccountingSystemForWindowsFormLast.Models;

namespace AccountingSystemForWindowsFormLast.Forms
{
    public partial class StockReport : Form
    {
        private readonly ReportService _reportService;
        private readonly ItemService _itemService;

        public StockReport()
        {
            InitializeComponent();

            // UiTheme.Apply(this);
            UiTheme.Apply(panelHeader);
            UiTheme.Apply(dgvStock);
            UiTheme.StyleButton(btnSearch, Accent.Primary);
            UiTheme.StyleButton(btnShowAll, Accent.Neutral);

            _reportService = new ReportService();
            _itemService = new ItemService();

            btnSearch.Click += BtnSearch_Click;
            btnShowAll.Click += BtnShowAll_Click;
        }

        private void StockReport_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpToDate.Value = DateTime.Today;

            LoadItems();
            LoadStockReport();
        }

        private void LoadItems()
        {
            try
            {
                List<Item> items = _itemService.GetAll();

                // Add "All items" option at top
                List<Item> comboItems = new List<Item>
                {
                    new Item { ItemId = 0, ItemNumber = "", ItemName = "كل الأصناف", Unit = "" }
                };
                comboItems.AddRange(items);

                cmbItem.DataSource = null;
                cmbItem.DisplayMember = "ItemName";
                cmbItem.ValueMember = "ItemId";
                cmbItem.DataSource = comboItems;
                cmbItem.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"حدث خطأ أثناء تحميل الأصناف:\n{ex.Message}", "خطأ");
            }
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            LoadStockReport();
        }

        private void BtnShowAll_Click(object? sender, EventArgs e)
        {
            dtpFromDate.Value = new DateTime(2000, 1, 1);
            dtpToDate.Value = DateTime.Today;
            cmbItem.SelectedIndex = 0;
            LoadStockReport();
        }

        private void LoadStockReport()
        {
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;

            if (fromDate > toDate)
            {
                MessageHelper.ShowWarning("تاريخ البداية يجب أن يكون قبل تاريخ النهاية.", "تنبيه");
                return;
            }

            int? selectedItemId = null;
            if (cmbItem.SelectedValue != null &&
                int.TryParse(cmbItem.SelectedValue.ToString(), out int id) &&
                id > 0)
            {
                selectedItemId = id;
            }

            try
            {
                DataTable table = _reportService.GetStockReport(selectedItemId, fromDate, toDate);
                dgvStock.DataSource = table;

                if (dgvStock.Columns["ItemId"] != null)
                {
                    dgvStock.Columns["ItemId"].Visible = false;
                }

                FormatGrid();
                CalculateTotals(table);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"حدث خطأ أثناء تحميل تقرير المخزون:\n{ex.Message}", "خطأ");
            }
        }

        private void FormatGrid()
        {
            if (dgvStock.Columns["رقم الصنف"] != null)
                dgvStock.Columns["رقم الصنف"].FillWeight = 15;

            if (dgvStock.Columns["اسم الصنف"] != null)
                dgvStock.Columns["اسم الصنف"].FillWeight = 25;

            if (dgvStock.Columns["الوحدة"] != null)
                dgvStock.Columns["الوحدة"].FillWeight = 10;

            if (dgvStock.Columns["رصيد أول المدة"] != null)
            {
                dgvStock.Columns["رصيد أول المدة"].DefaultCellStyle.Format = "N2";
                dgvStock.Columns["رصيد أول المدة"].FillWeight = 15;
            }

            if (dgvStock.Columns["إجمالي المشتريات"] != null)
            {
                dgvStock.Columns["إجمالي المشتريات"].DefaultCellStyle.Format = "N2";
                dgvStock.Columns["إجمالي المشتريات"].FillWeight = 15;
            }

            if (dgvStock.Columns["إجمالي المبيعات"] != null)
            {
                dgvStock.Columns["إجمالي المبيعات"].DefaultCellStyle.Format = "N2";
                dgvStock.Columns["إجمالي المبيعات"].FillWeight = 15;
            }

            if (dgvStock.Columns["الرصيد"] != null)
            {
                dgvStock.Columns["الرصيد"].DefaultCellStyle.Format = "N2";
                dgvStock.Columns["الرصيد"].FillWeight = 15;
            }
        }

        private void CalculateTotals(DataTable table)
        {
            decimal totalPurchases = 0;
            decimal totalSales = 0;
            decimal totalBalance = 0;

            foreach (DataRow row in table.Rows)
            {
                totalPurchases += Convert.ToDecimal(row["إجمالي المشتريات"]);
                totalSales += Convert.ToDecimal(row["إجمالي المبيعات"]);
                totalBalance += Convert.ToDecimal(row["الرصيد"]);
            }

            lblTotalPurchase.Text = totalPurchases.ToString("N2");
            lblTotalSales.Text = totalSales.ToString("N2");
            lblTotalBalance.Text = totalBalance.ToString("N2");
        }
    }
}