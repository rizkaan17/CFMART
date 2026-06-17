using CFMART.Models;
using CFMART.Models.Context;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CFMART.Controllers
{
    public class KaryawanController
    {
        // Menghubungkan ke ContextUser yang sudah mewarisi BaseContext
        private readonly ContextUser _contextUser = new ContextUser();

        /// <summary>
        /// 1. TAMBAH KARYAWAN BARU
        /// Melemparkan data ke Stored Procedure di Context dengan parameter ID = null (artinya INSERT)
        /// </summary>
        public (bool sukses, string pesan) TambahKaryawan(string username, string password, int roleId, bool status, string namaLengkap, string nomerTelepon)
        {
            // Validasi input dasar di tingkat Controller sebelum menyentuh database
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(namaLengkap))
            {
                return (false, "Username dan Nama Lengkap tidak boleh kosong!");
            }

            try
            {
                // Kirim ID null ke Stored Procedure untuk menandakan data baru (INSERT)
                _contextUser.ExecuteUpsertKaryawan(null, username, password, roleId, status, namaLengkap, nomerTelepon);
                return (true, "Karyawan baru berhasil ditambahkan ke sistem CFMART.");
            }
            catch (PostgresException ex)
            {
                // Menangkap error custom yang dikirim langsung dari trigger/constraint PostgreSQL
                return (false, ex.MessageText);
            }
            catch (Exception ex)
            {
                return (false, "Kesalahan sistem: " + ex.Message);
            }
        }

        /// <summary>
        /// 2. EDIT / UPDATE DATA KARYAWAN
        /// Melemparkan data ke Stored Procedure di Context dengan menyertakan ID User yang mau diubah
        /// </summary>
        public (bool sukses, string pesan) EditKaryawan(int idUser, string username, string password, int roleId, bool status, string namaLengkap, string nomerTelepon)
        {
            if (idUser <= 0)
            {
                return (false, "ID Karyawan tidak valid!");
            }

            try
            {
                // Kirim ID yang ada angkanya ke Stored Procedure untuk menandakan update data (UPDATE)
                _contextUser.ExecuteUpsertKaryawan(idUser, username, password, roleId, status, namaLengkap, nomerTelepon);
                return (true, "Data karyawan berhasil diperbarui.");
            }
            catch (PostgresException ex)
            {
                return (false, ex.MessageText);
            }
            catch (Exception ex)
            {
                return (false, "Kesalahan sistem: " + ex.Message);
            }
        }
        public bool HapusKaryawan(int idUser)
        {
            try
            {
                return _contextUser.HapusKaryawan(idUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghapus: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 3. AMBIL SEMUA KARYAWAN (GAYA OOP MURNI)
        /// Mengembalikan List berisi Objek Model User, bukan Dictionary mentah lagi.
        /// </summary>
        public List<User> AmbilSemuaKaryawan()
        {
            try
            {
                return _contextUser.GetAllUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat daftar karyawan ke layar: " + ex.Message, "Error Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<User>();
            }
        }
    }
}