using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using AccountingSystemForWindowsFormLast.Data;

namespace AccountingSystemForWindowsFormLast.Services
{
    public class UserService
    {
        public UserSession? Login(string userName, string password)
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            const string query = @"
                SELECT
                    u.UserId,
                    u.UserName,
                    u.PasswordHash,
                    u.RoleId,
                    r.RoleName
                FROM Users u
                INNER JOIN Roles r
                    ON r.RoleId = u.RoleId
                WHERE u.UserName = @UserName
                  AND u.IsActive = 1";

            UserSession? session = null;

            using (SqlCommand command =
                new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue(
                    "@UserName",
                    userName);

                using SqlDataReader reader =
                    command.ExecuteReader();

                if (!reader.Read())
                    return null;

                string storedPassword =
                    reader["PasswordHash"]?.ToString() ?? "";

                // مؤقتاً لأن كلمة المرور مخزنة كنص
                if (storedPassword != password)
                    return null;

                session = new UserSession
                {
                    UserId = Convert.ToInt32(reader["UserId"]),
                    UserName = reader["UserName"]?.ToString() ?? "",
                    RoleId = Convert.ToInt32(reader["RoleId"]),
                    RoleName = reader["RoleName"]?.ToString() ?? ""
                };
            }

            // تحميل صلاحيات الدور
            const string permissionsQuery = @"
                SELECT p.PermissionCode
                FROM RolePermissions rp
                INNER JOIN Permissions p
                    ON p.PermissionId = rp.PermissionId
                WHERE rp.RoleId = @RoleId";

            using (SqlCommand permissionCommand =
                new SqlCommand(permissionsQuery, connection))
            {
                permissionCommand.Parameters.AddWithValue(
                    "@RoleId",
                    session.RoleId);

                using SqlDataReader permissionReader =
                    permissionCommand.ExecuteReader();

                while (permissionReader.Read())
                {
                    session.Permissions.Add(
                        permissionReader["PermissionCode"]?.ToString() ?? "");
                }
            }

            return session;
        }
    }

    public class UserSession
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = "";

        public int RoleId { get; set; }

        public string RoleName { get; set; } = "";

        public List<string> Permissions { get; set; } =
            new List<string>();
    }
}