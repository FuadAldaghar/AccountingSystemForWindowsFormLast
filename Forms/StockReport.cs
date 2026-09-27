using System;
using System.Data;
using System.Windows.Forms;
using AccountingSystemForWindowsFormLast.Data;
using Microsoft.Data.SqlClient;

namespace AccountingSystemForWindowsFormLast.Forms
{
    public partial class StockReport : Form
    {
        public StockReport()
        {
            InitializeComponent();

            btnSearch.Click += BtnSearch_Click;
            btnShowAll.Click += BtnShowAll_Click;
        }

        private void StockReport_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value =
                new DateTime(DateTime.Today.Year, 1, 1);

            dtpToDate.Value = DateTime.Today;

            LoadItems();
            LoadStockReport();
        }

        private void LoadItems()
        {
            try
            {
                using SqlConnection connection =
                    DatabaseConnection.GetConnection();

                connection.Open();

                string query = @"
                    SELECT 
                        ItemId,
                        ItemNumber,
                        ItemName,
                        Unit
                    FROM Items
                    ORDER BY ItemNumber";

                using SqlCommand command =
                    new SqlCommand(query, connection);

                using SqlDataReader reader =
                    command.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(reader);

                DataRow allRow = table.NewRow();

                allRow["ItemId"] = 0;
                allRow["ItemNumber"] = "";
                allRow["ItemName"] = "كل الأصناف";
                allRow["Unit"] = "";

                table.Rows.InsertAt(allRow, 0);

                cmbItem.DataSource = table;
                cmbItem.DisplayMember = "ItemName";
                cmbItem.ValueMember = "ItemId";

                cmbItem.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تحميل الأصناف:\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadStockReport()
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date;

                if (fromDate > toDate)
                {
                    MessageBox.Show(
                        "تاريخ البداية يجب أن يكون قبل تاريخ النهاية.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                using SqlConnection connection =
                    DatabaseConnection.GetConnection();

                connection.Open();

                string query = @"
                    SELECT
                        i.ItemId,
                        i.ItemNumber AS [رقم الصنف],
                        i.ItemName AS [اسم الصنف],
                        i.Unit AS [الوحدة],

                        ISNULL((
                            SELECT SUM(pid.Quantity)
                            FROM PurchaseInvoiceDetails pid
                            INNER JOIN PurchaseInvoices pi
                                ON pi.PurchaseInvoiceId =
                                   pid.PurchaseInvoiceId
                            WHERE pid.ItemId = i.ItemId
                              AND pi.InvoiceDate >= @FromDate
                              AND pi.InvoiceDate < DATEADD(DAY, 1, @ToDate)
                        ), 0) AS [إجمالي المشتريات],

                        ISNULL((
                            SELECT SUM(sid.Quantity)
                            FROM SalesInvoiceDetails sid
                            INNER JOIN SalesInvoices si
                                ON si.SalesInvoiceId =
                                   sid.SalesInvoiceId
                            WHERE sid.ItemId = i.ItemId
                              AND si.InvoiceDate >= @FromDate
                              AND si.InvoiceDate < DATEADD(DAY, 1, @ToDate)
                        ), 0) AS [إجمالي المبيعات]

                    FROM Items i

                    WHERE
                        @ItemId IS NULL
                        OR i.ItemId = @ItemId

                    ORDER BY i.ItemNumber";

                using SqlCommand command =
                    new SqlCommand(query, connection);

                command.Parameters.Add(
                    "@FromDate",
                    SqlDbType.DateTime).Value = fromDate;

                command.Parameters.Add(
                    "@ToDate",
                    SqlDbType.DateTime).Value = toDate;

                int itemId = 0;

                if (cmbItem.SelectedValue != null &&
                    cmbItem.SelectedValue != DBNull.Value)
                {
                    itemId =
                        Convert.ToInt32(cmbItem.SelectedValue);
                }

                command.Parameters.Add(
                    "@ItemId",
                    SqlDbType.Int).Value =
                    itemId == 0
                        ? DBNull.Value
                        : itemId;

                using SqlDataReader reader =
                    command.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(reader);

                table.Columns.Add(
                    "الرصيد",
                    typeof(decimal));

                foreach (DataRow row in table.Rows)
                {
                    decimal purchases =
                        Convert.ToDecimal(
                            row["إجمالي المشتريات"]);

                    decimal sales =
                        Convert.ToDecimal(
                            row["إجمالي المبيعات"]);

                    row["الرصيد"] =
                        purchases - sales;
                }

                dgvStock.DataSource = table;

                if (dgvStock.Columns["ItemId"] != null)
                {
                    dgvStock.Columns["ItemId"].Visible = false;
                }

                FormatGrid();
                CalculateTotals();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تحميل تقرير المخزون:\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            if (dgvStock.Columns["رقم الصنف"] != null)
                dgvStock.Columns["رقم الصنف"].HeaderText =
                    "رقم الصنف";

            if (dgvStock.Columns["اسم الصنف"] != null)
                dgvStock.Columns["اسم الصنف"].HeaderText =
                    "اسم الصنف";

            if (dgvStock.Columns["الوحدة"] != null)
                dgvStock.Columns["الوحدة"].HeaderText =
                    "الوحدة";

            if (dgvStock.Columns["إجمالي المشتريات"] != null)
                dgvStock.Columns["إجمالي المشتريات"].HeaderText =
                    "المشتريات";

            if (dgvStock.Columns["إجمالي المبيعات"] != null)
                dgvStock.Columns["إجمالي المبيعات"].HeaderText =
                    "المبيعات";

            if (dgvStock.Columns["الرصيد"] != null)
                dgvStock.Columns["الرصيد"].HeaderText =
                    "الرصيد";

            foreach (DataGridViewColumn column in dgvStock.Columns)
            {
                column.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }

            dgvStock.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
        }

        private void CalculateTotals()
        {
            decimal totalPurchases = 0;
            decimal totalSales = 0;
            decimal totalBalance = 0;

            foreach (DataGridViewRow row in dgvStock.Rows)
            {
                if (row.IsNewRow)
                    continue;

                totalPurchases +=
                    Convert.ToDecimal(
                        row.Cells["إجمالي المشتريات"].Value);

                totalSales +=
                    Convert.ToDecimal(
                        row.Cells["إجمالي المبيعات"].Value);

                totalBalance +=
                    Convert.ToDecimal(
                        row.Cells["الرصيد"].Value);
            }

            lblTotalPurchase.Text =
                $"المشتريات: {totalPurchases:N2}";

            lblTotalSales.Text =
                $"المبيعات: {totalSales:N2}";

            lblTotalBalance.Text =
                $"الرصيد: {totalBalance:N2}";
        }

        private void BtnSearch_Click(
            object? sender,
            EventArgs e)
        {
            LoadStockReport();
        }

        private void BtnShowAll_Click(
            object? sender,
            EventArgs e)
        {
            cmbItem.SelectedIndex = 0;

            LoadStockReport();
        }
    }
}