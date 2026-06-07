using CFMART.Helpers;
using Npgsql;
using System.Collections.Generic;

namespace CFMART.Models
{
    public class ContextStatusOrder
    {
        public List<StatusOrder> GetAllStatusOrder()
        {
            List<StatusOrder> statusList = new List<StatusOrder>();

            string query = @"
                SELECT
                    id_status_order,
                    status_order
                FROM Status_Order
                ORDER BY id_status_order";

            using (NpgsqlConnection conn = connectDB.GetConn())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    statusList.Add(new StatusOrder
                    {
                        Id_Status_Order = reader.GetInt32(0),
                        Status_Order = reader.GetString(1)
                    });
                }
            }

            return statusList;
        }

        public bool AddStatusOrder(StatusOrder status)
        {
            string query = @"
                INSERT INTO Status_Order
                (
                    status_order
                )
                VALUES
                (
                    @status
                )";

            using (NpgsqlConnection conn = connectDB.GetConn())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@status", status.Status_Order);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateStatusOrder(StatusOrder status)
        {
            string query = @"
                UPDATE Status_Order
                SET status_order = @status
                WHERE id_status_order = @id";

            using (NpgsqlConnection conn = connectDB.GetConn())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", status.Id_Status_Order);
                cmd.Parameters.AddWithValue("@status", status.Status_Order);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteStatusOrder(int id)
        {
            string query = @"
                DELETE FROM Status_Order
                WHERE id_status_order = @id";

            using (NpgsqlConnection conn = connectDB.GetConn())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}