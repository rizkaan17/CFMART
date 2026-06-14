using CFMART.Helpers;
using CFMART.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CFMART.Controllers
{
    // =========================================================================
    // ENCAPSULATION: Membungkus logika akses data di dalam satu Class agar
    // Form tidak perlu tahu detail query SQL.
    // =========================================================================
    public class ProdukController
    {
        // 1. CRUD PRODUK
        
        // ABSTRAKSI: Menampilkan fungsi 'GetAllProduk()' sehingga user 
        // tidak perlu tahu proses NpgsqlCommand dan Connection-nya.
        public List<Produk> GetAllProduk()
        {
            var list = new List<Produk>();
            try
            {
                using var conn = connectDB.GetConn();
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT id_produk, jenis_produk, harga, stok, foto_produk FROM produk", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Produk
                    {
                        Id_Produk = reader.GetInt32(0),
                        Jenis_Produk = reader.GetString(1),
                        Harga = (double)reader.GetDecimal(2),
                        Stok = reader.GetInt32(3),
                        Foto_Produk = reader.IsDBNull(4) ? null : (byte[])reader["foto_produk"]
                    });
                }
            }
            catch (Exception ex) { MessageBox.Show("Error Load Produk: " + ex.Message); }
            return list;
        }

        // POLYMORPHISM (Method Overloading): 
        // Contoh: CariProduk(int id) dan CariProduk(string keyword)
        // Nama sama, tapi parameter beda, sehingga fungsi bisa berjalan secara fleksibel.
        public Produk GetProdukById(int id)
        {
            using var conn = connectDB.GetConn();
            conn.Open();
            var cmd = new NpgsqlCommand("SELECT id_produk, jenis_produk, harga, stok, foto_produk FROM produk WHERE id_produk = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Produk
                {
                    Id_Produk = reader.GetInt32(0),
                    Jenis_Produk = reader.GetString(1),
                    Harga = (double)reader.GetDecimal(2),
                    Stok = reader.GetInt32(3),
                    Foto_Produk = reader.IsDBNull(4) ? null : (byte[])reader["foto_produk"]
                };
            }
            return null;
        }

        public List<Produk> SearchProduk(string keyword)
        {
            var list = new List<Produk>();
            using var conn = connectDB.GetConn();
            conn.Open();
            var cmd = new NpgsqlCommand("SELECT id_produk, jenis_produk, harga, stok FROM produk WHERE LOWER(jenis_produk) LIKE LOWER(@keyword)", conn);
            cmd.Parameters.AddWithValue("keyword", $"%{keyword}%");
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Produk { Id_Produk = reader.GetInt32(0), Jenis_Produk = reader.GetString(1), Harga = (double)reader.GetDecimal(2), Stok = reader.GetInt32(3) });
            }
            return list;
        }

        public bool TambahProduk(string nama, double harga, int stok, byte[] foto)
        {
            using var conn = connectDB.GetConn();
            conn.Open();
            string query = "INSERT INTO produk (jenis_produk, harga, stok, foto_produk) VALUES (@nama, @harga, @stok, @foto)";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("nama", nama);
            cmd.Parameters.AddWithValue("harga", harga);
            cmd.Parameters.AddWithValue("stok", stok);
            cmd.Parameters.AddWithValue("foto", (object)foto ?? DBNull.Value);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool EditProduk(int id, string nama, double harga, int stok, byte[] foto)
        {
            using var conn = connectDB.GetConn();
            conn.Open();
            string query = "UPDATE produk SET jenis_produk=@nama, harga=@harga, stok=@stok, foto_produk=@foto WHERE id_produk=@id";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("nama", nama);
            cmd.Parameters.AddWithValue("harga", harga);
            cmd.Parameters.AddWithValue("stok", stok);
            cmd.Parameters.AddWithValue("foto", (object)foto ?? DBNull.Value);
            cmd.Parameters.AddWithValue("id", id);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool HapusProduk(int id)
        {
            using var conn = connectDB.GetConn();
            conn.Open();
            var cmd = new NpgsqlCommand("DELETE FROM produk WHERE id_produk = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool UpdateStok(int idProduk, int stokBaru)
        {
            using var conn = connectDB.GetConn();
            conn.Open();
            var cmd = new NpgsqlCommand("UPDATE produk SET stok = @stok WHERE id_produk = @id", conn);
            cmd.Parameters.AddWithValue("id", idProduk);
            cmd.Parameters.AddWithValue("stok", stokBaru);
            return cmd.ExecuteNonQuery() > 0;
        }

        // 2. DASHBOARD & STATISTIK
        
        public Dictionary<string, object> AmbilAngkaStatistik()
        {
            var data = new Dictionary<string, object>();
            using var conn = connectDB.GetConn();
            conn.Open();
            // Implementasi Query kompleks disembunyikan agar form tetap bersih
            using (var cmd = new NpgsqlCommand(@"SELECT COUNT(*) FROM ""Order""", conn)) data["total_pesanan"] = Convert.ToInt32(cmd.ExecuteScalar());
            using (var cmd = new NpgsqlCommand(@"SELECT COALESCE(SUM(stok), 0) FROM produk", conn)) data["total_stok"] = Convert.ToInt32(cmd.ExecuteScalar());
            using (var cmd = new NpgsqlCommand(@"SELECT COUNT(*) FROM ""User"" WHERE status_karyawan = true", conn)) data["karyawan_aktif"] = Convert.ToInt32(cmd.ExecuteScalar());
            return data;
        }

        public Dictionary<string, object> AmbilAngkaStatistikKasir()
        {
            var data = new Dictionary<string, object>();
            using var conn = connectDB.GetConn();
            conn.Open();
            using (var cmd = new NpgsqlCommand(@"SELECT COUNT(*) FROM ""Order""", conn)) data["total_transaksi"] = Convert.ToInt32(cmd.ExecuteScalar());
            using (var cmd = new NpgsqlCommand(@"SELECT COALESCE(SUM(harga), 0) FROM produk", conn))
            {
                double pendapatan = Convert.ToDouble(cmd.ExecuteScalar());
                data["total_pendapatan"] = "Rp " + pendapatan.ToString("N0");
            }
            using (var cmd = new NpgsqlCommand("SELECT jenis_produk FROM produk ORDER BY stok DESC LIMIT 1", conn))
            {
                object result = cmd.ExecuteScalar();
                data["produk_terlaris"] = result != null ? result.ToString() : "Belum Ada";
            }
            return data;
        }

        public DataTable AmbilPesananTerbaru()
        {
            DataTable dt = new DataTable();
            using var conn = connectDB.GetConn();
            conn.Open();
            string query = @"SELECT id_order AS ""ID Order"", nama_pelanggan AS ""Nama Pelanggan"", tgl_order AS ""Waktu Pesan"" FROM ""Order"" ORDER BY id_order DESC LIMIT 5";
            using var cmd = new NpgsqlCommand(query, conn);
            using var adapter = new NpgsqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
    }
}
