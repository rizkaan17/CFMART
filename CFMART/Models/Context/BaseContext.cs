using CFMART.Helpers;
using Npgsql;

namespace CFMART.Models.Context
{
    public abstract class BaseContext
    {
        protected NpgsqlConnection AmbilKoneksi()
        {
            // Hanya mengambil objek koneksi yang belum terbuka
            return connectDB.GetConn();
        }
    }
}