namespace AccountingSystemForWindowsFormLast.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemNumber { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
    }
}