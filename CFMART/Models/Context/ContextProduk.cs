using Npgsql;
using System;
using System.Collections.Generic;

namespace CFMART.Models.Context
{
    // INHERITANCE: Mewarisi BaseContext
    public class ContextProduk : BaseContext
    {
        // TAMPILKAN SEMUA PRODUK
        public List<Produk> GetAllProduk()
        {
            List<Produk> produkList = new List<Produk>();
            string query = @"SELECT id_produk, jenis_produk, harga, stok, foto_produk FROM produk ORDER BY id_produk";

            using (NpgsqlConnection conn = AmbilKoneksi()) // Menggunakan fungsi induk
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    produkList.Add(new Produk
                    {
                        id_produk = Convert.ToInt32(reader["id_produk"]),
                        jenis_produk = reader["jenis_produk"].ToString() ?? "",
                        harga = Convert.ToDouble(reader["harga"]),
                        stok = Convert.ToInt32(reader["stok"]),
                        foto_Produk = reader["foto_produk"] == DBNull.Value ? null : (byte[])reader["foto_produk"]
                    });
                }
            }
            return produkList;
        }

        // UPDATE STOK / HARGA PRODUK
        public bool UpdateProduk(Produk produk)
        {
            string query = @"UPDATE produk SET jenis_produk = @jenis, harga = @harga, stok = @stok, foto_produk = @foto WHERE id_produk = @id";

            using (NpgsqlConnection conn = AmbilKoneksi())
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

        // Taruh di dalam kelas ContextProduk : BaseContext

        public bool AddProduk(Produk produk)
        {
            string query = @"INSERT INTO produk (jenis_produk, harga, stok, foto_produk) VALUES (@jenis, @harga, @stok, @foto)";

            using (NpgsqlConnection conn = AmbilKoneksi())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@jenis", produk.jenis_produk);
                cmd.Parameters.AddWithValue("@harga", produk.harga);
                cmd.Parameters.AddWithValue("@stok", produk.stok);
                cmd.Parameters.AddWithValue("@foto", (object?)produk.foto_Produk ?? DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteProduk(int id)
        {
            string query = @"DELETE FROM produk WHERE id_produk = @id";

            using (NpgsqlConnection conn = AmbilKoneksi())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}