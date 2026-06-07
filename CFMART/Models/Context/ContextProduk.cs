using CFMART.Helpers;
using Npgsql;
using System.Collections.Generic;

namespace CFMART.Models.Context
{
    public class ContextProduk
    {
        public List<Produk> GetAllProduk()
        {
            List<Produk> produkList = new List<Produk>();

            string query = @"
                SELECT
                    id_produk,
                    jenis_produk,
                    harga,
                    stok,
                    foto_produk
                FROM Produk
                ORDER BY id_produk";

            using (NpgsqlConnection conn = connectDB.GetConn())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produk produk = new Produk
                            {
                                Id_Produk = reader.GetInt32(0),
                                Jenis_Produk = reader.GetString(1),
                                Harga = reader.GetDouble(2),
                                Stok = reader.GetInt32(3),
                                Foto_Produk = reader.IsDBNull(4)
                                    ? null
                                    : (byte[])reader["foto_produk"]
                            };

                            produkList.Add(produk);
                        }
                    }
                }
            }

            return produkList;
        }

        public Produk GetProdukById(int id)
        {
            Produk produk = null;

            string query = @"
                SELECT
                    id_produk,
                    jenis_produk,
                    harga,
                    stok,
                    foto_produk
                FROM Produk
                WHERE id_produk = @id";

            using (NpgsqlConnection conn = connectDB.GetConn())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            produk = new Produk
                            {
                                Id_Produk = reader.GetInt32(0),
                                Jenis_Produk = reader.GetString(1),
                                Harga = reader.GetDouble(2),
                                Stok = reader.GetInt32(3),
                                Foto_Produk = reader.IsDBNull(4)
                                    ? null
                                    : (byte[])reader["foto_produk"]
                            };
                        }
                    }
                }
            }

            return produk;
        }

        public bool AddProduk(Produk produk)
        {
            string query = @"
                INSERT INTO Produk
                (
                    jenis_produk,
                    harga,
                    stok,
                    foto_produk
                )
                VALUES
                (
                    @jenis,
                    @harga,
                    @stok,
                    @foto
                )";

            using (NpgsqlConnection conn = connectDB.GetConn())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@jenis", produk.Jenis_Produk);
                    cmd.Parameters.AddWithValue("@harga", produk.Harga);
                    cmd.Parameters.AddWithValue("@stok", produk.Stok);
                    cmd.Parameters.AddWithValue("@foto",
                        (object?)produk.Foto_Produk ?? DBNull.Value);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateProduk(Produk produk)
        {
            string query = @"
                UPDATE Produk
                SET
                    jenis_produk = @jenis,
                    harga = @harga,
                    stok = @stok,
                    foto_produk = @foto
                WHERE id_produk = @id";

            using (NpgsqlConnection conn = connectDB.GetConn())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", produk.Id_Produk);
                    cmd.Parameters.AddWithValue("@jenis", produk.Jenis_Produk);
                    cmd.Parameters.AddWithValue("@harga", produk.Harga);
                    cmd.Parameters.AddWithValue("@stok", produk.Stok);
                    cmd.Parameters.AddWithValue("@foto",
                        (object?)produk.Foto_Produk ?? DBNull.Value);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteProduk(int id)
        {
            string query = @"
                DELETE FROM Produk
                WHERE id_produk = @id";

            using (NpgsqlConnection conn = connectDB.GetConn())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}