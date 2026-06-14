using CFMART.Controllers;
using CFMART.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CFMART.Views.Kasir
{
    public partial class UCPilihproduk : UserControl
    {
        // 1. Inisialisasi ProdukController sesuai aturan MVC
        private readonly ProdukController _produkController = new ProdukController();

        public UCPilihproduk()
        {
            InitializeComponent();

            // Mengikat event Load secara aman lewat kode
            this.Load += new System.EventHandler(this.UCPilihproduk_Load);
        }

        private void UCPilihproduk_Load(object sender, EventArgs e)
        {
            // Atur desain awal DataGridView agar terlihat rapi saat data masuk
            AturKomponenOtomatis();

            // Memuat data produk dari database saat halaman pertama kali dibuka
            MuatDaftarProduk();
        }

        /// <summary>
        /// Mengambil data dari Controller untuk dimasukkan ke DataGridView
        /// </summary>
        private void MuatDaftarProduk()
        {
            // Ambil list produk via Controller (View tidak tahu apa-apa tentang SQL/Context)
            List<Produk> listProduk = _produkController.AmbilSemuaProduk();

            // Pasang list tersebut sebagai sumber data DataGridView
            dgvDaftarPesanan.DataSource = listProduk;

            // Kustomisasi Header Kolom DataGridView agar enak dibaca manusia
            if (dgvDaftarPesanan.Columns.Count > 0)
            {
                if (dgvDaftarPesanan.Columns["id_produk"] != null)
                    dgvDaftarPesanan.Columns["id_produk"].HeaderText = "ID Produk";

                if (dgvDaftarPesanan.Columns["jenis_produk"] != null)
                    dgvDaftarPesanan.Columns["jenis_produk"].HeaderText = "Nama Produk";

                if (dgvDaftarPesanan.Columns["harga"] != null)
                {
                    dgvDaftarPesanan.Columns["harga"].HeaderText = "Harga (Rp)";
                    dgvDaftarPesanan.Columns["harga"].DefaultCellStyle.Format = "N0"; // Format ribuan (cth: 15.000)
                }

                if (dgvDaftarPesanan.Columns["stok"] != null)
                    dgvDaftarPesanan.Columns["stok"].HeaderText = "Sisa Stok";

                // Sembunyikan kolom foto_Produk di grid jika kamu tidak ingin data byte[] mentah merusak tampilan grid
                if (dgvDaftarPesanan.Columns["foto_Produk"] != null)
                    dgvDaftarPesanan.Columns["foto_Produk"].Visible = false;
            }
        }

        /// <summary>
        /// Pengaturan kosmetik awal untuk DataGridView via Code
        /// </summary>
        private void AturKomponenOtomatis()
        {
            dgvDaftarPesanan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDaftarPesanan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDaftarPesanan.MultiSelect = false;

            // Memberikan placeholder teks pada textbox cari produk
            tbSearchProduk.Text = "Cari produk di sini...";
            tbSearchProduk.ForeColor = Color.Gray;

            // Kaitkan event untuk fitur pencarian interaktif nantinya
            tbSearchProduk.Enter += TextBox1_Enter;
            tbSearchProduk.Leave += TextBox1_Leave;
        }

        // Efek kosmetik TextBox Cari saat diklik
        private void TextBox1_Enter(object sender, EventArgs e)
        {
            if (tbSearchProduk.Text == "Cari produk di sini...")
            {
                tbSearchProduk.Text = "";
                tbSearchProduk.ForeColor = Color.Black;
            }
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSearchProduk.Text))
            {
                tbSearchProduk.Text = "Cari produk di sini...";
                tbSearchProduk.ForeColor = Color.Gray;
            }
        }
    }
}