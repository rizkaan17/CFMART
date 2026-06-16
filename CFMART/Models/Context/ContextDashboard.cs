using Npgsql;
using System.Collections.Generic;
using System.Data;

namespace CFMART.Models.Context
{
    public class ContextDashboard : BaseContext
    {
        public Dictionary<string, object> GetStatistikDashboard()
        {
            var data = new Dictionary<string, object>();

            using (var conn = AmbilKoneksi())
            {
                conn.Open(); // <-- DILENGKAPI

                // Gunakan 'using' untuk setiap command agar perintah bersih
                using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM \"Order\"", conn))
                    data["total_pesanan"] = cmd.ExecuteScalar();

                using (var cmd = new NpgsqlCommand("SELECT SUM(stok) FROM \"produk\"", conn))
                    data["total_stok"] = cmd.ExecuteScalar();

                using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM \"User\" WHERE status_karyawan = true", conn))
                    data["karyawan_aktif"] = cmd.ExecuteScalar();
            }
            return data;
        }

        public DataTable GetPesananTerbaru()
        {
            DataTable dt = new DataTable();
            string query = "SELECT id_order, tgl_order, user_id_user, meja_id_meja, tipe_pesanan_id_tipe_pesanan, nama_pelanggan, metode_pembayaran_id_metode_pembayaran, nomor_pelanggan FROM \"Order\" ORDER BY id_order DESC";

            using (var conn = AmbilKoneksi())
            {
                conn.Open(); // <-- DILENGKAPI
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }

        public DataTable GetPesananTerbaru(int idUserKaryawan)
        {
            DataTable dt = new DataTable();
            string query = "SELECT id_order, tgl_order, user_id_user, meja_id_meja, tipe_pesanan_id_tipe_pesanan, nama_pelanggan, metode_pembayaran_id_metode_pembayaran, nomor_pelanggan FROM \"Order\" WHERE user_id_user = @userId ORDER BY id_order DESC";

            using (var conn = AmbilKoneksi())
            {
                conn.Open(); // <-- DILENGKAPI
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", idUserKaryawan);
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }
    }
}