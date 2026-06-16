using Npgsql;
using System;
using System.Collections.Generic;

namespace CFMART.Models.Context
{
    // INHERITANCE: Mewarisi BaseContext
    public class ContextProduk : BaseContext
    {
        public List<Produk> GetAllProduk()
        {
            List<Produk> produkList = new List<Produk>();
            string query = "SELECT id_produk, jenis_produk, harga, stok, foto_produk FROM produk ORDER BY id_produk";

            using (NpgsqlConnection conn = AmbilKoneksi())
            {
                conn.Open(); // <-- DILENGKAPI
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var p = new Produk
                        {
                            id_produk = reader.GetInt32(0),
                            jenis_produk = reader.GetString(1),
                            harga = reader.GetDouble(2),
                            stok = reader.GetInt32(3),
                            foto_Produk = reader["foto_produk"] != DBNull.Value ? (byte[])reader["foto_produk"] : null
                        };
                        produkList.Add(p);
                    }
                }
            }
            return produkList;
        }

        public bool UpdateProduk(Produk produk)
        {
            string query = @"UPDATE produk SET jenis_produk = @jenis, harga = @harga, stok = @stok, foto_produk = @foto WHERE id_produk = @id";

            using (NpgsqlConnection conn = AmbilKoneksi())
            {
                conn.Open(); // <-- DILENGKAPI
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", produk.id_produk);
                    cmd.Parameters.AddWithValue("@jenis", produk.jenis_produk);
                    cmd.Parameters.AddWithValue("@harga", produk.harga);
                    cmd.Parameters.AddWithValue("@stok", produk.stok);
                    cmd.Parameters.AddWithValue("@foto", (object?)produk.foto_Produk ?? DBNull.Value);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool AddProduk(Produk produk)
        {
            string query = @"INSERT INTO produk (jenis_produk, harga, stok, foto_produk) VALUES (@jenis, @harga, @stok, @foto)";

            using (NpgsqlConnection conn = AmbilKoneksi())
            {
                conn.Open(); // <-- DILENGKAPI
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@jenis", produk.jenis_produk);
                    cmd.Parameters.AddWithValue("@harga", produk.harga);
                    cmd.Parameters.AddWithValue("@stok", produk.stok);
                    cmd.Parameters.AddWithValue("@foto", (object?)produk.foto_Produk ?? DBNull.Value);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteProduk(int id)
        {
            string query = @"DELETE FROM produk WHERE id_produk = @id";

            using (NpgsqlConnection conn = AmbilKoneksi())
            {
                conn.Open(); // <-- DILENGKAPI
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}