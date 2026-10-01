
using AccountingSystemForWindowsFormLast.Services;

namespace AccountingSystemForWindowsFormLast.Helpers.users
{
    public static class CurrentUser
    {
        public static int UserId { get; private set; }

        public static string UserName { get; private set; } = "";

        public static int RoleId { get; private set; }

        public static string RoleName { get; private set; } = "";

        private static readonly HashSet<string> _permissions =
            new HashSet<string>();

        public static bool IsLoggedIn =>
            UserId > 0;

        public static void Login(UserSession session)
        {
            UserId = session.UserId;
            UserName = session.UserName;
            RoleId = session.RoleId;
            RoleName = session.RoleName;

            _permissions.Clear();

            foreach (string permission in session.Permissions)
            {
                _permissions.Add(permission);
            }
        }

        public static bool HasPermission(string permissionCode)
        {
            return _permissions.Contains(permissionCode);
        }

        public static void Logout()
        {
            UserId = 0;
            UserName = "";
            RoleId = 0;
            RoleName = "";

            _permissions.Clear();
        }
    }
}