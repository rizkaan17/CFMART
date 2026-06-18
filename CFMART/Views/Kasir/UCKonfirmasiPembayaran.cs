using CFMART.Controllers;
using CFMART.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CFMART.Models.Context;

namespace CFMART.Views.Kasir
{
    public partial class UCKonfirmasiPembayaran : UserControl
    {
        private double _totalBelanja = 0;
        private string _statusPembayaran = "Lunas";
        private System.Data.DataTable _dtDetailPesanan;
        private System.Data.DataTable _dtPesananAsli;
        private string _catatanUmum = "";

        public UCKonfirmasiPembayaran()
        {
            InitializeComponent();

            // Event Handlers
            tbUangDiterima.TextChanged += TbUangDiterima_TextChanged;
            btnKonfirmasi.Click += BtnKonfirmasi_Click;
            btnKeluar.Click += (s, e) => this.Dispose();
            this.Load += UCKonfirmasiPembayaran_Load;

            // Radio Button Logic
            rbtnLunas.CheckedChanged += (s, e) => { if (rbtnLunas.Checked) _statusPembayaran = "Lunas"; };
            rbtnBlmLunas.CheckedChanged += (s, e) => { if (rbtnBlmLunas.Checked) _statusPembayaran = "Belum Lunas"; };

            // Set Default
            rbtnLunas.Checked = true;
        }

        private void UCKonfirmasiPembayaran_Load(object sender, EventArgs e)
        {
            OrderController controller = new OrderController();
            _dtPesananAsli = controller.AmbilDaftarPesananPending(); 
            dgvKonfirmasiPembayaran.DataSource = _dtPesananAsli;
            dgvKonfirmasiPembayaran.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvKonfirmasiPembayaran_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string idOrder = dgvKonfirmasiPembayaran.Rows[e.RowIndex].Cells["id_order"].Value.ToString();
                string noMeja = dgvKonfirmasiPembayaran.Rows[e.RowIndex].Cells["meja_id_meja"].Value?.ToString() ?? "-";

                lblAngkaNoPesanan.Text = ": " + idOrder;
                lblAngkaNoMeja.Text = ": " + noMeja;
                lblWaktu.Text = ": " + DateTime.Now.ToString("HH:mm:ss");

                OrderController controller = new OrderController();
                DataTable dtDetail = controller.AmbilDetailPesanan(idOrder);
                _dtDetailPesanan = dtDetail;

                // Tampilkan di flpPesanan (FlowLayoutPanel), bukan dgvDetail
                flpPesanan.Controls.Clear();
                foreach (DataRow row in dtDetail.Rows)
                {
                    Label lblItem = new Label();
                    lblItem.AutoSize = true;
                    lblItem.Text = $"{row["jenis_produk"]}   x{row["quantity"]}   Rp {Convert.ToDouble(row["sub_total"]):N0}";
                    flpPesanan.Controls.Add(lblItem);
                }

                // tambahan: kumpulin semua catatan dari tiap item jadi satu teks
                List<string> daftarCatatan = new List<string>();
                foreach (DataRow row in dtDetail.Rows)
                {
                    string catatanItem = row["catatan"]?.ToString();
                    if (!string.IsNullOrWhiteSpace(catatanItem))
                        daftarCatatan.Add(catatanItem);
                }
                _catatanUmum = string.Join(", ", daftarCatatan);

                _totalBelanja = 0;
                foreach (DataRow row in dtDetail.Rows)
                {
                    _totalBelanja += Convert.ToDouble(row["sub_total"]);
                }
                lblAngkaTotal.Text = ": Rp. " + _totalBelanja.ToString("N0");
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
            if (_dtDetailPesanan == null || _dtDetailPesanan.Rows.Count == 0)
            {
                MessageBox.Show("Pilih pesanan terlebih dahulu sebelum konfirmasi!", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (double.TryParse(tbUangDiterima.Text, out double uangDiterima) && uangDiterima >= _totalBelanja)
            {
                OrderController controller = new OrderController(); // tambahan: deklarasi yang hilang

                List<ItemKeranjang> listItem = new List<ItemKeranjang>();
                foreach (DataRow row in _dtDetailPesanan.Rows)
                {
                    int qty = Convert.ToInt32(row["quantity"]);
                    double subTotalDb = Convert.ToDouble(row["sub_total"]);
                    double hargaSatuan = qty > 0 ? subTotalDb / qty : 0;

                    listItem.Add(new ItemKeranjang
                    {
                        nama_produk = row["jenis_produk"].ToString(),
                        quantity = qty,
                        harga = hargaSatuan
                    });
                }

                FormCetakNota formNota = new FormCetakNota();
                double kembalian = uangDiterima - _totalBelanja;
                string metode = rbtnLunas.Checked ? "Tunai" : "QRIS";
                string idOrder = lblAngkaNoPesanan.Text.Replace(": ", "");

                // update status pembayaran ke database
                bool statusLunasBool = (_statusPembayaran == "Lunas");
                int idKasirAktif = ContextUser.user?.id_user ?? 2; 
                controller.UpdateStatusPembayaran(idOrder, statusLunasBool, idKasirAktif); // huruf kecil

                // refresh DGV biar checkbox ke-update sebelum form ditutup
                _dtPesananAsli = controller.AmbilDaftarPesananPending();
                dgvKonfirmasiPembayaran.DataSource = _dtPesananAsli; // refresh DGV biar checkbox ke-update sebelum form ditutup

                // kirim data ke nota — ini sebelumnya hilang, dikembalikan
                formNota.TampilkanDataNotaBaru(
                    listItem,
                    _totalBelanja,
                    kembalian,
                    metode,
                    lblAngkaNoMeja.Text.Replace(": ", ""),
                    idOrder,
                    _statusPembayaran,
                    _catatanUmum
                );

                formNota.ShowDialog();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Uang kurang atau input tidak valid!", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UCKonfirmasiPembayaran_Load_1(object sender, EventArgs e)
        {

        }
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtPesananAsli == null) return;

            string keyword = tbSearch.Text.Trim();
            string keywordAman = keyword.Replace("'", "''");

            DataView dv = new DataView(_dtPesananAsli);

            if (!string.IsNullOrEmpty(keyword))
            {
                dv.RowFilter = $"CONVERT(meja_id_meja, 'System.String') LIKE '%{keywordAman}%'";
                dv.Sort = "tgl_order DESC";
            }

              // ← tambahan ini

            dgvKonfirmasiPembayaran.DataSource = dv;
        }
    }
}