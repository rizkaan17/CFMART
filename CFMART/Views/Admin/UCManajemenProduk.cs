using CFMART.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CFMART.Views.Admin
{
    public partial class UCManajemenProduk : UserControl
    {
        public UCManajemenProduk()
        {
            InitializeComponent();

        }
            public void RefreshData()
        {
            ProdukController pc = new ProdukController();
            dgvManajemenProduk.DataSource = pc.GetAllProduk(); // memanggil logika di Controller
        }


        private void btnSimpan2_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validasi agar tidak crash (System.FormatException)
                if (string.IsNullOrWhiteSpace(tbNamaProduk.Text) || string.IsNullOrWhiteSpace(tbHarga.Text) || string.IsNullOrWhiteSpace(tbStok.Text))
                {
                    MessageBox.Show("Isi semua data dulu!");
                    return;
                }

                // 2. Ambil data
                string nama = tbNamaProduk.Text;
                double harga = double.Parse(tbHarga.Text);
                int stok = int.Parse(tbStok.Text);

                // --- TAMBAHAN: FOTO ---
                // Jika kamu belum ada fitur pilih foto, kirim null saja untuk sementara
                byte[] foto = null;

                // 3. Panggil Controller (Pastikan pakai 4 parameter sesuai yg sudah kita buat)
                ProdukController pc = new ProdukController();
                bool sukses = pc.TambahProduk(nama, harga, stok, foto);

                if (sukses)
                {
                    MessageBox.Show("Berhasil disimpan!");
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Gagal menyimpan ke database.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}

