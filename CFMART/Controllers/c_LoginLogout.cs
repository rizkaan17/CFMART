using CFMART.Helpers;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using CFMART.Models;

namespace CFMART.Controllers
{
    public class c_LoginLogout
    {
        public User? Login(string username, string password)
        {
            using var conn = connectDB.GetConn();

            // WAJIB DIKEMBALIKAN: Buka koneksinya di sini sebelum menjalankan perintah SQL!
            conn.Open();

            var cmd = new NpgsqlCommand(
                        @"SELECT u.id_user, u.username, u.password_user, 
                        u.role_id_role, u.status_karyawan
                        FROM ""User"" u
                        WHERE u.username = @username 
                        AND u.password_user = @password 
                        AND u.status_karyawan = true", conn);

            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("password", password);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new User
                {
                    Id_User = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Password_User = reader.GetString(2),
                    Role_Id_Role = reader.GetInt32(3),
                    Status_Karyawan = reader.GetBoolean(4)
                };
            }
            return null;
        }
    }
}