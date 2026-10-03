
using System.Data;
using AccountingSystemForWindowsFormLast.Models;
using AccountingSystemForWindowsFormLast.Data;
using Microsoft.Data.SqlClient;

namespace AccountingSystemForWindowsFormLast.Services
{
    public class VoucherService
    {
        private readonly JournalService journalService;

        public VoucherService()
        {
            journalService = new JournalService();
        }

        public string GetNextPaymentVoucherNumber()
        {
            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            const string sql = @"
                SELECT ISNULL(
                    MAX(TRY_CAST(VoucherNumber AS INT)),
                    0
                ) + 1
                FROM PaymentVouchers";

            using SqlCommand command = new SqlCommand(sql, connection);
            return Convert.ToInt32(command.ExecuteScalar()).ToString();
        }

        public string GetNextReceiptVoucherNumber()
        {
            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            const string sql = @"
                SELECT ISNULL(
                    MAX(TRY_CAST(VoucherNumber AS INT)),
                    0
                ) + 1
                FROM ReceiptVouchers";

            using SqlCommand command = new SqlCommand(sql, connection);
            return Convert.ToInt32(command.ExecuteScalar()).ToString();
        }

        public int SavePaymentVoucher(
            string voucherNumber,
            DateTime voucherDate,
            decimal amount,
            int beneficiaryAccountId,
            int paymentAccountId,
            string notes)
        {
            if (string.IsNullOrWhiteSpace(voucherNumber))
                throw new ArgumentException("رقم سند الصرف مطلوب.");

            if (amount <= 0)
                throw new ArgumentException("المبلغ يجب أن يكون أكبر من صفر.");

            if (beneficiaryAccountId <= 0)
                throw new ArgumentException("يرجى اختيار الحساب المستفيد.");

            if (paymentAccountId <= 0)
                throw new ArgumentException("يرجى اختيار حساب الدفع.");

            if (beneficiaryAccountId == paymentAccountId)
                throw new ArgumentException("لا يمكن أن يكون الحساب المستفيد هو نفس حساب الدفع.");

            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            using SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                const string voucherSql = @"
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

                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                int voucherId;
                using (SqlCommand command = new SqlCommand(voucherSql, connection, transaction))
                {
                    command.Parameters.Add("@VoucherNumber", SqlDbType.NVarChar, 50).Value = voucherNumber.Trim();
                    command.Parameters.Add("@VoucherDate", SqlDbType.Date).Value = voucherDate.Date;
                    command.Parameters.Add("@Amount", SqlDbType.Decimal).Value = amount;
                    command.Parameters.Add("@AccountId", SqlDbType.Int).Value = beneficiaryAccountId;
                    command.Parameters.Add("@Notes", SqlDbType.NVarChar, 500).Value =
                        string.IsNullOrWhiteSpace(notes) ? DBNull.Value : notes.Trim();

                    voucherId = Convert.ToInt32(command.ExecuteScalar());
                }

                string description = $"سند صرف رقم {voucherNumber}";
                if (!string.IsNullOrWhiteSpace(notes))
                {
                    description += $" - {notes.Trim()}";
                }

                journalService.CreateJournalEntry(
                    connection,
                    transaction,
                    voucherDate,
                    description,
                    new[]
                    {
                        new JournalLine
                        {
                            AccountId = beneficiaryAccountId,
                            Debit = amount,
                            Credit = 0,
                            Description = description
                        },
                        new JournalLine
                        {
                            AccountId = paymentAccountId,
                            Debit = 0,
                            Credit = amount,
                            Description = description
                        }
                    });

                transaction.Commit();
                return voucherId;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public int SaveReceiptVoucher(
            string voucherNumber,
            DateTime voucherDate,
            decimal amount,
            int sourceAccountId,
            int receiptAccountId,
            string notes)
        {
            if (string.IsNullOrWhiteSpace(voucherNumber))
                throw new ArgumentException("رقم سند القبض مطلوب.");

            if (amount <= 0)
                throw new ArgumentException("المبلغ يجب أن يكون أكبر من صفر.");

            if (sourceAccountId <= 0)
                throw new ArgumentException("يرجى اختيار الحساب المستلم منه.");

            if (receiptAccountId <= 0)
                throw new ArgumentException("يرجى اختيار حساب القبض (الصندوق / البنك).");

            if (sourceAccountId == receiptAccountId)
                throw new ArgumentException("لا يمكن أن يكون حساب المستلم منه هو نفس حساب القبض.");

            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            using SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                const string voucherSql = @"
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

                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                int voucherId;
                using (SqlCommand command = new SqlCommand(voucherSql, connection, transaction))
                {
                    command.Parameters.Add("@VoucherNumber", SqlDbType.NVarChar, 50).Value = voucherNumber.Trim();
                    command.Parameters.Add("@VoucherDate", SqlDbType.Date).Value = voucherDate.Date;
                    command.Parameters.Add("@Amount", SqlDbType.Decimal).Value = amount;
                    command.Parameters.Add("@AccountId", SqlDbType.Int).Value = sourceAccountId;
                    command.Parameters.Add("@Notes", SqlDbType.NVarChar, 500).Value =
                        string.IsNullOrWhiteSpace(notes) ? DBNull.Value : notes.Trim();

                    voucherId = Convert.ToInt32(command.ExecuteScalar());
                }

                string description = $"سند قبض رقم {voucherNumber}";
                if (!string.IsNullOrWhiteSpace(notes))
                {
                    description += $" - {notes.Trim()}";
                }

                journalService.CreateJournalEntry(
                    connection,
                    transaction,
                    voucherDate,
                    description,
                    new[]
                    {
                        new JournalLine
                        {
                            AccountId = receiptAccountId,
                            Debit = amount,
                            Credit = 0,
                            Description = description
                        },
                        new JournalLine
                        {
                            AccountId = sourceAccountId,
                            Debit = 0,
                            Credit = amount,
                            Description = description
                        }
                    });

                transaction.Commit();
                return voucherId;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
