using AccountingSystemForWindowsFormLast.Data;
using Microsoft.Data.SqlClient;

namespace AccountingSystemForWindowsFormLast.Forms
{
    public partial class PaymentVoucher : Form
    {
        public PaymentVoucher()
        {
            InitializeComponent();

            btnNew.Click += btnNew_Click;
            btnSave.Click += btnSave_Click;
        }

        // =========================================================
        // Form Load
        // =========================================================

        private void PaymentVoucher_Load(
            object? sender,
            EventArgs e)
        {
            LoadAccounts();
            LoadPaymentAccounts();

            GenerateVoucherNumber();

            ClearVoucher();
        }

        // =========================================================
        // تحميل الحسابات المستفيدة
        // =========================================================

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
                            Id =
                                Convert.ToInt32(
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

        // =========================================================
        // تحميل حسابات الدفع
        //
        // حساب الدفع يجب أن يكون من حسابات الأصل:
        // صندوق / بنك / حساب نقدي.
        // =========================================================

        private void LoadPaymentAccounts()
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
                            Id =
                                Convert.ToInt32(
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
                    "حدث خطأ أثناء تحميل حسابات الدفع:\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // توليد رقم سند الدفع
        // =========================================================

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
                            TRY_CAST(
                                VoucherNumber AS INT
                            )
                        ),
                        0
                    ) + 1
                    FROM PaymentVouchers";

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

        // =========================================================
        // سند جديد
        // =========================================================

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

            cmbAccount.SelectedIndex =
                -1;

            cmbCashAccount.SelectedIndex =
                -1;

            nudAmount.Value =
                0;

            txtNotes.Clear();
        }

        // =========================================================
        // حفظ سند الدفع
        // =========================================================

        private void btnSave_Click(
            object? sender,
            EventArgs e)
        {
            if (cmbAccount.SelectedItem
                is not AccountItem beneficiaryAccount)
            {
                MessageBox.Show(
                    "اختر الحساب المستفيد.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (cmbCashAccount.SelectedItem
                is not AccountItem paymentAccount)
            {
                MessageBox.Show(
                    "اختر حساب الدفع.",
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

            if (beneficiaryAccount.Id ==
                paymentAccount.Id)
            {
                MessageBox.Show(
                    "لا يمكن أن يكون الحساب المستفيد هو نفس حساب الدفع.",
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
                    // =============================================
                    // 1. حفظ رأس سند الدفع
                    // =============================================

                    int voucherId =
                        InsertVoucher(
                            connection,
                            transaction,
                            beneficiaryAccount.Id);

                    // =============================================
                    // 2. إنشاء القيد المحاسبي
                    //
                    // مدين  : الحساب المستفيد
                    // دائن  : الصندوق / البنك
                    // =============================================

                    CreateJournalEntry(
                        connection,
                        transaction,
                        beneficiaryAccount.Id,
                        paymentAccount.Id,
                        amount);

                    // =============================================
                    // 3. تثبيت العملية
                    // =============================================

                    transaction.Commit();

                    MessageBox.Show(
                        "تم حفظ سند الدفع والقيد المحاسبي بنجاح.",
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
                    "تعذر حفظ سند الدفع:\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // إدخال رأس سند الدفع
        // =========================================================

        private int InsertVoucher(
            SqlConnection connection,
            SqlTransaction transaction,
            int accountId)
        {
            const string sql = @"
                INSERT INTO PaymentVouchers
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

        // =========================================================
        // إنشاء القيد المحاسبي
        // =========================================================

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

            // =====================================================
            // رأس القيد
            // =====================================================

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
                    $"سند دفع رقم {txtVoucherNumber.Text}");

                journalEntryId =
                    Convert.ToInt32(
                        command.ExecuteScalar());
            }

            // =====================================================
            // الطرف المدين
            //
            // مثال:
            //
            // مدين: المورد
            // =====================================================

            InsertJournalDetail(
                connection,
                transaction,
                journalEntryId,
                debitAccountId,
                amount,
                0,
                "الحساب المستفيد من سند الدفع");

            // =====================================================
            // الطرف الدائن
            //
            // مثال:
            //
            // دائن: الصندوق
            // =====================================================

            InsertJournalDetail(
                connection,
                transaction,
                journalEntryId,
                creditAccountId,
                0,
                amount,
                "حساب الدفع");
        }

        // =========================================================
        // توليد رقم القيد
        // =========================================================

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

        // =========================================================
        // إضافة تفاصيل القيد
        // =========================================================

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

        // =========================================================
        // Account Item
        // =========================================================

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