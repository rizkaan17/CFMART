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
        public UCKonfirmasiPembayaran()
        {
            InitializeComponent();

            // Event untuk hitung kembalian otomatis saat angka diketik
            tbUangDiterima.TextChanged += TbUangDiterima_TextChanged;

            // Event untuk tombol konfirmasi
            btnKonfirmasi.Click += BtnKonfirmasi_Click;
            btnKeluar.Click += (s, e) => this.Dispose(); // Menutup UC
        }

        // Method untuk menerima data dari halaman sebelumnya
        public void TampilkanData(string noPesanan, string noMeja, List<ItemKeranjang> listPesanan)
        {
            lblAngkaNoPesanan.Text = ": " + noPesanan;
            lblAngkaNoMeja.Text = ": " + noMeja;
            lblWaktu.Text = ": " + DateTime.Now.ToString("HH:mm:ss");

            _totalBelanja = listPesanan.Sum(i => i.sub_total);
            lblAngkaTotal.Text = ": Rp. " + _totalBelanja.ToString("N0");

            // Tampilkan detail pesanan di FlowLayoutPanel (gunakan UserControl item sederhana)
            flpPesanan.Controls.Clear();
            foreach (var item in listPesanan)
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
                lblAngkaKembalian.ForeColor = kembalian >= 0 ? System.Drawing.Color.Black : System.Drawing.Color.Red;
            }
        }

        private void BtnKonfirmasi_Click(object sender, EventArgs e)
        {
            if (double.TryParse(tbUangDiterima.Text, out double uangDiterima) && uangDiterima >= _totalBelanja)
            {
                MessageBox.Show("Pembayaran Berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormCetakNota formNota = new FormCetakNota();
                double kembalian = uangDiterima - _totalBelanja;

                // --- BAGIAN YANG DIPERBAIKI ---
                // Tambahkan argumen ke-6 (identitas)
                // Kita gunakan 'lblAngkaNoMeja.Text' sebagai identitas
                formNota.TampilkanDataNotaBaru(
                    _listPesanan,
                    _totalBelanja,
                    kembalian,
                    rbtnTunai.Checked ? "Tunai" : "Qris",
                    "Lunas",
                    lblAngkaNoMeja.Text.Replace(": ", "") // Mengambil teks nomor meja saja
                );
                // ------------------------------

                formNota.ShowDialog();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Uang kurang atau tidak valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
    
}