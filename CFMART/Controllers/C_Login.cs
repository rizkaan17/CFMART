using CFMART.Models;
using CFMART.Models.Context;
using System;
using System.Windows.Forms;

namespace CFMART.Controllers
{
    public class LoginController
    {
        // Hubungkan ke ContextUser yang mengatur query ke database
        private readonly ContextUser _contextUser = new ContextUser();

        /// <summary>
        /// Fungsi untuk menangani proses autentikasi login pengguna
        /// </summary>
        /// <param name="username">Input dari TextBox Username</param>
        /// <param name="password">Input dari TextBox Password</param>
        /// <returns>Mengembalikan objek User jika sukses, atau null jika gagal</returns>
        public User ProsesLogin(string username, string password)
        {
            // 1. Validasi Input Dasar
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            try
            {
                // 2. Panggil fungsi Login di ContextUser untuk dicek ke PostgreSQL
                User userLogon = _contextUser.Login(username.Trim(), password.Trim());

                // 3. Berikan feedback/respon ke pengguna berdasarkan hasil query
                if (userLogon != null)
                {
                    // Cek status karyawan aktif/tidak
                    if (!userLogon.status_karyawan)
                    {
                        MessageBox.Show("Akun Anda telah dinonaktifkan. Silakan hubungi Super Admin.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return null;
                    }

                    // 🌟 SINKRONISASI SESI GLOBAL: Simpan user yang berhasil logon ke session static
                    ContextUser.user = userLogon;

                    MessageBox.Show($"Selamat Datang, {userLogon.nama_lengkap}!", "Login Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return userLogon;
                }
                else
                {
                    MessageBox.Show("Username atau Password salah. Silakan coba lagi.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Menangkap error jika koneksi database terputus/gagal
                MessageBox.Show("Terjadi kesalahan sistem saat login: " + ex.Message, "Error Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}