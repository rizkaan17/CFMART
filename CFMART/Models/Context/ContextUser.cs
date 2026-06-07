using CFMART.Helpers;
using Npgsql;
using System.Collections.Generic;

namespace CFMART.Models.Context
{
    public class ContextUser
    {
        // LOGIN
        public User Login(string username, string password)
        {
            User user = null;

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
                            user = new User
                            {
                                Id_User = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Role_Id_Role = reader.GetInt32(3),
                                Status_Karyawan = reader.GetBoolean(4)
                            };
                        }
                    }
                }
            }

            return user;
        }

        // MENAMPILKAN SEMUA USER
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            string query = @"
                SELECT
                id_user,
                username,
                password_user,
                role_id_role,
                status_karyawan
                FROM ""User""
                ORDER BY id_user";

            using (NpgsqlConnection conn = connectDB.GetConn())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User
                            {
                                Id_User = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Role_Id_Role = reader.GetInt32(3),
                                Status_Karyawan = reader.GetBoolean(4),
                            };

                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }

        // TAMBAH USER
        public bool AddUser(User user)
        {
            string query = @"
                INSERT INTO ""User""
                (
                    username,
                    password_user,
                    role_id_role,
                    status_karyawan
                )
                VALUES
                (
                    @username,
                    @password,
                    @role,
                    @status
                )";

            using (NpgsqlConnection conn = connectDB.GetConn())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@role", user.Role_Id_Role);
                    cmd.Parameters.AddWithValue("@status", user.Status_Karyawan);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // EDIT USER
        public bool UpdateUser(User user)
        {
            string query = @"
                UPDATE ""User""
                SET
                    username = @username,
                    password_user = @password,
                    role_id_role = @role,
                    status_karyawan = @status
                WHERE id_user = @id";

            using (NpgsqlConnection conn = connectDB.GetConn())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", user.Id_User);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@role", user.Role_Id_Role);
                    cmd.Parameters.AddWithValue("@status", user.Status_Karyawan);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // HAPUS USER
        public bool DeleteUser(int id)
        {
            string query = @"DELETE FROM ""User"" WHERE id_user = @id";

            using (NpgsqlConnection conn = connectDB.GetConn())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}