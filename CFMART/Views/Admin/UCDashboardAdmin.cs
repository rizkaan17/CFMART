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
        // 🌟 PERBAIKAN: Ganti ProdukController menjadi DashboardController
        private readonly DashboardController _dashboardController = new DashboardController();

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
                // Sekarang fungsi AmbilAngkaStatistik() sudah bisa dikenali tanpa error
                Dictionary<string, object> statistik = _dashboardController.AmbilAngkaStatistik();

                // Mengubah teks pada label angka secara otomatis di dashboard
                lblTotalPesanan.Text = statistik["total_pesanan"]?.ToString() ?? "0";
                lblTotalStok.Text = statistik["total_stok"]?.ToString() ?? "0";
                lblAngkaKaryawan.Text = statistik["karyawan_aktif"]?.ToString() ?? "0";

                // Ambil data pesanan terbaru untuk DataGridView bagian bawah (Menerapkan Polymorphism Bentuk 1)
                DataTable dtPesanan = _dashboardController.AmbilPesananTerbaru();
                dgvPesananTerbaru.DataSource = dtPesanan;

                // Kosmetik DataGridView agar rapi memenuhi layar
                dgvPesananTerbaru.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvPesananTerbaru.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvPesananTerbaru.ReadOnly = true;

                // Opsional: Merapikan judul kolom DataGridView agar enak dibaca Admin
                if (dgvPesananTerbaru.Columns["id_order"] != null) dgvPesananTerbaru.Columns["id_order"].HeaderText = "ID Nota";
                if (dgvPesananTerbaru.Columns["tgl_order"] != null) dgvPesananTerbaru.Columns["tgl_order"].HeaderText = "Tanggal Transaksi";
                if (dgvPesananTerbaru.Columns["nama_pelanggan"] != null) dgvPesananTerbaru.Columns["nama_pelanggan"].HeaderText = "Nama Pelanggan";
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