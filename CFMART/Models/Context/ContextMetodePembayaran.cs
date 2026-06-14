using Npgsql;
using System;
using System.Collections.Generic;

namespace CFMART.Models.Context
{
    // INHERITANCE: Kelas ini mewarisi BaseContext memakai tanda ':'
    public class ContextMetodePembayaran : BaseContext
    {
        public List<MetodePembayaran> GetAllMetodePembayaran()
        {
            List<MetodePembayaran> metodeList = new List<MetodePembayaran>();
            string query = @"SELECT id_metode_pembayaran, nama_metode FROM ""Metode_Pembayaran"" ORDER BY id_metode_pembayaran";

            // ABSTRACTION: Tinggal panggil AmbilKoneksi() milik induknya, tidak perlu connectDB.GetConn() lagi
            using (NpgsqlConnection conn = AmbilKoneksi())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    metodeList.Add(new MetodePembayaran
                    {
                        id_metode_pembayaran = Convert.ToInt32(reader["id_metode_pembayaran"]),
                        nama_metode = reader["nama_metode"]?.ToString() ?? ""
                    });
                }
            }
            return metodeList;
        }

        public bool AddMetodePembayaran(MetodePembayaran metode)
        {
            string query = @"INSERT INTO ""Metode_Pembayaran"" (nama_metode) VALUES (@nama)";

            using (NpgsqlConnection conn = AmbilKoneksi()) // Warisan induk
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nama", metode.nama_metode ?? (object)DBNull.Value);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateMetodePembayaran(MetodePembayaran metode)
        {
            string query = @"UPDATE ""Metode_Pembayaran"" SET nama_metode = @nama WHERE id_metode_pembayaran = @id";

            using (NpgsqlConnection conn = AmbilKoneksi()) // Warisan induk
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", metode.id_metode_pembayaran);
                cmd.Parameters.AddWithValue("@nama", metode.nama_metode ?? (object)DBNull.Value);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteMetodePembayaran(int id)
        {
            string query = @"DELETE FROM ""Metode_Pembayaran"" WHERE id_metode_pembayaran = @id";

            using (NpgsqlConnection conn = AmbilKoneksi()) // Warisan induk
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}