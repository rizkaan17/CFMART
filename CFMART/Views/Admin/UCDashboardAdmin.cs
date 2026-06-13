using CFMART.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace CFMART.Views.Admin
{
    public partial class UCDashboardAdmin : UserControl
    {
        // 1. Ini variabel objek yang kamu buat (menggunakan awalan '_')
        private ProdukController _dashboardController = new ProdukController();

        public UCDashboardAdmin()
        {
            InitializeComponent();
        }

        private void UCDashboardAdmin_Load(object sender, EventArgs e)
        {
            RefreshDataDashboard();
        }

        public void RefreshDataDashboard()
        {
            try
            {
                Dictionary<string, object> statistik = _dashboardController.AmbilAngkaStatistik();

                // Mengubah teks pada label angka secara otomatis
                lblTotalPesanan.Text = statistik["total_pesanan"].ToString();
                lblTotalStok.Text = statistik["total_stok"].ToString(); // <--- Mengubah angka 120
                lblAngkaKaryawan.Text = statistik["karyawan_aktif"].ToString(); // <--- Mengubah angka 5

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
        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }
    }
}