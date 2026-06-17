using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CFMART.Models;

namespace CFMART.Views.Kasir
{
    public partial class UCKonfirmasiPembayaran : UserControl
    {
        private double _totalBelanja = 0;
        private List<ItemKeranjang> _listPesanan = new List<ItemKeranjang>();

        // Variabel untuk menyimpan status yang diedit kasir
        private string _statusPembayaran = "Lunas";

        public UCKonfirmasiPembayaran()
        {
            InitializeComponent();

            // Event untuk hitung kembalian otomatis
            tbUangDiterima.TextChanged += TbUangDiterima_TextChanged;
            btnKonfirmasi.Click += BtnKonfirmasi_Click;
            btnKeluar.Click += (s, e) => this.Dispose();

            // Event untuk radio button status (Pastikan nama rbtnLunas & rbtnBlmLunas sesuai Designer)
            rbtnLunas.CheckedChanged += (s, e) => { if (rbtnLunas.Checked) _statusPembayaran = "Lunas"; };
            rbtnBlmLunas.CheckedChanged += (s, e) => { if (rbtnBlmLunas.Checked) _statusPembayaran = "Belum Lunas"; };
        }

        public void TampilkanData(string noPesanan, string noMeja, List<ItemKeranjang> listPesanan)
        {
            if (listPesanan == null) return;
            _listPesanan = listPesanan;

            lblAngkaNoPesanan.Text = ": " + noPesanan;
            lblAngkaNoMeja.Text = ": " + noMeja;
            lblWaktu.Text = ": " + DateTime.Now.ToString("HH:mm:ss");

            _totalBelanja = _listPesanan.Sum(i => i.sub_total);
            lblAngkaTotal.Text = ": Rp. " + _totalBelanja.ToString("N0");

            // Tampilkan detail pesanan
            flpPesanan.Controls.Clear();
            foreach (var item in _listPesanan)
            {
                Label lblItem = new Label
                {
                    Text = $"{item.nama_produk} x{item.quantity} = Rp {item.sub_total:N0}",
                    AutoSize = true
                };
                flpPesanan.Controls.Add(lblItem);
            }
        }

        private void TbUangDiterima_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(tbUangDiterima.Text, out double uangDiterima))
            {
                double kembalian = uangDiterima - _totalBelanja;
                lblAngkaKembalian.Text = kembalian >= 0 ? "Rp. " + kembalian.ToString("N0") : "Kurang";
            }
            else
            {
                lblAngkaKembalian.Text = "Rp. -";
            }
        }

        private void BtnKonfirmasi_Click(object sender, EventArgs e)
        {
            // Validasi uang
            if (double.TryParse(tbUangDiterima.Text, out double uangDiterima) && uangDiterima >= _totalBelanja)
            {
                FormCetakNota formNota = new FormCetakNota();
                double kembalian = uangDiterima - _totalBelanja;
                string metode = (rbtnLunas != null && rbtnLunas.Checked) ? "Tunai" : "QRIS";
                string idOrder = DateTime.Now.ToString("yyyyMMddHHmmss");

                // ✅ MEMANGGIL DENGAN 7 PARAMETER SESUAI REVISI TERAKHIR
                formNota.TampilkanDataNotaBaru(
                    _listPesanan,
                    _totalBelanja,
                    kembalian,
                    metode,
                    lblAngkaNoMeja.Text.Replace(": ", ""), // Identitas
                    idOrder,
                    _statusPembayaran // Status Lunas/Belum Lunas
                );

                formNota.ShowDialog();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Uang tidak valid/kurang!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}