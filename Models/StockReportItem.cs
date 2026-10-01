namespace AccountingSystemForWindowsFormLast.Models
{
    public class StockReportItem
    {
        public int ItemId { get; set; }
        public string ItemNumber { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public decimal OpeningBalance { get; set; }
        public decimal Purchases { get; set; }
        public decimal Sales { get; set; }
        public decimal CurrentBalance => OpeningBalance + Purchases - Sales;
    }
}
