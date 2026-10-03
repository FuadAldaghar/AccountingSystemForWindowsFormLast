namespace AccountingSystemForWindowsFormLast.Models
{
    /// <summary>
    /// معايير البحث المستخدمة في تقريري عرض المشتريات وعرض المبيعات.
    /// </summary>
    public class InvoiceListFilter
    {
        public DateTime FromDate { get; set; } = new DateTime(DateTime.Today.Year, 1, 1);

        public DateTime ToDate { get; set; } = DateTime.Today;

        /// <summary>
        /// نص البحث الحر: يطابق رقم الفاتورة أو اسم الحساب أو اسم أحد الأصناف.
        /// </summary>
        public string SearchText { get; set; } = string.Empty;

        /// <summary>
        /// نوع الدفع، أو فارغ للعرض بلا تقييد.
        /// </summary>
        public string? PaymentType { get; set; }

        /// <summary>
        /// الصنف المطلوب، أو فارغ للعرض بلا تقييد.
        /// </summary>
        public int? ItemId { get; set; }

        public void Validate()
        {
            if (FromDate.Date > ToDate.Date)
                throw new ArgumentException("تاريخ البداية يجب أن يكون قبل تاريخ النهاية.");
        }

        public string? GetSearchPattern()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                return null;

            return "%" + SearchText.Trim() + "%";
        }
    }

    /// <summary>
    /// معايير البحث المستخدمة في كشف سندات القبض وكشف سندات الصرف.
/// إضافة إلى البحث النصي والفترة الزمنية، يسمح بتقييد المبلغ
        /// بين حد أدنى وحد أعلى (null يعني بلا حد).
    /// </summary>
    public class VoucherListFilter
    {
        public DateTime FromDate { get; set; } = new DateTime(DateTime.Today.Year, 1, 1);

        public DateTime ToDate { get; set; } = DateTime.Today;

        /// <summary>
        /// نص البحث الحر: يطابق رقم السند أو اسم الحساب أو الملاحظات.
        /// </summary>
        public string SearchText { get; set; } = string.Empty;

        public decimal? MinAmount { get; set; }

        public decimal? MaxAmount { get; set; }

        public void Validate()
        {
            if (FromDate.Date > ToDate.Date)
                throw new ArgumentException("تاريخ البداية يجب أن يكون قبل تاريخ النهاية.");

            if (MinAmount.HasValue && MaxAmount.HasValue && MinAmount.Value > MaxAmount.Value)
                throw new ArgumentException("أقل مبلغ يجب أن يكون أقل من أكبر مبلغ.");
        }

        public string? GetSearchPattern()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                return null;

            return "%" + SearchText.Trim() + "%";
        }
    }
}
