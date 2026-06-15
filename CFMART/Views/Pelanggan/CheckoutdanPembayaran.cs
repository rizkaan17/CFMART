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

        private void ResetWarnaTombolMetode()
        {
            button1.BackColor = Color.FromArgb(60, 65, 75); // Abu-abu redup
            button1.ForeColor = Color.DarkGray;

            button2.BackColor = Color.FromArgb(60, 65, 75); // Abu-abu redup
            button2.ForeColor = Color.DarkGray;
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
            // VALIDASI 1: Pastikan dropdown nomor meja (comboBox1) sudah dipilih nilainya
            if (comboBox1 == null || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Silakan tentukan Nomor Meja makan kamu terlebih dahulu pada dropdown!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // VALIDASI 2: Pastikan pelanggan sudah menekan tombol Tunai / QRIS
            if (string.IsNullOrEmpty(_metodePembayaranTerpilih))
            {
                MessageBox.Show("Pilih metode pembayaran dulu ya! Klik tombol 'Tunai' atau 'QRIS'.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ambil nomor meja yang dipilih dari comboBox1 desainer
            string nomorMejaDipilih = comboBox1.SelectedItem.ToString();

            // 🌟 PROSES INSERT DATABASE: Langsung melempar list global secara alami karena tipe data sudah klop
            bool suksesSimpanDb = _transaksiController.SimpanTransaksiBaru(Program.DaftarBelanjaan, nomorMejaDipilih);

            if (suksesSimpanDb)
            {
                // Notifikasi petunjuk alur jika data sukses terkirim ke server database
                string notaNotifikasi = $"Pesanan untuk Meja [{nomorMejaDipilih}] sukses dibuat melalui pembayaran {_metodePembayaranTerpilih}!\n\n" +
                                         "⚠️ SILAKAN SEGERA KE KASIR UNTUK MELAKUKAN KONFIRMASI PEMBAYARAN DAN MENGAMBIL NOTA TRANSAKSI KAMU.";

                MessageBox.Show(notaNotifikasi, "Sukses Pemesanan CFMART", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // =========================================================================
                // CLEAN-UP SESSI RAM GLOBAL SETELAH TRANSAKSI AMAN
                // =========================================================================
                Program.DaftarBelanjaan.Clear(); // Kosongkan keranjang belanja karena pesanan sudah masuk database
                Program.TipePesanan = "";        // Reset status tipe pesanan global
                Program.MetodePembayaran = "";   // Reset penampung metode pembayaran global

                // Buka kembali halaman DashboardPelanggan (Katalog produk menu utama)
                DashboardPelanggan frmKatalog = new DashboardPelanggan();
                frmKatalog.Show();

                this.Close(); // Tutup form CheckoutdanPembayaran ini
            }
            else
            {
                MessageBox.Show("Gagal menyimpan data transaksi ke database server. Silakan hubungi kasir atau coba lagi.", "Error PostgreSQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}