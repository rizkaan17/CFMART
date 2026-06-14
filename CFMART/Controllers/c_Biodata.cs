using CFMART.Models;
using CFMART.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CFMART.Controllers
{
    public class BiodataController
    {
        private readonly ContextUser _contextUser = new ContextUser();

        /// <summary>
        /// Mengambil sesi user static yang sedang login (Menggunakan properti session global)
        /// </summary>
        public User GetUserSession()
        {
            return ContextUser.user;
        }

        // =======================================================
        // 🌟 PILAR POLYMORPHISM: METHOD OVERLOADING (Nama Sama, Parameter Beda)
        // =======================================================

        /// <summary>
        /// Bentuk 1: Mengambil data user berdasarkan ID (Integer) - KODE SUDAH DI-FIX
        /// </summary>
        public User GetBiodata(int id)
        {
            try
            {
                // Mengambil semua user dari Context, lalu difilter menggunakan LINQ FirstOrDefault
                List<User> listUser = _contextUser.GetAllUser();
                return listUser.FirstOrDefault(u => u.id_user == id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil biodata user berdasarkan ID: " + ex.Message, "Error Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Bentuk 2: Mengambil data user berdasarkan Username (String)
        /// </summary>
        public User GetBiodata(string username)
        {
            try
            {
                List<User> listUser = _contextUser.GetAllUser();
                return listUser.FirstOrDefault(u => u.username.Equals(username.Trim(), StringComparison.OrdinalIgnoreCase));
            }
            catch
            {
                return null;
            }
        }

        // =======================================================

        /// <summary>
        /// Melakukan update data profil menggunakan fungsi UpdateUser dari ContextUser
        /// </summary>
        public bool UpdateProfilLengkap(int id, string nama, string nohp, string email, string passwordBaru)
        {
            // 1. Ambil data user lama dari database agar data yang tidak diubah (role/status) tidak hilang
            User userLama = GetBiodata(id);
            if (userLama == null)
            {
                MessageBox.Show("Data pengguna tidak ditemukan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 2. Petakan data baru ke dalam objek model User (Otomatis melewati filter Encapsulation properti)
            User userUpdate = new User
            {
                id_user = id,
                nama_lengkap = nama,
                nomer_telepon_karyawan = nohp,
                email = email,
                username = userLama.username,        // Tetap mempertahankan username lama
                role_id_role = userLama.role_id_role, // Tetap mempertahankan role lama
                status_karyawan = userLama.status_karyawan // Tetap mempertahankan status lama
            };

            // Jika input password baru diisi, gunakan yang baru. Jika kosong, pertahankan password lama.
            userUpdate.password_user = !string.IsNullOrEmpty(passwordBaru?.Trim())
                ? passwordBaru.Trim()
                : userLama.password_user;

            try
            {
                // 3. Kirim objek ke ContextUser untuk dieksekusi query UPDATE-nya
                bool sukses = _contextUser.UpdateUser(userUpdate);

                // 4. Jika sukses memperbarui database, sinkronkan juga session static global-nya di aplikasi
                if (sukses && ContextUser.user != null && ContextUser.user.id_user == id)
                {
                    ContextUser.user.nama_lengkap = userUpdate.nama_lengkap;
                    ContextUser.user.nomer_telepon_karyawan = userUpdate.nomer_telepon_karyawan;
                    ContextUser.user.email = userUpdate.email;
                    ContextUser.user.password_user = userUpdate.password_user;

                    MessageBox.Show("Profil Anda berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return sukses;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memperbarui profil: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}