using CFMART.Models;
using CFMART.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CFMART.Controllers
{
    public class ProdukController
    {
        private readonly ContextProduk _contextProduk = new ContextProduk();

        /// <summary>
        /// Mengambil semua list produk dari database
        /// </summary>
        public List<Produk> AmbilSemuaProduk()
        {
            try
            {
                return _contextProduk.GetAllProduk();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil data produk: " + ex.Message, "Error Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Produk>();
            }
        }

        // =======================================================
        // 🌟 PILAR POLYMORPHISM: METHOD OVERLOADING (Pencarian Produk)
        // =======================================================

        /// <summary>
        /// Bentuk 1: Mengambil satu data produk berdasarkan ID (Integer)
        /// </summary>
        public Produk CariProduk(int id)
        {
            try
            {
                // Memanfaatkan list data dari GetAllProduk() lalu difilter menggunakan LINQ FirstOrDefault
                List<Produk> semuaProduk = _contextProduk.GetAllProduk();
                return semuaProduk.FirstOrDefault(p => p.id_produk == id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencari produk: " + ex.Message, "Error Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Bentuk 2: Mencari produk berdasarkan Ketikan Nama (String)
        /// </summary>
        public List<Produk> CariProduk(string nama)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nama)) return AmbilSemuaProduk();

                List<Produk> semuaProduk = _contextProduk.GetAllProduk();
                return semuaProduk.Where(p => p.jenis_produk.ToLower().Contains(nama.ToLower().Trim())).ToList();
            }
            catch
            {
                return new List<Produk>();
            }
        }

        // =======================================================
        // 🌟 PILAR POLYMORPHISM: METHOD OVERLOADING (Update/Ubah Data)
        // =======================================================

        /// <summary>
        /// Bentuk 1: Update produk LENGKAP dengan memperbarui Foto Produk (byte[])
        /// </summary>
        public bool UpdateProduk(int id, string jenis, double harga, int stok, byte[] foto)
        {
            if (id <= 0) return false;

            if (string.IsNullOrEmpty(jenis?.Trim()))
            {
                MessageBox.Show("Nama/Jenis produk wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                Produk produkEdit = new Produk
                {
                    id_produk = id,
                    jenis_produk = jenis.Trim(),
                    harga = harga,
                    stok = stok,
                    foto_Produk = foto // Disesuaikan dengan properti model: foto_Produk
                };

                return _contextProduk.UpdateProduk(produkEdit);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengubah data produk: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Bentuk 2: Update data produk CEPAT tanpa mengubah file gambar/foto lamanya
        /// </summary>
        public bool UpdateProduk(int id, string nama, double harga, int stok)
        {
            // Mengambil data lama terlebih dahulu agar file foto lama tidak hilang tertimpa null
            Produk produkLama = CariProduk(id);
            byte[]? fotoLama = produkLama?.foto_Produk;

            // Melemparkan data ke Bentuk 1 menggunakan teknik chaining reuse code
            return UpdateProduk(id, nama, harga, stok, fotoLama);
        }

        // =======================================================

        /// <summary>
        /// Validasi dan simpan produk baru (Gunakan Insert murni di Context jika Stored Procedure tidak ada)
        /// </summary>
        public bool TambahProduk(string jenis, double harga, int stok, byte[] foto)
        {
            if (string.IsNullOrEmpty(jenis?.Trim()))
            {
                MessageBox.Show("Nama/Jenis produk wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                Produk produkBaru = new Produk
                {
                    jenis_produk = jenis.Trim(),
                    harga = harga,
                    stok = stok,
                    foto_Produk = foto // Disesuaikan dengan properti model: foto_Produk
                };

                // Pastikan fungsi AddProduk sudah dideklarasikan di ContextProduk.cs kamu jika mau dipakai
                return _contextProduk.AddProduk(produkBaru);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menambah produk ke database: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        /// <summary>
        /// Method tambahan untuk menambah produk langsung dari file path
        /// </summary>
        public bool TambahProdukDariFile(string jenis, double harga, int stok, string filePath)
        {
            try
            {
                // 1. Validasi file path agar tidak error saat aplikasi dijalankan
                if (string.IsNullOrEmpty(filePath) || !System.IO.File.Exists(filePath))
                {
                    // Jika user tidak pilih foto, kita tetap bisa simpan produk (foto = null)
                    return TambahProduk(jenis, harga, stok, null);
                }

                // 2. Ubah file jadi byte array
                byte[] fotoByte = System.IO.File.ReadAllBytes(filePath);

                // 3. Panggil method TambahProduk yang sudah ada (Code Reuse)
                return TambahProduk(jenis, harga, stok, fotoByte);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memproses file foto: " + ex.Message, "Error File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Menghapus produk berdasarkan ID
        /// </summary>
        public bool HapusProduk(int id)
        {
            if (id <= 0) return false;

            try
            {
                // Pastikan fungsi DeleteProduk sudah dideklarasikan di ContextProduk.cs kamu jika mau dipakai
                return _contextProduk.DeleteProduk(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghapus produk dari database: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}