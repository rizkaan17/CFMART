using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using CFMART.Models;

namespace CFMART.Models.Context
{
    // 🌟 SINKRON MVC & OOP: Mewarisi (Inherit) dari BaseContext
    public class ContextTransaksi : BaseContext
    {
        // Query Simpan Transaksi Kasir & Potong Stok
        public bool InsertNotaDanDetail(int idKasir, double totalHarga, string nomerMeja, List<ItemKeranjang> keranjang)
        {
            // 🌟 Menggunakan fungsi AmbilKoneksi() bawaan BaseContext
            using var conn = AmbilKoneksi();
            if (conn.State != ConnectionState.Open) conn.Open();
            using var trans = conn.BeginTransaction();
            try
            {
                string sqlOrder = @"INSERT INTO ""Order"" (nama_pelanggan, status_order_id_status_order, user_id_user, meja_id_meja, tipe_pesanan_id_tipe_pesanan, status_pembayaran) 
                                    VALUES (@nama, 1, @kasirId, 1, 1, true) RETURNING id_order;";

                int idBaru;
                using (var cmd = new NpgsqlCommand(sqlOrder, conn, trans))
                {
                    cmd.Parameters.AddWithValue("nama", "Pelanggan Meja " + nomerMeja);
                    cmd.Parameters.AddWithValue("kasirId", idKasir);
                    idBaru = Convert.ToInt32(cmd.ExecuteScalar());
                }

                foreach (var item in keranjang)
                {
                    string sqlDet = @"INSERT INTO ""Detail_Order"" (order_id_order, produk_id_produk, quantity, harga_per_item) 
                                      VALUES (@oid, @pid, @qty, @harga);";

                    using (var cmdD = new NpgsqlCommand(sqlDet, conn, trans))
                    {
                        cmdD.Parameters.AddWithValue("oid", idBaru);
                        cmdD.Parameters.AddWithValue("pid", item.id_produk);
                        cmdD.Parameters.AddWithValue("qty", item.quantity);
                        cmdD.Parameters.AddWithValue("harga", item.harga);
                        cmdD.ExecuteNonQuery();
                    }

                    string sqlUpdateStok = @"UPDATE ""Produk"" SET stok = stok - @qty WHERE id_produk = @pid;";
                    using (var cmdUp = new NpgsqlCommand(sqlUpdateStok, conn, trans))
                    {
                        cmdUp.Parameters.AddWithValue("qty", item.quantity);
                        cmdUp.Parameters.AddWithValue("pid", item.id_produk);
                        cmdUp.ExecuteNonQuery();
                    }
                }
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Database Error: " + ex.Message);
                return false;
            }
        }

        // Query Hitung Nota Transaksi Hari Ini (Kotak Kiri)
        public int GetTotalTransaksiHariIni()
        {
            int total = 0;
            string query = @"SELECT COUNT(id_order) FROM ""Order"" WHERE tgl_order::date = CURRENT_DATE;";
            try
            {
                // 🌟 Menggunakan fungsi AmbilKoneksi() bawaan BaseContext
                using var conn = AmbilKoneksi();
                if (conn.State != ConnectionState.Open) conn.Open();
                using var cmd = new NpgsqlCommand(query, conn);
                total = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch { return 0; }
            return total;
        }

        // Query Hitung Total Omzet Pendapatan Hari Ini (Kotak Tengah)
        public double GetPendapatanHariIni()
        {
            double total = 0;
            string query = @"
                SELECT COALESCE(SUM(d.quantity * d.harga_per_item), 0) 
                FROM ""Order"" o
                JOIN ""Detail_Order"" d ON o.id_order = d.order_id_order
                WHERE o.status_pembayaran = true AND o.tgl_order::date = CURRENT_DATE;";
            try
            {
                // 🌟 Menggunakan fungsi AmbilKoneksi() bawaan BaseContext
                using var conn = AmbilKoneksi();
                if (conn.State != ConnectionState.Open) conn.Open();
                using var cmd = new NpgsqlCommand(query, conn);
                total = Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch { return 0; }
            return total;
        }

        // Query Cari Kuantitas Terbanyak Produk Terlaris (Kotak Kanan)
        public int GetTotalProdukTerlaris()
        {
            int total = 0;
            string query = @"SELECT COALESCE(MAX(quantity), 0) FROM ""Detail_Order"";";
            try
            {
                // 🌟 Menggunakan fungsi AmbilKoneksi() bawaan BaseContext
                using var conn = AmbilKoneksi();
                if (conn.State != ConnectionState.Open) conn.Open();
                using var cmd = new NpgsqlCommand(query, conn);
                total = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch { return 0; }
            return total;
        }

        // Query Tarik Data Riwayat (Tabel Bawah)
        public DataTable GetRiwayatTransaksi()
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT o.id_order AS ""ID Order"", 
                       o.tgl_order AS ""Tanggal"", 
                       o.nama_pelanggan AS ""Pelanggan"", 
                       COALESCE(SUM(d.quantity * d.harga_per_item), 0) AS ""Total Belanja""
                FROM ""Order"" o
                LEFT JOIN ""Detail_Order"" d ON o.id_order = d.order_id_order
                GROUP BY o.id_order, o.tgl_order, o.nama_pelanggan
                ORDER BY o.tgl_order DESC;";
            try
            {
                // 🌟 Menggunakan fungsi AmbilKoneksi() bawaan BaseContext
                using var conn = AmbilKoneksi();
                if (conn.State != ConnectionState.Open) conn.Open();
                using var cmd = new NpgsqlCommand(query, conn);
                using NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch { }
            return dt;
        }
    }
}