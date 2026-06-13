using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Npgsql;
using CFMART.Helpers;

namespace CFMART.Views.Pelanggan
{
    public partial class KeranjangBelanja : Form
    {
        public KeranjangBelanja()
        {
            InitializeComponent();
            SegarkanKeranjang(); 
        }

        // ==========================================
        // FITUR 1: MENAMPILKAN PESANAN & TOTAL HARGA (READ)
        // ==========================================
        private void SegarkanKeranjang()
        {
            try
            {
                // Menghubungkan langsung ke dataGridView1 bawaan desainer kamu
                if (dataGridView1 != null)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = Program.DaftarBelanjaan;

                    // Merapikan nama kolom tabel di layar
                    if (dataGridView1.Columns["NamaProduk"] != null) dataGridView1.Columns["NamaProduk"].HeaderText = "Nama Menu";
                    if (dataGridView1.Columns["HargaSatuan"] != null) dataGridView1.Columns["HargaSatuan"].HeaderText = "Harga Satuan";
                    if (dataGridView1.Columns["Jumlah"] != null) dataGridView1.Columns["Jumlah"].HeaderText = "Qty";
                    if (dataGridView1.Columns["TotalHarga"] != null) dataGridView1.Columns["TotalHarga"].HeaderText = "Sub Total";
                }

                // Menghitung total belanjaan dari list global
                int total = Program.DaftarBelanjaan.Sum(x => x.TotalHarga);

                // SEKARANG SINKRON KE label2 (Label Total Pesanan kamu)
                if (label2 != null)
                {
                    label2.Text = $"Total Pesanan: Rp {total:N0}";
                }
            }
            catch (Exception)
            {
                // Mencegah crash jika data desainer belum siap
            }
        }

        // ==========================================
        // FITUR 2: TOMBOL UBAH PESANAN / QTY (UPDATE)
        // ==========================================
        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1 == null || dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Pilih item makanan di tabel terlebih dahulu!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mengambil item yang sedang di-klik di tabel
            dynamic itemDipilih = dataGridView1.CurrentRow.DataBoundItem;

            if (itemDipilih != null)
            {
                // Memunculkan kotak popup input angka baru
                string input = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Masukkan jumlah porsi baru untuk {itemDipilih.NamaProduk}:",
                    "Ubah Jumlah Pesanan",
                    itemDipilih.Jumlah.ToString()
                );

                // Validasi jika input adalah angka bulat positif
                if (int.TryParse(input, out int jumlahBaru) && jumlahBaru > 0)
                {
                    itemDipilih.Jumlah = jumlahBaru;
                    SegarkanKeranjang(); // Otomatis mengupdate tabel dan label2
                }
                else if (!string.IsNullOrEmpty(input))
                {
                    MessageBox.Show("Jumlah porsi harus berupa angka positif!", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // FITUR 3: TOMBOL HAPUS PESANAN (DELETE)
        // ==========================================
        private void button4_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1 == null || dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Pilih menu makanan yang ingin dihapus dari tabel!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dynamic itemDipilih = dataGridView1.CurrentRow.DataBoundItem;

            if (itemDipilih != null)
            {
                DialogResult konfirmasi = MessageBox.Show($"Hapus {itemDipilih.NamaProduk} dari keranjang?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (konfirmasi == DialogResult.Yes)
                {
                    // Menghapus menu terpilih dari list keranjang global
                    Program.DaftarBelanjaan.RemoveAll(x => x.NamaProduk == itemDipilih.NamaProduk);
                    SegarkanKeranjang(); // Otomatis mengupdate tabel dan label2
                }
            }
        }

        // ==========================================
        // FITUR 4: TOMBOL LANJUT CHECKOUT (PINDAH FORM)
        // ==========================================
        private void button6_Click(object sender, EventArgs e)
        {
            if (Program.DaftarBelanjaan.Count == 0)
            {
                MessageBox.Show("Keranjang belanja kamu masih kosong!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tampilkan pilihan tipe pesanan pakai MessageBox Yes/No/Cancel secara instan
            DialogResult opsiPesanan = MessageBox.Show(
                "Apakah pesanan ini ingin Makan di Sini?\n\n(Pilih YES untuk Makan di Sini / NO untuk Bawa Pulang)",
                "Pilih Tipe Pesanan",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            );

            if (opsiPesanan == DialogResult.Yes)
            {
                Program.TipePesanan = "Dine In";
            }
            else if (opsiPesanan == DialogResult.No)
            {
                Program.TipePesanan = "Takeaway";
            }
            else
            {
                return; // Jika pilih cancel, batalkan proses pindah halaman
            }

            // Buka form Checkout yang sudah kamu gambar desainer-nya
            CFMART.Views.Pelanggan.CheckoutdanPembayaran frmCheckout = new CFMART.Views.Pelanggan.CheckoutdanPembayaran();
            frmCheckout.Show();
            this.Hide();
        }

        // ==========================================
        // EVENT CLICK UNTUK LABEL TOTAL PESANAN
        // ==========================================
        private void label2_Click(object sender, EventArgs e)
        {
            // Jika label2 di-klik, dia akan melakukan refresh data & total harga manual
            SegarkanKeranjang();
        }

        // ==========================================
        // NAVIGASI BAR ATAS (MENU KATALOG)
        // ==========================================
        private void button3_Click(object sender, EventArgs e)
        {
            DashboardPelanggan frmKatalog = new DashboardPelanggan();
            frmKatalog.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button6_Click(sender, e);
        }

        // Sisa method penyeimbang desainer agar murni bebas dari eror compile
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void btnEditJumlah_Click_1(object sender, EventArgs e) { }
        private void button4_Click(object sender, EventArgs e) { }
        private void button3_Click_1(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void btnEditJumlah_Click(object sender, EventArgs e) { }
        private void btnHapusItembtnHapusItem_Click(object sender, EventArgs e) { }
    }
}