using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace CFMART.Models.Context
{
    // INHERITANCE: Mewarisi BaseContext
    public class ContextRingkasanKasir : BaseContext
    {
        /// <summary>
        /// Mengambil angka statistik harian (Total Nota, Total Uang, Produk Terlaris)
        /// </summary>
        public Dictionary<string, object> GetStatistikKasir()
        {
            Dictionary<string, object> hasil = new Dictionary<string, object>
            {
                { "total_transaksi", 0 },
                { "total_pendapatan", 0.0 },
                { "produk_terlaris", "Belum Ada" }
            };

            // 🌟 PERBAIKAN 1: COUNT DISTINCT agar jumlah transaksi dihitung per nota unik, bukan per jumlah baris barang belanjaan
            string queryStats = @"
                SELECT 
                    COUNT(DISTINCT o.id_order) AS total_nota, 
                    COALESCE(SUM(od.sub_total), 0) AS total_duit
                FROM ""Order"" o
                LEFT JOIN detail_order od ON o.id_order = od.order_id_order
                WHERE DATE(o.tgl_order) = CURRENT_DATE";

            string queryTerlaris = @"
                SELECT p.jenis_produk 
                FROM detail_order d
                JOIN produk p ON d.produk_id_produk = p.id_produk
                JOIN ""Order"" o ON d.order_id_order = o.id_order
                WHERE DATE(o.tgl_order) = CURRENT_DATE
                GROUP BY p.jenis_produk 
                ORDER BY SUM(d.quantity) DESC 
                LIMIT 1";

            using (NpgsqlConnection conn = AmbilKoneksi())
            {
                // 1. Ambil data nota dan pendapatan harian
                using (NpgsqlCommand cmd = new NpgsqlCommand(queryStats, conn))
                using (NpgsqlDataReader r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        hasil["total_transaksi"] = Convert.ToInt32(r["total_nota"]);
                        // 🌟 PERBAIKAN 2: Membaca kolom 'total_duit' sesuai alias query SQL di atas
                        hasil["total_pendapatan"] = Convert.ToDouble(r["total_duit"]);
                    }
                }

                // 2. Ambil data nama produk paling laris hari ini
                using (NpgsqlCommand cmd = new NpgsqlCommand(queryTerlaris, conn))
                {
                    object obj = cmd.ExecuteScalar();
                    if (obj != null && obj != DBNull.Value)
                    {
                        hasil["produk_terlaris"] = obj.ToString();
                    }
                }
            }
            return hasil;
        }

        // =======================================================
        // 🌟 PILAR POLYMORPHISM DI LEVEL CONTEXT (OVERLOADING QUERY)
        // =======================================================

        /// <summary>
        /// Bentuk 1: Mengambil seluruh data riwayat nota transaksi terbaru secara GLOBAL
        /// </summary>
        public DataTable GetPesananTerbaru()
        {
            DataTable dt = new DataTable();

            // 🌟 PERBAIKAN 3: Menggunakan SUM(od.sub_total) AS total_harga dan GROUP BY 
            // agar data di DataGridView tidak duplikat saat 1 nota berisi banyak item barang!
            string query = @"
                SELECT 
                    o.id_order, 
                    o.tgl_order, 
                    COALESCE(SUM(od.sub_total), 0) AS total_harga, 
                    u.nama_lengkap
                FROM ""Order"" o
                JOIN ""User"" u ON o.user_id_user = u.id_user
                LEFT JOIN detail_order od ON o.id_order = od.order_id_order
                GROUP BY o.id_order, o.tgl_order, u.nama_lengkap
                ORDER BY o.tgl_order DESC 
                LIMIT 50";

            using (NpgsqlConnection conn = AmbilKoneksi())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// Bentuk 2: Mengambil data riwayat transaksi yang KHUSUS difilter berdasarkan ID User Kasir tertentu lewat database SQL
        /// </summary>
        public DataTable GetPesananTerbaru(int idUser)
        {
            DataTable dt = new DataTable();

            // 🌟 PERBAIKAN 4: Berlaku hal yang sama, ditambahkan SUM dan GROUP BY untuk filter ID kasir
            string query = @"
                SELECT 
                    o.id_order, 
                    o.tgl_order, 
                    COALESCE(SUM(od.sub_total), 0) AS total_harga, 
                    u.nama_lengkap
                FROM ""Order"" o
                JOIN ""User"" u ON o.user_id_user = u.id_user
                LEFT JOIN detail_order od ON o.id_order = od.order_id_order
                WHERE o.user_id_user = @userId
                GROUP BY o.id_order, o.tgl_order, u.nama_lengkap
                ORDER BY o.tgl_order DESC";

            using (NpgsqlConnection conn = AmbilKoneksi())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@userId", idUser);
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        // =======================================================
    }
}