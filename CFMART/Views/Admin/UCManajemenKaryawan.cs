using CFMART.Controllers;
using CFMART.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CFMART.Views.Admin
{
    public partial class UCManajemenKaryawan : UserControl
    {
        private readonly KaryawanController c_Karyawan = new KaryawanController();
        private int? selectedIdUser = null;

        public UCManajemenKaryawan()
        {
            InitializeComponent();
        }

        private void UCManajemenKaryawan_Load(object sender, EventArgs e)
        {
            // 1. Atur Pilihan ComboBox Role
            cbRole.Items.Clear();
            cbRole.Items.Add("Admin");
            cbRole.Items.Add("Kasir");

            // 2. Atur Pilihan ComboBox Status Karyawan
            cbStatusKaryawan.Items.Clear();
            cbStatusKaryawan.Items.Add("Aktif");
            cbStatusKaryawan.Items.Add("Tidak Aktif");

            // 3. Bersihkan form awal
            BersihkanForm();

            // 4. Jalankan fungsi memuat data dari database
            TampilkanSemuaKaryawan();

            if (dgvManajemenKaryawan.Columns["btnHapus"] == null)
            {
                DataGridViewButtonColumn btnHapus = new DataGridViewButtonColumn();
                btnHapus.Name = "btnHapus";
                btnHapus.HeaderText = ""; // Biar bersih, tidak ada judul
                btnHapus.Text = "Hapus";
                btnHapus.UseColumnTextForButtonValue = true;
                dgvManajemenKaryawan.Columns.Add(btnHapus);
            }
        }

        /// <summary>
        /// 🌟 PERBAIKAN: Membaca data berbasis List Objek Model User (OOP Murni)
        /// </summary>
        private void TampilkanSemuaKaryawan()
        {
            try
            {
                // Menggil fungsi controller baru yang mengembalikan List<User>
                List<User> dataKaryawan = c_Karyawan.AmbilSemuaKaryawan();

                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Username", typeof(string));
                dt.Columns.Add("Nama", typeof(string));
                dt.Columns.Add("Role", typeof(string));
                dt.Columns.Add("Status", typeof(string));
                dt.Columns.Add("No HP", typeof(string));

                foreach (User karyawan in dataKaryawan)
                {
                    // Konversi Role ID (1 = Admin, selain itu Kasir)
                    string roleNama = (karyawan.role_id_role == 1) ? "Admin" : "Kasir";

                    dt.Rows.Add(
                        karyawan.id_user,
                        karyawan.username,
                        karyawan.nama_lengkap,
                        roleNama,
                        karyawan.status_karyawan ? "Aktif" : "Tidak Aktif",
                        karyawan.nomer_telepon_karyawan
                    );
                }

                dgvManajemenKaryawan.DataSource = dt;

                // Menyembunyikan kolom No HP di grid visual, tapi datanya tetap aman di memori cell click
                if (dgvManajemenKaryawan.Columns["No HP"] != null)
                    dgvManajemenKaryawan.Columns["No HP"].Visible = false;

                dgvManajemenKaryawan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvManajemenKaryawan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvManajemenKaryawan.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error memuat data: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTambahKaryawan_Click(object sender, EventArgs e)
        {
            // 1. VALIDASI INPUT UTAMA
            if (string.IsNullOrWhiteSpace(tbUsernameEdit.Text) || string.IsNullOrWhiteSpace(tbNamaEdit.Text) || string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                MessageBox.Show("Untuk menambah karyawan baru, Username, Password, dan Nama Lengkap wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Ambil nilai inputan
            int roleId = (cbRole.SelectedItem != null && cbRole.SelectedItem.ToString() == "Admin") ? 1 : 2;
            bool statusAktif = (cbStatusKaryawan.SelectedItem != null && cbStatusKaryawan.SelectedItem.ToString() == "Aktif");

            // 3. Eksekusi Tambah Karyawan
            var result = c_Karyawan.TambahKaryawan(tbUsernameEdit.Text, tbPassword.Text, roleId, statusAktif, tbNamaEdit.Text, tbNoHP.Text);

            if (result.sukses)
            {
                MessageBox.Show(result.pesan, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TampilkanSemuaKaryawan();
                BersihkanForm();
            }
            else
            {
                MessageBox.Show("Gagal menambah data: " + result.pesan, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateManajemen_Click(object sender, EventArgs e)
        {
            // 1. VALIDASI SELEKSI BARIS
            if (selectedIdUser == null)
            {
                MessageBox.Show("Pilih karyawan terlebih dahulu di tabel untuk diedit!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int roleId = (cbRole.SelectedItem != null && cbRole.SelectedItem.ToString() == "Admin") ? 1 : 2;
            bool statusAktif = (cbStatusKaryawan.SelectedItem != null && cbStatusKaryawan.SelectedItem.ToString() == "Aktif");

            // 2. Jalankan Mode Edit (Password dikirim "********" sebagai flag tidak diubah)
            var result = c_Karyawan.EditKaryawan(selectedIdUser.Value, tbUsernameEdit.Text, "********", roleId, statusAktif, tbNamaEdit.Text, tbNoHP.Text);

            if (result.sukses)
            {
                MessageBox.Show(result.pesan, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TampilkanSemuaKaryawan();
                BersihkanForm();
            }
            else
            {
                MessageBox.Show("Gagal memperbarui data: " + result.pesan, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvManajemenKaryawan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvManajemenKaryawan.Rows[e.RowIndex];

                selectedIdUser = Convert.ToInt32(row.Cells["ID"].Value);

                tbUsernameEdit.Text = row.Cells["Username"].Value?.ToString() ?? "";
                tbNamaEdit.Text = row.Cells["Nama"].Value?.ToString() ?? "";
                tbNoHP.Text = row.Cells["No HP"].Value?.ToString() ?? "";

                cbRole.SelectedItem = row.Cells["Role"].Value?.ToString() ?? "Kasir";
                cbStatusKaryawan.SelectedItem = row.Cells["Status"].Value?.ToString() ?? "Aktif";

                tbPassword.Text = "********";

                // Kunci input yang tidak boleh diganti saat edit status/role oleh admin
                tbUsernameEdit.Enabled = false;
                tbNamaEdit.Enabled = false;
                tbNoHP.Enabled = false;
                tbPassword.Enabled = false;

                lblTambahKaryawan.Text = "Edit Status Karyawan (ID: " + selectedIdUser + ")";
            }
        }

        private void dgvManajemenKaryawan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvManajemenKaryawan.Columns[e.ColumnIndex].Name == "btnHapus")
            {
                int idHapus = Convert.ToInt32(dgvManajemenKaryawan.Rows[e.RowIndex].Cells["ID"].Value);

                var confirm = MessageBox.Show("Yakin ingin menghapus karyawan ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    if (c_Karyawan.HapusKaryawan(idHapus))
                    {
                        MessageBox.Show("Karyawan berhasil dihapus!");
                        TampilkanSemuaKaryawan(); // Refresh tabel
                        BersihkanForm();
                    }
                }
            }
        }

        private void BersihkanForm()
        {
            tbNamaEdit.Clear();
            tbUsernameEdit.Clear();
            tbPassword.Clear();
            tbNoHP.Clear();

            if (cbRole.Items.Count > 0)
                cbRole.SelectedIndex = 1; // Default: Kasir

            if (cbStatusKaryawan.Items.Count > 0)
                cbStatusKaryawan.SelectedIndex = 0; // Default: Aktif

            // Buka gembok kembali agar form siap dipakai tambah karyawan baru
            tbUsernameEdit.Enabled = true;
            tbNamaEdit.Enabled = true;
            tbNoHP.Enabled = true;
            cbRole.Enabled = true;
            tbPassword.Enabled = true;

            selectedIdUser = null;
            lblTambahKaryawan.Text = "Tambah Karyawan Baru";
        }

        private void btnBatal1_Click(object sender, EventArgs e)
        {
            BersihkanForm();
        }
    }
}