using CFMART.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace CFMART.Models.Context
{
    // 🌟 SINKRON MVC & OOP: Mewarisi (Inherit) dari BaseContext
    public class ContextTransaksi : BaseContext
    {
        // Query Simpan Transaksi Kasir & Potong Stok
        public bool InsertNotaDanDetail(int idKasir, double totalHarga, string nomerMeja, List<ItemKeranjang> keranjang, string catatanUmum)
        {
            using var conn = AmbilKoneksi();
            if (conn.State != ConnectionState.Open) conn.Open();
            using var trans = conn.BeginTransaction();
            try
            {
                string sqlOrder = @"INSERT INTO ""Order"" (nama_pelanggan, user_id_user, meja_id_meja, tipe_pesanan_id_tipe_pesanan, status_pembayaran) 
                            VALUES (@nama, @kasirId, 1, 1, true) RETURNING id_order;";

                int idBaru;
                using (var cmd = new NpgsqlCommand(sqlOrder, conn, trans))
                {
                    cmd.Parameters.AddWithValue("nama", "Pelanggan Meja " + nomerMeja);
                    cmd.Parameters.AddWithValue("kasirId", idKasir);
                    idBaru = Convert.ToInt32(cmd.ExecuteScalar());
                }

                foreach (var item in keranjang)
                {
                    string sqlDet = @"INSERT INTO detail_order (order_id_order, produk_id_produk, quantity, sub_total, catatan) 
                              VALUES (@oid, @pid, @qty, @subTotal, @catatan);";

                    using (var cmdD = new NpgsqlCommand(sqlDet, conn, trans))
                    {
                        cmdD.Parameters.AddWithValue("oid", idBaru);
                        cmdD.Parameters.AddWithValue("pid", item.id_produk);
                        cmdD.Parameters.AddWithValue("qty", item.quantity);
                        cmdD.Parameters.AddWithValue("subTotal", item.quantity * item.harga);
                        cmdD.Parameters.AddWithValue("catatan", (object?)catatanUmum ?? DBNull.Value);
                        cmdD.ExecuteNonQuery();
                    }

                    string sqlUpdateStok = @"UPDATE produk SET stok = stok - @qty WHERE id_produk = @pid;";
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
                MessageBox.Show("Database Error: " + ex.ToString());
                return false;
            }
        }

        public bool InsertPesananPelanggan(string mejaTeks, string tipePesanan, string metodePembayaran, string catatanUmum, List<ItemKeranjang> keranjang)
        {
            using var conn = AmbilKoneksi();
            if (conn.State != ConnectionState.Open) conn.Open();
            using var trans = conn.BeginTransaction();
            try
            {
                // Asumsi: angka di comboBox nomor meja sama dengan id_meja di database (keduanya 1-15)
                int? idMeja = null;
                if (int.TryParse(mejaTeks, out int parsedMeja))
                    idMeja = parsedMeja;

                int idTipePesanan = (tipePesanan == "Dine In") ? 1 : 2; // 1 = Dine In, 2 = Take Away
                int idMetode = (metodePembayaran == "Tunai") ? 1 : 2;   // 1 = Tunai, 2 = QRIS

                string sqlOrder = @"INSERT INTO ""Order"" 
            (nama_pelanggan, user_id_user, meja_id_meja, tipe_pesanan_id_tipe_pesanan, status_pembayaran, metode_pembayaran_id_metode_pembayaran) 
            VALUES (@nama, @userId, @meja, @tipe, false, @metode) RETURNING id_order;";

                int idBaru;
                using (var cmd = new NpgsqlCommand(sqlOrder, conn, trans))
                {
                    cmd.Parameters.AddWithValue("nama", idMeja.HasValue ? "Pelanggan Meja " + idMeja.Value : "Pelanggan Takeaway");
                    cmd.Parameters.AddWithValue("userId", 2); // sementara pakai ID 2 (sama seperti pola lama), sesuaikan kalau nanti ada user khusus pelanggan
                    cmd.Parameters.AddWithValue("meja", idMeja.HasValue ? (object)idMeja.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("tipe", idTipePesanan);
                    cmd.Parameters.AddWithValue("metode", idMetode);
                    idBaru = Convert.ToInt32(cmd.ExecuteScalar());
                }

                foreach (var item in keranjang)
                {
                    string sqlDet = @"INSERT INTO detail_order (order_id_order, produk_id_produk, quantity, sub_total, catatan) 
                              VALUES (@oid, @pid, @qty, @subTotal, @catatan);";
                    using (var cmdD = new NpgsqlCommand(sqlDet, conn, trans))
                    {
                        cmdD.Parameters.AddWithValue("oid", idBaru);
                        cmdD.Parameters.AddWithValue("pid", item.id_produk);
                        cmdD.Parameters.AddWithValue("qty", item.quantity);
                        cmdD.Parameters.AddWithValue("subTotal", item.quantity * item.harga);
                        cmdD.Parameters.AddWithValue("catatan", (object?)catatanUmum ?? DBNull.Value);
                        cmdD.ExecuteNonQuery();
                    }

                    // Potong stok di sini — karena di alur pelanggan, stok belum pernah dipotong sebelumnya
                    string sqlUpdateStok = @"UPDATE produk SET stok = stok - @qty WHERE id_produk = @pid;";
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
                MessageBox.Show("Database Error: " + ex.ToString());
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
                SELECT COALESCE(SUM(d.quantity * d.sub_total), 0) 
                FROM ""Order"" o
                JOIN detail_order d ON o.id_order = d.order_id_order
                WHERE o.status_pembayaran = true AND o.tgl_order::date = CURRENT_DATE;";
            try
            {
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
            string query = @"SELECT COALESCE(MAX(quantity), 0) FROM detail_order;";
            try
            {
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
                       COALESCE(SUM(d.quantity * d.sub_total), 0) AS ""Total Belanja""
                FROM ""Order"" o
                LEFT JOIN detail_order d ON o.id_order = d.order_id_order
                GROUP BY o.id_order, o.tgl_order, o.nama_pelanggan
                ORDER BY o.tgl_order DESC;";
            try
            {
                using var conn = AmbilKoneksi();
                if (conn.State != ConnectionState.Open) conn.Open();
                using var cmd = new NpgsqlCommand(query, conn);
                using NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch { }
            return dt;
        }
        // Di dalam class ContextTransaksi
        public DataTable GetPesananPending()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT * FROM ""Order"";";

            try
            {
                using var conn = AmbilKoneksi();
                if (conn.State != ConnectionState.Open) conn.Open();

                using var cmd = new NpgsqlCommand(query, conn);
                using var da = new NpgsqlDataAdapter(cmd);
                da.Fill(dt);
                // baris MessageBox.Show(...) dihapus dari sini
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
            return dt;
        }
        public DataTable GetDetailPesanan(string idOrder)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT p.jenis_produk, d.quantity, d.sub_total, d.catatan 
                 FROM detail_order d
                 JOIN produk p ON d.produk_id_produk = p.id_produk
                 WHERE d.order_id_order = @id";

            using var conn = AmbilKoneksi();
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id", int.Parse(idOrder));
            using var da = new NpgsqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public bool UpdateStatusPembayaran(string idOrder, bool statusLunas, int idKasir)
        {
            string query = @"UPDATE ""Order"" SET status_pembayaran = @status, user_id_user = @idKasir WHERE id_order = @id;";
            try
            {
                using var conn = AmbilKoneksi();
                if (conn.State != ConnectionState.Open) conn.Open();
                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("status", statusLunas);
                cmd.Parameters.AddWithValue("idKasir", idKasir);
                cmd.Parameters.AddWithValue("id", int.Parse(idOrder));
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
                return false;
            }
        }
    }
}