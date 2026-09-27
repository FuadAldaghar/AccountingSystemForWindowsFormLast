using System.Data;
using AccountingSystemForWindowsFormLast.Data;
using Microsoft.Data.SqlClient;

namespace AccountingSystemForWindowsFormLast.Forms
{
    public partial class AccountStatement : Form
    {
        public AccountStatement()
        {
            InitializeComponent();

            btnSearch.Click += BtnSearch_Click;
            btnShowAll.Click += BtnShowAll_Click;
        }

        private void AccountStatement_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value =
                new DateTime(DateTime.Today.Year, 1, 1);

            dtpToDate.Value = DateTime.Today;

            LoadAccounts();
        }

        private void LoadAccounts()
        {
            try
            {
                using SqlConnection connection =
                    DatabaseConnection.GetConnection();

                connection.Open();

                string query = @"
                    SELECT
                        AccountId,
                        AccountNumber,
                        AccountName,
                        AccountNature
                    FROM Accounts
                    WHERE IsGroup = 0
                    ORDER BY AccountNumber";

                using SqlCommand command =
                    new SqlCommand(query, connection);

                using SqlDataReader reader =
                    command.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(reader);

                cmbAccount.DataSource = table;

                cmbAccount.DisplayMember = "AccountName";
                cmbAccount.ValueMember = "AccountId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تحميل الحسابات:\n" + ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadStatement()
        {
            try
            {
                if (cmbAccount.SelectedValue == null)
                {
                    MessageBox.Show(
                        "اختر الحساب أولاً.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (dtpFromDate.Value.Date > dtpToDate.Value.Date)
                {
                    MessageBox.Show(
                        "تاريخ البداية يجب أن يكون قبل تاريخ النهاية.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                int accountId =
                    Convert.ToInt32(cmbAccount.SelectedValue);

                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date;

                using SqlConnection connection =
                    DatabaseConnection.GetConnection();

                connection.Open();

                string natureQuery = @"
                    SELECT AccountNature
                    FROM Accounts
                    WHERE AccountId = @AccountId";

                string accountNature;

                using (SqlCommand natureCommand =
                    new SqlCommand(natureQuery, connection))
                {
                    natureCommand.Parameters.AddWithValue(
                        "@AccountId",
                        accountId);

                    object? result =
                        natureCommand.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show(
                            "الحساب غير موجود.",
                            "تنبيه",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    accountNature = result.ToString() ?? "مدين";
                }

                // الرصيد السابق لتاريخ البداية
                string openingQuery = @"
                    SELECT
                        ISNULL(SUM(Debit), 0),
                        ISNULL(SUM(Credit), 0)
                    FROM JournalEntryDetails jed
                    INNER JOIN JournalEntries je
                        ON je.JournalEntryId = jed.JournalEntryId
                    WHERE jed.AccountId = @AccountId
                      AND je.EntryDate < @FromDate";

                decimal previousDebit = 0;
                decimal previousCredit = 0;

                using (SqlCommand openingCommand =
                    new SqlCommand(openingQuery, connection))
                {
                    openingCommand.Parameters.AddWithValue(
                        "@AccountId",
                        accountId);

                    openingCommand.Parameters.AddWithValue(
                        "@FromDate",
                        fromDate);

                    using SqlDataReader reader2 = openingCommand.ExecuteReader();

                
                    if (reader2.Read())
                    {
                        previousDebit =
                            Convert.ToDecimal(reader2.GetValue(0));

                        previousCredit =
                            Convert.ToDecimal(reader2.GetValue(1));
                    }
                }

                decimal openingBalance;

                if (accountNature == "دائن")
                {
                    openingBalance =
                        previousCredit - previousDebit;
                }
                else
                {
                    openingBalance =
                        previousDebit - previousCredit;
                }

                // حركة الحساب داخل الفترة
                string statementQuery = @"
                    SELECT
                        je.EntryDate AS [التاريخ],
                        je.EntryNumber AS [رقم القيد],
                        je.Description AS [البيان],
                        jed.Debit AS [مدين],
                        jed.Credit AS [دائن]
                    FROM JournalEntryDetails jed
                    INNER JOIN JournalEntries je
                        ON je.JournalEntryId = jed.JournalEntryId
                    WHERE jed.AccountId = @AccountId
                      AND je.EntryDate >= @FromDate
                      AND je.EntryDate < DATEADD(DAY, 1, @ToDate)
                    ORDER BY
                        je.EntryDate,
                        je.JournalEntryId,
                        jed.JournalEntryDetailId";

                using SqlCommand command =
                    new SqlCommand(statementQuery, connection);

                command.Parameters.AddWithValue(
                    "@AccountId",
                    accountId);

                command.Parameters.AddWithValue(
                    "@FromDate",
                    fromDate);

                command.Parameters.AddWithValue(
                    "@ToDate",
                    toDate);

                using SqlDataReader reader =
                    command.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(reader);

                table.Columns.Add("الرصيد", typeof(decimal));

                decimal runningBalance = openingBalance;

                decimal totalDebit = 0;
                decimal totalCredit = 0;

                foreach (DataRow row in table.Rows)
                {
                    decimal debit =
                        Convert.ToDecimal(row["مدين"]);

                    decimal credit =
                        Convert.ToDecimal(row["دائن"]);

                    totalDebit += debit;
                    totalCredit += credit;

                    if (accountNature == "دائن")
                    {
                        runningBalance += credit - debit;
                    }
                    else
                    {
                        runningBalance += debit - credit;
                    }

                    row["الرصيد"] = runningBalance;
                }

                dgvStatement.DataSource = table;

                FormatGrid();

                lblOpeningBalance.Text =
                    openingBalance.ToString("N2");

                lblDebitTotal.Text =
                    totalDebit.ToString("N2");

                lblCreditTotal.Text =
                    totalCredit.ToString("N2");

                lblFinalBalance.Text =
                    runningBalance.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تحميل كشف الحساب:\n" + ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            if (dgvStatement.Columns["التاريخ"] != null)
            {
                dgvStatement.Columns["التاريخ"]
                    .DefaultCellStyle.Format = "yyyy-MM-dd";
            }

            foreach (DataGridViewColumn column in dgvStatement.Columns)
            {
                column.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }

            dgvStatement.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            LoadStatement();
        }

        private void BtnShowAll_Click(object? sender, EventArgs e)
        {
            dtpFromDate.Value =
                new DateTime(2000, 1, 1);

            dtpToDate.Value =
                DateTime.Today;

            LoadStatement();
        }
    }
}