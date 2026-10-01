namespace AccountingSystemForWindowsFormLast.Models
{
    public class AccountItem
    {
        public int AccountId { get; set; }

        public int Id
        {
            get => AccountId;
            set => AccountId = value;
        }

        public string AccountNumber { get; set; } = string.Empty;

        public string Number
        {
            get => AccountNumber;
            set => AccountNumber = value;
        }

        public string AccountName { get; set; } = string.Empty;

        public string Name
        {
            get => AccountName;
            set => AccountName = value;
        }

        public string AccountNature { get; set; } = string.Empty;

        public string DisplayText => string.IsNullOrWhiteSpace(AccountNumber)
            ? AccountName
            : $"{AccountNumber} - {AccountName}";

        public override string ToString()
        {
            return DisplayText;
        }
    }
}
