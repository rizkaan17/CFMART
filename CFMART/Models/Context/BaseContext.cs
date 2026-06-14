using CFMART.Helpers;
using Npgsql;
using System;
using System.Data;

namespace CFMART.Models.Context
{
    /// <summary>
    /// ABSTRACTION: Kelas induk abstrak untuk menyembunyikan kerumitan koneksi database.
    /// </summary>
    public abstract class BaseContext
    {
        // Protected artinya hanya bisa diakses oleh kelas ini dan kelas-kelas anaknya (Inheritance)
        protected NpgsqlConnection AmbilKoneksi()
        {
            NpgsqlConnection conn = connectDB.GetConn();

            // Memastikan koneksi otomatis terbuka jika dalam keadaan tertutup
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            return conn;
        }
    }
}