using CFMART.Helpers;
using Npgsql;
using System.Collections.Generic;

namespace CFMART.Models
{
    public class ContextDetailOrder
    {
        public List<DetailOrder> GetAllDetailOrder()
        {
            List<DetailOrder> detailOrders = new List<DetailOrder>();

            string query = @"
                SELECT
                    id_detail_order,
                    quantity,
                    catatan,
                    order_id_order,
                    produk_id_produk,
                    harga_per_item
                FROM Detail_Order
                ORDER BY id_detail_order";

            using (NpgsqlConnection conn = connectDB.GetConn())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    detailOrders.Add(new DetailOrder
                    {
                        Id_Detail_Order = reader.GetInt32(0),
                        Quantity = reader.GetInt32(1),
                        Catatan = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Order_Id_Order = reader.GetInt32(3),
                        Produk_Id_Produk = reader.GetInt32(4),
                        Harga_Per_Item = reader.GetDouble(5)
                    });
                }
            }

            return detailOrders;
        }

        public bool AddDetailOrder(DetailOrder detail)
        {
            string query = @"
                INSERT INTO Detail_Order
                (
                    quantity,
                    catatan,
                    order_id_order,
                    produk_id_produk,
                    harga_per_item
                )
                VALUES
                (
                    @quantity,
                    @catatan,
                    @order,
                    @produk,
                    @harga
                )";

            using (NpgsqlConnection conn = connectDB.GetConn())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@quantity", detail.Quantity);
                cmd.Parameters.AddWithValue("@catatan",
                    (object?)detail.Catatan ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@order", detail.Order_Id_Order);
                cmd.Parameters.AddWithValue("@produk", detail.Produk_Id_Produk);
                cmd.Parameters.AddWithValue("@harga", detail.Harga_Per_Item);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateDetailOrder(DetailOrder detail)
        {
            string query = @"
                UPDATE Detail_Order
                SET
                    quantity = @quantity,
                    catatan = @catatan,
                    order_id_order = @order,
                    produk_id_produk = @produk,
                    harga_per_item = @harga
                WHERE id_detail_order = @id";

            using (NpgsqlConnection conn = connectDB.GetConn())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", detail.Id_Detail_Order);
                cmd.Parameters.AddWithValue("@quantity", detail.Quantity);
                cmd.Parameters.AddWithValue("@catatan",
                    (object?)detail.Catatan ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@order", detail.Order_Id_Order);
                cmd.Parameters.AddWithValue("@produk", detail.Produk_Id_Produk);
                cmd.Parameters.AddWithValue("@harga", detail.Harga_Per_Item);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteDetailOrder(int id)
        {
            string query = @"
                DELETE FROM Detail_Order
                WHERE id_detail_order = @id";

            using (NpgsqlConnection conn = connectDB.GetConn())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}