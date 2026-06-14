using System;
using System.Collections.Generic;
using Npgsql;
using CFMART.Helpers;
using CFMART.Models.Context; // Pastikan ini sesuai dengan namespace model keranjangmu

namespace CFMART.Controllers
{
    public class OrderController
    {
        public bool KirimPesanan(string namaPelanggan, List<ContextItemKeranjang> items)
        {
            using var conn = connectDB.GetConn();
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

                // Insert ke Detail_Order
                foreach (var item in items)
                {
                    string sqlDet = "INSERT INTO Detail_Order (order_id_order, produk_id_produk, quantity, harga_per_item) VALUES (@oid, @pid, @qty, @harga)";
                    using (var cmdD = new NpgsqlCommand(sqlDet, conn, trans))
                    {
                        cmdD.Parameters.AddWithValue("oid", idBaru);
                        cmdD.Parameters.AddWithValue("pid", 1); // Sesuaikan ID produk
                        cmdD.Parameters.AddWithValue("qty", item.Jumlah);
                        cmdD.Parameters.AddWithValue("harga", item.HargaSatuan);
                        cmdD.ExecuteNonQuery();
                    }
                }
                trans.Commit();
                return true;
            }
            catch { trans.Rollback(); return false; }
        }
    }
}