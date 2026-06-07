using CFMART.Helpers;
using Npgsql;
using System.Collections.Generic;

namespace CFMART.Models.Context
{
    public class ContextOrder
    {
        public List<Order> GetAllOrder()
        {
            List<Order> orders = new List<Order>();

            string query = @"
                SELECT
                    id_order,
                    tgl_order,
                    user_id_user,
                    status_order_id_status_order,
                    meja_id_meja,
                    tipe_pesanan_id_tipe_pesanan,
                    status_pembayaran,
                    metode_pembayaran_id_metode_pembayaran,
                    nomor_pelanggan,
                    nama_pelanggan
                FROM ""Order""
                ORDER BY id_order";

            using (NpgsqlConnection conn = connectDB.GetConn())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    orders.Add(new Order
                    {
                        Id_Order = reader.GetInt32(0),
                        Tgl_Order = reader.GetDateTime(1),
                        User_Id_User = reader.GetInt32(2),
                        Status_Order_Id_Status_Order = reader.GetInt32(3),
                        Meja_Id_Meja = reader.GetInt32(4),
                        Tipe_Pesanan_Id_Tipe_Pesanan = reader.GetInt32(5),
                        Status_Pembayaran = reader.GetBoolean(6),

                        Metode_Pembayaran_Id_Metode_Pembayaran =
                            reader.IsDBNull(7) ? null : reader.GetInt32(7),

                        Nomor_Pelanggan =
                            reader.IsDBNull(8) ? null : reader.GetString(8),

                        Nama_Pelanggan =
                            reader.IsDBNull(9) ? null : reader.GetString(9)
                    });
                }
            }

            return orders;
        }
    }
}