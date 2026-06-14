using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFMART.Models
{
    public class User
    {
        public int id_user { get; set; }
        public string username { get; set; }
        public string password_user { get; set; }
        public int role_id_role { get; set; }
        public bool status_karyawan { get; set; }
        public string nama_lengkap { get; set; }

        // Backing fields untuk Enkapsulasi
        private string _email;
        private string _nomerTeleponKaryawan;

        public string email
        {
            get => _email;
            set
            {
                // Validasi enkapsulasi dasar format email
                if (!string.IsNullOrEmpty(value) && value.Contains("@"))
                    _email = value.Trim();
                else
                    _email = "invalid_email@cfmart.com"; // Teks pencegah error database
            }
        }

        public string nomer_telepon_karyawan
        {
            get => _nomerTeleponKaryawan;
            set => _nomerTeleponKaryawan = value?.Replace(" ", "").Replace("-", "") ?? string.Empty; // Otomatis merapikan format nomor
        }
    }
}