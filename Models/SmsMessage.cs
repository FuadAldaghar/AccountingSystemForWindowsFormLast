namespace AccountingSystemForWindowsFormLast.Models
{
    public class SmsMessage
    {
        public int SmsMessageId { get; set; }

        public int AccountId { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public string AccountNature { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public DateTime? StatementFromDate { get; set; }
        public DateTime? StatementToDate { get; set; }

        public decimal Balance { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }

        public string MessageText { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending";

        public string? ProviderMessageId { get; set; }
        public string? ProviderResponse { get; set; }
        public string? ErrorMessage { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? SentAt { get; set; }
    }
}
