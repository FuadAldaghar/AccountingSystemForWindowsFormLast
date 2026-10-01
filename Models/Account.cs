namespace AccountingSystemForWindowsFormLast.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public string AccountNature { get; set; } = string.Empty;
        public int? ParentAccountId { get; set; }
        public bool IsGroup { get; set; }
        public bool IsSystem { get; set; }

        public override string ToString()
        {
            return $"{AccountNumber} - {AccountName}";
        }
    }
}
