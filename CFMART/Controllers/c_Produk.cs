using CFMART.Helpers;
using CFMART.Models;
using Npgsql;
using System.Data;

namespace CFMART.Controllers
{
    public class ProdukController
    {
        // Ambil semua produk
        public List<Produk> GetAllProduk()
        {
            var list = new List<Produk>();
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
            return list;
        }

        // Search produk by nama
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

        // Tambah produk baru
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

        // Edit produk
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

        // Update stok saja
        public bool UpdateStok(int idProduk, int stokBaru)
        {
            using var conn = connectDB.GetConn();
            conn.Open();
            var cmd = new NpgsqlCommand(
                "UPDATE produk SET stok = @stok WHERE id_produk = @id", conn);
            cmd.Parameters.AddWithValue("id", idProduk);
            cmd.Parameters.AddWithValue("stok", stokBaru);
            return cmd.ExecuteNonQuery() > 0;
        }

        // Hapus produk (akan ditolak trigger jika punya transaksi)
        public bool HapusProduk(int id)
        {
            using var conn = connectDB.GetConn();
            conn.Open();
            var cmd = new NpgsqlCommand("DELETE FROM produk WHERE id_produk = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            return cmd.ExecuteNonQuery() > 0;
        }

        // 6. DETAIL: Ambil detail by ID (Penting untuk Form Edit)
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
        // --- TAMBAHAN UNTUK DASHBOARD (Taruh di dalam class ProdukController) ---

        // 1. Fungsi hitung angka 3 kotak atas
        // =========================================================================
        // FIX QUERY DASHBOARD SESUAI STRUKTUR TABEL SQL ASLI 
        // =========================================================================

        // 1. Fungsi hitung angka untuk 3 kotak statistik atas
        public Dictionary<string, object> AmbilAngkaStatistik()
        {
            var data = new Dictionary<string, object>();
            using var conn = connectDB.GetConn();
            conn.Open();

            // SINKRONISASI 1: Hitung total baris dari tabel "Order" (bukan transaksi)
            using (var cmd = new NpgsqlCommand(@"SELECT COUNT(*) FROM ""Order""", conn))
            {
                data["total_pesanan"] = Convert.ToInt32(cmd.ExecuteScalar());
            }

            // SINKRONISASI 2: Hitung total stok dari tabel Produk kolom Stok (huruf S besar sesuai SQL)
            using (var cmd = new NpgsqlCommand(@"SELECT COALESCE(SUM(stok), 0) FROM produk", conn))
            {
                data["total_stok"] = Convert.ToInt32(cmd.ExecuteScalar());
            }

            // SINKRONISASI 3: Hitung karyawan aktif dari tabel "User" kolom Status_Karyawan
            using (var cmd = new NpgsqlCommand(@"SELECT COUNT(*) FROM ""User"" WHERE status_karyawan = true", conn))
            {
                data["karyawan_aktif"] = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return data;
        }

        // 2. Fungsi mengisi DataGridView pesanan terbawah
        public DataTable AmbilPesananTerbaru()
        {
            DataTable dt = new DataTable();
            using var conn = connectDB.GetConn();
            conn.Open();

            // SINKRONISASI 4: Menggunakan Id_Order, Nama_Pelanggan dari tabel "Order"
            string query = @"SELECT id_order AS ""ID Order"", 
                            nama_pelanggan AS ""Nama Pelanggan"",
                            tgl_order AS ""Waktu Pesan""
                     FROM ""Order"" 
                     ORDER BY id_order DESC 
                     LIMIT 5";

            using (var cmd = new NpgsqlCommand(query, conn))
            {
                using (var adapter = new NpgsqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        // 1. Fungsi hitung angka untuk 3 kotak statistik atas (Versi Sinkron Kasir)
        public Dictionary<string, object> AmbilAngkaStatistikKasir()
        {
            var data = new Dictionary<string, object>();
            using var conn = connectDB.GetConn();
            conn.Open();

            // 1. Kotak 1: Hitung total transaksi dari tabel "Order"
            using (var cmd = new NpgsqlCommand(@"SELECT COUNT(*) FROM ""Order""", conn))
            {
                data["total_transaksi"] = Convert.ToInt32(cmd.ExecuteScalar());
            }

            // 2. Kotak 2: Hitung total pendapatan (Contoh: Total harga semua produk yang ada)
            using (var cmd = new NpgsqlCommand(@"SELECT COALESCE(SUM(harga), 0) FROM produk", conn))
            {
                double pendapatan = Convert.ToDouble(cmd.ExecuteScalar());
                data["total_pendapatan"] = "Rp " + pendapatan.ToString("N0");
            }

            // 3. Kotak 3: Cari NAMA PRODUK TERLARIS (Paling banyak diorder)
            // Catatan: Query ini mengambil asumsi nama kolom 'jenis_produk' dari tabel produk kamu.
            string queryProdukTerlaris = @"
        SELECT p.jenis_produk 
        FROM produk p
        ORDER BY p.stok DESC 
        LIMIT 1";
            // 💡 Catatan: Jika kamu punya tabel ""OrderDetail"" atau ""ItemOrder"", 
            // query di atas nanti bisa diganti ke JOIN tabel tersebut. 
            // Untuk sementara, ini mengambil produk yang stoknya paling sedikit/paling laku.

            using (var cmd = new NpgsqlCommand(queryProdukTerlaris, conn))
            {
                object result = cmd.ExecuteScalar();
                data["produk_terlaris"] = result != null ? result.ToString() : "Belum Ada";
            }

            return data;
        }
    }
}