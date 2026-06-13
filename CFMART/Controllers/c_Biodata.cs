using CFMART.Helpers;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFMART.Controllers
{
    public class BiodataController
    {
        // 1. AMBIL DATA BIODATA (Bisa dipanggil oleh Admin maupun Kasir)
        public Dictionary<string, object>? GetBiodataById(int idUser)
        {
            try
            {
                using var conn = connectDB.GetConn();
                conn.Open();

                // Catatan: Indeks kolom dimulai dari 0
                // 0:id_user, 1:username, 2:password_user, 3:role_id_role, 4:status_karyawan, 5:nama_lengkap, 6:nomer_telepon_karyawan, 7:email
                var cmd = new NpgsqlCommand(
                    @"SELECT id_user, username, password_user, role_id_role, status_karyawan, nama_lengkap, nomer_telepon_karyawan, email
                      FROM ""User"" 
                      WHERE id_user = @id", conn);

                cmd.Parameters.AddWithValue("id", idUser);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // 🌟 PERBAIKAN: Memastikan string penampung di UI mengambil kolom email/username yang tepat
                    return new Dictionary<string, object>
                    {
                        ["id_user"] = reader.GetInt32(0),
                        ["username"] = reader.IsDBNull(7) ? (reader.IsDBNull(1) ? "" : reader.GetString(1)) : reader.GetString(7), // Prioritas ambil dari kolom email (indeks 7) atau username (indeks 1)
                        ["nama_lengkap"] = reader.IsDBNull(5) ? "Tanpa Nama" : reader.GetString(5),
                        ["nomer_telepon_karyawan"] = reader.IsDBNull(6) ? "Belum Update" : reader.GetString(6)
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Eror Query Profil: " + ex.Message);
                return null;
            }
        }

        // 2. UPDATE DATA BIODATA (Otomatis mengupdate nama, no HP, dan EMAIL ke database)
        public bool UpdateProfilLengkap(int idUser, string nama, string noHP, string email, string passwordBaru)
        {
            try
            {
                using var conn = connectDB.GetConn();
                conn.Open();

                int rows = 0;

                // Skenario 1: Jika password baru DIISI (Update Nama, No HP, Email, dan Password)
                if (!string.IsNullOrEmpty(passwordBaru?.Trim()))
                {
                    // 🌟 PERBAIKAN: Menambahkan 'email = @email' dan 'username = @email' ke dalam perintah SQL UPDATE
                    string query = @"UPDATE ""User"" 
                                    SET nama_lengkap = @nama, 
                                        nomer_telepon_karyawan = @no_hp, 
                                        email = @email, 
                                        username = @email, 
                                        password_user = @password 
                                    WHERE id_user = @id";

                    using var cmd = new NpgsqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("id", idUser);
                    cmd.Parameters.AddWithValue("nama", nama ?? "");
                    cmd.Parameters.AddWithValue("no_hp", noHP ?? "");
                    cmd.Parameters.AddWithValue("email", email ?? "");
                    cmd.Parameters.AddWithValue("password", passwordBaru.Trim());

                    rows = cmd.ExecuteNonQuery();
                }
                // Skenario 2: Jika password baru DIKOSONGKAN (Hanya Update Nama, No HP, dan Email)
                else
                {
                    // 🌟 PERBAIKAN: Menambahkan 'email = @email' dan 'username = @email' ke dalam perintah SQL UPDATE tanpa password
                    string query = @"UPDATE ""User"" 
                                    SET nama_lengkap = @nama, 
                                        nomer_telepon_karyawan = @no_hp, 
                                        email = @email, 
                                        username = @email 
                                    WHERE id_user = @id";

                    using var cmd = new NpgsqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("id", idUser);
                    cmd.Parameters.AddWithValue("nama", nama ?? "");
                    cmd.Parameters.AddWithValue("no_hp", noHP ?? "");
                    cmd.Parameters.AddWithValue("email", email ?? "");

                    rows = cmd.ExecuteNonQuery();
                }

                // Jika rows > 0 berarti sukses terupdate
                return rows > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Pesan Eror Database Asli: " + ex.Message, "Pelacakan Bug", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }
        }
    }
}