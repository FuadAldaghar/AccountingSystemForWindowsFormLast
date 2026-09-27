using AccountingSystemForWindowsFormLast.Data;
using Microsoft.Data.SqlClient;

namespace AccountingSystemForWindowsFormLast.Forms
{
    public partial class ReceiptVoucher : Form
    {
        public ReceiptVoucher()
        {
            InitializeComponent();

            btnNew.Click += btnNew_Click;
            btnSave.Click += btnSave_Click;
        }

        private void ReceiptVoucher_Load(
            object? sender,
            EventArgs e)
        {
            LoadAccounts();
            LoadCashAccounts();
            GenerateVoucherNumber();

            ClearVoucher();
        }

        // ==========================================
        // تحميل الحسابات المستلمة
        // ==========================================

        private void LoadAccounts()
        {
            try
            {
                using SqlConnection connection =
                    DatabaseConnection.GetConnection();

                connection.Open();

                const string sql = @"
                    SELECT
                        AccountId,
                        AccountNumber,
                        AccountName
                    FROM Accounts
                    WHERE IsGroup = 0
                    ORDER BY AccountNumber";

                using SqlCommand command =
                    new SqlCommand(
                        sql,
                        connection);

                using SqlDataReader reader =
                    command.ExecuteReader();

                cmbAccount.Items.Clear();

                while (reader.Read())
                {
                    cmbAccount.Items.Add(
                        new AccountItem
                        {
                            Id = Convert.ToInt32(
                                reader["AccountId"]),

                            Number =
                                reader["AccountNumber"]
                                ?.ToString() ?? "",

                            Name =
                                reader["AccountName"]
                                ?.ToString() ?? ""
                        });
                }

                cmbAccount.DisplayMember =
                    "DisplayText";

                cmbAccount.ValueMember =
                    "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تحميل الحسابات:\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // حسابات القبض
        //
        // نعرض حسابات الأصل فقط
        // حتى يكون المقبوض فعلياً من صندوق/بنك.
        // ==========================================

        private void LoadCashAccounts()
        {
            try
            {
                using SqlConnection connection =
                    DatabaseConnection.GetConnection();

                connection.Open();

                const string sql = @"
                    SELECT
                        AccountId,
                        AccountNumber,
                        AccountName
                    FROM Accounts
                    WHERE IsGroup = 0
                      AND AccountType = N'أصل'
                    ORDER BY AccountNumber";

                using SqlCommand command =
                    new SqlCommand(
                        sql,
                        connection);

                using SqlDataReader reader =
                    command.ExecuteReader();

                cmbCashAccount.Items.Clear();

                while (reader.Read())
                {
                    cmbCashAccount.Items.Add(
                        new AccountItem
                        {
                            Id = Convert.ToInt32(
                                reader["AccountId"]),

                            Number =
                                reader["AccountNumber"]
                                ?.ToString() ?? "",

                            Name =
                                reader["AccountName"]
                                ?.ToString() ?? ""
                        });
                }

                cmbCashAccount.DisplayMember =
                    "DisplayText";

                cmbCashAccount.ValueMember =
                    "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تحميل حسابات القبض:\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // توليد رقم السند
        // ==========================================

        private void GenerateVoucherNumber()
        {
            try
            {
                using SqlConnection connection =
                    DatabaseConnection.GetConnection();

                connection.Open();

                const string sql = @"
                    SELECT ISNULL(
                        MAX(
                            TRY_CAST(VoucherNumber AS INT)
                        ),
                        0
                    ) + 1
                    FROM ReceiptVouchers";

                using SqlCommand command =
                    new SqlCommand(
                        sql,
                        connection);

                txtVoucherNumber.Text =
                    Convert.ToInt32(
                        command.ExecuteScalar())
                    .ToString();
            }
            catch
            {
                txtVoucherNumber.Text = "1";
            }
        }

        // ==========================================
        // زر جديد
        // ==========================================

        private void btnNew_Click(
            object? sender,
            EventArgs e)
        {
            ClearVoucher();
        }

        private void ClearVoucher()
        {
            GenerateVoucherNumber();

            dtpVoucherDate.Value =
                DateTime.Today;

            cmbAccount.SelectedIndex = -1;
            cmbCashAccount.SelectedIndex = -1;

            nudAmount.Value = 0;

            txtNotes.Clear();
        }

        // ==========================================
        // حفظ سند القبض
        // ==========================================

        private void btnSave_Click(
            object? sender,
            EventArgs e)
        {
            if (cmbAccount.SelectedItem
                is not AccountItem sourceAccount)
            {
                MessageBox.Show(
                    "اختر الحساب المستلم منه.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (cmbCashAccount.SelectedItem
                is not AccountItem cashAccount)
            {
                MessageBox.Show(
                    "اختر حساب القبض.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            decimal amount =
                nudAmount.Value;

            if (amount <= 0)
            {
                MessageBox.Show(
                    "المبلغ يجب أن يكون أكبر من صفر.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (sourceAccount.Id ==
                cashAccount.Id)
            {
                MessageBox.Show(
                    "لا يمكن أن يكون الحساب المستلم منه هو نفس حساب القبض.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                using SqlConnection connection =
                    DatabaseConnection.GetConnection();

                connection.Open();

                using SqlTransaction transaction =
                    connection.BeginTransaction();

                try
                {
                    // ==================================
                    // 1. حفظ رأس سند القبض
                    // ==================================

                    int voucherId =
                        InsertVoucher(
                            connection,
                            transaction,
                            sourceAccount.Id);

                    // ==================================
                    // 2. إنشاء القيد المحاسبي
                    //
                    // مدين  : الصندوق / البنك
                    // دائن  : الحساب المستلم منه
                    // ==================================

                    CreateJournalEntry(
                        connection,
                        transaction,
                        cashAccount.Id,
                        sourceAccount.Id,
                        amount);

                    // ==================================
                    // 3. تثبيت العملية كاملة
                    // ==================================

                    transaction.Commit();

                    MessageBox.Show(
                        "تم حفظ سند القبض والقيد المحاسبي بنجاح.",
                        "نجاح",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearVoucher();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "تعذر حفظ سند القبض:\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // إدخال سند القبض
        // ==========================================

        private int InsertVoucher(
            SqlConnection connection,
            SqlTransaction transaction,
            int accountId)
        {
            const string sql = @"
                INSERT INTO ReceiptVouchers
                (
                    VoucherNumber,
                    VoucherDate,
                    Amount,
                    AccountId,
                    Notes
                )
                VALUES
                (
                    @VoucherNumber,
                    @VoucherDate,
                    @Amount,
                    @AccountId,
                    @Notes
                );

                SELECT CAST(
                    SCOPE_IDENTITY()
                    AS INT
                );";

            using SqlCommand command =
                new SqlCommand(
                    sql,
                    connection,
                    transaction);

            command.Parameters.AddWithValue(
                "@VoucherNumber",
                txtVoucherNumber.Text);

            command.Parameters.AddWithValue(
                "@VoucherDate",
                dtpVoucherDate.Value.Date);

            command.Parameters.AddWithValue(
                "@Amount",
                nudAmount.Value);

            command.Parameters.AddWithValue(
                "@AccountId",
                accountId);

            command.Parameters.AddWithValue(
                "@Notes",
                string.IsNullOrWhiteSpace(
                    txtNotes.Text)
                    ? DBNull.Value
                    : txtNotes.Text.Trim());

            return Convert.ToInt32(
                command.ExecuteScalar());
        }

        // ==========================================
        // إنشاء القيد
        // ==========================================

        private void CreateJournalEntry(
            SqlConnection connection,
            SqlTransaction transaction,
            int debitAccountId,
            int creditAccountId,
            decimal amount)
        {
            string entryNumber =
                GenerateJournalEntryNumber(
                    connection,
                    transaction);

            // --------------------------------------
            // رأس القيد
            // --------------------------------------

            const string headerSql = @"
                INSERT INTO JournalEntries
                (
                    EntryNumber,
                    EntryDate,
                    Description
                )
                VALUES
                (
                    @EntryNumber,
                    @EntryDate,
                    @Description
                );

                SELECT CAST(
                    SCOPE_IDENTITY()
                    AS INT
                );";

            int journalEntryId;

            using (SqlCommand command =
                   new SqlCommand(
                       headerSql,
                       connection,
                       transaction))
            {
                command.Parameters.AddWithValue(
                    "@EntryNumber",
                    entryNumber);

                command.Parameters.AddWithValue(
                    "@EntryDate",
                    dtpVoucherDate.Value.Date);

                command.Parameters.AddWithValue(
                    "@Description",
                    $"سند قبض رقم {txtVoucherNumber.Text}");

                journalEntryId =
                    Convert.ToInt32(
                        command.ExecuteScalar());
            }

            // --------------------------------------
            // مدين: الصندوق / البنك
            // --------------------------------------

            InsertJournalDetail(
                connection,
                transaction,
                journalEntryId,
                debitAccountId,
                amount,
                0,
                "قبض نقدية");

            // --------------------------------------
            // دائن: الحساب المستلم منه
            // --------------------------------------

            InsertJournalDetail(
                connection,
                transaction,
                journalEntryId,
                creditAccountId,
                0,
                amount,
                "الحساب المقابل لسند القبض");
        }

        // ==========================================
        // رقم القيد
        // ==========================================

        private string GenerateJournalEntryNumber(
            SqlConnection connection,
            SqlTransaction transaction)
        {
            const string sql = @"
                SELECT ISNULL(
                    MAX(
                        TRY_CAST(
                            EntryNumber AS INT
                        )
                    ),
                    0
                ) + 1
                FROM JournalEntries";

            using SqlCommand command =
                new SqlCommand(
                    sql,
                    connection,
                    transaction);

            return Convert.ToInt32(
                command.ExecuteScalar())
                .ToString();
        }

        // ==========================================
        // تفاصيل القيد
        // ==========================================

        private void InsertJournalDetail(
            SqlConnection connection,
            SqlTransaction transaction,
            int journalEntryId,
            int accountId,
            decimal debit,
            decimal credit,
            string description)
        {
            if (debit > 0 && credit > 0)
            {
                throw new Exception(
                    "لا يجوز أن يحتوي سطر القيد على مدين ودائن في نفس الوقت.");
            }

            if (debit <= 0 && credit <= 0)
            {
                throw new Exception(
                    "يجب أن يحتوي سطر القيد على مبلغ مدين أو دائن.");
            }

            const string sql = @"
                INSERT INTO JournalEntryDetails
                (
                    JournalEntryId,
                    AccountId,
                    Debit,
                    Credit,
                    Description
                )
                VALUES
                (
                    @JournalEntryId,
                    @AccountId,
                    @Debit,
                    @Credit,
                    @Description
                )";

            using SqlCommand command =
                new SqlCommand(
                    sql,
                    connection,
                    transaction);

            command.Parameters.AddWithValue(
                "@JournalEntryId",
                journalEntryId);

            command.Parameters.AddWithValue(
                "@AccountId",
                accountId);

            command.Parameters.AddWithValue(
                "@Debit",
                debit);

            command.Parameters.AddWithValue(
                "@Credit",
                credit);

            command.Parameters.AddWithValue(
                "@Description",
                description);

            command.ExecuteNonQuery();
        }

        // ==========================================
        // Account Item
        // ==========================================

        private class AccountItem
        {
            public int Id { get; set; }

            public string Number { get; set; } = "";

            public string Name { get; set; } = "";

            public string DisplayText =>
                $"{Number} - {Name}";
        }
    }
}