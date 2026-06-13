using CFMART.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CFMART.Views.Admin
{
    public partial class UCManajemenKaryawan : UserControl
    {
        private KaryawanController c_Karyawan = new KaryawanController();
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

            // 3. Sembunyikan panel inputan di awal & bersihkan form
            BersihkanForm();

            // 4. Jalankan fungsi memuat data dari database
            TampilkanSemuaKaryawan();
        }

        //private void RefreshGridKaryawan()
        //{
        //    try
        //    {
        //        List<Dictionary<string, object>> dataKaryawan = c_Karyawan.GetAllKaryawan();

        //        // Konversi List Dictionary ke DataTable agar bisa dibaca DataGridView
        //        DataTable dt = new DataTable();
        //        dt.Columns.Add("ID", typeof(int));
        //        dt.Columns.Add("Username", typeof(string));
        //        dt.Columns.Add("Role", typeof(string));
        //        dt.Columns.Add("Status Aktif", typeof(bool));

        //        foreach (var row in dataKaryawan)
        //        {
        //            dt.Rows.Add(
        //                row["id_user"],
        //                row["username"],
        //                row["nama_role"],
        //                row["status_karyawan"]
        //            );
        //        }

        //        dgvManajemenKaryawan.DataSource = dt;
        //        dgvManajemenKaryawan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Gagal memuat data karyawan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void TampilkanSemuaKaryawan()
        {
            try
            {
                List<Dictionary<string, object>> dataKaryawan = c_Karyawan.GetAllKaryawan();
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Username", typeof(string));
                dt.Columns.Add("Nama", typeof(string));
                dt.Columns.Add("Role", typeof(string));
                dt.Columns.Add("Status", typeof(string));
                dt.Columns.Add("No HP", typeof(string));

                foreach (var karyawan in dataKaryawan)
                {
                    bool statusBool = Convert.ToBoolean(karyawan["status_karyawan"]);
                    dt.Rows.Add(
                        karyawan["id_user"],
                        karyawan["username"],       
                        karyawan["nama_lengkap"],
                        karyawan["nama_role"],
                        statusBool ? "Aktif" : "Tidak Aktif",
                        karyawan["nomer_telepon_karyawan"]
                    );
                }
                dgvManajemenKaryawan.DataSource = dt;
                dgvManajemenKaryawan.Columns["No HP"].Visible = false; // Kolom tersembunyi di tabel, tapi datanya tetap bisa dibaca saat baris diklik!
                dgvManajemenKaryawan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvManajemenKaryawan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error memuat data: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTambahKaryawan_Click(object sender, EventArgs e)
        {
            // 1. VALIDASI INPUT UTAMA SEBELUM DISIMPAN
            if (string.IsNullOrEmpty(tbUsernameEdit.Text) || string.IsNullOrEmpty(tbNamaEdit.Text))
            {
                MessageBox.Show("Untuk menambah karyawan baru, isi dulu Nama Lengkap dan Username di form, baru klik tombol ini!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Ambil nilai dari inputan (Gunakan pengecekan null yang aman untuk ComboBox)
            int roleId = (cbRole.SelectedItem != null && cbRole.SelectedItem.ToString() == "Admin") ? 1 : 2;

            // FIX EROR CS0019: Cek langsung string-nya, jika "Aktif" maka true, selain itu false
            bool statusAktif = (cbStatusKaryawan.SelectedItem != null && cbStatusKaryawan.SelectedItem.ToString() == "Aktif");

            // 3. --- MODE: KHUSUS TAMBAH KARYAWAN BARU ---
            // Pastikan tbPassword sesuai dengan nama komponen textbox password kamu di desainer
            var result = c_Karyawan.TambahKaryawan(tbUsernameEdit.Text, tbPassword.Text, roleId, statusAktif, tbNamaEdit.Text, tbNoHP.Text);

            if (result.sukses)
            {
                MessageBox.Show(result.pesan, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TampilkanSemuaKaryawan(); // Refresh tabel biar karyawan baru langsung nongol
                BersihkanForm();          // Bersihkan form kembali kosong
            }
            else
            {
                MessageBox.Show("Gagal menambah data: " + result.pesan, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateManajemen_Click(object sender, EventArgs e)
        {// 1. VALIDASI: Pastikan user sudah benar-benar klik salah satu karyawan di tabel
            if (selectedIdUser == null)
            {
                MessageBox.Show("Pilih karyawan terlebih dahulu di tabel (klik sampai barisnya berwarna biru) untuk diedit!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Ambil nilai Role ID berdasarkan pilihan ComboBox figma (Kasir = 2, Admin = 1)
            int roleId = (cbRole.SelectedItem != null && cbRole.SelectedItem.ToString() == "Admin") ? 1 : 2;

            // 3. Ambil nilai Status berdasarkan ComboBox status
            bool statusAktif = (cbStatusKaryawan.SelectedItem != null && cbStatusKaryawan.SelectedItem.ToString() == "Aktif");

            // 4. --- JALANKAN MODE EDIT KARYAWAN ---
            // Gunakan c_Karyawan untuk menembak ke Controller
            var result = c_Karyawan.EditKaryawan(selectedIdUser.Value, tbUsernameEdit.Text, "********", roleId, statusAktif, tbNamaEdit.Text, tbNoHP.Text);

            if (result.sukses)
            {
                MessageBox.Show(result.pesan, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TampilkanSemuaKaryawan(); // Refresh tabel agar perubahan status/role langsung kelihatan!
                BersihkanForm();          // Reset form dan kosongkan selectedIdUser kembali ke null
            }
            else
            {
                MessageBox.Show("Gagal memperbarui data: " + result.pesan, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvManajemenKaryawan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pastikan yang di-klik adalah baris data yang valid, bukan header tabel
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvManajemenKaryawan.Rows[e.RowIndex];

                // FIX: Ambil data berdasarkan nama kolom DataTable agar posisinya akurat
                selectedIdUser = Convert.ToInt32(row.Cells["ID"].Value);

                tbUsernameEdit.Text = row.Cells["Username"].Value?.ToString() ?? "";
                tbNamaEdit.Text = row.Cells["Nama"].Value?.ToString() ?? ""; // Menyesuaikan dengan kolom dt.Columns.Add("Name") Anda yang di atas

                // FIX: Masukkan data No HP ke TextBox figma agar muncul saat baris diklik!
                tbNoHP.Text = row.Cells["No HP"].Value?.ToString() ?? "";

                string roleNama = row.Cells["Role"].Value?.ToString() ?? "Kasir";
                cbRole.SelectedItem = roleNama;

                string statusNama = row.Cells["Status"].Value?.ToString() ?? "Aktif";
                cbStatusKaryawan.SelectedItem = statusNama;

                tbPassword.Text = "********"; // Penanda visual bahwa password tidak kosong

                // Kunci input yang tidak boleh diganti saat edit (sesuai figma kamu)
                tbUsernameEdit.Enabled = false; // Kunci total Username (jadi abu-abu)
                tbNamaEdit.Enabled = false;     // Kunci total Nama Lengkap (jadi abu-abu)
                tbNoHP.Enabled = false;         // Kunci total No HP (jadi abu-abu)
                tbPassword.Enabled = false;// Biarkan kosong atau digembok kalau cuma edit status/role

                // Ubah judul figma di atas untuk penanda mode Edit
                lblTambahKaryawan.Text = "Edit Status Karyawan (ID: " + selectedIdUser + ")";
            }
        }

        private void dgvManajemenKaryawan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvManajemenKaryawan_CellClick(sender, e);
        }

        private void BersihkanForm()
        {
            tbNamaEdit.Clear();
            tbUsernameEdit.Clear();
            tbPassword.Clear();
            tbNoHP.Clear();
            // tbNoHP.Clear(); // hapus baris ini kalau tbNoHP tidak ada di Designer

            // Reset combo box ke default, BUKAN dikosongkan (tetap ada item)
            if (cbRole.Items.Count > 0)
                cbRole.SelectedIndex = 1; // default: Kasir

            if (cbStatusKaryawan.Items.Count > 0)
                cbStatusKaryawan.SelectedIndex = 0; // default: Aktif

            // Buka kembali gembok semua inputan agar bisa dipakai input karyawan baru
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