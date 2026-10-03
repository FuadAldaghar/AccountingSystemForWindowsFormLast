using System;
using System.IO;
using AccountingSystemForWindowsFormLast.Data;
using Microsoft.Data.SqlClient;

namespace AccountingSystemForWindowsFormLast.Services
{

    /// نسخ احتياطي واستعادة قاعدة البيانات عبر T-SQL (BACKUP / RESTORE).
   
    public class DatabaseBackupService
    {
        private const string BackupExtension = ".bak";

   
        /// نسخ احتياطي لقاعدة البيانات في المسار المحدد.
     
        public void Backup(string backupPath)
        {
            if (string.IsNullOrWhiteSpace(backupPath))
                throw new ArgumentException("مسار النسخ الاحتياطي مطلوب.");

            string? directory = Path.GetDirectoryName(backupPath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            string databaseName = GetDatabaseName();

            // Connect to master so we are never inside the target DB.
            using SqlConnection connection = GetMasterConnection();
            connection.Open();

            // BACKUP DATABASE — bracket-quote the DB name to prevent injection.
            string sql = $@"
                BACKUP DATABASE [{EscapeIdentifier(databaseName)}]
                TO DISK = @BackupPath
                WITH FORMAT,
                     NAME = N'Full Backup',
                     STATS = 10;";

            using SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandTimeout = 300; // 5 minutes
            cmd.Parameters.AddWithValue("@BackupPath", backupPath);
            cmd.ExecuteNonQuery();
        }

        // ---------------------------------------------------------------
        // Restore
        // ---------------------------------------------------------------

        /// <summary>
        /// استعادة قاعدة البيانات من الملف المحدد.
        /// </summary>
        public void Restore(string backupPath)
        {
            if (string.IsNullOrWhiteSpace(backupPath))
                throw new ArgumentException("مسار الاستعادة مطلوب.");

            if (!File.Exists(backupPath))
                throw new FileNotFoundException("ملف النسخ الاحتياطي غير موجود.", backupPath);

            string databaseName = GetDatabaseName();

            // All restore work must be done from the master database.
            using SqlConnection connection = GetMasterConnection();
            connection.Open();

            // 1. Read logical / physical file names stored inside the .bak.
            (string dataFile, string logFile, string dataPath, string logPath)
                = GetFileList(connection, backupPath, databaseName);

            // 2. Kill every active session on the target DB (excluding ours).
            KillActiveConnections(connection, databaseName);

            // 3. Set DB to SINGLE_USER so RESTORE can take exclusive control.
            SetSingleUser(connection, databaseName);

            // 4. Perform the RESTORE.
            //    MOVE clause values come from the .bak itself (not user input)
            //    so we escape them safely with EscapeString.
            string restoreSql = $@"
                RESTORE DATABASE [{EscapeIdentifier(databaseName)}]
                FROM DISK = @BackupPath
                WITH REPLACE,
                     MOVE N'{EscapeString(dataFile)}' TO N'{EscapeString(dataPath)}',
                     MOVE N'{EscapeString(logFile)}'  TO N'{EscapeString(logPath)}',
                     STATS = 10;";

            using SqlCommand restoreCmd = new SqlCommand(restoreSql, connection);
            restoreCmd.CommandTimeout = 600; // 10 minutes
            restoreCmd.Parameters.AddWithValue("@BackupPath", backupPath);
            restoreCmd.ExecuteNonQuery();
        }

        // ---------------------------------------------------------------
        // Public helpers
        // ---------------------------------------------------------------

        public string GetDatabaseName()
        {
            // Parse from the connection string – no connection needed.
            using SqlConnection conn = DatabaseConnection.GetConnection();
            return conn.Database;
        }

        public string GetDefaultBackupFileName()
        {
            string databaseName = GetDatabaseName();
            return databaseName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + BackupExtension;
        }

        // ---------------------------------------------------------------
        // Private helpers
        // ---------------------------------------------------------------

        /// <summary>
        /// Returns a SqlConnection to the <c>master</c> database on the same
        /// server as the application's target database.
        /// </summary>
        private SqlConnection GetMasterConnection()
        {
            using SqlConnection template = DatabaseConnection.GetConnection();
            SqlConnectionStringBuilder builder =
                new SqlConnectionStringBuilder(template.ConnectionString)
                {
                    InitialCatalog = "master"
                };
            return new SqlConnection(builder.ConnectionString);
        }

        /// <summary>
        /// Reads logical (Data / Log) file names and physical paths stored
        /// inside the backup file via RESTORE FILELISTONLY.
        /// </summary>
        private (string dataFile, string logFile, string dataPath, string logPath)
            GetFileList(SqlConnection connection, string backupPath, string databaseName)
        {
            const string sql = "RESTORE FILELISTONLY FROM DISK = @BackupPath;";

            // Sensible defaults in case the backup contains unexpected file types.
            string dataFile = databaseName;
            string logFile  = databaseName + "_log";
            string dataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "MSSQL", "DATA", databaseName + ".mdf");
            string logPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "MSSQL", "DATA", databaseName + "_log.ldf");

            using SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandTimeout = 120;
            cmd.Parameters.AddWithValue("@BackupPath", backupPath);

            using SqlDataReader reader = cmd.ExecuteReader();

            int logicalNameOrdinal  = reader.GetOrdinal("LogicalName");
            int physicalNameOrdinal = reader.GetOrdinal("PhysicalName");
            int typeOrdinal         = reader.GetOrdinal("Type");

            while (reader.Read())
            {
                string type         = reader.GetString(typeOrdinal).Trim().ToUpperInvariant();
                string logicalName  = reader.GetString(logicalNameOrdinal);
                string physicalName = reader.GetString(physicalNameOrdinal);

                if (type == "D")      // data file
                {
                    dataFile = logicalName;
                    dataPath = physicalName;
                }
                else if (type == "L") // log file
                {
                    logFile = logicalName;
                    logPath = physicalName;
                }
            }

            return (dataFile, logFile, dataPath, logPath);
        }

  
        /// Terminates all active sessions on the target database (except the
        /// current SPID) so that RESTORE can take exclusive access.
       
        private void KillActiveConnections(SqlConnection connection, string databaseName)
        {
            const string sql = @"
                DECLARE @kill NVARCHAR(MAX) = N'';
                SELECT @kill = @kill + N'KILL ' + CONVERT(NVARCHAR(12), session_id) + N'; '
                FROM sys.dm_exec_sessions
                WHERE database_id = DB_ID(@DatabaseName)
                  AND session_id  <> @@SPID;

                IF (@kill <> N'')
                    EXEC sp_executesql @kill;";

            using SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@DatabaseName", databaseName);
            cmd.ExecuteNonQuery();
        }

        /// Switches the target database to SINGLE_USER mode with immediate
        /// rollback so RESTORE can take full control.
     
        private void SetSingleUser(SqlConnection connection, string databaseName)
        {
            string sql = $@"
                IF DB_ID(N'{EscapeString(databaseName)}') IS NOT NULL
                    ALTER DATABASE [{EscapeIdentifier(databaseName)}]
                    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";

            using SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
        }

        /// Escapes bracket-delimited T-SQL identifiers (replaces ] with ]]).</summary>
        private static string EscapeIdentifier(string name) => name.Replace("]", "]]");

        /// <summary>Escapes T-SQL string literals (replaces ' with '').</summary>
        private static string EscapeString(string value) => value.Replace("'", "''");
    }
}