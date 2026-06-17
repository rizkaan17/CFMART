using CFMART.Controllers;
using CFMART.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CFMART.Views.Kasir // 🌟 Murni CFMART
{
    public partial class UCPilihproduk : UserControl
    {
        private readonly TransaksiController _transaksiController = new TransaksiController();
        private readonly ProdukController _produkController = new ProdukController();
        private List<ItemKeranjang> _keranjangBelanja = new List<ItemKeranjang>();

        private string _pilihanMetode = "Tunai";
        private string _pilihanStatus = "Lunas";

        private Panel[] _arrayPanelMenu = Array.Empty<Panel>();
        private Label[] _arrayLabelNama = Array.Empty<Label>();
        private Label[] _arrayLabelHarga = Array.Empty<Label>();
        private Label[] _arrayLabelStok = Array.Empty<Label>();
        private Button[] _arrayButtonPlus = Array.Empty<Button>();

        public UCPilihproduk()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.UCPilihproduk_Load);

            if (tbSearchProduk != null)
                tbSearchProduk.TextChanged += new System.EventHandler(this.tbSearchProduk_TextChanged);

            if (btnCetakNota != null) btnCetakNota.Click += btnCetakNota_Click;
            if (btnTunai != null && btnQris != null) btnTunai.Click += (s, e) => SetMetodePembayaran("Tunai", btnTunai, btnQris);
            if (btnQris != null && btnTunai != null) btnQris.Click += (s, e) => SetMetodePembayaran("QRIS", btnQris, btnTunai);
            if (btnLunas != null && btnBlmLunas != null) btnLunas.Click += (s, e) => SetStatusPembayaran("Lunas", btnLunas, btnBlmLunas);
            if (btnBlmLunas != null && btnLunas != null) btnBlmLunas.Click += (s, e) => SetStatusPembayaran("Belum Lunas", btnBlmLunas, btnLunas);
        }

        private void UCPilihproduk_Load(object? sender, EventArgs e)
        {
            InisialisasiArrayKomponen();
            AturKomponenOtomatis();
            MuatKatalogProduk("");
            RenderListPanelKanan();

            if (btnTunai != null) btnTunai.BackColor = Color.DarkSlateGray;
            if (btnLunas != null) btnLunas.BackColor = Color.DarkSlateGray;
        }

        private void InisialisasiArrayKomponen()
        {
            _arrayPanelMenu = new Panel[] { pnlMenu1, pnlMenu2, pnlMenu3, pnlMenu4, pnlMenu5, pnlMenu6 };
            _arrayLabelNama = new Label[] { lblMenu1, lblMenu2, lblMenu3, lblMenu4, lblMenu5, lblMenu6 };
            _arrayLabelHarga = new Label[] { lblHargaMenu1, lblHargaMenu2, lblHargaMenu3, lblHargaMenu4, lblHargaMenu5, lblHargaMenu6 };
            _arrayLabelStok = new Label[] { lblAngkaStok, lblAngkaStok2, lblAngkaStok3, lblAngkaStok4, lblAngkaStok5, lblAngkaStok6 };
            _arrayButtonPlus = new Button[] { btnMenu1, btnMenu2, btnMenu3, btnMenu4, btnMenu5, btnMenu6 };

            for (int i = 0; i < _arrayButtonPlus.Length; i++)
            {
                if (_arrayButtonPlus[i] != null) _arrayButtonPlus[i].Click += TombolPlusKatalog_Click;
            }
        }

        private void MuatKatalogProduk(string keyword)
        {
            List<Produk> listProduk = string.IsNullOrWhiteSpace(keyword) || keyword == "Cari produk di sini..." || keyword == "Cari Produk..."
                ? _produkController.AmbilSemuaProduk()
                : _produkController.CariProduk(keyword);

            for (int i = 0; i < _arrayPanelMenu.Length; i++)
            {
                if (_arrayPanelMenu[i] == null) continue;

                if (i < listProduk.Count)
                {
                    Produk prod = listProduk[i];
                    if (_arrayLabelNama[i] != null) _arrayLabelNama[i].Text = prod.jenis_produk;
                    if (_arrayLabelHarga[i] != null) _arrayLabelHarga[i].Text = $"Rp {prod.harga:N0}";
                    if (_arrayLabelStok[i] != null) _arrayLabelStok[i].Text = prod.stok.ToString();
                    if (_arrayButtonPlus[i] != null) _arrayButtonPlus[i].Tag = prod;

                    _arrayPanelMenu[i].Visible = true;
                }
                else
                {
                    _arrayPanelMenu[i].Visible = false;
                    if (_arrayButtonPlus[i] != null) _arrayButtonPlus[i].Tag = null;
                }
            }
        }

        private void TombolPlusKatalog_Click(object sender, EventArgs e)
        {
            if (sender is not Button btnPlus || btnPlus.Tag is not Produk prod) return;

            // 1. Cek & Kurangi di database dulu
            if (_produkController.KurangiStok(prod.id_produk, 1))
            {
                // 2. Kalau database sukses, baru tambah ke keranjang
                ItemKeranjang itemAda = _keranjangBelanja.FirstOrDefault(k => k.id_produk == prod.id_produk);
                if (itemAda != null) itemAda.quantity++;
                else _keranjangBelanja.Add(new ItemKeranjang { id_produk = prod.id_produk, nama_produk = prod.jenis_produk, harga = prod.harga, quantity = 1 });

                // 3. Refresh UI biar stok di layar update
                MuatKatalogProduk(tbSearchProduk.Text);
                RenderListPanelKanan();
            }
            else
            {
                MessageBox.Show("Stok habis di database!");
            }
        }

        private void RenderListPanelKanan()
        {
            if (flpDaftarPesanan == null) return;
            flpDaftarPesanan.Controls.Clear();

            if (lblDaftarPesanan != null) flpDaftarPesanan.Controls.Add(lblDaftarPesanan);

            foreach (ItemKeranjang item in _keranjangBelanja)
            {
                UCItemKeranjang cardItem = new UCItemKeranjang();
                cardItem.SetData(item);

                cardItem.OnKuantitasBerubah += (itemTerupdate) => HitungUlangTotalBelanja();
                cardItem.OnDataPerluRefresh += () => MuatKatalogProduk("");
                cardItem.OnHapusItemKlik += (itemDihapus) =>
                {
                    // 1. KEMBALIKAN STOK ke database saat item dihapus (PENTING!)
                    _produkController.TambahStok(itemDihapus.id_produk, itemDihapus.quantity);

                    // 2. Hapus dari keranjang
                    _keranjangBelanja.Remove(itemDihapus);

                    // 3. Refresh tampilan
                    RenderListPanelKanan();
                    MuatKatalogProduk(""); // Refresh katalog agar stok terbaru muncul
                };
                flpDaftarPesanan.Controls.Add(cardItem);
            }

            HitungUlangTotalBelanja();
        }

        private void HitungUlangTotalBelanja()
        {
            double total = _keranjangBelanja.Sum(item => item.sub_total);
            if (lblTotal != null) lblTotal.Text = $"Rp {total:N0}";
        }

        private void SetMetodePembayaran(string metode, Button aktif, Button nonAktif)
        {
            _pilihanMetode = metode;
            if (aktif != null) aktif.BackColor = Color.DarkSlateGray;
            if (nonAktif != null) nonAktif.BackColor = Color.SlateGray;
        }

        private void SetStatusPembayaran(string status, Button aktif, Button nonAktif)
        {
            _pilihanStatus = status;
            if (aktif != null) aktif.BackColor = Color.DarkSlateGray;
            if (nonAktif != null) nonAktif.BackColor = Color.SlateGray;
        }

        private void btnCetakNota_Click(object? sender, EventArgs e)
        {
            // 1. Validasi awal
            if (_keranjangBelanja.Count == 0)
            {
                MessageBox.Show("Daftar pesanan kasir masih kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string namaPemesan = tbAtasNama != null ? tbAtasNama.Text.Trim() : "Umum";

            if (string.IsNullOrWhiteSpace(namaPemesan))
            {
                MessageBox.Show("Nama pelanggan wajib diisi!", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (tbAtasNama != null) tbAtasNama.Focus();
                return;
            }

            double totalBelanja = _keranjangBelanja.Sum(item => item.sub_total);
            double uangDibayar = totalBelanja;
            if (tbUangDiterima != null && double.TryParse(tbUangDiterima.Text, out double inputCash))
            {
                uangDibayar = inputCash;
            }

            if (uangDibayar < totalBelanja)
            {
                MessageBox.Show("Uang pembayaran kurang!", "Transaksi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double kembalian = uangDibayar - totalBelanja;

            // 2. Simpan ke Database
            bool statusSimpanDb;
            try
            {
                statusSimpanDb = _transaksiController.KirimPesanan(namaPemesan, _keranjangBelanja, _pilihanStatus);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Debug Error");
                return;
            }

            // 3. Tampilkan Nota (Hanya sekali saja!)
            if (statusSimpanDb)
            {
                FormCetakNota notaForm = new FormCetakNota();

                // Kirim semua data termasuk namaPemesan
                notaForm.TampilkanDataNotaBaru(_keranjangBelanja, totalBelanja, kembalian, _pilihanMetode, namaPemesan, DateTime.Now.ToString("yyyyMMddHHmmss"),_pilihanStatus);

                notaForm.ShowDialog();

                // 4. Reset form setelah nota ditutup
                _keranjangBelanja.Clear();
                if (tbAtasNama != null) tbAtasNama.Text = "";
                if (tbUangDiterima != null) tbUangDiterima.Text = "";

                RenderListPanelKanan();
                MuatKatalogProduk("");
            }
            else
            {
                MessageBox.Show("Gagal menyimpan transaksi ke database.", "Gagal");
            }
        }
        private void tbSearchProduk_TextChanged(object? sender, EventArgs e)
        {
            if (tbSearchProduk == null) return;
            string keyword = tbSearchProduk.Text;
            if (keyword != "Cari produk di sini..." && keyword != "Cari Produk...") MuatKatalogProduk(keyword);
        }

        private void AturKomponenOtomatis()
        {
            if (tbSearchProduk != null)
            {
                tbSearchProduk.Text = "Cari Produk...";
                tbSearchProduk.ForeColor = Color.Gray;
                tbSearchProduk.Enter += (s, e) => { if (s is TextBox txt && txt.Text == "Cari Produk...") { txt.Text = ""; txt.ForeColor = Color.Black; } };
                tbSearchProduk.Leave += (s, e) => { if (s is TextBox txt && string.IsNullOrWhiteSpace(txt.Text)) { txt.Text = "Cari Produk..."; txt.ForeColor = Color.Gray; MuatKatalogProduk(""); } };
            }
            if (flpDaftarPesanan != null) { flpDaftarPesanan.FlowDirection = FlowDirection.TopDown; flpDaftarPesanan.WrapContents = false; }
        }
    }
}