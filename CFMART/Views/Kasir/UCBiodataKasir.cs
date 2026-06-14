using CFMART.Controllers;
using CFMART.Models;
using System;
using System.Windows.Forms;

namespace CFMART.Views.Kasir
{
    public partial class UCBiodataKasir : UserControl
    {
        // View memanggil Controller untuk urusan data
        private readonly BiodataController c_biodata = new BiodataController();

        // Variabel untuk menampung ID Kasir yang sedang login
        private int idKasirLogin = 0;

        public UCBiodataKasir()
        {
            InitializeComponent();

            // 🌟 TRICK PASTI JALAN: Kita paksa ikat Event Load lewat kode konstruktor.
            // Ini menjamin data PostgreSQL langsung ditarik saat halaman biodata dibuka.
            this.Load += new System.EventHandler(this.UCBiodataKasir_Load);
        }

        private void UCBiodataKasir_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Ambil ID dari session user yang berhasil login (Sari / kasir lainnya)
                User currentUser = c_biodata.GetUserSession();
                if (currentUser != null)
                {
                    idKasirLogin = currentUser.id_user;
                }

                // 2. Aktifkan fitur masking password (karakter bulat/bintang)
                tbPasswdBaruKasir.UseSystemPasswordChar = true;

                // 3. Panggil fungsi untuk menampilkan profil kasir ke layar
                TampilkanDataProfilKasir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal inisialisasi sesi kasir: " + ex.Message, "Error Sesi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TampilkanDataProfilKasir()
        {
            try
            {
                // 🌟 Menerapkan Polymorphism: Memanggil GetBiodata(int id)
                User profil = c_biodata.GetBiodata(idKasirLogin);

                if (profil != null)
                {
                    // Masukkan data dari database ke dalam TextBox UI
                    tbNamaKasir.Text = profil.nama_lengkap ?? "";
                    tbNoHPKasir.Text = profil.nomer_telepon_karyawan ?? "";
                    tbEmailKasir.Text = profil.email ?? "";

                    // Update label Header (di samping foto profil)
                    lblNamaLengkap.Text = profil.nama_lengkap ?? "Nama Kasir";
                    lblRoleUsername.Text = $"Kasir . {profil.username}";

                    // Tampilkan tanda bintang sebagai penanda keamanan password
                    tbPasswdBaruKasir.Text = "********";
                }
                else
                {
                    MessageBox.Show("Data profil tidak ditemukan di database!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat profil ke form: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSimpanPerubahanKasir_Click(object sender, EventArgs e)
        {
            // 1. Validasi Input Dasar
            if (string.IsNullOrWhiteSpace(tbNamaKasir.Text) || string.IsNullOrWhiteSpace(tbEmailKasir.Text))
            {
                MessageBox.Show("Nama Lengkap dan Email wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kirim data ke Controller untuk di-update ke PostgreSQL
            // Password dikirim apa adanya, Controller akan cek jika "********" maka password tidak diubah.
            bool suksesUpdate = c_biodata.UpdateProfilLengkap(
                idKasirLogin,
                tbNamaKasir.Text.Trim(),
                tbNoHPKasir.Text.Trim(),
                tbEmailKasir.Text.Trim(),
                tbPasswdBaruKasir.Text
            );

            // 3. Feedback ke user
            if (suksesUpdate)
            {
                // Refresh data agar label Nama & Email di atas ikut berubah real-time
                TampilkanDataProfilKasir();
            }
            else
            {
                MessageBox.Show("Gagal memperbarui profil. Cek koneksi database Anda.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}