using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace CFMART.Models.Context
{
    // INHERITANCE: Resmi mewarisi BaseContext
    public class ContextDashboard : BaseContext
    {
        /// <summary>
        /// Mengambil angka statistik dashboard admin (Total Order, Total Stok, Karyawan Aktif)
        /// </summary>
        public Dictionary<string, object> GetStatistikDashboard()
        {
            var data = new Dictionary<string, object>();

            // ABSTRACTION: Menggunakan AmbilKoneksi() warisan dari BaseContext (Koneksi otomatis terbuka)
            using (var conn = AmbilKoneksi())
            {
                data["total_pesanan"] = new NpgsqlCommand("SELECT COUNT(*) FROM \"Order\"", conn).ExecuteScalar();
                data["total_stok"] = new NpgsqlCommand("SELECT SUM(stok) FROM \"produk\"", conn).ExecuteScalar();
                data["karyawan_aktif"] = new NpgsqlCommand("SELECT COUNT(*) FROM \"User\" WHERE status_karyawan = true", conn).ExecuteScalar();
            }
            return data;
        }

        /// <summary>
        /// Mengambil seluruh data riwayat pesanan terbaru untuk admin
        /// </summary>
        public DataTable GetPesananTerbaru()
        {
            DataTable dt = new DataTable();
            string query = "SELECT id_order, tgl_order, user_id_user, meja_id_meja, tipe_pesanan_id_tipe_pesanan, nama_pelanggan, metode_pembayaran_id_metode_pembayaran, nomor_pelanggan FROM \"Order\" ORDER BY id_order DESC";

            using (var conn = AmbilKoneksi()) // Menggunakan fungsi induk
            using (var cmd = new NpgsqlCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                dt.Load(reader);
            }
            return dt;
        }

        /// <summary>
        /// Mengambil data riwayat pesanan khusus yang dilayani oleh user/kasir tertentu
        /// </summary>
        public DataTable GetPesananTerbaru(int idUserKaryawan)
        {
            DataTable dt = new DataTable();
            string query = "SELECT id_order, tgl_order, user_id_user, meja_id_meja, tipe_pesanan_id_tipe_pesanan, nama_pelanggan, metode_pembayaran_id_metode_pembayaran, nomor_pelanggan FROM \"Order\" WHERE user_id_user = @userId ORDER BY id_order DESC";

            using (var conn = AmbilKoneksi())
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@userId", idUserKaryawan);
                using (var reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }
    }
}