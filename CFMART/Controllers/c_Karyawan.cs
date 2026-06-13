using CFMART.Helpers;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFMART.Controllers
{
    public class KaryawanController
    {
        // 1. TAMBAH KARYAWAN (Menggunakan INSERT INTO murni agar bebas eror procedure)
        public (bool sukses, string pesan) TambahKaryawan(
    string username, string password, int roleId, bool status, string namaLengkap, string nomerTelepon)
        {
            try
            {
                using var conn = connectDB.GetConn();
                conn.Open();
                var cmd = new NpgsqlCommand(
                    "CALL sp_upsert_karyawan(@id, @username, @password, @role, @status, @nama, @nomer_telepon_karyawan)", conn);

                cmd.Parameters.Add(new NpgsqlParameter("id", NpgsqlDbType.Integer)
                {
                    Value = DBNull.Value
                });
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("password", password);
                cmd.Parameters.AddWithValue("role", roleId);
                cmd.Parameters.AddWithValue("status", status);
                cmd.Parameters.AddWithValue("nama", namaLengkap);
                cmd.Parameters.AddWithValue("nomer_telepon_karyawan", nomerTelepon);

                cmd.ExecuteNonQuery();
                return (true, "Karyawan baru berhasil ditambahkan.");
            }
            catch (PostgresException ex)
            {
                return (false, ex.MessageText);
            }
        }

        public (bool sukses, string pesan) EditKaryawan(
            int idUser, string? username, string? password, int? roleId, bool? status, string? namaLengkap, string? nomerTelepon)
        {
            try
            {
                using var conn = connectDB.GetConn();
                conn.Open();
                var cmd = new NpgsqlCommand(
                    "CALL sp_upsert_karyawan(@id, @username, @password, @role, @status, @nama, @nomer_telepon_karyawan)", conn);

                cmd.Parameters.AddWithValue("id", idUser);
                cmd.Parameters.Add(new NpgsqlParameter("username", NpgsqlDbType.Varchar)
                {
                    Value = username ?? (object)DBNull.Value
                });

                // Password: kalau "********" berarti tidak diubah, kirim NULL
                cmd.Parameters.Add(new NpgsqlParameter("password", NpgsqlDbType.Varchar)
                {
                    Value = (password == "********" || string.IsNullOrEmpty(password))
                        ? (object)DBNull.Value
                        : password
                });

                cmd.Parameters.Add(new NpgsqlParameter("role", NpgsqlDbType.Integer)
                {
                    Value = roleId.HasValue ? (object)roleId.Value : DBNull.Value
                });
                cmd.Parameters.Add(new NpgsqlParameter("status", NpgsqlDbType.Boolean)
                {
                    Value = status.HasValue ? (object)status.Value : DBNull.Value
                });
                cmd.Parameters.Add(new NpgsqlParameter("nama", NpgsqlDbType.Varchar)
                {
                    Value = namaLengkap ?? (object)DBNull.Value
                });
                cmd.Parameters.Add(new NpgsqlParameter("nomer_telepon_karyawan", NpgsqlDbType.Varchar)
                {
                    Value = nomerTelepon ?? (object)DBNull.Value
                });
                cmd.ExecuteNonQuery();
                return (true, "Data karyawan berhasil diperbarui.");
            }
            catch (PostgresException ex)
            {
                return (false, ex.MessageText);
            }
        }

        // 3. AMBIL SEMUA KARYAWAN (Tetap sama, mengambil nama_lengkap juga)
        public List<Dictionary<string, object>> GetAllKaryawan()
        {
            var list = new List<Dictionary<string, object>>();
            using var conn = connectDB.GetConn();
            conn.Open();

            var cmd = new NpgsqlCommand(
                @"SELECT u.id_user, u.username, r.nama_role, u.status_karyawan, u.nama_lengkap, u.nomer_telepon_karyawan
                  FROM ""User"" u
                  JOIN ""Role"" r ON u.role_id_role = r.id_role
                  ORDER BY u.id_user", conn);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Dictionary<string, object>
                {
                    ["id_user"] = reader.GetInt32(reader.GetOrdinal("id_user")),
                    ["username"] = reader.GetString(reader.GetOrdinal("username")),
                    ["nama_role"] = reader.GetString(reader.GetOrdinal("nama_role")),
                    ["status_karyawan"] = reader.GetBoolean(reader.GetOrdinal("status_karyawan")),
                    ["nama_lengkap"] = reader.GetString(reader.GetOrdinal("nama_lengkap")),
                    ["nomer_telepon_karyawan"] = reader.IsDBNull(reader.GetOrdinal("nomer_telepon_karyawan"))
                                                    ? ""
                                                    : reader.GetString(reader.GetOrdinal("nomer_telepon_karyawan"))
                });
            }
            return list;
        }
    }
}