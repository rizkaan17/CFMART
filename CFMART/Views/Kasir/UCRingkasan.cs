using System;
using System.Windows.Forms;
using CFMART.Controllers;

namespace CFMART.Views.Kasir
{
    public partial class UCRingkasan : UserControl
    {
        public UCRingkasan()
        {
            InitializeComponent();
            this.Load += UCRingkasan_Load;
        }

        private void UCRingkasan_Load(object sender, EventArgs e)
        {
            MuatDataDashboardRingkasan();
        }

        public void MuatDataDashboardRingkasan()
        {
            try
            {
                // Inisialisasi controller sesuai konsep MVC murni
                OrderController orderCtrl = new OrderController();

                // 🌟 KOTAK 1: KIRI (TRANSAKSI HARI INI)
                int totalTransaksi = orderCtrl.AmbilTotalTransaksiHariIni();
                if (lblTransaksi != null) lblTransaksi.Text = totalTransaksi.ToString();
                if (lblTotalPesanan != null) lblTotalPesanan.Text = "Transaksi hari ini";

                // 🌟 KOTAK 2: TENGAH (NOMINAL OMEZET PENDAPATAN)
                double totalPendapatan = orderCtrl.AmbilPendapatanHariIni();
                if (lblAngkaPendapatan != null) lblAngkaPendapatan.Text = $"Rp {totalPendapatan:N0}";
                if (lblPendapatan != null) lblPendapatan.Text = "Pendapatan Hari ini";

                // 🌟 KOTAK 3: KANAN (PRODUK TERLARIS KASIR)
                int produkTerlaris = orderCtrl.AmbilTotalProdukTerlaris();
                if (lblTerlaris != null) lblTerlaris.Text = produkTerlaris.ToString();
                if (lblProdukTerlaris != null) lblProdukTerlaris.Text = "Produk Terlaris";

                // 🌟 TABEL BAWAH: DATA RIWAYAT 
                if (dgvPesananTerbaru != null)
                {
                    dgvPesananTerbaru.DataSource = orderCtrl.AmbilRiwayatTransaksi();
                    dgvPesananTerbaru.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal merender data MVC di layar: " + ex.Message, "UI Error");
            }
        }
    }
}