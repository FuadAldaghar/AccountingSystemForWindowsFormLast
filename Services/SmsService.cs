using System.Data;
using AccountingSystemForWindowsFormLast.Data;
using AccountingSystemForWindowsFormLast.Models;
using Microsoft.Data.SqlClient;

namespace AccountingSystemForWindowsFormLast.Services
{
    public sealed class SmsService
    {
        private readonly SmsGatewayClient _gatewayClient;

        public SmsService(SmsGatewayClient? gatewayClient = null)
        {
            _gatewayClient = gatewayClient ?? new SmsGatewayClient();
        }

        public async Task<SmsMessage> SendAsync(
            SmsMessage message,
            CancellationToken cancellationToken = default)
        {
            ValidateMessage(message);

            message.PhoneNumber = NormalizeYemenPhone(message.PhoneNumber);
            message.Status = "Pending";

            int smsId = InsertPending(message);
            message.SmsMessageId = smsId;

            try
            {
                SmsGatewayResult result = await _gatewayClient.SendAsync(
                    message.PhoneNumber,
                    message.MessageText,
                    cancellationToken);

                message.Status = "Sent";
                message.ProviderMessageId = result.ProviderMessageId;
                message.ProviderResponse = result.ProviderResponse;
                message.ErrorMessage = null;
                message.SentAt = DateTime.Now;

                UpdateResult(message);

                return message;
            }
            catch (Exception ex)
            {
                message.Status = "Failed";
                message.ErrorMessage = ex.Message;

                try
                {
                    UpdateResult(message);
                }
                catch
                {
                    // Keep the original send exception as the meaningful error.
                }

                throw;
            }
        }

        private static void ValidateMessage(SmsMessage message)
        {
            if (message.AccountId <= 0)
                throw new ArgumentException("الحساب غير صالح.");

            if (string.IsNullOrWhiteSpace(message.AccountName))
                throw new ArgumentException("اسم الحساب مطلوب.");

            if (string.IsNullOrWhiteSpace(message.PhoneNumber))
                throw new ArgumentException("رقم الجوال مطلوب.");

            if (string.IsNullOrWhiteSpace(message.MessageText))
                throw new ArgumentException("نص الرسالة مطلوب.");

            if (message.MessageText.Length > 2000)
                throw new ArgumentException("نص الرسالة يتجاوز الحد المسموح.");
        }

        public static string NormalizeYemenPhone(string phone)
        {
            string value = new string(phone.Where(char.IsDigit).ToArray());

            if (value.StartsWith("00967"))
                value = value[2..];

            if (value.StartsWith("967"))
            {
                if (value.Length != 12)
                    throw new ArgumentException(
                        "رقم اليمن يجب أن يكون بصيغة 967XXXXXXXXX.");

                return value;
            }

            if (value.StartsWith("0"))
                value = value[1..];

            if (value.Length == 9 && value.StartsWith("7"))
                return "967" + value;

            throw new ArgumentException(
                "أدخل رقم جوال يمني صحيح، مثال: 777123456 أو 967777123456.");
        }

        private static int InsertPending(SmsMessage message)
        {
            const string sql = @"
                INSERT INTO SmsMessages
                (
                    AccountId,
                    AccountName,
                    AccountNature,
                    PhoneNumber,
                    StatementFromDate,
                    StatementToDate,
                    Balance,
                    DebitAmount,
                    CreditAmount,
                    MessageText,
                    Status
                )
                VALUES
                (
                    @AccountId,
                    @AccountName,
                    @AccountNature,
                    @PhoneNumber,
                    @StatementFromDate,
                    @StatementToDate,
                    @Balance,
                    @DebitAmount,
                    @CreditAmount,
                    @MessageText,
                    @Status
                );

                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            using SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.Add("@AccountId", SqlDbType.Int).Value =
                message.AccountId;

            command.Parameters.Add("@AccountName", SqlDbType.NVarChar, 200).Value =
                message.AccountName.Trim();

            command.Parameters.Add("@AccountNature", SqlDbType.NVarChar, 20).Value =
                message.AccountNature.Trim();

            command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar, 30).Value =
                message.PhoneNumber;

            command.Parameters.Add("@StatementFromDate", SqlDbType.Date).Value =
                message.StatementFromDate.HasValue
                    ? message.StatementFromDate.Value.Date
                    : DBNull.Value;

            command.Parameters.Add("@StatementToDate", SqlDbType.Date).Value =
                message.StatementToDate.HasValue
                    ? message.StatementToDate.Value.Date
                    : DBNull.Value;

            AddDecimal(command, "@Balance", message.Balance);
            AddDecimal(command, "@DebitAmount", message.DebitAmount);
            AddDecimal(command, "@CreditAmount", message.CreditAmount);

            command.Parameters.Add("@MessageText", SqlDbType.NVarChar, 2000).Value =
                message.MessageText;

            command.Parameters.Add("@Status", SqlDbType.NVarChar, 20).Value =
                message.Status;

            return Convert.ToInt32(command.ExecuteScalar());
        }

        private static void UpdateResult(SmsMessage message)
        {
            const string sql = @"
                UPDATE SmsMessages
                SET
                    PhoneNumber = @PhoneNumber,
                    Status = @Status,
                    ProviderMessageId = @ProviderMessageId,
                    ProviderResponse = @ProviderResponse,
                    ErrorMessage = @ErrorMessage,
                    SentAt = @SentAt
                WHERE SmsMessageId = @SmsMessageId";

            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            using SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.Add("@SmsMessageId", SqlDbType.Int).Value =
                message.SmsMessageId;

            command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar, 30).Value =
                message.PhoneNumber;

            command.Parameters.Add("@Status", SqlDbType.NVarChar, 20).Value =
                message.Status;

            command.Parameters.Add("@ProviderMessageId", SqlDbType.NVarChar, 200).Value =
                (object?)message.ProviderMessageId ?? DBNull.Value;

            command.Parameters.Add("@ProviderResponse", SqlDbType.NVarChar, -1).Value =
                (object?)message.ProviderResponse ?? DBNull.Value;

            command.Parameters.Add("@ErrorMessage", SqlDbType.NVarChar, 2000).Value =
                (object?)message.ErrorMessage ?? DBNull.Value;

            command.Parameters.Add("@SentAt", SqlDbType.DateTime2).Value =
                message.SentAt.HasValue
                    ? message.SentAt.Value
                    : DBNull.Value;

            command.ExecuteNonQuery();
        }

        private static void AddDecimal(
            SqlCommand command,
            string parameterName,
            decimal value)
        {
            SqlParameter parameter =
                command.Parameters.Add(parameterName, SqlDbType.Decimal);

            parameter.Precision = 18;
            parameter.Scale = 2;
            parameter.Value = value;
        }
    }
}
