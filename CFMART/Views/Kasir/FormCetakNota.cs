using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CFMART.Models;
using CFMART.Models.Context;

namespace CFMART.Views.Kasir
{
    public partial class FormCetakNota : Form
    {
        public FormCetakNota()
        {
            InitializeComponent();
        }

        public void TampilkanDataNotaBaru(
            List<ItemKeranjang> items,
            double total,
            double kembalian,
            string metode,
            string identitas,
            string idOrder,
            string status,
            string catatanUmum)
        {
            lblTglNota.Text = ": " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            lblNoNota.Text = ": " + idOrder;
            lblNamaKasir.Text = ": " + (ContextUser.user?.nama_lengkap ?? "Admin");
            lblIsiNamaMeja.Text = ": " + identitas;

            lblAngkaTotal.Text = ": Rp. " + total.ToString("N0");
            lblAngkaKembalian.Text = ": Rp. " + kembalian.ToString("N0");
            lblNamaMetode.Text = ": " + metode;

            if (lblNamaStatus != null)
                lblNamaStatus.Text = ": " + status;

            if (lblIsiCatatan != null)
                lblIsiCatatan.Text = string.IsNullOrWhiteSpace(catatanUmum) ? "-" : catatanUmum;

            flpItemNota.Controls.Clear();
            flpItemNota.FlowDirection = FlowDirection.TopDown;
            flpItemNota.WrapContents = false;
            flpItemNota.AutoScroll = true;

            foreach (var it in items ?? new List<ItemKeranjang>())
            {
                string teksBaris = $"{it.nama_produk} x {it.quantity} = Rp {it.sub_total:N0}";

                Label lblItem = new Label
                {
                    Text = teksBaris,
                    AutoSize = true,
                    ForeColor = Color.Black,
                    Margin = new Padding(0, 5, 0, 0),
                    Font = new Font("Segoe UI", 9)
                };
                flpItemNota.Controls.Add(lblItem);
            }

            this.Refresh();
        }
    }
}