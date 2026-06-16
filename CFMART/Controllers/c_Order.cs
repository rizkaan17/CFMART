using System;
using System.Collections.Generic;
using Npgsql;
using CFMART.Helpers;
using CFMART.Models; // 🌟 WAJIB: Memanggil namespace folder model baru kamu

namespace CFMART.Controllers
{
    // =========================================================================
    // ENCAPSULATION: Menggabungkan logika transaksi yang kompleks (Insert Header & Detail)
    // ke dalam satu metode 'KirimPesanan'. Form tidak perlu tahu cara melakukan 
    // transaksi database (BeginTransaction, Commit, Rollback).
    // =========================================================================
    public class OrderController
    {
        // ABSTRAKSI: User hanya perlu memanggil KirimPesanan(nama, listItem), 
        // detail tentang 'tabel apa yang di-insert' disembunyikan di sini.
        // 🌟 SINKRONISASI: Sekarang menerima List<ItemKeranjang> sesuai standar RAM global baru
        public bool KirimPesanan(string namaPelanggan, List<ItemKeranjang> items)
        {
            // Validasi awal untuk mencegah eksekusi SQL kosong
            if (items == null || items.Count == 0) return false;

            using var conn = connectDB.GetConn();

            // Pastikan gerbang koneksi terbuka sebelum memulai transaksi database pgAdmin
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }

            // Menggunakan transaksi untuk memastikan data konsisten (ACID)
            using var trans = conn.BeginTransaction();

            try
            {
                // 1. Insert ke tabel "Order" (Header)
                string sqlOrder = @"INSERT INTO ""Order"" (nama_pelanggan, status_order_id_status_order, user_id_user, meja_id_meja, tipe_pesanan_id_tipe_pesanan, status_pembayaran) 
                                    VALUES (@nama, 1, 1, 1, 1, false) RETURNING id_order;";

                int idBaru;
                using (var cmd = new NpgsqlCommand(sqlOrder, conn, trans))
                {
                    cmd.Parameters.AddWithValue("nama", namaPelanggan);
                    idBaru = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // 2. Insert ke Detail_Order (Item Produk)
                // POLYMORPHISM/ITERATION: Menggunakan loop untuk memproses setiap item 
                // dengan struktur yang seragam, terlepas dari berapa jumlah itemnya.
                foreach (var item in items)
                {
                    string sqlDet = @"INSERT INTO ""Detail_Order"" (order_id_order, produk_id_produk, quantity, harga_per_item) 
                                      VALUES (@oid, @pid, @qty, @harga);";

                    using (var cmdD = new NpgsqlCommand(sqlDet, conn, trans))
                    {
                        cmdD.Parameters.AddWithValue("oid", idBaru);

                        // 🌟 SEKARANG DINAMIS: Mengambil properti asli dari model ItemKeranjang (Bukan hardcode angka 1 lagi!)
                        cmdD.Parameters.AddWithValue("pid", item.id_produk);
                        cmdD.Parameters.AddWithValue("qty", item.quantity);
                        cmdD.Parameters.AddWithValue("harga", item.harga);

                        cmdD.ExecuteNonQuery();
                    }
                }

                // Commit: Menyetujui semua perubahan jika berhasil
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                // Rollback: Membatalkan semua perubahan jika terjadi error di tengah jalan
                trans.Rollback();
                System.Windows.Forms.MessageBox.Show("Gagal menyimpan transaksi ke database: " + ex.Message, "Error OrderController");
                return false;
            }
        }
    }
}