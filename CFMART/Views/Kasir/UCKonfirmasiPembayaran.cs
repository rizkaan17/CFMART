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

        // Penampung internal agar data barang tidak hilang saat berpindah method
        private List<ItemKeranjang> _listPesanan = new List<ItemKeranjang>();

        public UCKonfirmasiPembayaran()
        {
            InitializeComponent();

            // Event untuk hitung kembalian otomatis saat angka diketik
            tbUangDiterima.TextChanged += TbUangDiterima_TextChanged;

            // Event untuk tombol konfirmasi
            btnKonfirmasi.Click += BtnKonfirmasi_Click;

            // Pengaman disposal agar tidak crash
            btnKeluar.Click += (s, e) => this.Dispose();
        }

        // Method untuk menerima lemparan data dari halaman pesanan sebelumnya
        public void TampilkanData(string noPesanan, string noMeja, List<ItemKeranjang> listPesanan)
        {
            if (listPesanan == null) return;

            // ✅ AMAN: Mengunci data list pesanan luar ke dalam variabel internal RAM
            _listPesanan = listPesanan;

            lblAngkaNoPesanan.Text = ": " + noPesanan;
            lblAngkaNoMeja.Text = ": " + noMeja;
            lblWaktu.Text = ": " + DateTime.Now.ToString("HH:mm:ss");

            _totalBelanja = _listPesanan.Sum(i => i.sub_total);
            lblAngkaTotal.Text = ": Rp. " + _totalBelanja.ToString("N0");

            // Tampilkan detail pesanan di FlowLayoutPanel secara vertikal
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
                lblAngkaKembalian.ForeColor = kembalian >= 0 ? System.Drawing.Color.Black : System.Drawing.Color.Red;
            }
            else
            {
                lblAngkaKembalian.Text = "Rp. -";
                lblAngkaKembalian.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void BtnKonfirmasi_Click(object sender, EventArgs e)
        {
            if (double.TryParse(tbUangDiterima.Text, out double uangDiterima) && uangDiterima >= _totalBelanja)
            {
                MessageBox.Show("Pembayaran Berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormCetakNota formNota = new FormCetakNota();
                double kembalian = uangDiterima - _totalBelanja;

                // 🌟 TUNTAS: Memilih string metode pembayaran berdasarkan RadioButton aktif kasir
                // (Sesuaikan rbtnTunai dengan name komponen RadioButton figma-mu jika berbeda)
                string metodeTerpilih = (rbtnTunai != null && rbtnTunai.Checked) ? "Tunai" : "QRIS";

                // ✅ SINKRON TOTAL: Memanggil TampilkanDataNotaBaru tepat dengan 4 parameter sesuai request nota murni!
                formNota.TampilkanDataNotaBaru(
                    _listPesanan,
                    _totalBelanja,
                    kembalian,
                    metodeTerpilih
                );

                formNota.ShowDialog();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Uang pembayaran kurang atau tidak valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}