using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using AccountingSystemForWindowsFormLast.Data;

namespace AccountingSystemForWindowsFormLast.Services
{
    public class UserService
    {
        // =========================================================
        // تسجيل الدخول
        // =========================================================
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


        // =========================================================
        // تغيير كلمة المرور
        // =========================================================
        public bool ChangePassword(
            int userId,
            string currentPassword,
            string newPassword)
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            const string query = @"
                UPDATE Users
                SET PasswordHash = @NewPassword
                WHERE UserId = @UserId
                  AND PasswordHash = @CurrentPassword
                  AND IsActive = 1";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@UserId",
                userId);

            command.Parameters.AddWithValue(
                "@CurrentPassword",
                currentPassword);

            command.Parameters.AddWithValue(
                "@NewPassword",
                newPassword);

            return command.ExecuteNonQuery() > 0;
        }


        // =========================================================
        // جلب الأدوار
        // =========================================================
        public List<RoleItem> GetRoles()
        {
            List<RoleItem> roles =
                new List<RoleItem>();

            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            const string query = @"
                SELECT
                    RoleId,
                    RoleName
                FROM Roles
                ORDER BY RoleId";

            using SqlCommand command =
                new SqlCommand(query, connection);

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                roles.Add(
                    new RoleItem
                    {
                        RoleId =
                            Convert.ToInt32(reader["RoleId"]),

                        RoleName =
                            reader["RoleName"]?.ToString() ?? ""
                    });
            }

            return roles;
        }


        // =========================================================
        // التحقق من وجود اسم المستخدم
        // =========================================================
        public bool UserNameExists(string userName)
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            const string query = @"
                SELECT COUNT(1)
                FROM Users
                WHERE UserName = @UserName";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@UserName",
                userName);

            int count =
                Convert.ToInt32(command.ExecuteScalar());

            return count > 0;
        }


        // =========================================================
        // إنشاء مستخدم جديد
        // =========================================================
        public bool CreateUser(
            string userName,
            string password,
            int roleId,
            bool isActive)
        {
            using SqlConnection connection =
                DatabaseConnection.GetConnection();

            connection.Open();

            const string query = @"
                INSERT INTO Users
                (
                    UserName,
                    PasswordHash,
                    RoleId,
                    IsActive
                )
                VALUES
                (
                    @UserName,
                    @PasswordHash,
                    @RoleId,
                    @IsActive
                )";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@UserName",
                userName);

            command.Parameters.AddWithValue(
                "@PasswordHash",
                password);

            command.Parameters.AddWithValue(
                "@RoleId",
                roleId);

            command.Parameters.AddWithValue(
                "@IsActive",
                isActive);

            return command.ExecuteNonQuery() > 0;
        }
    }


    // =============================================================
    // بيانات الدور المستخدمة في ComboBox
    // =============================================================
    public class RoleItem
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; } = "";

        public override string ToString()
        {
            return RoleName;
        }
    }


    // =============================================================
    // جلسة المستخدم الحالي
    // =============================================================
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