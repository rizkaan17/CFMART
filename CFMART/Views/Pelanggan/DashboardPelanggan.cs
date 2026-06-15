using CFMART.Models.Context;
using CFMART.Views;
using CFMART.Views.Pelanggan;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CFMART
{
    public partial class DashboardPelanggan : Form
    {
        // Menyambungkan halaman ke ProdukController untuk operasi pencarian dan stok riil
        private readonly ProdukController _produkController = new ProdukController();
        private PanelHasilCari panelHasil = null;

        public DashboardPelanggan()
        {
            InitializeComponent();

            // Mengikat event Load Form secara dinamis lewat kode
            this.Load += new System.EventHandler(this.DashboardPelanggan_Load);
        }

        private void DashboardPelanggan_Load(object sender, EventArgs e)
        {
            // Sinkronisasikan angka-angka stok kartu menu figma kamu dengan isi database pgAdmin saat aplikasi dibuka
            AmbilStokTerbaruDariDatabase();
        }

        /// <summary>
        /// Mengambil sisa stok riil dari PostgreSQL agar kasir/pelanggan tahu jika makanan sudah habis
        /// </summary>
        private void AmbilStokTerbaruDariDatabase()
        {
            List<Produk> listProduk = _produkController.AmbilSemuaProduk();

            // 1. Sinkronisasi Stok Lele Bakar (ID 1)
            var pBakar = listProduk.FirstOrDefault(p => p.jenis_produk.ToLower().Contains("bakar"));
            if (pBakar != null) labelstoklelebakar.Text = pBakar.stok.ToString();

            // 2. Sinkronisasi Stok Mangut Lele (ID 2)
            var pMangut = listProduk.FirstOrDefault(p => p.jenis_produk.ToLower().Contains("mangut"));
            if (pMangut != null) lblstokmangutlele.Text = pMangut.stok.ToString();

            // 3. Sinkronisasi Stok Air Mineral (ID 3)
            var pAir = listProduk.FirstOrDefault(p => p.jenis_produk.ToLower().Contains("air"));
            if (pAir != null) lblstokairmineral.Text = pAir.stok.ToString();

            // 4. Sinkronisasi Stok Es Jeruk (ID 4)
            var pJeruk = listProduk.FirstOrDefault(p => p.jenis_produk.ToLower().Contains("jeruk"));
            if (pJeruk != null) lblstokesjeruk.Text = pJeruk.stok.ToString();

            // 5. Sinkronisasi Stok Lele Goreng (ID 5)
            var pGoreng = listProduk.FirstOrDefault(p => p.jenis_produk.ToLower().Contains("goreng"));
            if (pGoreng != null) lblstoklelegoreng.Text = pGoreng.stok.ToString();

            // 6. Sinkronisasi Stok Es Teh (ID 6)
            var pTeh = listProduk.FirstOrDefault(p => p.jenis_produk.ToLower().Contains("teh"));
            if (pTeh != null) lblstokesteh.Text = pTeh.stok.ToString();
        }

        // --- FUNGSI UTAMA TAMBAH KE KERANJANG BELANJA RAM ---
        private void TambahKeKeranjang(int idProduk, string nama, double harga)
        {
            if (Program.DaftarBelanjaan == null)
            {
                Program.DaftarBelanjaan = new List<ItemKeranjang>();
            }

            // Cek apakah item makanan ini sudah masuk daftar order sebelumnya?
            var itemAda = Program.DaftarBelanjaan.FirstOrDefault(i => i.id_produk == idProduk);

            if (itemAda != null)
            {
                itemAda.quantity += 1;
            }
            else
            {
                // Membuat bungkusan ItemKeranjang baru bersertifikat Model terpusat
                ItemKeranjang itemBaru = new ItemKeranjang
                {
                    id_produk = idProduk,
                    nama_produk = nama,
                    harga = harga,
                    quantity = 1
                };
                Program.DaftarBelanjaan.Add(itemBaru);
            }

            MessageBox.Show($"{nama} sukses dimasukkan ke dalam keranjang belanja!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =========================================================================
        // --- EVENT KLIK TOMBOL PLUS DESAINER KAMU (button1 sampai button6) ---
        // =========================================================================
        private void button1_Click_1(object sender, EventArgs e) { TambahKeKeranjang(1, "Lele Bakar", 18000); }
        private void button2_Click_1(object sender, EventArgs e) { TambahKeKeranjang(2, "Mangut Lele", 22000); }
        private void button3_Click_1(object sender, EventArgs e) { TambahKeKeranjang(3, "Air Mineral", 5000); }
        private void button4_Click_1(object sender, EventArgs e) { TambahKeKeranjang(4, "Es Jeruk", 7000); }
        private void button5_Click_1(object sender, EventArgs e) { TambahKeKeranjang(5, "Lele Goreng", 12000); }
        private void button6_Click_1(object sender, EventArgs e) { TambahKeKeranjang(6, "Es Teh", 5000); }

        // --- NAVIGASI ANTAR TOMBOL HEADER FIGMA ---
        private void btnKeranjang_Click(object sender, EventArgs e)
        {
            Views.Pelanggan.KeranjangBelanja frmKeranjang = new Views.Pelanggan.KeranjangBelanja();
            frmKeranjang.Show();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            Views.Pelanggan.CheckoutdanPembayaran frmCheckout = new Views.Pelanggan.CheckoutdanPembayaran();
            frmCheckout.Show();
        }

        // --- FILTER KATEGORI CIRI KHAS KAFE ---
        private void btnSemua_Click(object sender, EventArgs e) => ToggleVisibility(true, true);
        private void btnMakanan_Click(object sender, EventArgs e) => ToggleVisibility(true, false);
        private void btnMinuman_Click(object sender, EventArgs e) => ToggleVisibility(false, true);

        private void ToggleVisibility(bool mkn, bool mnm)
        {
            panelLeleGoreng.Visible = panelLeleBakar.Visible = panelMangutLele.Visible = mkn;
            panelAirMineral.Visible = panelEsJeruk.Visible = panelEsTeh.Visible = mnm;
        }

        // =========================================================================
        // --- KONTROL PENCARIAN DINAMIS (Terhubung riil ke PostgreSQL) ---
        // =========================================================================
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            // Jika textbox kosong atau berisi teks petunjuk awal figma, musnahkan panel hasil cari melayang
            if (string.IsNullOrEmpty(keyword) || keyword == "Cari lele bakar, goreng, ...")
            {
                if (panelHasil != null)
                {
                    this.Controls.Remove(panelHasil);
                    panelHasil.Dispose();
                    panelHasil = null;
                }
                return;
            }

            // 1. Ambil data asli database berupa List<Produk>
            List<Produk> hasilPencarianDb = _produkController.CariProduk(keyword);

            // 2. 🌟 TRIK PENYELAMAT: Mengubah List<Produk> menjadi List<DataProdukCari> secara instan di RAM
            // Supaya TampilkanHasil tidak membaca merah objeknya lagi
            var hasilUntukPanel = hasilPencarianDb.Select(p => new DataProdukCari
            {
                Nama = p.jenis_produk,
                Harga = (int)p.harga,
                Gambar = null
            }).ToList();

            if (panelHasil == null)
            {
                panelHasil = new PanelHasilCari();
                panelHasil.Location = new Point(150, 170); // Diatur pas di bawah bar panel2 search kamu

                panelHasil.OnTambahKeranjangKlik += (nama, harga) =>
                {
                    var produkTerpilih = hasilPencarianDb.FirstOrDefault(p => p.jenis_produk == nama);
                    int idProd = (produkTerpilih != null) ? produkTerpilih.id_produk : 1;
                    TambahKeKeranjang(idProd, nama, harga);
                };

                panelHasil.OnCloseKlik += () =>
                {
                    this.Controls.Remove(panelHasil);
                    panelHasil.Dispose();
                    panelHasil = null;
                    txtSearch.Clear();
                };
                this.Controls.Add(panelHasil);
                panelHasil.BringToFront();
            }

            panelHasil.SetJudul(keyword);

            // ✅ SEKARANG AMAN: Yang kita kirim adalah objek hasilUntukPanel yang sudah sesuai tipe lamamu
            panelHasil.TampilkanHasil(hasilUntukPanel);
        }

        private void btnloginkaryawan_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();

            // Menampilkan form tersebut
            loginForm.Show();

        }
    }
}