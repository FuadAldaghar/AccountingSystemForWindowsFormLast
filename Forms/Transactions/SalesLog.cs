using System.Data;
using AccountingSystemForWindowsFormLast.Data;
using AccountingSystemForWindowsFormLast.Helpers;
using Microsoft.Data.SqlClient;

namespace AccountingSystemForWindowsFormLast.Forms
{
    public partial class SalesLog : Form
    {
        private DataTable _salesTable = new();

        public SalesLog()
        {
            InitializeComponent();

            UiTheme.Apply(this);
            UiTheme.StyleButton(btnSearch, Accent.Primary);
            UiTheme.StyleButton(btnClear, Accent.Neutral);
        }

        private void SalesLog_Load(object? sender, EventArgs e)
        {
            try
            {
                dtpFromDate.Value = DateTime.Today.AddMonths(-1);
                dtpToDate.Value = DateTime.Today;

                cmbPaymentType.SelectedIndex = 0;

                LoadItems();
                LoadAccounts();
                LoadSales();
            }
            catch (Exception ex)
            {
                ShowError("تعذر تحميل سجل المبيعات.", ex);
            }
        }

        private void LoadItems()
        {
            const string sql = @"
                SELECT
                    ItemId,
                    ItemNumber,
                    ItemName
                FROM Items
                ORDER BY ItemNumber;";

            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            DataTable table = new();
            table.Columns.Add("ItemId", typeof(int));
            table.Columns.Add("DisplayText", typeof(string));

            table.Rows.Add(DBNull.Value, "الكل");

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["ItemId"]);
                string number = reader["ItemNumber"]?.ToString() ?? "";
                string name = reader["ItemName"]?.ToString() ?? "";

                table.Rows.Add(id, $"{number} - {name}");
            }

            cmbItem.DataSource = table;
            cmbItem.DisplayMember = "DisplayText";
            cmbItem.ValueMember = "ItemId";
            cmbItem.SelectedIndex = 0;
        }

        private void LoadAccounts()
        {
            const string sql = @"
                SELECT
                    AccountId,
                    AccountNumber,
                    AccountName
                FROM Accounts
                WHERE IsGroup = 0
                ORDER BY AccountNumber;";

            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            DataTable table = new();
            table.Columns.Add("AccountId", typeof(int));
            table.Columns.Add("DisplayText", typeof(string));

            table.Rows.Add(DBNull.Value, "الكل");

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["AccountId"]);
                string number = reader["AccountNumber"]?.ToString() ?? "";
                string name = reader["AccountName"]?.ToString() ?? "";

                table.Rows.Add(id, $"{number} - {name}");
            }

            cmbAccount.DataSource = table;
            cmbAccount.DisplayMember = "DisplayText";
            cmbAccount.ValueMember = "AccountId";
            cmbAccount.SelectedIndex = 0;
        }

        private void LoadSales()
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date;

                if (fromDate > toDate)
                {
                    MessageBox.Show(
                        "تاريخ البداية يجب أن يكون قبل أو مساويًا لتاريخ النهاية.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                const string sql = @"
SELECT
    si.SalesInvoiceId,
    si.InvoiceNumber,
    si.InvoiceDate,
    si.PaymentType,
    a.AccountNumber,
    a.AccountName,
    i.ItemNumber,
    i.ItemName,
    i.Unit,
    sid.Quantity,
    sid.UnitPrice,
    (sid.Quantity * sid.UnitPrice) AS LineTotal
FROM SalesInvoices si
INNER JOIN SalesInvoiceDetails sid
    ON sid.SalesInvoiceId = si.SalesInvoiceId
INNER JOIN Items i
    ON i.ItemId = sid.ItemId
INNER JOIN Accounts a
    ON a.AccountId = si.AccountId
WHERE
    si.InvoiceDate >= @FromDate
    AND si.InvoiceDate < DATEADD(DAY, 1, @ToDate)
    AND
    (
        @InvoiceNumber = ''
        OR si.InvoiceNumber LIKE '%' + @InvoiceNumber + '%'
    )
    AND
    (
        @ItemId IS NULL
        OR sid.ItemId = @ItemId
    )
    AND
    (
        @AccountId IS NULL
        OR si.AccountId = @AccountId
    )
    AND
    (
        @PaymentType = ''
        OR si.PaymentType = @PaymentType
    )
ORDER BY
    si.InvoiceDate DESC,
    si.SalesInvoiceId DESC,
    i.ItemNumber;";

                using SqlConnection connection = DatabaseConnection.GetConnection();
                using SqlCommand command = new(sql, connection);

                command.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = fromDate;
                command.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = toDate;
                command.Parameters.Add("@InvoiceNumber", SqlDbType.NVarChar, 50)
                    .Value = txtInvoiceNumber.Text.Trim();

                command.Parameters.Add("@ItemId", SqlDbType.Int).Value =
                    GetNullableComboInt(cmbItem);

                command.Parameters.Add("@AccountId", SqlDbType.Int).Value =
                    GetNullableComboInt(cmbAccount);

                string paymentType =
                    cmbPaymentType.SelectedIndex <= 0
                        ? ""
                        : cmbPaymentType.Text.Trim();

                command.Parameters.Add("@PaymentType", SqlDbType.NVarChar, 50)
                    .Value = paymentType;

                DataTable table = new();

                connection.Open();

                using SqlDataAdapter adapter = new(command);
                adapter.Fill(table);

                _salesTable = table;
                dgvSales.DataSource = _salesTable;

                ConfigureGrid();
                UpdateSummary();
            }
            catch (Exception ex)
            {
                ShowError("تعذر تحميل بيانات المبيعات.", ex);
            }
        }

        private static int? GetNullableComboInt(ComboBox comboBox)
        {
            if (comboBox.SelectedValue == null ||
                comboBox.SelectedValue == DBNull.Value)
                return null;

            if (comboBox.SelectedValue is DataRowView)
                return null;

            if (int.TryParse(comboBox.SelectedValue.ToString(), out int value))
                return value;

            return null;
        }

        private void ConfigureGrid()
        {
            if (dgvSales.Columns.Count == 0)
                return;

            SetHeader("InvoiceNumber", "رقم الفاتورة");
            SetHeader("InvoiceDate", "التاريخ");
            SetHeader("PaymentType", "نوع البيع");
            SetHeader("AccountNumber", "رقم الحساب");
            SetHeader("AccountName", "الحساب");
            SetHeader("ItemNumber", "رقم الصنف");
            SetHeader("ItemName", "الصنف");
            SetHeader("Unit", "الوحدة");
            SetHeader("Quantity", "الكمية");
            SetHeader("UnitPrice", "سعر الوحدة");
            SetHeader("LineTotal", "الإجمالي");

            HideColumn("SalesInvoiceId");

            dgvSales.Columns["InvoiceDate"].DefaultCellStyle.Format = "yyyy/MM/dd";
            dgvSales.Columns["Quantity"].DefaultCellStyle.Format = "N2";
            dgvSales.Columns["UnitPrice"].DefaultCellStyle.Format = "N2";
            dgvSales.Columns["LineTotal"].DefaultCellStyle.Format = "N2";

            dgvSales.Columns["Quantity"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvSales.Columns["UnitPrice"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvSales.Columns["LineTotal"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvSales.ClearSelection();
            dgvSales.CurrentCell = null;
        }

        private void UpdateSummary()
        {
            int count = 0;
            decimal total = 0;

            foreach (DataRow row in _salesTable.Rows)
            {
                count++;
                total += row.Field<decimal?>("LineTotal") ?? 0;
            }

            lblCount.Text = count.ToString("N0");
            lblTotal.Text = total.ToString("N2");
        }

        private void SetHeader(string columnName, string headerText)
        {
            if (dgvSales.Columns.Contains(columnName))
                dgvSales.Columns[columnName].HeaderText = headerText;
        }

        private void HideColumn(string columnName)
        {
            if (dgvSales.Columns.Contains(columnName))
                dgvSales.Columns[columnName].Visible = false;
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            LoadSales();
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            dtpFromDate.Value = DateTime.Today.AddMonths(-1);
            dtpToDate.Value = DateTime.Today;
            txtInvoiceNumber.Clear();

            if (cmbItem.Items.Count > 0)
                cmbItem.SelectedIndex = 0;

            if (cmbAccount.Items.Count > 0)
                cmbAccount.SelectedIndex = 0;

            cmbPaymentType.SelectedIndex = 0;

            LoadSales();
        }

        private void txtInvoiceNumber_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadSales();
            }
        }

        private void ShowError(string message, Exception ex)
        {
            MessageBox.Show(
                message + Environment.NewLine + ex.Message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
