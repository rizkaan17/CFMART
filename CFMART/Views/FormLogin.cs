using CFMART.Controllers;
using CFMART.Helpers;
using CFMART.Models;
using CFMART.Views.Kasir;
using CFMART.Views.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CFMART.Views
{
    public partial class FormLogin : Form
    {
        public bool LoginBerhasil { get; private set; } = false; 
        public FormLogin()
        {
            InitializeComponent();

            // 🌟 SETTING AWAL: Memastikan password langsung bertopeng bulat-bulat saat aplikasi pertama dibuka
            if (tbPassword != null)
            {
                tbPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginController loginCtrl = new LoginController();

            // Ambil input teks dari TextBox UI kamu
            User userAktif = loginCtrl.ProsesLogin(tbUsername.Text, tbPassword.Text);

            if (userAktif != null)
            {
                LoginBerhasil = true;
              
                if (userAktif.role_id_role == 1)
                {
                    // Jika Role ID 1 adalah Admin, buka Form Utama Admin
                    FormDashboard adminForm = new FormDashboard();
                    adminForm.Show();
                }
                else
                {
                    // Jika Role ID 2 adalah Kasir, buka Form Transaksi Kasir
                    FormDashboardKasir kasirForm = new FormDashboardKasir();
                    kasirForm.Show();
                }

                this.Hide(); // Sembunyikan form login agar RAM tetap aman
            }
        }

        // ======================================================================
        // 🌟 FITUR BARU: Mengatur Intip/Sembunyikan Password via Button btnEye
        // ======================================================================
        private void btnEye_Click(object sender, EventArgs e)
        {
            if (tbPassword != null && btnEye != null)
            {
                // Membalik keadaan topeng password (kalau true jadi false, kalau false jadi true)
                tbPassword.UseSystemPasswordChar = !tbPassword.UseSystemPasswordChar;

                // Mengubah tulisan tombol secara dinamis agar interaktif sesuai keadaan password
                btnEye.Text = tbPassword.UseSystemPasswordChar ? "Lihat" : "Sembunyikan";
            }
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Memastikan seluruh thread aplikasi mati total saat form login di-close oleh user
            Application.Exit();
        }
    }
}