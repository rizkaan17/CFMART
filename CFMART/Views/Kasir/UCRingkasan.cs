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
        // View hanya terikat dan bergantung pada Controller saja
        private readonly DashboardRingkasanKasir _dashboardController = new DashboardRingkasanKasir();

        public UCRingkasan()
        {
            InitializeComponent();

            // Memastikan event Load dipanggil secara aman saat user control lahir
            this.Load += new System.EventHandler(this.UCRingkasan_Load);
        }

        private void UCRingkasan_Load(object sender, EventArgs e)
        {
            RefreshDashboardKasir();
        }

        /// <summary>
        /// Mengisi total transaksi, pendapatan, produk terlaris, dan riwayat grid secara dinamis
        /// </summary>
        public void RefreshDashboardKasir()
        {
            try
            {
                // 1. Ambil data hitungan statistik dari Controller
                Dictionary<string, object> statistik = _dashboardController.AmbilAngkaStatistikKasir();

                // 2. Pasang hasil hitungan ke masing-masing Label UI Card
                lblTransaksi.Text = statistik["total_transaksi"]?.ToString() ?? "0";
                lblTerlaris.Text = statistik["produk_terlaris"]?.ToString() ?? "Belum Ada";

                if (statistik["total_pendapatan"] != null)
                {
                    double pendapatanNominal = Convert.ToDouble(statistik["total_pendapatan"]);
                    // Mengubah format angka desimal biasa menjadi format uang Rupiah (Contoh: Rp 1.750.000)
                    lblAngkaPendapatan.Text = pendapatanNominal > 0
                        ? string.Format("Rp {0:N0}", pendapatanNominal)
                        : "Rp 0";
                }

                // 3. Ambil data list model ringkasan dari controller untuk dipasang ke DataGridView
                List<DashboardRingkasanKasir.OrderRingkasan> listPesanan = _dashboardController.AmbilPesananTerbaru();
                dgvPesananTerbaru.DataSource = listPesanan;

                // 4. Atur tampilan kosmetik visual kolom DataGridView
                AturTataLetakGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat visualisasi ringkasan dashboard: " + ex.Message, "Sistem Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Merapikan susunan nama kolom grid dan format uang di dalam baris DataGridView
        /// </summary>
        private void AturTataLetakGrid()
        {
            dgvPesananTerbaru.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPesananTerbaru.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPesananTerbaru.ReadOnly = true;
            dgvPesananTerbaru.MultiSelect = false;

            // Pastikan kolom sudah ter-generate sebelum kustomisasi nama teks header
            if (dgvPesananTerbaru.Columns.Count > 0)
            {
                if (dgvPesananTerbaru.Columns["id_order"] != null)
                    dgvPesananTerbaru.Columns["id_order"].HeaderText = "ID Transaksi / Nota";

                if (dgvPesananTerbaru.Columns["tanggal_order"] != null)
                    dgvPesananTerbaru.Columns["tanggal_order"].HeaderText = "Waktu Belanja";

                if (dgvPesananTerbaru.Columns["total_harga"] != null)
                {
                    dgvPesananTerbaru.Columns["total_harga"].HeaderText = "Total Belanja";
                    dgvPesananTerbaru.Columns["total_harga"].DefaultCellStyle.Format = "N0"; // Format ribuan angka belanja
                }

                if (dgvPesananTerbaru.Columns["nama_kasir"] != null)
                    dgvPesananTerbaru.Columns["nama_kasir"].HeaderText = "Kasir Melayani";
            }
        }

        private void lblAngkaTotal_Click(object sender, EventArgs e)
        {
            // Dikongkan jika label angka tidak membutuhkan fungsi klik khusus
        }
    }
}