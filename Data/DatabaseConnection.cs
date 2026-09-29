using Microsoft.Data.SqlClient;

namespace AccountingSystemForWindowsFormLast.Data
{
    public static class DatabaseConnection
    {
        private static readonly string connectionString =
            "Server=localhost;Database=AccountingSystemForWindowsForm;Trusted_Connection=True;TrustServerCertificate=True;";

        //private static readonly string connectionString =
        //  "Server=.\\SQLEXPRESS;Database=AccountingSystemForWindowsForm;Trusted_Connection=True;TrustServerCertificate=True;";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
