using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CFMART.Models;

namespace CFMART.Views.Kasir
{
    public partial class FormCetakNota : Form
    {
        // =========================================================================
        // 🌟 SINKRONISASI NOTA: MURNI HANYA MENAMPILKAN METODE PEMBAYARAN
        // =========================================================================
        public void TampilkanDataNotaBaru(List<ItemKeranjang> daftarBarang, double total, double kembalian, string metodePembayaran)
        {
            try
            {
                if (lblTotal != null)
                {
                    lblTotal.Text = $"Rp {total:N0}";
                }

                if (lblKembalian != null)
                {
                    lblKembalian.Text = $"Rp {kembalian:N0}";
                }

                // Kita suapi label metode pembayaran dengan string murni ("Tunai" / "QRIS")
                if (lblMetode != null)
                {
                    lblMetode.Text = metodePembayaran;
                }

                if (flpItemNota != null)
                {
                    flpItemNota.Controls.Clear();

                    foreach (var item in daftarBarang)
                    {
                        Label lblBarisBarang = new Label();
                        lblBarisBarang.AutoSize = true;
                        lblBarisBarang.ForeColor = System.Drawing.Color.Black;
                        lblBarisBarang.Text = $"{item.nama_produk}   x{item.quantity}   Rp {item.sub_total:N0}";

                        flpItemNota.Controls.Add(lblBarisBarang);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal merelasikan data ke struk nota visual: " + ex.Message, "Error TampilkanDataNotaBaru");
            }
        }
    }
}