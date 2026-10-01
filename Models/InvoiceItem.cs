namespace AccountingSystemForWindowsFormLast.Models
{
    public class InvoiceItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal Total => Quantity * UnitPrice;
    }
}
