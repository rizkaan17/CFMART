using Npgsql;
using System;
using System.Collections.Generic;

namespace CFMART.Models.Context
{
    // INHERITANCE: Mewarisi BaseContext
    public class ContextOrder : BaseContext
    {
        public List<Order> GetAllOrder()
        {
            List<Order> orders = new List<Order>();
            string query = @"
                SELECT id_order, tgl_order, user_id_user, meja_id_meja, tipe_pesanan_id_tipe_pesanan, status_pembayaran, metode_pembayaran_id_metode_pembayaran, nomor_pelanggan, nama_pelanggan
                FROM ""Order""
                ORDER BY id_order";

            using (NpgsqlConnection conn = AmbilKoneksi()) // Menggunakan fungsi induk
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    orders.Add(new Order
                    {
                        id_order = Convert.ToInt32(reader["id_order"]),
                        tgl_order = Convert.ToDateTime(reader["tgl_order"]),
                        user_id_user = Convert.ToInt32(reader["user_id_user"]),
                        meja_id_meja = Convert.ToInt32(reader["meja_id_meja"]),
                        tipe_pesanan_id_tipe_pesanan = Convert.ToInt32(reader["tipe_pesanan_id_tipe_pesanan"]),
                        status_pembayaran = Convert.ToBoolean(reader["status_pembayaran"]),
                        metode_pembayaran_id_metode_pembayaran = reader["metode_pembayaran_id_metode_pembayaran"] == DBNull.Value ? 0 : Convert.ToInt32(reader["metode_pembayaran_id_metode_pembayaran"]),
                        nomor_pelanggan = reader["nomor_pelanggan"] == DBNull.Value ? string.Empty : reader["nomor_pelanggan"].ToString() ?? string.Empty,
                        nama_pelanggan = reader["nama_pelanggan"] == DBNull.Value ? null : reader["nama_pelanggan"].ToString()
                    });
                }
            }
            return orders;
        }

        public bool AddOrder(Order order)
        {
            string query = @"
                INSERT INTO ""Order"" (tgl_order, user_id_user, meja_id_meja, tipe_pesanan_id_tipe_pesanan, status_pembayaran, metode_pembayaran_id_metode_pembayaran, nomor_pelanggan, nama_pelanggan)
                VALUES (@tgl, @user, @meja, @tipe, @status_bayar, @metode_bayar, @nomor, @nama)";

            using (NpgsqlConnection conn = AmbilKoneksi())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@tgl", order.tgl_order);
                cmd.Parameters.AddWithValue("@user", order.user_id_user);
                cmd.Parameters.AddWithValue("@meja", order.meja_id_meja);
                cmd.Parameters.AddWithValue("@tipe", order.tipe_pesanan_id_tipe_pesanan);
                cmd.Parameters.AddWithValue("@status_bayar", order.status_pembayaran);
                cmd.Parameters.AddWithValue("@metode_bayar", order.metode_pembayaran_id_metode_pembayaran == 0 ? DBNull.Value : order.metode_pembayaran_id_metode_pembayaran);
                cmd.Parameters.AddWithValue("@nomor", (object?)order.nomor_pelanggan ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@nama", (object?)order.nama_pelanggan ?? DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}