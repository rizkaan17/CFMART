using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFMART.Helpers
{
    public class connectDB
    {
        //ini inisialisasi database
        private static string connString =
            "Host=localhost;" +
            "Port=5432;" +
            "Username=postgres;" +
            "Password=riz27;" + //password kalian
            "Database=CFMART;"; //database kalian
        public static NpgsqlConnection GetConn() //ini method manggil database
        {
            NpgsqlConnection conn = new NpgsqlConnection(connString);

            try
            {
                conn.Open();
                //Jika koneksi sudah berhasil matikan atau comment messagebox dibawah
                //MessageBox.Show("Koneksi Berhasil"); comment ini jika sudah koneksi berhasil agar tidak muncul ketika buka tab
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi gagal di : " + ex.Message);
            }

            return conn;
        }

    }
}
