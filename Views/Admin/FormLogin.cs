using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace CFMART
{
    public partial class FormLogin : Form
    {
        public FormLogin()
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
            MakeControlRounded(PortalAdmin, 50);

            kelolaAdmin.Top = 430; // Kalimat "Masuk untuk mengelola sistem"
            LeleAdmin.Top = 350;
        }
        private void MakeControlRounded(Control targetControl, int radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            gp.AddArc(new Rectangle(targetControl.Width - radius, 0, radius, radius), 270, 90);
            gp.AddArc(new Rectangle(targetControl.Width - radius, targetControl.Height - radius, radius, radius), 0, 90);
            gp.AddArc(new Rectangle(0, targetControl.Height - radius, radius, radius), 90, 90);
            targetControl.Region = new Region(gp);
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

        private void kelolaAdmin_Click(object sender, EventArgs e)
        {
            // 1. (Opsional) Tempatkan validasi username/password kamu di sini nanti

            // 2. Buat objek baru dari Form kedua kamu
            // (Ganti 'FormUtama' dengan nama asli class Form kedua yang kamu buat tadi)
            FormDashboard halamanUtama = new FormDashboard();

            // 3. Tampilkan Form kedua
            halamanUtama.Show();

            // 4. Sembunyikan Form Login (Form1) agar tidak menumpuk di layar
            this.Hide();
        }

    }
}