using CFMART.Controllers;
using CFMART.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CFMART.Views.Kasir
{
    public partial class UCPilihproduk : UserControl
    {
        // 1. Inisialisasi Kontroler dan Data Global
        private readonly ProdukController _produkController = new ProdukController();
        private List<ItemKeranjang> _keranjangBelanja = new List<ItemKeranjang>();

        // 2. Variabel State
        private string _pilihanMetode = "Tunai";
        private string _pilihanStatus = "Lunas";

        // 3. Array untuk mapping UI (PENTING: Pastikan nama di Designer sama)
        private Panel[] _arrayPanelMenu;
        private Label[] _arrayLabelNama, _arrayLabelHarga, _arrayLabelStok;
        private Button[] _arrayButtonPlus;

        public UCPilihproduk()
        {
            InitializeComponent();

            // Inisialisasi Komponen UI
            InisialisasiArrayKomponen();
            AturKomponenOtomatis();

            // Bind Event
            btnCetakNota.Click += btnCetakNota_Click;
            btnTunai.Click += (s, e) => SetMetodePembayaran("Tunai", btnTunai, btnQris);
            btnQris.Click += (s, e) => SetMetodePembayaran("QRIS", btnQris, btnTunai);
            btnLunas.Click += (s, e) => SetStatusPembayaran("Lunas", btnLunas, btnBlmLunas);
            btnBlmLunas.Click += (s, e) => SetStatusPembayaran("Belum Lunas", btnBlmLunas, btnLunas);

            // Paksa Load saat objek dibuat
            this.Load += (s, e) => {
                MuatKatalogProduk("");
                RenderListPanelKanan();
            };
        }

        private void InisialisasiArrayKomponen()
        {
            _arrayPanelMenu = new Panel[] { pnlMenu1, pnlMenu2, pnlMenu3, pnlMenu4, pnlMenu5, pnlMenu6 };
            _arrayLabelNama = new Label[] { lblMenu1, lblMenu2, lblMenu3, lblMenu4, lblMenu5, lblMenu6 };
            _arrayLabelHarga = new Label[] { lblHargaMenu1, lblHargaMenu2, lblHargaMenu3, lblHargaMenu4, lblHargaMenu5, lblHargaMenu6 };
            _arrayLabelStok = new Label[] { lblAngkaStok, lblAngkaStok2, lblAngkaStok3, lblAngkaStok4, lblAngkaStok5, lblAngkaStok6 };
            _arrayButtonPlus = new Button[] { btnMenu1, btnMenu2, btnMenu3, btnMenu4, btnMenu5, btnMenu6 };

            foreach (var btn in _arrayButtonPlus) btn.Click += TombolPlusKatalog_Click;
        }

        private void MuatKatalogProduk(string keyword)
        {
            try
            {
                var listProduk = _produkController.AmbilSemuaProduk();

                if (listProduk == null || listProduk.Count == 0)
                {
                    // Jika ini muncul, berarti database kosong atau query salah
                    return;
                }

                for (int i = 0; i < _arrayPanelMenu.Length; i++)
                {
                    if (i < listProduk.Count)
                    {
                        _arrayPanelMenu[i].Visible = true;
                        _arrayLabelNama[i].Text = listProduk[i].jenis_produk;
                        _arrayLabelHarga[i].Text = $"Rp {listProduk[i].harga:N0}";
                        _arrayLabelStok[i].Text = listProduk[i].stok.ToString();
                        _arrayButtonPlus[i].Tag = listProduk[i];
                    }
                    else { _arrayPanelMenu[i].Visible = false; }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
        }

        private void TombolPlusKatalog_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var prod = (Produk)btn.Tag;
            if (prod == null) return;

            var item = _keranjangBelanja.FirstOrDefault(k => k.id_produk == prod.id_produk);
            if (item == null)
            {
                _keranjangBelanja.Add(new ItemKeranjang
                {
                    id_produk = prod.id_produk,
                    nama_produk = prod.jenis_produk,
                    harga = prod.harga,
                    quantity = 1
                });
            }
            else if (item.quantity < prod.stok)
            {
                item.quantity++;
            }
            else { MessageBox.Show("Stok tidak mencukupi!"); }

            RenderListPanelKanan();
        }

        private void RenderListPanelKanan()
        {
            flpDaftarPesanan.Controls.Clear();
            foreach (var item in _keranjangBelanja)
            {
                var card = new UCItemKeranjang();
                card.SetData(item);
                card.OnHapusItemKlik += (x) => { _keranjangBelanja.Remove(x); RenderListPanelKanan(); };
                flpDaftarPesanan.Controls.Add(card);
            }
            lblTotal.Text = $"Rp {_keranjangBelanja.Sum(i => i.sub_total):N0}";
        }

        private void btnCetakNota_Click(object sender, EventArgs e)
        {
            if (_keranjangBelanja.Count == 0) return;
            OrderController oc = new OrderController();

            if (oc.KirimPesanan("Kasir", _keranjangBelanja))
            {
                FormCetakNota nota = new FormCetakNota();
                nota.TampilkanDataNotaBaru(_keranjangBelanja, _keranjangBelanja.Sum(i => i.sub_total), 0, _pilihanMetode, _pilihanStatus, "Kasir CFMART");
                nota.ShowDialog();
                _keranjangBelanja.Clear();
                RenderListPanelKanan();
                MuatKatalogProduk("");
            }
            else MessageBox.Show("Gagal simpan ke database!");
        }

        private void SetMetodePembayaran(string m, Button a, Button n) { _pilihanMetode = m; a.BackColor = Color.DarkSlateGray; n.BackColor = Color.SlateGray; }
        private void SetStatusPembayaran(string s, Button a, Button n) { _pilihanStatus = s; a.BackColor = Color.DarkSlateGray; n.BackColor = Color.SlateGray; }
        private void AturKomponenOtomatis() { flpDaftarPesanan.FlowDirection = FlowDirection.TopDown; flpDaftarPesanan.WrapContents = false; }
    }
}