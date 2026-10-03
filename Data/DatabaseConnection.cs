using Microsoft.Data.SqlClient;

namespace AccountingSystemForWindowsFormLast.Data
{
    public static class DatabaseConnection
    {
        private static readonly string defaultConnectionString =
            "Server=localhost;Database=AccountingSystemForWindowsForm;Trusted_Connection=True;TrustServerCertificate=True;";

        // Runtime override set by the connection form. Null means "use default".
        private static string? overrideConnectionString;

        //private static readonly string connectionString =
        //  "Server=.\\SQLEXPRESS;Database=AccountingSystemForWindowsForm;Trusted_Connection=True;TrustServerCertificate=True;";

        /// <summary>
        /// The connection string currently used by every service in the app.
        /// Defaults to the compiled-in value; the connection form can replace it.
        /// </summary>
        public static string ConnectionString => overrideConnectionString ?? defaultConnectionString;

        /// <summary>
        /// Replaces the active connection string. Pass null to restore the default.
        /// </summary>
        public static void SetConnectionString(string? connectionString)
        {
            overrideConnectionString = string.IsNullOrWhiteSpace(connectionString)
                ? null
                : connectionString.Trim();
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Opens a connection using the given string and returns whether the
        /// server accepted it. Never throws — the caller reads the exception.
        /// </summary>
        public static bool TestConnection(string connectionString, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                error = "يرجى إدخال سلسلة الاتصال.";
                return false;
            }

            try
            {
                using SqlConnection connection = new SqlConnection(connectionString.Trim());
                connection.Open();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}
