using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CFMART.Models;
using CFMART.Models.Context; // Pastikan namespace ini sesuai dengan project-mu

namespace CFMART.Views.Kasir
{
    public partial class FormCetakNota : Form
    {
        public FormCetakNota()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Menampilkan data nota secara lengkap.
        /// Pastikan urutan parameter sama persis di semua tempat pemanggilan!
        /// </summary>
        public void TampilkanDataNotaBaru(
            List<ItemKeranjang> items,
            double total,
            double kembalian,
            string metode,
            string identitas,
            string idOrder,
            string status)
        {
            // 1. Header Nota
            lblTglNota.Text = ": " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            lblNoNota.Text = ": " + idOrder;
            lblNamaKasir.Text = ": " + (ContextUser.user?.nama_lengkap ?? "Admin");
            lblNamaMeja.Text = ": " + identitas; // Menampilkan No Meja atau Nama Pelanggan

            // 2. Data Nominal
            lblAngkaTotal.Text = ": Rp. " + total.ToString("N0");
            lblAngkaKembalian.Text = ": Rp. " + kembalian.ToString("N0");
            lblNamaMetode.Text = ": " + metode;

            // PASTIKAN label ini ada di Designer!
            if (lblNamaStatus != null)
                lblNamaStatus.Text = ": " + status;

            // 3. List Produk (Menggunakan FlowLayoutPanel)
            flpItemNota.Controls.Clear();
            flpItemNota.FlowDirection = FlowDirection.TopDown;
            flpItemNota.WrapContents = false;
            flpItemNota.AutoScroll = true;

            foreach (var item in items)
            {
                Label lblItem = new Label
                {
                    Text = $"{item.nama_produk} x {item.quantity} = Rp {item.sub_total:N0}",
                    AutoSize = true,
                    ForeColor = Color.Black,
                    Margin = new Padding(0, 5, 0, 0),
                    Font = new Font("Segoe UI", 9)
                };
                flpItemNota.Controls.Add(lblItem);
            }

            // 4. Force UI Refresh agar tidak muncul putih kosong
            this.Refresh();
        }
    }
}