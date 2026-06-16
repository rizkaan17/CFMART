using CFMART.Controllers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CFMART.Views.Kasir
{
    public partial class UCRingkasan : UserControl
    {
        private readonly DashboardRingkasanKasir _dashboardController = new DashboardRingkasanKasir();

        public UCRingkasan()
        {
            InitializeComponent();
            this.Load += UCRingkasan_Load;
        }

        private void UCRingkasan_Load(object sender, EventArgs e)
        {
            RefreshDashboardKasir();
        }

        public void RefreshDashboardKasir()
        {
            try
            {
                // 1. Ambil statistik
                var statistik = _dashboardController.AmbilAngkaStatistikKasir();

                // Cek apakah statistik null
                if (statistik == null)
                {
                    MessageBox.Show("Controller tidak mengembalikan data statistik!");
                    return;
                }

                lblTransaksi.Text = statistik.ContainsKey("total_transaksi") ? statistik["total_transaksi"].ToString() : "0";
                lblTerlaris.Text = statistik.ContainsKey("produk_terlaris") ? statistik["produk_terlaris"].ToString() : "-";

                // 2. Ambil List Pesanan
                var listPesanan = _dashboardController.AmbilPesananTerbaru();
                dgvPesananTerbaru.DataSource = listPesanan;

                // 3. Atur Grid
                AturTataLetakGrid();
            }
            catch (Exception ex)
            {
                // PESAN INI ADALAH KUNCI MASALAHMU
                MessageBox.Show("Error saat memuat ringkasan: " + ex.Message, "DEBUG INFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AturTataLetakGrid()
        {
            dgvPesananTerbaru.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Pastikan tidak error kalau datanya kosong
            if (dgvPesananTerbaru.Columns["total_harga"] != null)
                dgvPesananTerbaru.Columns["total_harga"].DefaultCellStyle.Format = "N0";
        }
    }
}