using CFMART.Controllers;
using CFMART.Helpers;
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
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            // 1. Panggil controllernya
            CFMART.Controllers.c_LoginLogout auth = new CFMART.Controllers.c_LoginLogout();

            // 2. Tampung hasil login ke dalam objek User
            CFMART.Models.User userTerlogin = auth.Login(username, password);

            // 3. Cek apakah usernya sukses login
            if (userTerlogin != null)
            {
                MessageBox.Show($"Selamat datang, {userTerlogin.Username}!", "Login Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sembunyikan form login
                this.Hide();

                // ======================================================================
                // BARIS PENYELAMAT: Simpan data user ke Session statis global
                // Dengan baris ini, UCBiodata akan tahu kalau yang login adalah Harley!
                CFMART.Models.Context.ContextUser.user = userTerlogin;
                // ======================================================================

                // 4. Cek role ID nya
                if (userTerlogin.Role_Id_Role == 1)
                {
                    // Kalau admin (1), buka form dashboard milik admin
                    FormDashboard adminForm = new FormDashboard();
                    adminForm.ShowDialog();
                }
                else if (userTerlogin.Role_Id_Role == 2)
                {
                    // Kalau kasir (2), buka form dashboard kasir
                    CFMART.Views.Kasir.FormDashboardKasir kasirForm = new CFMART.Views.Kasir.FormDashboardKasir();
                    kasirForm.ShowDialog();
                }

                // Close total aplikasinya biar gak ngegantung di Task Manager
                this.Close();
            }
            else
            {
                MessageBox.Show("Username atau Password salah / Akun tidak aktif!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}