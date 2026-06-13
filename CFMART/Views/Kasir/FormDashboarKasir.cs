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
            this.Load += new System.EventHandler(this.FormDashboardKasir_Load);
        }

        private void FormDashboardKasir_Load(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
        }

        private void PindahHalaman(UserControl halamanBaru)
        {
            // 1. Bersihkan panel utama (panelMain) dari halaman lama
            pnlMain.Controls.Clear();

            // 2. Atur ukuran halaman baru biar memenuhi seluruh panel
            halamanBaru.Dock = DockStyle.Fill;

            // 3. Masukkan dan tampilkan halaman baru tersebut
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

        private void btnKeluarKasir_Click(object sender, EventArgs e)
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
