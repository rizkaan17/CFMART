using CFMART.Controllers;
using CFMART.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CFMART.Views.Pelanggan
{
    public partial class CheckoutdanPembayaran : Form
    {
        private readonly TransaksiController _transaksiController = new TransaksiController();
        private string _metodePembayaranTerpilih = "";

        public CheckoutdanPembayaran()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CheckoutdanPembayaran_Load(object sender, EventArgs e)
        {
            if (pictureBox1 != null) pictureBox1.Visible = false;

            ResetWarnaTombolMetode();
            HitungTotalBayar();

            // Perbaikan: Pindahkan label2 ke dalam method yang benar
            if (label2 != null) label2.Text = "Metode Pembayaran";
        }

        private void HitungTotalBayar()
        {
            if (Program.DaftarBelanjaan == null || Program.DaftarBelanjaan.Count == 0)
            {
                if (label4 != null) label4.Text = "Rp 0";
                return;
            }

            double totalAkhir = Program.DaftarBelanjaan.Sum(item => item.sub_total);
            if (label4 != null) label4.Text = "Rp " + totalAkhir.ToString("N0");
        }

        private void ResetWarnaTombolMetode()
        {
            button1.BackColor = Color.FromArgb(60, 65, 75);
            button2.BackColor = Color.FromArgb(60, 65, 75);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _metodePembayaranTerpilih = "Tunai";
            Program.MetodePembayaran = "Tunai";

            if (pictureBox1 != null) pictureBox1.Visible = false;

            button1.BackColor = Color.FromArgb(35, 40, 55);
            button1.ForeColor = Color.White;
            button2.BackColor = Color.FromArgb(60, 65, 75);
            button2.ForeColor = Color.DarkGray;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _metodePembayaranTerpilih = "QRIS";
            Program.MetodePembayaran = "QRIS";

            if (pictureBox1 != null) pictureBox1.Visible = true;

            button2.BackColor = Color.FromArgb(35, 40, 55);
            button2.ForeColor = Color.White;
            button1.BackColor = Color.FromArgb(60, 65, 75);
            button1.ForeColor = Color.DarkGray;
        }

        private void btnBayarSekarang_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Silakan pilih nomor meja terlebih dahulu!");
                return;
            }

            if (string.IsNullOrEmpty(_metodePembayaranTerpilih))
            {
                MessageBox.Show("Silakan pilih metode pembayaran (Tunai/QRIS) terlebih dahulu!");
                return;
            }

            string isiCatatan = tbCatatan.Text;
            string nomorMejaDipilih = comboBox1.SelectedItem.ToString();
            Program.CatatanPesanan = isiCatatan;

            // tambahan: simpan pesanan ke database
            bool sukses = _transaksiController.KirimPesananPelanggan(
                nomorMejaDipilih,
                Program.TipePesanan,
                _metodePembayaranTerpilih,
                isiCatatan,
                Program.DaftarBelanjaan
            );

            if (!sukses)
            {
                MessageBox.Show("Gagal menyimpan pesanan ke database. Silakan coba lagi atau hubungi kasir.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string notaNotifikasi = $"Pesanan untuk [{nomorMejaDipilih}] sukses dibuat!\n" +
                                     $"Catatan: {isiCatatan}\n\n" +
                                     "⚠️ SILAKAN SEGERA KE KASIR.";
            MessageBox.Show(notaNotifikasi, "Sukses Pemesanan CFMART", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Program.DaftarBelanjaan.Clear();
            Program.TipePesanan = "";
            Program.MetodePembayaran = "";
            Program.CatatanPesanan = "";

            DashboardPelanggan frmKatalog = new DashboardPelanggan();
            frmKatalog.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) => HitungTotalBayar();

        // Event dummy desainer
        private void label2_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void tbCatatan_TextChanged(object sender, EventArgs e) { }
    }
}