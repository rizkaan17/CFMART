using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CFMART.Models; // 🌟 Memanggil model ItemKeranjang yang baru

namespace CFMART.Views.Pelanggan
{
    public partial class KeranjangBelanja : Form
    {
        public KeranjangBelanja()
        {
            InitializeComponent();

            // Memaksa posisi form muncul tepat di tengah layar monitor pelanggan
            this.StartPosition = FormStartPosition.CenterScreen;

            SegarkanKeranjang();
        }

        // =========================================================================
        // FITUR 1: MENAMPILKAN PESANAN & TOTAL HARGA (READ)
        // =========================================================================
        private void SegarkanKeranjang()
        {
            try
            {
                // Menghubungkan langsung ke dataGridView1 bawaan desainer kamu
                if (dataGridView1 != null)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = Program.DaftarBelanjaan;

                    // 🌟 SINKRONISASI KOLOM: Merapikan header berdasarkan properti baru Model ItemKeranjang
                    if (dataGridView1.Columns["id_produk"] != null) dataGridView1.Columns["id_produk"].Visible = false; // Sembunyikan ID agar rapi
                    if (dataGridView1.Columns["nama_produk"] != null) dataGridView1.Columns["nama_produk"].HeaderText = "Nama Menu";
                    if (dataGridView1.Columns["harga"] != null) dataGridView1.Columns["harga"].HeaderText = "Harga Satuan";
                    if (dataGridView1.Columns["quantity"] != null) dataGridView1.Columns["quantity"].HeaderText = "Qty";
                    if (dataGridView1.Columns["sub_total"] != null) dataGridView1.Columns["sub_total"].HeaderText = "Sub Total";
                }

                // 🌟 SINKRONISASI LINQ: Menghitung total belanjaan dari properti sub_total milik ItemKeranjang
                double total = Program.DaftarBelanjaan.Sum(x => x.sub_total);

                // Sinkron ke label2 desainer kamu
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

        // =========================================================================
        // FITUR 2: TOMBOL UBAH PESANAN / QTY (UPDATE) -> button5
        // =========================================================================
        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1 == null || dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Pilih item makanan di tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mengambil item bertipe ItemKeranjang yang sedang di-klik di tabel
            ItemKeranjang itemDipilih = dataGridView1.CurrentRow.DataBoundItem as ItemKeranjang;

            if (itemDipilih != null)
            {
                // Memunculkan kotak popup input angka baru
                string input = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Masukkan jumlah porsi baru untuk {itemDipilih.nama_produk}:",
                    "Ubah Jumlah Pesanan",
                    itemDipilih.quantity.ToString()
                );

                // Validasi jika input adalah angka bulat positif
                if (int.TryParse(input, out int jumlahBaru) && jumlahBaru > 0)
                {
                    itemDipilih.quantity = jumlahBaru; // 🌟 Update menggunakan properti quantity
                    SegarkanKeranjang(); // Otomatis mengupdate tabel dan label2
                }
                else if (!string.IsNullOrEmpty(input))
                {
                    MessageBox.Show("Jumlah porsi harus berupa angka positif!", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =========================================================================
        // FITUR 3: TOMBOL HAPUS PESANAN (DELETE) -> button4_Click_1
        // =========================================================================
        private void button4_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1 == null || dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Pilih menu makanan yang ingin dihapus dari tabel!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ItemKeranjang itemDipilih = dataGridView1.CurrentRow.DataBoundItem as ItemKeranjang;

            if (itemDipilih != null)
            {
                DialogResult konfirmasi = MessageBox.Show($"Hapus {itemDipilih.nama_produk} dari keranjang?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (konfirmasi == DialogResult.Yes)
                {
                    // 🌟 Menghapus menu terpilih dari list keranjang global memakai id_produk
                    Program.DaftarBelanjaan.RemoveAll(x => x.id_produk == itemDipilih.id_produk);
                    SegarkanKeranjang(); // Otomatis mengupdate tabel dan label2
                }
            }
        }

        // =========================================================================
        // FITUR 4: TOMBOL LANJUT CHECKOUT (PINDAH FORM) -> button6
        // =========================================================================
        private void button6_Click(object sender, EventArgs e)
        {
            if (Program.DaftarBelanjaan.Count == 0)
            {
                MessageBox.Show("Keranjang belanja kamu masih kosong! Silakan pilih lele atau es teh dulu di katalog.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tampilkan pilihan tipe pesanan pakai MessageBox Yes/No/Cancel secara instan
            DialogResult opsiPesanan = MessageBox.Show(
                "Apakah pesanan ini ingin Makan di Sini?\n\n(Pilih YES untuk Makan di Sini / NO untuk Bawa Pulang)",
                "Pilih Tipe Pesanan CFMART",
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

            // Buka form Checkout yang sudah kamu sinkronkan kemarin
            CheckoutdanPembayaran frmCheckout = new CheckoutdanPembayaran();
            frmCheckout.Show();
            this.Hide();
        }

        // =========================================================================
        // EVENT CLICK UNTUK LABEL TOTAL PESANAN
        // =========================================================================
        private void label2_Click(object sender, EventArgs e)
        {
            SegarkanKeranjang();
        }

        // =========================================================================
        // NAVIGASI BAR ATAS (MENU KATALOG) -> button3
        // =========================================================================
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