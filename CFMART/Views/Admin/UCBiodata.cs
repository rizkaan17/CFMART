using CFMART.Controllers;
using CFMART.Models;
using System;
using System.Windows.Forms;

namespace CFMART.Views.Admin
{
    public partial class UCBiodata : UserControl
    {
        private readonly BiodataController c_biodata = new BiodataController();
        private int idAdminLogin = 1; // Default fallback ID

        public UCBiodata()
        {
            InitializeComponent();

            // 🌟 TRICK JALAN PINTAS PASTI JALAN: 
            // Kita paksa ikat Event Load di sini lewat kodingan konstruktor,
            // jadi meskipun di desainer visual kosong, fungsi LOAD AKAN TETAP DIPANGGIL!
            this.Load += new System.EventHandler(this.UCBiodata_Load);
        }

        private void UCBiodata_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Ambil data session user yang sedang aktif login melalui Controller
                User currentUser = c_biodata.GetUserSession();
                if (currentUser != null)
                {
                    idAdminLogin = currentUser.id_user;
                }

                // 2. Mengaktifkan karakter bulat/bintang pada TextBox password baru
                tbPasswdBaru.UseSystemPasswordChar = true;

                // 3. Panggil fungsi untuk menampilkan profil admin ke layar
                TampilkanDataProfilAdmin();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal inisialisasi sesi admin: " + ex.Message, "Error Sesi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TampilkanDataProfilAdmin()
        {
            try
            {
                // Menggunakan GetBiodata(id) sesuai wujud baru Polymorphism di BiodataController
                var profil = c_biodata.GetBiodata(idAdminLogin);

                if (profil != null)
                {
                    // Masukkan data dari database ke dalam TextBox
                    tbNamaAdmin.Text = profil.nama_lengkap ?? "";
                    tbNoHPAdmin.Text = profil.nomer_telepon_karyawan ?? "";
                    tbEmailAdmin.Text = profil.email ?? "";

                    // Menampilkan nama di samping foto profil
                    lblAdminUtama.Text = profil.nama_lengkap ?? "Admin";
                    lblNamaEmail.Text = profil.email ?? "";

                    // Isi TextBox Password dengan tanda samar bintang sebagai penanda awal
                    tbPasswdBaru.Text = "********";
                }
                else
                {
                    MessageBox.Show("Profil kosong! Tidak ada data ditemukan untuk ID: " + idAdminLogin, "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat profil admin ke form: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdminChange_Click(object sender, EventArgs e)
        {
            // 1. Validasi Input Dasar
            if (string.IsNullOrWhiteSpace(tbNamaAdmin.Text) || string.IsNullOrWhiteSpace(tbEmailAdmin.Text))
            {
                MessageBox.Show("Nama Lengkap dan Email Admin wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kirim data ke Controller menggunakan ID Admin yang valid
            bool suksesUpdate = c_biodata.UpdateProfilLengkap(
                idAdminLogin,
                tbNamaAdmin.Text.Trim(),
                tbNoHPAdmin.Text.Trim(),
                tbEmailAdmin.Text.Trim(),
                tbPasswdBaru.Text
            );

            // 3. Respon Hasil Akhir
            if (suksesUpdate)
            {
                TampilkanDataProfilAdmin(); // Refresh tampilan agar tersamar kembali otomatis
            }
            else
            {
                MessageBox.Show("Gagal memperbarui profil admin. ID Terbaca: " + idAdminLogin, "Gagal Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}