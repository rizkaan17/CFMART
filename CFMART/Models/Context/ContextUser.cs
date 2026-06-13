using CFMART.Helpers;
using Npgsql;
using System.Collections.Generic;

namespace CFMART.Models.Context
{
    public class ContextUser
    {
        // 🌟 TAMBAHKAN BARIS INI UNTUK MENYIMPAN SESI USER YANG SEDANG LOGIN
        public static User user { get; set; }

        // LOGIN
        public User Login(string username, string password)
        {
            User userHasil = null; // ubah nama variabel lokal agar tidak bentrok

            string query = @"
                SELECT *
                FROM ""User""
                WHERE username = @username
                AND password_user = @password";

            using (NpgsqlConnection conn = connectDB.GetConn())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userHasil = new User
                            {
                                Id_User = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password_User = reader.GetString(2),
                                Role_Id_Role = reader.GetInt32(3),
                                Status_Karyawan = reader.GetBoolean(4)
                            };

                            // 🌟 SIMPAN KE VARIABEL STATIC KETIKA LOGIN BERHASIL
                            user = userHasil;
                        }
                    }
                }
            }

            return userHasil;
        }

        // ... sisa kode GetAllUsers, AddUser, dll tetap sama ...
    }
}