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

            // Memaksa posisi dashboard langsung muncul tepat di tengah layar monitor kasir
            this.StartPosition = FormStartPosition.CenterScreen;

            // Mengikat Event Load secara manual agar fungsi FormDashboardKasir_Load PASTI dieksekusi saat form muncul
            this.Load += new System.EventHandler(this.FormDashboardKasir_Load);
        }

        private void FormDashboardKasir_Load(object sender, EventArgs e)
        {
            // Saat pertama kali kasir masuk dashboard, langsung tampilkan halaman transaksi produk agar tidak kosong
            PindahHalaman(new UCPilihproduk());
        }

        /// <summary>
        /// Mekanisme untuk mengganti isi panel utama dengan User Control baru secara dinamis
        /// </summary>
        private void PindahHalaman(UserControl halamanBaru)
        {
            // Proteksi awal: mencegah crash jika pnlMain belum ter-render sempurna oleh desainer
            if (pnlMain == null) return;

            // 1. Bersihkan semua komponen/User Control lama di dalam panelMain
            pnlMain.Controls.Clear();

            // 2. Paksa ukuran User Control baru mengikuti luas panelMain figma kamu
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


        // =========================================================================
        // 🌟 SINKRONISASI HALAMAN: MENYAMBUNGKAN TOMBOL KONFIRMASI KASIR
        // =========================================================================
        private void btnKonfirmasi_Click(object sender, EventArgs e)
        {
            // 💡 Catatan Penting: Jika nama file UC konfirmasi di kelompokmu sedikit berbeda,
            // (misal cuma 'UCKonfirmasi' atau 'UCKonfirmasiPesanan'), silakan ganti nama class di bawah ini ya!
            PindahHalaman(new UCKonfirmasiPembayaran());
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

                // 4. Sembunyikan form dashboard saat ini tanpa mematikan aplikasi
                this.Hide();
            }
        }
    }
}