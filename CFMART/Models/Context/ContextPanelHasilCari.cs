using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using System.Drawing;
using System.IO;

namespace CFMART.Models.Context
{
    // 🌟 SINKRON OOP: Mewarisi BaseContext dan memanggil AmbilKoneksi()
    public class ContextProdukCari : BaseContext
    {
        public List<DataProdukCari> AmbilHasilPencarianDb(string keyword)
        {
            List<DataProdukCari> listHasil = new List<DataProdukCari>();

            // Menembak langsung ke tabel Produk dengan filter LIKE
            string query = @"SELECT jenis_produk, harga, foto FROM ""Produk"" WHERE LOWER(jenis_produk) LIKE @key;";

            try
            {
                using var conn = AmbilKoneksi();
                if (conn.State != ConnectionState.Open) conn.Open();

                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("key", "%" + keyword.ToLower() + "%");

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DataProdukCari prod = new DataProdukCari();
                    prod.Nama = reader["jenis_produk"].ToString();
                    prod.Harga = Convert.ToInt32(reader["harga"]);

                    // Memproses data blob byte[] foto di pgAdmin menjadi Image C#
                    if (reader["foto"] != DBNull.Value)
                    {
                        byte[] fotoBytes = (byte[])reader["foto"];
                        using MemoryStream ms = new MemoryStream(fotoBytes);
                        prod.Gambar = Image.FromStream(ms);
                    }

                    listHasil.Add(prod);
                }
            }
            catch
            {
                // Jika database kosong, kembalikan list kosong agar UI tidak crash
                return listHasil;
            }

            return listHasil;
        }
    }
}