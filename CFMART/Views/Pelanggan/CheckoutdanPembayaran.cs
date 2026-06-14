using System;
using System.Drawing;
using System.Linq; // Wajib dipasang di paling atas biar fungsi .Sum() gak error
using System.Windows.Forms;

namespace CFMART.Views.Pelanggan
{
    public partial class CheckoutdanPembayaran : Form
    {
        public CheckoutdanPembayaran()
        {
            InitializeComponent();

            // Panggilan Pertama: Hitung langsung setelah semua komponen desainer siap
            HitungTotalBayar();
        }

        private void CheckoutdanPembayaran_Load(object sender, EventArgs e)
        {
            // Sembunyikan gambar QRIS secara default saat halaman pertama kali terbuka
            if (pictureBox1 != null)
            {
                pictureBox1.Visible = false;
            }

            // Panggilan Kedua: Pastikan dihitung ulang saat form benar-benar muncul di layar
            HitungTotalBayar();
        }

        private void HitungTotalBayar()
        {
            // Pastikan list belanjaan global tidak kosong sebelum dihitung
            if (Program.DaftarBelanjaan == null || Program.DaftarBelanjaan.Count == 0)
            {
                if (label4 != null) label4.Text = "Rp 0";
                return;
            }

            // Menjumlahkan total harga semua item yang ada di memori keranjang secara akurat
            int totalAkhir = Program.DaftarBelanjaan.Sum(item => item.TotalHarga);

            // Menampilkan nominal rupiah ke label4 bawaan desainer kamu
            if (label4 != null)
            {
                label4.Text = "Rp " + totalAkhir.ToString("N0");
            }

            // Mengupdate tulisan Ringkasan Akhir agar memuat info Dine In / Takeaway bawaan dari Keranjang
            if (label2 != null)
            {
                label2.Text = "Ringkasan Akhir";
            }
        }

        // ==========================================
        // 1. TOMBOL TUNAI (button1)
        // ==========================================
        private void button1_Click(object sender, EventArgs e)
        {
            Program.MetodePembayaran = "Tunai";

            // Sembunyikan gambar QRIS karena bayar pakai cash di kasir
            if (pictureBox1 != null) pictureBox1.Visible = false;

            MessageBox.Show("Metode pembayaran diatur ke: TUNAI.\nSilakan siapkan uang pas untuk dibayarkan di kasir.", "Info Pembayaran", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ==========================================
        // 2. TOMBOL QRIS (button2)
        // ==========================================
        private void button2_Click(object sender, EventArgs e)
        {
            Program.MetodePembayaran = "QRIS";

            // Munculkan barcode/QRIS desainer kamu untuk di-scan
            if (pictureBox1 != null) pictureBox1.Visible = true;

            MessageBox.Show("Metode pembayaran diatur ke: QRIS.\nSilakan scan kode QR yang muncul di layar.", "Info Pembayaran", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ==========================================
        // 3. TOMBOL BAYAR SEKARANG (btnBayarSekarang)
        // ==========================================
        private void btnBayarSekarang_Click(object sender, EventArgs e)
        {
            // VALIDASI 1: Cek apakah user sudah memilih nomor meja di comboBox1 atau belum
            if (comboBox1 == null || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Silakan tentukan Nomor Meja / Opsi serah terima makanan terlebih dahulu pada dropdown!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // VALIDASI 2: Cek apakah user sudah menekan tombol Tunai atau QRIS
            if (string.IsNullOrEmpty(Program.MetodePembayaran))
            {
                MessageBox.Show("Pilih metode pembayaran dulu ya! Klik tombol 'Tunai' atau 'Qris'.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mengambil teks item nomor meja yang dipilih dari comboBox1
            string nomorMejaDipilih = comboBox1.SelectedItem.ToString();

            // Tampilkan notifikasi konfirmasi akhir yang memuat info nomor meja pesanan kasir
            string notaNotifikasi = $"Pesanan untuk [{nomorMejaDipilih}] sukses dibuat melalui pembayaran {Program.MetodePembayaran}!\n\n" +
                                     "⚠️ SILAKAN SEGERA KE KASIR UNTUK MELAKUKAN KONFIRMASI PEMBAYARAN DAN MENGAMBIL NOTA TRANSAKSI KAMU.";

            MessageBox.Show(notaNotifikasi, "Sukses Pemesanan CFMART", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // ==========================================
            // AKSI BERSIH-BERSIH SETELAH SELESAI BAYAR
            // ==========================================
            Program.DaftarBelanjaan.Clear(); // Kosongkan isi keranjang belanja karena sudah dipesan
            Program.TipePesanan = "";        // Reset tipe pesanan global
            Program.MetodePembayaran = "";   // Reset pilihan pembayaran global

            // Buka kembali halaman DashboardPelanggan (Katalog) utama kamu
            DashboardPelanggan frmKatalog = new DashboardPelanggan();
            frmKatalog.Show();

            this.Close(); // Tutup form checkout ini
        }

        // ==========================================
        // DROPDOWN NOMOR MEJA DI-KLIK (comboBox1)
        // ==========================================
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Panggilan Ketiga: Setiap kali user ganti meja/opsi, hitung ulang total biar mencegah angka 0 macet
            HitungTotalBayar();
        }

        // Event kosong sisa desainer (wajib dibiarkan agar tidak eror compile)
        private void label2_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
    }
}