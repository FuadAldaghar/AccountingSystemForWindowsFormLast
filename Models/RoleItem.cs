namespace AccountingSystemForWindowsFormLast.Models
{
    public class RoleItem
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;

        public override string ToString()
        {
            return RoleName;
        }
    }
}
