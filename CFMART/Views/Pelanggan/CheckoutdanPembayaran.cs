using CFMART.Controllers;
using CFMART.Models; // 🌟 Memanggil model ItemKeranjang yang baru
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CFMART.Views.Pelanggan
{
    public partial class CheckoutdanPembayaran : Form
    {
        // Menghubungkan Form ke TransaksiController untuk akses PostgreSQL
        private readonly TransaksiController _transaksiController = new TransaksiController();

        // Penampung internal jenis metode pembayaran yang diklik pelanggan
        private string _metodePembayaranTerpilih = "";

        public CheckoutdanPembayaran()
        {
            InitializeComponent();

            // Memaksa posisi form muncul tepat di tengah layar monitor pelanggan
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CheckoutdanPembayaran_Load(object sender, EventArgs e)
        {
            // Sembunyikan gambar QRIS/Barcode secara default saat pertama kali dimuat
            if (pictureBox1 != null)
            {
                pictureBox1.Visible = false;
            }

            // Atur warna redup awal untuk kedua tombol pilihan metode pembayaran
            ResetWarnaTombolMetode();

            // Hitung total belanjaan pelanggan dari RAM global
            HitungTotalBayar();
        }

        private void HitungTotalBayar()
        {
            // Validasi: Cegah error crash jika list belanjaan global kosong
            if (Program.DaftarBelanjaan == null || Program.DaftarBelanjaan.Count == 0)
            {
                if (label4 != null) label4.Text = "Rp 0";
                return;
            }

            // 🌟 SINKRONISASI TOTAL: Menggunakan properti sub_total milik model ItemKeranjang baru
            double totalAkhir = Program.DaftarBelanjaan.Sum(item => item.sub_total);

            // Tampilkan nominal rupiah terformat (N0) ke komponen label4 desainer kamu
            if (label4 != null)
            {
                label4.Text = "Rp " + totalAkhir.ToString("N0");
            }
        }

            if (label2 != null)
            {
                label2.Text = "Metode Pembayaran";
            }
        }

        // =========================================================================
        // 💵 TOMBOL TUNAI (button1) -> Berfungsi mirip Radio Button eksklusif
        // =========================================================================
        private void button1_Click(object sender, EventArgs e)
        {
            _metodePembayaranTerpilih = "Tunai";
            Program.MetodePembayaran = "Tunai";

            // Sembunyikan QRIS karena pembayaran dilakukan manual pakai uang cash di kasir
            if (pictureBox1 != null) pictureBox1.Visible = false;

            // Ubah visual: Button Tunai menyala gelap tegas, Button QRIS redup mati
            button1.BackColor = Color.FromArgb(35, 40, 55);
            button1.ForeColor = Color.White;

            button2.BackColor = Color.FromArgb(60, 65, 75);
            button2.ForeColor = Color.DarkGray;
        }

        // =========================================================================
        // 📱 TOMBOL QRIS (button2) -> Berfungsi mirip Radio Button eksklusif
        // =========================================================================
        private void button2_Click(object sender, EventArgs e)
        {
            _metodePembayaranTerpilih = "QRIS";
            Program.MetodePembayaran = "QRIS";

            // Munculkan gambar kode QRIS desainer untuk di-scan oleh smartphone pelanggan
            if (pictureBox1 != null) pictureBox1.Visible = true;

            // Ubah visual: Button QRIS menyala gelap tegas, Button Tunai redup mati
            button2.BackColor = Color.FromArgb(35, 40, 55);
            button2.ForeColor = Color.White;

            button1.BackColor = Color.FromArgb(60, 65, 75);
            button1.ForeColor = Color.DarkGray;
        }

        // =========================================================================
        // 🚀 TOMBOL BAYAR SEKARANG (btnBayarSekarang) -> Kirim data ke PostgreSQL
        // =========================================================================
        private void btnBayarSekarang_Click(object sender, EventArgs e)
        {
            // ... (kode validasi kamu tetap di sini) ...

            // 1. AMBIL TEKS DARI TEXTBOX
            string isiCatatan = tbCatatan.Text;

            // 2. SIMPAN KE VARIABEL GLOBAL (Contoh: jika kamu punya class Program)
            // Pastikan di Program.cs sudah ada property: public static string CatatanPesanan { get; set; }
            Program.CatatanPesanan = isiCatatan;

            // Mengambil teks item nomor meja
            string nomorMejaDipilih = comboBox1.SelectedItem.ToString();

            // 3. TAMPILKAN NOTIFIKASI DENGAN CATATANNYA
            string notaNotifikasi = $"Pesanan untuk [{nomorMejaDipilih}] sukses dibuat!\n" +
                                     $"Catatan: {isiCatatan}\n\n" +
                                     "⚠️ SILAKAN SEGERA KE KASIR.";

                MessageBox.Show(notaNotifikasi, "Sukses Pemesanan CFMART", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // ==========================================
            // AKSI BERSIH-BERSIH
            // ==========================================
            Program.DaftarBelanjaan.Clear();
            Program.TipePesanan = "";
            Program.MetodePembayaran = "";
            Program.CatatanPesanan = ""; // Reset catatan juga agar tidak nyangkut ke pesanan berikutnya

            DashboardPelanggan frmKatalog = new DashboardPelanggan();
            frmKatalog.Show();

            this.Close();
        }

        // =========================================================================
        // EVENT DROPDOWN NOMOR MEJA (comboBox1)
        // =========================================================================
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kalkulasi ulang total bayar secara real-time demi mencegah angka macet/freeze
            HitungTotalBayar();
        }

        // Event kosong sisa desainer (Wajib dibiarkan utuh agar file desainer tidak error corrupt)
        private void label2_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }

        private void tbCatatan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
