using Npgsql;
using System;
using System.Collections.Generic;

namespace CFMART.Models.Context
{
    // INHERITANCE: Mewarisi BaseContext
    public class ContextDetailOrder : BaseContext
    {
        public List<DetailOrder> GetAllDetailOrder()
        {
            List<DetailOrder> detailOrders = new List<DetailOrder>();
            string query = @"SELECT id_detail_order, quantity, catatan, order_id_order, produk_id_produk, sub_total FROM ""Detail_Order"" ORDER BY id_detail_order";

            using (NpgsqlConnection conn = AmbilKoneksi()) // Menggunakan fungsi induk
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    detailOrders.Add(new DetailOrder
                    {
                        id_detail_order = Convert.ToInt32(reader["id_detail_order"]),
                        quantity = Convert.ToInt32(reader["quantity"]),
                        catatan = reader["catatan"] == DBNull.Value ? null : reader["catatan"].ToString(),
                        order_id_order = Convert.ToInt32(reader["order_id_order"]),
                        produk_id_produk = Convert.ToInt32(reader["produk_id_produk"]),
                        sub_total = Convert.ToDouble(reader["sub_total"])
                    });
                }
            }
            return detailOrders;
        }

        public bool AddDetailOrder(DetailOrder detail)
        {
            string query = @"INSERT INTO ""Detail_Order"" (quantity, catatan, order_id_order, produk_id_produk) VALUES (@quantity, @catatan, @order, @produk)";

            using (NpgsqlConnection conn = AmbilKoneksi()) // Menggunakan fungsi induk
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@quantity", detail.quantity);
                cmd.Parameters.AddWithValue("@catatan", (object?)detail.catatan ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@order", detail.order_id_order);
                cmd.Parameters.AddWithValue("@produk", detail.produk_id_produk);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateDetailOrder(DetailOrder detail)
        {
            string query = @"UPDATE ""Detail_Order"" SET quantity = @quantity, catatan = @catatan, order_id_order = @order, produk_id_produk = @produk WHERE id_detail_order = @id";

            using (NpgsqlConnection conn = AmbilKoneksi()) // Menggunakan fungsi induk
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", detail.id_detail_order);
                cmd.Parameters.AddWithValue("@quantity", detail.quantity);
                cmd.Parameters.AddWithValue("@catatan", (object?)detail.catatan ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@order", detail.order_id_order);
                cmd.Parameters.AddWithValue("@produk", detail.produk_id_produk);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteDetailOrder(int id)
        {
            string query = @"DELETE FROM ""Detail_Order"" WHERE id_detail_order = @id";

            using (NpgsqlConnection conn = AmbilKoneksi()) // Menggunakan fungsi induk
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}