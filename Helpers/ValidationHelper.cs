

namespace AccountingSystemForWindowsFormLast.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsNotEmpty(string? value, out string trimmed)
        {
            trimmed = value?.Trim() ?? string.Empty;
            return !string.IsNullOrWhiteSpace(trimmed);
        }

        public static bool IsPositive(decimal value)
        {
            return value > 0;
        }

        public static bool IsValidDateRange(DateTime fromDate, DateTime toDate)
        {
            return fromDate.Date <= toDate.Date;
        }
    }
}
