using CFMART.Views.Admin;
using CFMART.Views.Kasir;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CFMART.Views.Kasir
{
    public partial class FormDashboardKasir : Form
    {
        public FormDashboardKasir()
        {
            InitializeComponent();

            // Mengikat Event Load secara manual agar fungsi FormDashboardKasir_Load PASTI dieksekusi saat form muncul
            this.Load += new System.EventHandler(this.FormDashboardKasir_Load);
        }

        private void FormDashboardKasir_Load(object sender, EventArgs e)
        {
            // Saat pertama kali kasir masuk dashboard, langsung tampilkan halaman transaksi produk agar tidak kosong
            PindahHalaman(new UCPilihproduk());
        }

        /// <summary>
        /// Mekanisme untuk mengganti isi panel utama dengan User Control baru
        /// </summary>
        private void PindahHalaman(UserControl halamanBaru)
        {
            // 1. Bersihkan semua komponen/User Control lama di dalam panelMain
            pnlMain.Controls.Clear();

            // 2. Paksa ukuran User Control baru mengikuti luas panelMain
            halamanBaru.Dock = DockStyle.Fill;

            // 3. Masukkan dan munculkan User Control baru ke panelMain
            pnlMain.Controls.Add(halamanBaru);
            halamanBaru.Show();
        }

        private void btnKasir_Click(object sender, EventArgs e)
        {
            PindahHalaman(new UCPilihproduk());
        }

        private void btnRingkasan_Click(object sender, EventArgs e)
        {
            PindahHalaman(new UCRingkasan());
        }

        private void btnBiodata_Click(object sender, EventArgs e)
        {
            PindahHalaman(new UCBiodataKasir());
        }

        private void btnLogoutKasir_Click(object sender, EventArgs e)
        {
            // 1. Tampilkan konfirmasi biar kasir gak sengaja keklik keluar
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin keluar dari sistem CFMART?",
                                                  "Konfirmasi Logout",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 2. Kosongkan session static user yang login demi keamanan
                CFMART.Models.Context.ContextUser.user = null;

                // 3. Buat objek Form Login baru dan munculkan ke layar
                FormLogin loginForm = new FormLogin();
                loginForm.Show();

                // 4. Sembunyikan atau tutup form dashboard saat ini tanpa mematikan aplikasi
                this.Hide();
                // Catatan: Jika ingin benar-benar dispose memori form dashboard, gunakan: this.Dispose();
            }
        }
    }
}