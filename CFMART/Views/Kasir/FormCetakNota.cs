using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CFMART.Models;

namespace CFMART.Views.Kasir
{
    public partial class FormCetakNota : Form
    {
        public FormCetakNota()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            btnTutup.Click += (s, e) => this.Close();
            btnCetakNota.Click += BtnCetakNota_Click;
        }

        /// <summary>
        /// Fungsi utama penyuap data riil nota
        /// </summary>
        /// <param name="identitas">Bisa diisi Nama Pelanggan (jika kasir) atau No. Meja (jika pelanggan)</param>
        public void TampilkanDataNotaBaru(List<ItemKeranjang> listBelanja, double total, double kembali, string metode, string status, string identitas)
        {
            // 1. Data Meta
            lblTglNota.Text = ": " + DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            lblNoNota.Text = ": NOTA-" + DateTime.Now.ToString("yyMMddHHmmss");
            lblNamaKasir.Text = ": Kasir Aktif";

            // Logika baru: Menampilkan Nama/Meja berdasarkan data yang dikirim
            lblNamaMeja.Text = ": " + identitas;

            // 2. Loop Item
            flpItemNota.Controls.Clear();
            foreach (var item in listBelanja)
            {
                Label lblBarisItem = new Label();
                lblBarisItem.AutoSize = false;
                lblBarisItem.Size = new Size(380, 30);
                lblBarisItem.Font = new Font("Dubai", 8.5F, FontStyle.Regular);

                string namaMenu = item.nama_produk.Length > 15 ? item.nama_produk.Substring(0, 15) : item.nama_produk.PadRight(15);
                string qty = item.quantity.ToString().PadRight(4);
                string subTotalItem = item.sub_total.ToString("N0");

                lblBarisItem.Text = $"{namaMenu} x{qty} Rp {subTotalItem}";
                flpItemNota.Controls.Add(lblBarisItem);
            }

            // 3. Data Nominal
            lblAngkaTotal.Text = ": Rp " + total.ToString("N0");
            lblAngkaKembalian.Text = ": Rp " + kembali.ToString("N0");
            lblNamaMetode.Text = ": " + (string.IsNullOrWhiteSpace(metode) ? "Tunai" : metode);
            lblNamaStatus.Text = ": " + (string.IsNullOrWhiteSpace(status) ? "Lunas" : status);
        }

        private void BtnCetakNota_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nota berhasil dikirimkan ke printer thermal kasir!", "Cetak Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}