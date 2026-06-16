using Npgsql;
using System.Windows.Forms;

namespace CFMART.Helpers
{
    public class connectDB
    {
        private static string connString = 
            "Host=localhost;" +
            "Port=5432;" +
            "Username=postgres;" +
            "Password=riz27;" +
            "Database=CFMART;";

        public static NpgsqlConnection GetConn()
        {
            // Cukup buat objek koneksi, JANGAN panggil conn.Open() di sini
            return new NpgsqlConnection(connString);
        }
    }
}