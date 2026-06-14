using CFMART.Controllers;
using CFMART.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CFMART.Views.Admin
{
    public partial class UCManajemenProduk : UserControl
    {
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
            // Validasi Input Dasar
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

            // CEK KONDISI: Apakah sedang Mode Update atau Mode Simpan Baru?
            if (selectedIdProduk != null)
            {
                // A. JALANKAN MODE UPDATE
                bool suksesUpdate = _produkController.UpdateProduk(selectedIdProduk.Value, nama, harga, stok);
                if (suksesUpdate)
                {
                    MessageBox.Show("Data produk berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                    SetModeTambah();
                }
            }
            else
            {
                // B. JALANKAN MODE SIMPAN BARU
                bool suksesTambah = _produkController.TambahProduk(nama, harga, stok, null);
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
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvManajemenProduk.Rows[e.RowIndex];

                selectedIdProduk = Convert.ToInt32(row.Cells["id_produk"].Value);
                tbNamaProduk.Text = row.Cells["jenis_produk"].Value?.ToString() ?? "";
                tbHarga.Text = row.Cells["harga"].Value?.ToString() ?? "0";
                tbStok.Text = row.Cells["stok"].Value?.ToString() ?? "0";

                // Ubah teks tombol hijau menjadi "Update Produk"
                btnSimpan2.Text = "Update Produk";
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
            selectedIdProduk = null; // Reset ID jadi null kembali
            btnSimpan2.Text = "Simpan Produk"; // Kembalikan teks tombol hijau ke default figma
        }
    }
}