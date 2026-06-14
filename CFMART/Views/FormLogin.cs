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
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginController loginCtrl = new LoginController();

            // Ambil input teks dari TextBox UI kamu
            User userAktif = loginCtrl.ProsesLogin(tbUsername.Text, tbPassword.Text);

            if (userAktif != null)
            {
                // Login Sukses! Cek role untuk mengarahkan halaman
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

                this.Hide(); // Sembunyikan form login
            }
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Memastikan seluruh thread aplikasi mati total saat form login di-close
            Application.Exit();
        }
    }

    // ======================================================================
    // SELESAI
    // ======================================================================
    // Sisi 'else' (Pesan Gagal) sudah dihandle otomatis di dalam LoginController, 
    // jadi kita tidak perlu menulis MessageBox.Show() gagal lagi di sini.
}