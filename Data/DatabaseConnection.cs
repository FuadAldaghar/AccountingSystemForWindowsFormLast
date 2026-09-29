using Microsoft.Data.SqlClient;

namespace AccountingSystemForWindowsFormLast.Data
{
    public static class DatabaseConnection
    {
        private static readonly string connectionString =
            "Server=localhost;Database=AccountingSystemForWindowsForm;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}



//using Microsoft.Data.SqlClient;
//using System.Security.Cryptography;
//using System.Text;
//using System.Text.Json;

//namespace AccountingSystemForWindowsFormLast.Data
//{
//    public static class DatabaseConnection
//    {
//        private const string DefaultServer = "localhost";
//        private const string DefaultDatabase = "AccountingSystemForWindowsForm";

//        private static readonly string ConfigDirectory =
//            Path.Combine(
//                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
//                "AccountingSystemForWindowsFormLast");

//        private static readonly string ConfigFile =
//            Path.Combine(ConfigDirectory, "database.config.json");

//        private static string _server = DefaultServer;
//        private static string _database = DefaultDatabase;
//        private static bool _useWindowsAuthentication = true;
//        private static string _userName = string.Empty;
//        private static string _password = string.Empty;

//        static DatabaseConnection()
//        {
//            Load();
//        }

//        public static string Server => _server;
//        public static string DatabaseName => _database;
//        public static bool UseWindowsAuthentication => _useWindowsAuthentication;
//        public static string UserName => _userName;

//        public static SqlConnection GetConnection()
//        {
//            return new SqlConnection(BuildConnectionString());
//        }

//        public static SqlConnection GetMasterConnection()
//        {
//            var builder = new SqlConnectionStringBuilder(BuildConnectionString());
//            builder.InitialCatalog = "master";
//            return new SqlConnection(builder.ConnectionString);
//        }

//        public static string BuildConnectionString()
//        {
//            var builder = new SqlConnectionStringBuilder
//            {
//                DataSource = _server,
//                InitialCatalog = _database,
//                TrustServerCertificate = true,
//                ConnectTimeout = 10
//            };

//            if (_useWindowsAuthentication)
//            {
//                builder.IntegratedSecurity = true;
//            }
//            else
//            {
//                builder.UserID = _userName;
//                builder.Password = _password;
//                builder.IntegratedSecurity = false;
//            }

//            return builder.ConnectionString;
//        }

//        public static void SetConnection(
//            string server,
//            string database,
//            bool useWindowsAuthentication,
//            string userName,
//            string password,
//            bool save = true)
//        {
//            if (string.IsNullOrWhiteSpace(server))
//                throw new ArgumentException("يجب إدخال اسم الخادم.");

//            if (string.IsNullOrWhiteSpace(database))
//                throw new ArgumentException("يجب إدخال اسم قاعدة البيانات.");

//            if (!useWindowsAuthentication && string.IsNullOrWhiteSpace(userName))
//                throw new ArgumentException("يجب إدخال اسم المستخدم.");

//            _server = server.Trim();
//            _database = database.Trim();
//            _useWindowsAuthentication = useWindowsAuthentication;
//            _userName = useWindowsAuthentication ? string.Empty : userName.Trim();
//            _password = useWindowsAuthentication ? string.Empty : password;

//            if (save)
//                Save();
//        }

//        public static bool TestConnection(
//            string server,
//            string database,
//            bool useWindowsAuthentication,
//            string userName,
//            string password,
//            out string errorMessage)
//        {
//            try
//            {
//                var builder = new SqlConnectionStringBuilder
//                {
//                    DataSource = server.Trim(),
//                    InitialCatalog = database.Trim(),
//                    TrustServerCertificate = true,
//                    ConnectTimeout = 5
//                };

//                if (useWindowsAuthentication)
//                {
//                    builder.IntegratedSecurity = true;
//                }
//                else
//                {
//                    builder.UserID = userName.Trim();
//                    builder.Password = password;
//                    builder.IntegratedSecurity = false;
//                }

//                using var connection = new SqlConnection(builder.ConnectionString);
//                connection.Open();

//                errorMessage = string.Empty;
//                return true;
//            }
//            catch (Exception ex)
//            {
//                errorMessage = ex.Message;
//                return false;
//            }
//        }

//        public static bool TestServerConnection(
//            string server,
//            bool useWindowsAuthentication,
//            string userName,
//            string password,
//            out string errorMessage)
//        {
//            try
//            {
//                var builder = new SqlConnectionStringBuilder
//                {
//                    DataSource = server.Trim(),
//                    InitialCatalog = "master",
//                    TrustServerCertificate = true,
//                    ConnectTimeout = 5
//                };

//                if (useWindowsAuthentication)
//                {
//                    builder.IntegratedSecurity = true;
//                }
//                else
//                {
//                    builder.UserID = userName.Trim();
//                    builder.Password = password;
//                    builder.IntegratedSecurity = false;
//                }

//                using var connection = new SqlConnection(builder.ConnectionString);
//                connection.Open();

//                errorMessage = string.Empty;
//                return true;
//            }
//            catch (Exception ex)
//            {
//                errorMessage = ex.Message;
//                return false;
//            }
//        }

//        public static void Load()
//        {
//            try
//            {
//                if (!File.Exists(ConfigFile))
//                    return;

//                string json = File.ReadAllText(ConfigFile, Encoding.UTF8);
//                var config = JsonSerializer.Deserialize<DatabaseConfig>(json);

//                if (config == null)
//                    return;

//                _server = string.IsNullOrWhiteSpace(config.Server)
//                    ? DefaultServer
//                    : config.Server;

//                _database = string.IsNullOrWhiteSpace(config.Database)
//                    ? DefaultDatabase
//                    : config.Database;

//                _useWindowsAuthentication = config.UseWindowsAuthentication;
//                _userName = config.UserName ?? string.Empty;
//                _password = Decrypt(config.EncryptedPassword);
//            }
//            catch
//            {
//                // If the configuration is damaged, safely fall back to defaults.
//                _server = DefaultServer;
//                _database = DefaultDatabase;
//                _useWindowsAuthentication = true;
//                _userName = string.Empty;
//                _password = string.Empty;
//            }
//        }

//        private static void Save()
//        {
//            Directory.CreateDirectory(ConfigDirectory);

//            var config = new DatabaseConfig
//            {
//                Server = _server,
//                Database = _database,
//                UseWindowsAuthentication = _useWindowsAuthentication,
//                UserName = _userName,
//                EncryptedPassword = Encrypt(_password)
//            };

//            var options = new JsonSerializerOptions
//            {
//                WriteIndented = true
//            };

//            File.WriteAllText(
//                ConfigFile,
//                JsonSerializer.Serialize(config, options),
//                Encoding.UTF8);
//        }

//        private static string Encrypt(string value)
//        {
//            if (string.IsNullOrEmpty(value))
//                return string.Empty;

//            byte[] plainBytes = Encoding.UTF8.GetBytes(value);
//            byte[] protectedBytes = ProtectedData.Protect(
//                plainBytes,
//                null,
//                DataProtectionScope.CurrentUser);

//            return Convert.ToBase64String(protectedBytes);
//        }

//        private static string Decrypt(string value)
//        {
//            if (string.IsNullOrEmpty(value))
//                return string.Empty;

//            try
//            {
//                byte[] protectedBytes = Convert.FromBase64String(value);
//                byte[] plainBytes = ProtectedData.Unprotect(
//                    protectedBytes,
//                    null,
//                    DataProtectionScope.CurrentUser);

//                return Encoding.UTF8.GetString(plainBytes);
//            }
//            catch
//            {
//                return string.Empty;
//            }
//        }

//        private sealed class DatabaseConfig
//        {
//            public string Server { get; set; } = DefaultServer;
//            public string Database { get; set; } = DefaultDatabase;
//            public bool UseWindowsAuthentication { get; set; } = true;
//            public string UserName { get; set; } = string.Empty;
//            public string EncryptedPassword { get; set; } = string.Empty;
//        }
//    }
//}
