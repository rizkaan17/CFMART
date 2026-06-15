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
        private PanelHasilCari panelHasil = null;

        public DashboardPelanggan()
        {
            InitializeComponent();
        }

        // --- FUNGSI TAMBAH KE KERANJANG ---
        private void TambahKeKeranjang(string nama, int harga)
        {
            ContextItemKeranjang item = new ContextItemKeranjang
            {
                NamaProduk = nama,
                HargaSatuan = harga,
                Jumlah = 1
            };

            Program.DaftarBelanjaan.Add(item);
            MessageBox.Show(nama + " telah ditambahkan ke keranjang!", "Sukses");
        }

        // --- EVENT TOMBOL PRODUK ---
        private void button1_Click_1(object sender, EventArgs e) { TambahKeKeranjang("Lele Bakar", 18000); }
        private void button2_Click_1(object sender, EventArgs e) { TambahKeKeranjang("Mangut Lele", 22000); }
        private void button3_Click_1(object sender, EventArgs e) { TambahKeKeranjang("Air Mineral", 5000); }
        private void button4_Click_1(object sender, EventArgs e) { TambahKeKeranjang("Es Jeruk", 7000); }
        private void button5_Click_1(object sender, EventArgs e) { TambahKeKeranjang("Lele Goreng", 12000); }
        private void button6_Click_1(object sender, EventArgs e) { TambahKeKeranjang("Es Teh", 5000); }

        // --- NAVIGASI ---
        private void btnKeranjang_Click(object sender, EventArgs e) => new KeranjangBelanja().Show();
        private void btnCheckout_Click(object sender, EventArgs e) => new CheckoutdanPembayaran().Show();

        // --- FILTER ---
        private void btnSemua_Click(object sender, EventArgs e) => ToggleVisibility(true, true);
        private void btnMakanan_Click(object sender, EventArgs e) => ToggleVisibility(true, false);
        private void btnMinuman_Click(object sender, EventArgs e) => ToggleVisibility(false, true);

        private void ToggleVisibility(bool mkn, bool mnm)
        {
            panelLeleGoreng.Visible = panelLeleBakar.Visible = panelMangutLele.Visible = mkn;
            panelAirMineral.Visible = panelEsJeruk.Visible = panelEsTeh.Visible = mnm;
        }

        // --- SEARCH DINAMIS (PanelHasilCari) ---
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                if (panelHasil != null) { this.Controls.Remove(panelHasil); panelHasil.Dispose(); panelHasil = null; }
                return;
            }

            // Filter data dari Katalog global
            var hasil = Program.KatalogProduk.Where(p => p.Nama.ToLower().Contains(keyword.ToLower())).ToList();

            if (panelHasil == null)
            {
                panelHasil = new PanelHasilCari();
                panelHasil.Location = new Point(150, 100); // Sesuaikan posisi panel di form
                panelHasil.OnTambahKeranjangKlik += TambahKeKeranjang;
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
            panelHasil.TampilkanHasil(hasil);
        }

        private void btnloginkaryawan_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();

            // Menampilkan form tersebut
            loginForm.Show();

        }
    }
}