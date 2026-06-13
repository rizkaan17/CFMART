using CFMART.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CFMART.Views.Kasir
{
    public partial class UCBiodataKasir : UserControl
    {
        private BiodataController c_biodata = new BiodataController();

        // KUNCI UTAMA: Default langsung ke ID 2 (Sari Kasir) agar saat simpan nilainya tidak berangka 0
        private int idKasirLogin = 2;

        public UCBiodataKasir()
        {
            InitializeComponent();
        }

        private void UCBiodataKasir_Load(object sender, EventArgs e)
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
                            idKasirLogin = idSesi;
                        }
                    }
                }

                tbPasswdBaruKasir.UseSystemPasswordChar = true;
                TampilkanDataProfilKasir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal inisialisasi sesi kasir: " + ex.Message);
            }
        }

        private void TampilkanDataProfilKasir()
        {
            try
            {
                var profil = c_biodata.GetBiodataById(idKasirLogin);
                if (profil != null)
                {
                    // Masukkan data dari database ke dalam TextBox
                    tbNamaKasir.Text = profil["nama_lengkap"]?.ToString() ?? "";
                    tbNoHPKasir.Text = profil["nomer_telepon_karyawan"]?.ToString() ?? "";
                    tbEmailKasir.Text = profil["email"]?.ToString() ?? "";

                    // Menampilkan nama di samping foto profil
                    lblRoleUsername.Text = profil["username"]?.ToString() ?? "Kasir";
                    tbPasswdBaruKasir.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat profil kasir ke form: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSimpanPerubahanKasir_Click(object sender, EventArgs e)
        {
            // 1. Validasi Input Dasar
            if (string.IsNullOrEmpty(tbNamaKasir.Text.Trim()) || string.IsNullOrEmpty(tbEmailKasir.Text.Trim()))
            {
                MessageBox.Show("Nama Lengkap dan Email Kasir wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kirim data ke Controller menggunakan ID Kasir yang valid
            bool suksesUpdate = c_biodata.UpdateProfilLengkap(
                idKasirLogin,
                tbNamaKasir.Text.Trim(),
                tbNoHPKasir.Text.Trim(),
                tbEmailKasir.Text.Trim(),
                tbPasswdBaruKasir.Text
            );

            // 3. Respon Hasil Akhir
            if (suksesUpdate)
            {
                MessageBox.Show("Profil Kasir berhasil diperbarui ke database!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TampilkanDataProfilKasir(); // Refresh tampilan biar langsung singkron
            }
            else
            {
                MessageBox.Show("Gagal memperbarui profil kasir. ID Terbaca: " + idKasirLogin, "Gagal Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}