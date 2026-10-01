namespace AccountingSystemForWindowsFormLast.Models
{
    public class JournalLine
    {
        public int JournalEntryDetailId { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
