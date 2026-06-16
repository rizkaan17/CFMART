using CFMART.Helpers;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;

namespace CFMART.Models.Context
{
    public class ContextUser : BaseContext
    {
        public static User user { get; set; }

        public List<User> GetAllUser()
        {
            List<User> users = new List<User>();
            string query = "SELECT id_user, username, password_user, role_id_role, status_karyawan, nama_lengkap, nomer_telepon_karyawan, email FROM \"User\" ORDER BY id_user";

            using (NpgsqlConnection conn = AmbilKoneksi())
            {
                conn.Open(); // <-- INI WAJIB ADA
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            id_user = Convert.ToInt32(reader["id_user"]),
                            username = reader["username"].ToString() ?? "",
                            password_user = reader["password_user"].ToString() ?? "",
                            role_id_role = Convert.ToInt32(reader["role_id_role"]),
                            status_karyawan = Convert.ToBoolean(reader["status_karyawan"]),
                            nama_lengkap = reader["nama_lengkap"].ToString() ?? "",
                            nomer_telepon_karyawan = reader["nomer_telepon_karyawan"].ToString() ?? "",
                            email = reader["email"] == DBNull.Value ? "" : reader["email"].ToString() ?? ""
                        });
                    }
                }
            }
            return users;
        }

        public void ExecuteUpsertKaryawan(int? id, string username, string password, int roleId, bool status, string namaLengkap, string nomerTelepon)
        {
            string query = "CALL sp_upsert_karyawan(@id, @username, @password, @role, @status, @nama, @nomer_telepon_karyawan)";

            using (NpgsqlConnection conn = AmbilKoneksi())
            {
                conn.Open(); // <-- JANGAN LUPA INI
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("id", NpgsqlDbType.Integer) { Value = id.HasValue ? (object)id.Value : DBNull.Value });
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.Add(new NpgsqlParameter("password", NpgsqlDbType.Varchar) { Value = (password == "********" || string.IsNullOrEmpty(password)) ? (object)DBNull.Value : password });
                    cmd.Parameters.AddWithValue("role", roleId);
                    cmd.Parameters.AddWithValue("status", status);
                    cmd.Parameters.AddWithValue("nama", namaLengkap);
                    cmd.Parameters.AddWithValue("nomer_telepon_karyawan", nomerTelepon);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool UpdateUser(User usr)
        {
            string query = "UPDATE \"User\" SET username = @username, password_user = @password, role_id_role = @role, status_karyawan = @status, nama_lengkap = @nama, nomer_telepon_karyawan = @nohp, email = @email WHERE id_user = @id";

            using (NpgsqlConnection conn = AmbilKoneksi())
            {
                conn.Open(); // <-- JANGAN LUPA INI
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", usr.id_user);
                    cmd.Parameters.AddWithValue("@username", usr.username ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@password", usr.password_user ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@role", usr.role_id_role);
                    cmd.Parameters.AddWithValue("@status", usr.status_karyawan);
                    cmd.Parameters.AddWithValue("@nama", usr.nama_lengkap ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@nohp", usr.nomer_telepon_karyawan ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@email", usr.email ?? (object)DBNull.Value);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public User Login(string username, string password)
        {
            string query = "SELECT id_user, username, password_user, role_id_role, status_karyawan, nama_lengkap, nomer_telepon_karyawan, email FROM \"User\" WHERE username = @username AND password_user = @password LIMIT 1";

            using (NpgsqlConnection conn = AmbilKoneksi())
            {
                conn.Open(); // <-- JANGAN LUPA INI
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                id_user = Convert.ToInt32(reader["id_user"]),
                                username = reader["username"].ToString() ?? "",
                                password_user = reader["password_user"].ToString() ?? "",
                                role_id_role = Convert.ToInt32(reader["role_id_role"]),
                                status_karyawan = Convert.ToBoolean(reader["status_karyawan"]),
                                nama_lengkap = reader["nama_lengkap"].ToString() ?? "",
                                nomer_telepon_karyawan = reader["nomer_telepon_karyawan"].ToString() ?? "",
                                email = reader["email"] == DBNull.Value ? "" : reader["email"].ToString() ?? ""
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}