using CFMART.Controllers;
using CFMART.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CFMART.Views.Admin
{
    public partial class UCManajemenProduk : UserControl
    {
        private string selectedFilePath = "";
        private readonly ProdukController _produkController = new ProdukController();
        private int? selectedIdProduk = null;

        public UCManajemenProduk()
        {
            InitializeComponent();

            // 🌟 FIX MASALAH 1: Paksa ikat Event Load & CellClick via kode agar PASTI jalan saat running!
            this.Load += new System.EventHandler(this.UCManajemenProduk_Load);
            this.dgvManajemenProduk.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvManajemenProduk_CellClick);

            // Jika ada tombol "+ Tambah" di pojok kanan atas, kita ikat juga event-nya di sini
            // Pastikan namanya sesuai dengan nama komponen di desainer kamu (misal: btnTambahAtas)
            this.btnTambahProduk.Click += new System.EventHandler(this.btnTambahAtas_Click);
            SetupKolomHapus();
        }
        private void SetupKolomHapus()
        {
            DataGridViewButtonColumn btnHapus = new DataGridViewButtonColumn();
            btnHapus.HeaderText = "";
            btnHapus.Text = "Hapus";
            btnHapus.Name = "btnHapus";
            btnHapus.UseColumnTextForButtonValue = true;
            dgvManajemenProduk.Columns.Add(btnHapus);
        }

        private void UCManajemenProduk_Load(object sender, EventArgs e)
        {
            RefreshData();
            SetModeTambah(); // Di awal, set form dalam mode tambah kosong
        }

        /// <summary>
        /// Memuat data dari database ke DataGridView
        /// </summary>
        public void RefreshData()
        {
            try
            {
                List<Produk> listProduk = _produkController.AmbilSemuaProduk();
                dgvManajemenProduk.DataSource = listProduk;

                // Kosmetik grid visual
                dgvManajemenProduk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvManajemenProduk.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvManajemenProduk.ReadOnly = true;

                // Merapikan nama kolom teks di layar agar rapi dilihat admin
                if (dgvManajemenProduk.Columns["id_produk"] != null) dgvManajemenProduk.Columns["id_produk"].HeaderText = "ID Produk";
                if (dgvManajemenProduk.Columns["jenis_produk"] != null) dgvManajemenProduk.Columns["jenis_produk"].HeaderText = "Nama / Jenis Produk";
                if (dgvManajemenProduk.Columns["harga"] != null) dgvManajemenProduk.Columns["harga"].HeaderText = "Harga (Rp)";
                if (dgvManajemenProduk.Columns["stok"] != null) dgvManajemenProduk.Columns["stok"].HeaderText = "Stok Barang";
                if (dgvManajemenProduk.Columns["foto_Produk"] != null) dgvManajemenProduk.Columns["foto_Produk"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat visual tabel produk: " + ex.Message, "Sistem Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 🌟 MULTIFUNGSI BUTTON (HIJAU): Bisa jadi Simpan atau Update tergantung State
        /// </summary>
        private void btnSimpan2_Click(object sender, EventArgs e)
        {
            // 1. Validasi Input Dasar
            if (string.IsNullOrWhiteSpace(tbNamaProduk.Text) || string.IsNullOrWhiteSpace(tbHarga.Text) || string.IsNullOrWhiteSpace(tbStok.Text))
            {
                MessageBox.Show("Semua kolom data wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nama = tbNamaProduk.Text.Trim();
            if (!double.TryParse(tbHarga.Text, out double harga) || !int.TryParse(tbStok.Text, out int stok))
            {
                MessageBox.Show("Harga dan Stok harus berupa angka valid!", "Format Salah", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Ambil data foto (jika ada)
            byte[] fotoBytes = null;
            if (!string.IsNullOrEmpty(selectedFilePath) && System.IO.File.Exists(selectedFilePath))
            {
                fotoBytes = System.IO.File.ReadAllBytes(selectedFilePath);
            }

            // 3. Eksekusi Berdasarkan Mode
            if (selectedIdProduk != null)
            {
                // MODE UPDATE: Gunakan 5 parameter
                bool suksesUpdate = _produkController.UpdateProduk(selectedIdProduk.Value, nama, harga, stok, fotoBytes);
                if (suksesUpdate)
                {
                    MessageBox.Show("Data produk berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                    SetModeTambah();
                }
            }
            else
            {
                // MODE SIMPAN BARU: Gunakan 4 parameter
                // Pastikan controller kamu punya method TambahProduk(nama, harga, stok, fotoBytes)
                bool suksesTambah = _produkController.TambahProduk(nama, harga, stok, fotoBytes);
                if (suksesTambah)
                {
                    MessageBox.Show("Produk baru berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                    SetModeTambah();
                }
            }
        }

        /// <summary>
        /// 🌟 FIX MASALAH 2 (A): Kalo klik dgv, auto berubah jadi MODE UPDATE
        /// </summary>
        private void dgvManajemenProduk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Validasi: Jika klik header atau area kosong, abaikan
            if (e.RowIndex < 0) return;

            // 2. Ambil baris yang diklik
            DataGridViewRow row = dgvManajemenProduk.Rows[e.RowIndex];

            // 3. CEK: Apakah yang diklik kolom "Hapus"?
            if (dgvManajemenProduk.Columns[e.ColumnIndex].Name == "btnHapus")
            {
                int idHapus = Convert.ToInt32(row.Cells["id_produk"].Value);
                string namaHapus = row.Cells["jenis_produk"].Value?.ToString() ?? "";

                var confirm = MessageBox.Show(
                    $"Yakin ingin menghapus produk \"{namaHapus}\"?",
                    "Konfirmasi Hapus",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    bool sukses = _produkController.HapusProduk(idHapus);
                    if (sukses)
                    {
                        MessageBox.Show("Produk berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshData();
                        SetModeTambah();
                    }
                }
                return; // Keluar dari fungsi setelah proses hapus
            }

            // 4. JIKA KLIK DATA (MODE UPDATE): 
            // Ambil objek Produk dari baris yang diklik agar datanya lengkap termasuk foto
            Produk produkTerpilih = (Produk)row.DataBoundItem;

            if (produkTerpilih != null)
            {
                // Masukkan data ke TextBox
                selectedIdProduk = produkTerpilih.id_produk;
                tbNamaProduk.Text = produkTerpilih.jenis_produk;
                tbHarga.Text = produkTerpilih.harga.ToString();
                tbStok.Text = produkTerpilih.stok.ToString();

                // Ubah teks tombol menjadi Update
                btnSimpan2.Text = "Update Produk";

                // 5. TAMPILKAN FOTO DI PICTUREBOX
                if (produkTerpilih.foto_Produk != null && produkTerpilih.foto_Produk.Length > 0)
                {
                    try
                    {
                        using (var ms = new MemoryStream(produkTerpilih.foto_Produk))
                        {
                            pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal memuat foto: " + ex.Message);
                    }
                }
                else
                {
                    // Jika produk tidak punya foto, kosongkan PictureBox
                    pictureBox1.Image = null;
                }

                // Penting: Reset selectedFilePath karena kita sedang buka produk yang sudah ada di DB
                selectedFilePath = "";
            }
        }

        /// <summary>
        /// 🌟 FIX MASALAH 2 (B): Kalo tombol "+ Tambah" diklik, kosongkan form & set MODE SIMPAN
        /// </summary>
        private void btnTambahAtas_Click(object sender, EventArgs e)
        {
            SetModeTambah();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            SetModeTambah();
        }

        /// <summary>
        /// Fungsi pembantu untuk mengembalikan form ke status Tambah Baru
        /// </summary>
        private void SetModeTambah()
        {
            tbNamaProduk.Clear();
            tbHarga.Clear();
            tbStok.Clear();

            // Pastikan PictureBox bersih saat klik Tambah/Batal
            pictureBox1.Image = null;

            selectedIdProduk = null;
            selectedFilePath = ""; // Reset path
            btnSimpan2.Text = "Simpan Produk";
        }

        private void btnBatal2_Click(object sender, EventArgs e)
        {

        }

        private void btnPilihProduk_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (open.ShowDialog() == DialogResult.OK)
            {
                // 1. Simpan path file-nya
                selectedFilePath = open.FileName;

                // 2. Tampilkan gambar ke PictureBox agar Admin bisa melihat apa yang dipilih
                // Ganti 'pictureBoxProduk' dengan nama PictureBox yang ada di form kamu
                pictureBox1.Image = System.Drawing.Image.FromFile(selectedFilePath);

                // 3. (Opsional) Mengatur agar gambar pas dengan ukuran box
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                MessageBox.Show("Foto terpilih!");
            }
        }

        private void tbNamaProduk_TextChanged(object sender, EventArgs e)
        {

        }
    }
}