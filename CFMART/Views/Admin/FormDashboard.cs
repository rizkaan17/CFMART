using CFMART.Views.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CFMART.Views.Admin
{
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();

            this.Load += new System.EventHandler(this.FormDashboard_Load);
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
        }

        private void PindahHalaman(UserControl halamanBaru)
        {
            // 1. Bersihkan panel utama (panelMain) dari halaman lama
            panelMain.Controls.Clear();

            // 2. Atur ukuran halaman baru biar memenuhi seluruh panel
            halamanBaru.Dock = DockStyle.Fill;

            // 3. Masukkan dan tampilkan halaman baru tersebut
            panelMain.Controls.Add(halamanBaru);
            halamanBaru.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            PindahHalaman(new UCDashboardAdmin());
        }

        private void btnProduk_Click(object sender, EventArgs e)
        {
            PindahHalaman(new UCManajemenProduk());
        }

        private void btnKaryawan_Click(object sender, EventArgs e)
        {
            PindahHalaman(new UCManajemenKaryawan());
        }

        private void btnBiodata_Click(object sender, EventArgs e)
        {
            PindahHalaman(new UCBiodata());
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            // 1. Tampilkan konfirmasi biar gak sengaja kepencet keluar
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin logout dari sistem?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 2. Tutup Form Dashboard Kasir ini
                this.Close();
            }
        }
    }
}
