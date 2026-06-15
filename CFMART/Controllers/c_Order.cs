using System;
using System.Collections.Generic;
using Npgsql;
using CFMART.Helpers;
using CFMART.Models; // 🌟 WAJIB: Memanggil namespace model ItemKeranjang yang baru

namespace CFMART.Controllers
{
    public class OrderController
    {
        // 🌟 SINKRONISASI PARAMETER: Sekarang menerima List<ItemKeranjang> sesuai standar RAM global baru
        public bool KirimPesanan(string namaPelanggan, List<ItemKeranjang> items)
        {
            // Validasi awal untuk mencegah eksekusi SQL kosong
            if (items == null || items.Count == 0) return false;

            using var conn = connectDB.GetConn();

            // Pastikan koneksi terbuka sebelum memulai transaction database
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }

            using var trans = conn.BeginTransaction();
            try
            {
                // Insert ke tabel "Order"
                // id_status_order = 1 (Pending), tipe_pesanan = 1 (Dine-in/Default)
                string sqlOrder = @"INSERT INTO ""Order"" (nama_pelanggan, status_order_id_status_order, user_id_user, meja_id_meja, tipe_pesanan_id_tipe_pesanan, status_pembayaran) 
                                    VALUES (@nama, 1, 1, 1, 1, false) RETURNING id_order;";

                int idBaru;
                using (var cmd = new NpgsqlCommand(sqlOrder, conn, trans))
                {
                    cmd.Parameters.AddWithValue("nama", namaPelanggan);
                    idBaru = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // Insert ke Detail_Order secara looping dinamis
                foreach (var item in items)
                {
                    string sqlDet = @"INSERT INTO ""Detail_Order"" (order_id_order, produk_id_produk, quantity, harga_per_item) 
                                      VALUES (@oid, @pid, @qty, @harga);";

                    using (var cmdD = new NpgsqlCommand(sqlDet, conn, trans))
                    {
                        cmdD.Parameters.AddWithValue("oid", idBaru);

                        // 🌟 DIBIKIN DINAMIS: Mengambil properti asli dari model ItemKeranjang (Bukan hardcode angka 1 lagi!)
                        cmdD.Parameters.AddWithValue("pid", item.id_produk);
                        cmdD.Parameters.AddWithValue("qty", item.quantity);
                        cmdD.Parameters.AddWithValue("harga", item.harga);

                        cmdD.ExecuteNonQuery();
                    }
                }

                // Jika semua baris sukses masuk tanpa interupsi, kunci data permanen ke PostgreSQL
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                // Jika ada error (misal koneksi putus tengah jalan), batalkan semua agar tidak merusak relasi tabel
                trans.Rollback();
                System.Windows.Forms.MessageBox.Show("Gagal mengirim pesanan ke database: " + ex.Message, "Error OrderController");
                return false;
            }
        }
    }
}