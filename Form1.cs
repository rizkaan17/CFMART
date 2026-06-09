using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CFMART
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // HAPUS panggilan fungsi dari sini karena terlalu cepat
            this.StartPosition = FormStartPosition.CenterScreen;

            // 2. Buat fungsi matematika agar panel abu-abu (PortalAdmin / nama panelmu)
            // otomatis menghitung titik tengah form biru tua saat aplikasi dinyalakan
            // Ganti 'panelLogin' dengan nama variabel Panel Abu-abu kamu yang sebenarnya
            LeleAdmin.Location = new Point(
                (this.ClientSize.Width - LeleAdmin.Width) / 2,
                (this.ClientSize.Height - LeleAdmin.Height) / 2
            );

            // Kode melengkungkan panel kamu kemarin

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void PortalAdmin_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LeleAdmin_Click(object sender, EventArgs e)
        {

        }
    }
}