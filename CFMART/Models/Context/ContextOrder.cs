using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using CFMART.Models;

namespace CFMART.Models.Context
{
    public class ContextOrder : BaseContext
    {
        public bool KirimPesanan(string namaPelanggan, List<ItemKeranjang> items, string statusTeks)
        {
            if (items == null || items.Count == 0) return false;

            using var conn = AmbilKoneksi();
            if (conn.State != ConnectionState.Open) conn.Open();

            using var trans = conn.BeginTransaction();
            try
            {
                // 1. Insert Header Order
                string sqlOrder = @"INSERT INTO ""Order"" (nama_pelanggan, user_id_user, meja_id_meja, tipe_pesanan_id_tipe_pesanan, status_pembayaran) 
                                    VALUES (@nama, 2, 1, 1, true) RETURNING id_order;";

                int idBaru;
                using (var cmd = new NpgsqlCommand(sqlOrder, conn, trans))
                {
                    cmd.Parameters.AddWithValue("nama", namaPelanggan);
                    idBaru = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // 2. Insert Detail Order & Update Stok
                foreach (var item in items)
                {
                    // Insert ke detail_order (tanpa kutip)
                    string sqlDet = @"INSERT INTO detail_order (order_id_order, produk_id_produk, quantity, harga_per_item) 
                                      VALUES (@oid, @pid, @qty, @harga);";

                    using (var cmdD = new NpgsqlCommand(sqlDet, conn, trans))
                    {
                        cmdD.Parameters.AddWithValue("oid", idBaru);
                        cmdD.Parameters.AddWithValue("pid", item.id_produk);
                        cmdD.Parameters.AddWithValue("qty", item.quantity);
                        cmdD.Parameters.AddWithValue("harga", item.harga);
                        cmdD.ExecuteNonQuery();
                    }

                    // Update stok di tabel produk (tanpa kutip)
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
                MessageBox.Show("Gagal menyimpan pesanan: " + ex.Message);
                return false;
            }
        }

        public double AmbilPendapatanHariIni()
        {
            double total = 0;
            string query = @"
                SELECT COALESCE(SUM(d.quantity * d.harga_per_item), 0) 
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
            catch
            {
                return 0;
            }
            return total;
        }
    }
}