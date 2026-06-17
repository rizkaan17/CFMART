using CFMART.Controllers;
using CFMART.Models;
using CFMART.Views;
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
        private List<Produk> _semuaProdukCache = new List<Produk>();
        private string _kategoriAktif = "Semua"; // Untuk melacak filter tombol kategori

        public DashboardPelanggan()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.DashboardPelanggan_Load);

            this.Activated += DashboardPelanggan_Activated;

            // Ikat event klik 6 tombol plus menu makanan & minuman secara otomatis
            IkatEventTombolPlus();
        }
        private void DashboardPelanggan_Activated(object sender, EventArgs e)
        {
            // Setiap kali kembali ke dashboard ini, ambil data terbaru dari DB
            RefreshDataProduk();
        }

        private void DashboardPelanggan_Load(object sender, EventArgs e)
        {
            // Ambil data awal dari database PostgreSQL saat form dibuka
            RefreshDataProduk();
        }

        /// <summary>
        /// Mengambil data terbaru dari database dan merender katalog sesuai saringan
        /// </summary>
        private void RefreshDataProduk()
        {
            _semuaProdukCache = _produkController.AmbilSemuaProduk();
            FilterDanRenderKatalog();
        }
        private Image ConvertBytesToImage(byte[] data)
        {
            if (data == null || data.Length == 0) return null;
            using (var ms = new System.IO.MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        /// <summary>
        /// 🌟 LOGIKA UTAMA: Menyaring tampilan menu berdasarkan Textbox Search DAN Tombol Kategori
        /// </summary>
        private void FilterDanRenderKatalog()
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            // Abaikan keyword jika masih berupa placeholder bawaan figma
            if (keyword == "cari lele bakar, goreng, ...") keyword = "";

            // 1. Saring berdasarkan teks search
            var hasilSaring = _semuaProdukCache.Where(p =>
                string.IsNullOrEmpty(keyword) ||
                p.jenis_produk.ToLower().Contains(keyword)
            ).ToList();

            // 2. Saring berdasarkan kategori aktif (Makanan/Minuman)
            if (_kategoriAktif == "Makanan")
            {
                // Menyesuaikan ID makanan kelompokmu (Lele Bakar=1, Mangut=2, Lele Goreng=5)
                int[] idMakanan = { 1, 2, 3};
                hasilSaring = hasilSaring.Where(p => idMakanan.Contains(p.id_produk)).ToList();
            }
            else if (_kategoriAktif == "Minuman")
            {
                // Menyesuaikan ID minuman kelompokmu (Air Mineral=3, Es Jeruk=4, Es Teh=6)
                int[] idMinuman = { 4, 5, 6 };
                hasilSaring = hasilSaring.Where(p => idMinuman.Contains(p.id_produk)).ToList();
            }

            // 3. Atur Visibilitas Kontainer Panel Menu di Layar (Mirip cara kerja Kasir kamu!)

            UpdatePanelTampilan(1, panelLeleBakar, labelstoklelebakar, pblelebakar, button1, "Lele Bakar", 18000, hasilSaring);
            UpdatePanelTampilan(3, panelMangutLele, lblstokmangutlele, pbmangutlele, button2, "Mangut Lele", 22000, hasilSaring);
            UpdatePanelTampilan(6, panelAirMineral, lblstokairmineral, pbairmineral, button3, "Air Mineral", 5000, hasilSaring);
            UpdatePanelTampilan(5, panelEsJeruk, lblstokesjeruk, pbesjeruk, button4, "Es Jeruk", 7000, hasilSaring);
            UpdatePanelTampilan(2, panelLeleGoreng, lblstoklelegoreng, pblelegoreng, button5, "Lele Goreng", 12000, hasilSaring);
            UpdatePanelTampilan(4, panelEsTeh, lblstokesteh, pbesteh, button6, "Es Teh", 5000, hasilSaring);
        }

        private void UpdatePanelTampilan(int idProd, Panel pnl, Label lblStok, PictureBox pbx, Button btnPlus, string namaDefault, double hargaDefault, List<Produk> listSaring)
        {
            if (pnl == null) return;

            // Cek apakah produk dengan ID ini lolos dari saringan pencarian
            var prod = listSaring.FirstOrDefault(p => p.id_produk == idProd);

            if (prod != null)
            {
                if (lblStok != null) lblStok.Text = prod.stok.ToString();
                if (btnPlus != null) btnPlus.Tag = new Tuple<int, string, double>(prod.id_produk, prod.jenis_produk, prod.harga);
                if (pbx != null && prod.foto_Produk != null)
                {
                    pbx.Image = ConvertBytesToImage(prod.foto_Produk);
                }
                pnl.Visible = true; // Sembunyikan/tampilkan panel secara live di tempat!
            }
            else
            {
                pnl.Visible = false; // Jika tidak cocok dengan search, panel menu langsung sembunyi
                if (btnPlus != null) btnPlus.Tag = null;
            }
        }


        // --- 🌟 LIVE PENCARIAN (CARA KASIR): Menggantikan panel melayang lama ---
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Setiap kali huruf diketik, langsung saring item di tempat tanpa memunculkan form baru
            FilterDanRenderKatalog();
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
                    harga = (int)harga,
                    quantity = 1
                });
            }

            MessageBox.Show($"{nama} sukses dimasukkan ke dalam keranjang belanja!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void IkatEventTombolPlus()
        {
            if (button1 != null) button1.Click += TombolPlusMenu_Click;
            if (button2 != null) button2.Click += TombolPlusMenu_Click;
            if (button3 != null) button3.Click += TombolPlusMenu_Click;
            if (button4 != null) button4.Click += TombolPlusMenu_Click;
            if (button5 != null) button5.Click += TombolPlusMenu_Click;
            if (button6 != null) button6.Click += TombolPlusMenu_Click;
        }

        private void TombolPlusMenu_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Tuple<int, string, double> dataMenu)
            {
                TambahKeKeranjang(dataMenu.Item1, dataMenu.Item2, dataMenu.Item3);
            }
        }

        // --- FILTER KATEGORI (DIINTEGRASIKAN DENGAN SEARCH) ---
        private void btnSemua_Click(object sender, EventArgs e) { _kategoriAktif = "Semua"; FilterDanRenderKatalog(); }
        private void btnMakanan_Click(object sender, EventArgs e) { _kategoriAktif = "Makanan"; FilterDanRenderKatalog(); }
        private void btnMinuman_Click(object sender, EventArgs e) { _kategoriAktif = "Minuman"; FilterDanRenderKatalog(); }

        // --- NAVIGASI NAV BAR ---
        private void btnKeranjang_Click(object sender, EventArgs e)
        {
            Views.Pelanggan.KeranjangBelanja frmKeranjang = new Views.Pelanggan.KeranjangBelanja();
            frmKeranjang.ShowDialog();
            RefreshDataProduk(); // Segarkan stok barangkali ada item yang dikurangi/batal
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            Views.Pelanggan.CheckoutdanPembayaran frmCheckout = new Views.Pelanggan.CheckoutdanPembayaran();
            frmCheckout.ShowDialog();
            RefreshDataProduk();
        }

        private void btnloginkaryawan_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();
            loginForm.ShowDialog();
            RefreshDataProduk(); // Segarkan angka stok setelah kasir/karyawan selesai melakukan input transaksi baru
        }
    }
}