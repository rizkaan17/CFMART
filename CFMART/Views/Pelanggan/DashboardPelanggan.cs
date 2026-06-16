using CFMART.Views;
using CFMART.Controllers;
using CFMART.Views.Pelanggan;
using CFMART.Views.Kasir;     // Sudah aman mendeteksi PanelHasilCari di subfolder
using CFMART.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CFMART
{
    public partial class DashboardPelanggan : Form
    {
        private readonly ProdukController _produkController = new ProdukController();
        private PanelHasilCari panelHasil = null;

        public DashboardPelanggan()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.DashboardPelanggan_Load);

            // 🌟 OPSI TAMBAHAN: Jika di desainer button1-button6 belum diikat event-nya, 
            // kita ikat secara terpusat ke satu fungsi yang sama di sini
            IkatEventTombolPlus();
        }

        private void DashboardPelanggan_Load(object sender, EventArgs e)
        {
            AmbilStokTerbaruDariDatabase();
        }

        /// <summary>
        /// Mengambil sisa stok riil berdasarkan ID Produk mutlak dari database pgAdmin
        /// </summary>
        private void AmbilStokTerbaruDariDatabase()
        {
            List<Produk> listProduk = _produkController.AmbilSemuaProduk();

            // Pencarian berbasis ID Jauh lebih aman dibanding pencarian string nama
            var pBakar = listProduk.FirstOrDefault(p => p.id_produk == 1);
            if (pBakar != null && labelstoklelebakar != null) labelstoklelebakar.Text = pBakar.stok.ToString();

            var pMangut = listProduk.FirstOrDefault(p => p.id_produk == 2);
            if (pMangut != null && lblstokmangutlele != null) lblstokmangutlele.Text = pMangut.stok.ToString();

            var pAir = listProduk.FirstOrDefault(p => p.id_produk == 3);
            if (pAir != null && lblstokairmineral != null) lblstokairmineral.Text = pAir.stok.ToString();

            var pJeruk = listProduk.FirstOrDefault(p => p.id_produk == 4);
            if (pJeruk != null && lblstokesjeruk != null) lblstokesjeruk.Text = pJeruk.stok.ToString();

            var pGoreng = listProduk.FirstOrDefault(p => p.id_produk == 5);
            if (pGoreng != null && lblstoklelegoreng != null) lblstoklelegoreng.Text = pGoreng.stok.ToString();

            var pTeh = listProduk.FirstOrDefault(p => p.id_produk == 6);
            if (pTeh != null && lblstokesteh != null) lblstokesteh.Text = pTeh.stok.ToString();
        }

        private void TambahKeKeranjang(int idProduk, string nama, double harga)
        {
            if (Program.DaftarBelanjaan == null)
            {
                Program.DaftarBelanjaan = new List<ItemKeranjang>();
            }

            var itemAda = Program.DaftarBelanjaan.FirstOrDefault(i => i.id_produk == idProduk);

            if (itemAda != null)
            {
                itemAda.quantity += 1;
            }
            else
            {
                Program.DaftarBelanjaan.Add(new ItemKeranjang
                {
                    id_produk = idProduk,
                    nama_produk = nama,
                    harga = (int)harga, // Sinkronisasi cast ke int HargaSatuan milik ItemKeranjang
                    quantity = 1
                });
            }

            MessageBox.Show($"{nama} sukses dimasukkan ke dalam keranjang belanja!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =========================================================================
        // 🌟 REFACTOR TERPUSAT: Menggabungkan 6 fungsi tombol menjadi 1 fungsi sakti
        // =========================================================================
        private void IkatEventTombolPlus()
        {
            // Kita pasang data di properti Tag masing-masing button sebagai penanda (ID, Nama, Harga)
            if (button1 != null) { button1.Tag = new Tuple<int, string, double>(1, "Lele Bakar", 18000); button1.Click += TombolPlusMenu_Click; }
            if (button2 != null) { button2.Tag = new Tuple<int, string, double>(2, "Mangut Lele", 22000); button2.Click += TombolPlusMenu_Click; }
            if (button3 != null) { button3.Tag = new Tuple<int, string, double>(3, "Air Mineral", 5000); button3.Click += TombolPlusMenu_Click; }
            if (button4 != null) { button4.Tag = new Tuple<int, string, double>(4, "Es Jeruk", 7000); button4.Click += TombolPlusMenu_Click; }
            if (button5 != null) { button5.Tag = new Tuple<int, string, double>(5, "Lele Goreng", 12000); button5.Click += TombolPlusMenu_Click; }
            if (button6 != null) { button6.Tag = new Tuple<int, string, double>(6, "Es Teh", 5000); button6.Click += TombolPlusMenu_Click; }
        }

        private void TombolPlusMenu_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Tuple<int, string, double> dataMenu)
            {
                // Eksekusi fungsi tambah keranjang menggunakan data dinamis di dalam Tag
                TambahKeKeranjang(dataMenu.Item1, dataMenu.Item2, dataMenu.Item3);
            }
        }

        // --- NAVIGASI HEADER ---
        private void btnKeranjang_Click(object sender, EventArgs e)
        {
            Views.Pelanggan.KeranjangBelanja frmKeranjang = new Views.Pelanggan.KeranjangBelanja();
            frmKeranjang.ShowDialog(); // Diubah jadi ShowDialog agar fokus sebagai pop-up belanja
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            Views.Pelanggan.CheckoutdanPembayaran frmCheckout = new Views.Pelanggan.CheckoutdanPembayaran();
            frmCheckout.ShowDialog();
        }

        // --- FILTER KATEGORI ---
        private void btnSemua_Click(object sender, EventArgs e) => ToggleVisibility(true, true);
        private void btnMakanan_Click(object sender, EventArgs e) => ToggleVisibility(true, false);
        private void btnMinuman_Click(object sender, EventArgs e) => ToggleVisibility(false, true);

        private void ToggleVisibility(bool mkn, bool mnm)
        {
            if (panelLeleGoreng != null) panelLeleGoreng.Visible = mkn;
            if (panelLeleBakar != null) panelLeleBakar.Visible = mkn;
            if (panelMangutLele != null) panelMangutLele.Visible = mkn;

            if (panelAirMineral != null) panelAirMineral.Visible = mnm;
            if (panelEsJeruk != null) panelEsJeruk.Visible = mnm;
            if (panelEsTeh != null) panelEsTeh.Visible = mnm;
        }

        // --- PENCARIAN DINAMIS ---
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

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

            List<Produk> hasilPencarianDb = _produkController.CariProduk(keyword);

            var hasilUntukPanel = hasilPencarianDb.Select(p => new DataProdukCari
            {
                Nama = p.jenis_produk,
                Harga = (int)p.harga,
                Gambar = null
            }).ToList();

            if (panelHasil == null)
            {
                panelHasil = new PanelHasilCari();
                panelHasil.Location = new Point(150, 170);

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
            panelHasil.TampilkanHasil(hasilUntukPanel);
        }

        private void btnloginkaryawan_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();

            // 🌟 LEBIH ELEGAN: Membuka sebagai dialog penahan. Dashboard tidak perlu menghilang amblas
            loginForm.ShowDialog();

            // Begitu loginForm ditutup, segarkan angka stok barangkali ada perubahan dari kasir
            AmbilStokTerbaruDariDatabase();
        }
    }
}