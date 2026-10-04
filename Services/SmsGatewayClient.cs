using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AccountingSystemForWindowsFormLast.Services
{
    /// <summary>
    /// EasySendSMS REST client.
    ///
    /// Configuration is read from environment variables:
    /// ACCOUNTING_SMS_API_KEY
    /// ACCOUNTING_SMS_SENDER
    ///
    /// The endpoint can be overridden with:
    /// ACCOUNTING_SMS_API_URL
    /// </summary>
    public sealed class SmsGatewayClient
    {
        private const string DefaultApiUrl =
            "https://restapi.easysendsms.app/v1/rest/sms/send";

        private readonly HttpClient _httpClient;

        public SmsGatewayClient(HttpClient? httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(30)
            };
        }

        public async Task<SmsGatewayResult> SendAsync(
            string phoneNumber,
            string message,
            CancellationToken cancellationToken = default)
        {
            string apiKey =
                Environment.GetEnvironmentVariable("ACCOUNTING_SMS_API_KEY") ?? string.Empty;

            string sender =
                Environment.GetEnvironmentVariable("ACCOUNTING_SMS_SENDER") ?? string.Empty;

            string apiUrl =
                Environment.GetEnvironmentVariable("ACCOUNTING_SMS_API_URL")
                ?? DefaultApiUrl;

            if (string.IsNullOrWhiteSpace(apiKey))
                throw new InvalidOperationException(
                    "لم يتم إعداد مفتاح SMS API. عرّف المتغير ACCOUNTING_SMS_API_KEY.");

            if (string.IsNullOrWhiteSpace(sender))
                throw new InvalidOperationException(
                    "لم يتم إعداد اسم المرسل. عرّف المتغير ACCOUNTING_SMS_SENDER.");

            var payload = new
            {
                from = sender,
                to = phoneNumber,
                text = message,
                type = "0"
            };

            string json = JsonSerializer.Serialize(payload);

            using HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Post,
                apiUrl);

            request.Headers.Add("apikey", apiKey);
            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            request.Content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            using HttpResponseMessage response =
                await _httpClient.SendAsync(request, cancellationToken);

            string responseText =
                await response.Content.ReadAsStringAsync(cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException(
                    $"مزود SMS رفض الطلب. HTTP {(int)response.StatusCode}: {responseText}");
            }

            string? providerMessageId = TryGetMessageId(responseText);

            return new SmsGatewayResult
            {
                Success = true,
                ProviderMessageId = providerMessageId,
                ProviderResponse = responseText
            };
        }

        private static string? TryGetMessageId(string responseText)
        {
            if (string.IsNullOrWhiteSpace(responseText))
                return null;

            try
            {
                using JsonDocument document = JsonDocument.Parse(responseText);
                JsonElement root = document.RootElement;

                string[] possibleNames =
                {
                    "message_id",
                    "messageId",
                    "id",
                    "broadcast_id",
                    "broadcastId"
                };

                foreach (string name in possibleNames)
                {
                    if (root.TryGetProperty(name, out JsonElement value))
                        return value.ToString();
                }
            }
            catch (JsonException)
            {
                // Some providers may return plain text. Store it as ProviderResponse.
            }

            return null;
        }
    }

    public sealed class SmsGatewayResult
    {
        public bool Success { get; init; }
        public string? ProviderMessageId { get; init; }
        public string? ProviderResponse { get; init; }
    }
}
