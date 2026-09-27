namespace AccountingSystemForWindowsFormLast.Models
{
    public class AccountItem
    {
        public int AccountId { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{AccountNumber} - {AccountName}";
        }
    }
}