using CFMART.Models;
using Npgsql;
using System;
using System.Collections.Generic;

namespace CFMART.Models.Context
{
    public class ContextTransaksi
    {
        // 1. String koneksi database PostgreSQL (Sesuaikan Database, Username, dan Password-mu)
        private readonly string _connectionString = "Host=localhost;Port=5432;Database=db_cfmart;Username=postgres;Password=your_password;";

        /// <summary>
        /// Menyimpan data Master Order dan Detail Order secara bersamaan menggunakan Database Transaction
        /// </summary>
        public bool InsertNotaDanDetail(int idUser, double totalHarga, string nomerMeja, List<ItemKeranjang> listKeranjang)
        {
            bool isSukses = false;

            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                // 🌟 REKOMENDASI DOSEN: Menerapkan DATABASE TRANSACTION (Aman & Anti Gantung)
                using (NpgsqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        int idOrderBaru = 0;

                        // --- LANGKAH 1: INSERT KE TABEL INDUK ("Order") ---
                        // Catatan: Karena kata 'Order' adalah keyword sensitif di SQL, bungkus dengan petik ganda \"Order\"
                        string queryOrder = @"
                            INSERT INTO ""Order"" (id_user, tanggal_order, total_harga, nomer_meja) 
                            VALUES (@id_user, @tanggal_order, @total_harga, @nomer_meja) 
                            RETURNING id_order;"; // RETURNING untuk mengambil ID yang baru saja dibuat otomatis oleh serial/identity

                        using (NpgsqlCommand cmdOrder = new NpgsqlCommand(queryOrder, conn, transaction))
                        {
                            cmdOrder.Parameters.AddWithValue("@id_user", idUser);
                            cmdOrder.Parameters.AddWithValue("@tanggal_order", DateTime.Now);
                            cmdOrder.Parameters.AddWithValue("@total_harga", totalHarga);
                            cmdOrder.Parameters.AddWithValue("@nomer_meja", string.IsNullOrWhiteSpace(nomerMeja) ? (object)DBNull.Value : nomerMeja);

                            // Eksekusi dan tangkap ID-nya untuk dipakai di tabel detail
                            idOrderBaru = Convert.ToInt32(cmdOrder.ExecuteScalar());
                        }


                        // --- LANGKAH 2: LOOPING INSERT KE TABEL DETAIL & POTONG STOK ---
                        string queryDetail = @"
                            INSERT INTO detail_order (id_order, id_produk, quantity, sub_total) 
                            VALUES (@id_order, @id_produk, @quantity, @sub_total);";

                        string queryUpdateStok = @"
                            UPDATE produk 
                            SET stok = stok - @qty_beli 
                            WHERE id_produk = @id_produk;";

                        // Looping isi bungkusan List<ItemKeranjang> yang dikirim dari RAM kasir tadi
                        foreach (var item in listKeranjang)
                        {
                            // A. Insert data barang belanjaan ke detail_order
                            using (NpgsqlCommand cmdDetail = new NpgsqlCommand(queryDetail, conn, transaction))
                            {
                                cmdDetail.Parameters.AddWithValue("@id_order", idOrderBaru);
                                cmdDetail.Parameters.AddWithValue("@id_produk", item.id_produk);
                                cmdDetail.Parameters.AddWithValue("@quantity", item.quantity);
                                cmdDetail.Parameters.AddWithValue("@sub_total", item.sub_total);

                                cmdDetail.ExecuteNonQuery();
                            }

                            // B. Otomatis potong stok barang di tabel produk secara real-time
                            using (NpgsqlCommand cmdStok = new NpgsqlCommand(queryUpdateStok, conn, transaction))
                            {
                                cmdStok.Parameters.AddWithValue("@qty_beli", item.quantity);
                                cmdStok.Parameters.AddWithValue("@id_produk", item.id_produk);

                                cmdStok.ExecuteNonQuery();
                            }
                        }

                        // 🌟 JIKA SEMUA PROSES DI ATAS BERHASIL TANPA ERROR, PERMANENKAN KE PGADMIN
                        transaction.Commit();
                        isSukses = true;
                    }
                    catch (Exception ex)
                    {
                        // 🌟 JIKA ADA SATU SAJA BARANG YANG ERROR/GAGAL, BATALKAN SEMUA DATA YANG SEMPAT MASUK
                        transaction.Rollback();
                        throw new Exception("Gagal menyimpan transaksi (Rollback diaktifkan): " + ex.Message);
                    }
                }
            }

            return isSukses;
        }
    }
}