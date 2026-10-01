

namespace AccountingSystemForWindowsFormLast.Models
{
    public class JournalEntryModel
    {
        public int JournalEntryId { get; set; }
        public string EntryNumber { get; set; } = string.Empty;
        public DateTime EntryDate { get; set; } = DateTime.Today;
        public string Description { get; set; } = string.Empty;
        public List<JournalLine> Lines { get; set; } = new List<JournalLine>();
    }
}
