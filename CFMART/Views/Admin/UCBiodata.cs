using CFMART.Controllers;
using CFMART.Models.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CFMART.Views.Admin
{
    public partial class UCBiodata : UserControl
    {
        private BiodataController c_biodata = new BiodataController();
        private int idAdminLogin = 1;

        public UCBiodata()
        {
            InitializeComponent();
        }

        private void UCBiodata_Load(object sender, EventArgs e)
        {
            try
            {
                // Mencoba membaca session user secara dinamis
                if (CFMART.Models.Context.ContextUser.user != null)
                {
                    var userObj = CFMART.Models.Context.ContextUser.user;
                    var propertiId = userObj.GetType().GetProperty("id_user") ??
                                     userObj.GetType().GetProperty("idUser") ??
                                     userObj.GetType().GetProperty("IdUser");

                    if (propertiId != null)
                    {
                        int idSesi = Convert.ToInt32(propertiId.GetValue(userObj, null));
                        if (idSesi > 0)
                        {
                            idAdminLogin = idSesi;
                        }
                    }
                }

                tbPasswdBaru.UseSystemPasswordChar = true;
                TampilkanDataProfilAdmin();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal inisialisasi sesi admin: " + ex.Message);
            }
        }

        private void TampilkanDataProfilAdmin()
        {
            try
            {
                var profil = c_biodata.GetBiodataById(idAdminLogin);
                if (profil != null)
                {
                    // Masukkan data dari database ke dalam TextBox
                    tbNamaAdmin.Text = profil["nama_lengkap"]?.ToString() ?? "";
                    tbNoHPAdmin.Text = profil["nomer_telepon_karyawan"]?.ToString() ?? "";
                    tbEmailAdmin.Text = profil["username"]?.ToString() ?? "";

                    // Menampilkan nama di samping foto profil
                    lblAdminUtama.Text = profil["username"]?.ToString() ?? "Admin";
                    tbPasswdBaru.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat profil admin ke form: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Mengambil ID global dari user yang sedang login saat ini
        private void btnAdminChange_Click(object sender, EventArgs e)
        {
            // 1. Validasi Input Dasar
            if (string.IsNullOrEmpty(tbNamaAdmin.Text.Trim()) || string.IsNullOrEmpty(tbEmailAdmin.Text.Trim()))
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
                MessageBox.Show("Profil Admin berhasil diperbarui ke database!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TampilkanDataProfilAdmin(); // Refresh tampilan biar langsung singkron
            }
            else
            {
                MessageBox.Show("Gagal memperbarui profil admin. ID Terbaca: " + idAdminLogin, "Gagal Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}