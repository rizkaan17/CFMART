using System;
using System.Collections.Generic;
using Npgsql;
using CFMART.Helpers;
using CFMART.Models.Context;

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
        public bool KirimPesanan(string namaPelanggan, List<ContextItemKeranjang> items)
        {
            // Validasi awal untuk mencegah eksekusi SQL kosong
            if (items == null || items.Count == 0) return false;

            using var conn = connectDB.GetConn();
            conn.Open();
            
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
                        cmdD.Parameters.AddWithValue("pid", 1); // ID Produk harus di-mapping dengan benar
                        cmdD.Parameters.AddWithValue("qty", item.Jumlah);
                        cmdD.Parameters.AddWithValue("harga", item.HargaSatuan);
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
                Console.WriteLine("Error Transaksi: " + ex.Message);
                return false; 
            }
        }
    }
}
