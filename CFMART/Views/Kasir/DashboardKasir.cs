using CFMART.Views.Kasir;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CFMART.Views
{
    public partial class FormDbKasir : Form
    {
        public FormDbKasir()
        {
            // 1. WAJIB KOSONG SEPERTI INI AGAR DESIGNER BISA TERBUKA
            InitializeComponent();

            this.Load += new System.EventHandler(this.DashboardKasir_Load);

            // 2. Kalau mau ngatur atau pakai Size, taruh di bawahnya sini:
            // Contoh: var ukuran = this.ClientSize;
        }

        private void DashboardKasir_Load(object sender, EventArgs e)
        {
            // 1. JANGAN gunakan this.Controls.Clear() karena akan menghapus seluruh isi Form.

            // 2. Buat instance dari User Control

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnBiodata_Click(object sender, EventArgs e)
        {
            UCBiodataKasir biodata = new UCBiodataKasir();
            biodata.Dock = DockStyle.Fill;

            // 3. Masukkan ke dalam PANEL KONTAINER, bukan langsung ke Form.
            // Ganti "panelKonten" dengan nama ID panel yang ada di desain Form kamu (misal panel2 atau panel utama lainnya)
            // Menghapus isi panel kontainer saja sebelum ditimpa UC baru
            pnlFitur.Controls.Add(biodata);

            biodata.Show();
        }

        private void btnKasir_Click(object sender, EventArgs e)
        {

        }
    }
}
