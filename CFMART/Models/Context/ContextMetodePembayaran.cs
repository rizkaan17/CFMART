using CFMART.Helpers;
using Npgsql;
using System.Collections.Generic;

namespace CFMART.Models
{
    public class ContextMetodePembayaran
    {
        public List<MetodePembayaran> GetAllMetodePembayaran()
        {
            List<MetodePembayaran> metodeList = new List<MetodePembayaran>();

            string query = @"
                SELECT
                    id_metode_pembayaran,
                    nama_metode
                FROM Metode_Pembayaran
                ORDER BY id_metode_pembayaran";

            using (NpgsqlConnection conn = connectDB.GetConn())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    metodeList.Add(new MetodePembayaran
                    {
                        Id_Metode_Pembayaran = reader.GetInt32(0),
                        Nama_Metode = reader.GetString(1)
                    });
                }
            }

            return metodeList;
        }

        public bool AddMetodePembayaran(MetodePembayaran metode)
        {
            string query = @"
                INSERT INTO Metode_Pembayaran
                (
                    nama_metode
                )
                VALUES
                (
                    @nama
                )";

            using (NpgsqlConnection conn = connectDB.GetConn())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nama", metode.Nama_Metode);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateMetodePembayaran(MetodePembayaran metode)
        {
            string query = @"
                UPDATE Metode_Pembayaran
                SET nama_metode = @nama
                WHERE id_metode_pembayaran = @id";

            using (NpgsqlConnection conn = connectDB.GetConn())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", metode.Id_Metode_Pembayaran);
                cmd.Parameters.AddWithValue("@nama", metode.Nama_Metode);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteMetodePembayaran(int id)
        {
            string query = @"
                DELETE FROM Metode_Pembayaran
                WHERE id_metode_pembayaran = @id";

            using (NpgsqlConnection conn = connectDB.GetConn())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}