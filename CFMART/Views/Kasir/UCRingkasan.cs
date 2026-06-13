using CFMART.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CFMART.Views.Kasir
{
    public partial class UCRingkasan : UserControl
    {

        private ProdukController _dashboardController = new ProdukController();
        public UCRingkasan()
        {
            InitializeComponent();

            this.Load += new System.EventHandler(this.UCRingkasan_Load);
        }

        private void UCRingkasan_Load(object sender, EventArgs e)
        {
            RefreshDashboardKasir();
        }

        public void RefreshDashboardKasir()
        {
            try
            {
                Dictionary<string, object> statistik = _dashboardController.AmbilAngkaStatistikKasir();

                // Mengubah teks pada label angka secara otomatis
                lblTransaksi.Text = statistik["total_transaksi"].ToString() ?? "0";
                lblAngkaPendapatan.Text = statistik["total_pendapatan"].ToString() ?? "0";
                lblTerlaris.Text = statistik["produk_terlaris"].ToString() ?? "Belum Ada";

                // Ambil data pesanan terbaru untuk DataGridView bawah
                DataTable dtPesanan = _dashboardController.AmbilPesananTerbaru();
                dgvPesananTerbaru.DataSource = dtPesanan;

                // Kosmetik DataGridView
                dgvPesananTerbaru.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvPesananTerbaru.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvPesananTerbaru.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data dashboard otomatis: " + ex.Message, "Sistem Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lblAngkaTotal_Click(object sender, EventArgs e)
        {

        }
    }
}
