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
        // 1. Inisialisasi ProdukController sesuai aturan MVC
        private readonly ProdukController _produkController = new ProdukController();

        // LIST UNTUK KERANJANG BELANJA (Menampung barang sementara di RAM Kasir)
        private List<ItemKeranjang> _keranjangBelanja = new List<ItemKeranjang>();

        // Array pembantu komponen desainer katalog kiri kamu
        private Panel[] _arrayPanelMenu;
        private Label[] _arrayLabelNama;
        private Label[] _arrayLabelHarga;
        private Label[] _arrayLabelStok;
        private Button[] _arrayButtonPlus;

        public UCPilihproduk()
        {
            InitializeComponent();

            // Mengikat event Load & Pencarian secara aman lewat kode
            this.Load += new System.EventHandler(this.UCPilihproduk_Load);
            this.tbSearchProduk.TextChanged += new System.EventHandler(this.tbSearchProduk_TextChanged);
        }

        private void UCPilihproduk_Load(object sender, EventArgs e)
        {
            // Kelompokkan 6 kotak komponen desainer visual ke dalam array OOP
            InisialisasiArrayKomponen();

            // Atur kosmetik awal untuk komponen pendukung
            AturKomponenOtomatis();

            // Memuat data produk pertama kali dari database ke 6 kotak katalog kiri
            MuatKatalogProduk("");

            // Reset tampilan list kanan di awal running
            RenderListPanelKanan();
        }

        private void InisialisasiArrayKomponen()
        {
            _arrayPanelMenu = new Panel[] { pnlMenu1, pnlMenu2, pnlMenu3, pnlMenu4, pnlMenu5, pnlMenu6 };
            _arrayLabelNama = new Label[] { lblMenu1, lblMenu2, lblMenu3, lblMenu4, lblMenu5, lblMenu6 };
            _arrayLabelHarga = new Label[] { lblHargaMenu1, lblHargaMenu2, lblHargaMenu3, lblHargaMenu4, lblHargaMenu5, lblHargaMenu6 };
            _arrayLabelStok = new Label[] { lblAngkaStok, lblAngkaStok2, lblAngkaStok3, lblAngkaStok4, lblAngkaStok5, lblAngkaStok6 };
            _arrayButtonPlus = new Button[] { btnMenu1, btnMenu2, btnMenu3, btnMenu4, btnMenu5, btnMenu6 };

            // Mengikat event klik tombol plus (+) desainer katalog kiri secara massal
            for (int i = 0; i < _arrayButtonPlus.Length; i++)
            {
                _arrayButtonPlus[i].Click += TombolPlusKatalog_Click;
            }
        }

        private void MuatKatalogProduk(string keyword)
        {
            List<Produk> listProduk = string.IsNullOrWhiteSpace(keyword) || keyword == "Cari produk di sini..." || keyword == "Cari Produk..."
                ? _produkController.AmbilSemuaProduk()
                : _produkController.CariProduk(keyword);

            for (int i = 0; i < _arrayPanelMenu.Length; i++)
            {
                if (i < listProduk.Count)
                {
                    Produk prod = listProduk[i];

                    _arrayLabelNama[i].Text = prod.jenis_produk;
                    _arrayLabelHarga[i].Text = $"Rp {prod.harga:N0}";
                    _arrayLabelStok[i].Text = prod.stok.ToString();

                    _arrayButtonPlus[i].Tag = prod;
                    _arrayPanelMenu[i].Visible = true;
                }
                else
                {
                    _arrayPanelMenu[i].Visible = false;
                    _arrayButtonPlus[i].Tag = null;
                }
            }
        }

        /// <summary>
        /// EVENT KLIK TAMBAH BARANG DI KATALOG KIRI
        /// </summary>
        private void TombolPlusKatalog_Click(object sender, EventArgs e)
        {
            Button btnPlus = (Button)sender;
            if (btnPlus.Tag == null) return;

            Produk prod = (Produk)btnPlus.Tag;

            if (prod.stok <= 0)
            {
                MessageBox.Show($"Stok untuk '{prod.jenis_produk}' sudah habis!", "Stok Kosong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ItemKeranjang itemAda = _keranjangBelanja.FirstOrDefault(k => k.id_produk == prod.id_produk);

            if (itemAda != null)
            {
                if (itemAda.quantity >= prod.stok)
                {
                    MessageBox.Show($"Jumlah beli tidak boleh melebihi sisa stok toko ({prod.stok})!", "Batas Stok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                itemAda.quantity++;
            }
            else
            {
                _keranjangBelanja.Add(new ItemKeranjang
                {
                    id_produk = prod.id_produk,
                    nama_produk = prod.jenis_produk,
                    harga = prod.harga,
                    quantity = 1
                });
            }

            // Segarkan list di panel kanan
            RenderListPanelKanan();
        }

        /// <summary>
        /// 🌟 LOGIKA UTAMA: Memasukkan UCItemKeranjang ke dalam flowLayoutPanel1 secara dinamis
        /// </summary>
        private void RenderListPanelKanan()
        {
            // 1. Bersihkan isi lama agar item tidak menumpuk duplikat saat ada perubahan data
            flpDaftarPesanan.Controls.Clear();

            // 2. Tetap masukkan label header "Daftar Pesanan Pelanggan" ke baris paling atas panel
            flpDaftarPesanan.Controls.Add(lblDaftarPesanan);

            double grandTotal = 0;

            // 3. Looping untuk membuat dan memasukkan komponen cetakan kecil kamu ke panel kanan
            foreach (ItemKeranjang item in _keranjangBelanja)
            {
                // ✅ SINKRONISASI 1: Panggil constructor kosong bawaan desainer UC yang baru
                UCItemKeranjang cardItem = new UCItemKeranjang();

                // ✅ SINKRONISASI 2: Suapi data model ItemKeranjang lewat fungsi SetData
                cardItem.SetData(item);

                // ✅ SINKRONISASI 3: Mengikat Custom Event Action penambah/pengurang kuantitas porsi menu
                cardItem.OnKuantitasBerubah += (itemTerupdate) => HitungUlangTotalBelanja();

                // ✅ SINKRONISASI 4: Mengikat Custom Event Action tombol silang (x) hapus baris
                cardItem.OnHapusItemKlik += (itemDihapus) =>
                {
                    _keranjangBelanja.Remove(itemDihapus); // hapus dari list temporary RAM kasir
                    RenderListPanelKanan();                // gambar ulang seluruh isi panel kanan secara real-time
                };

                // 4. PERINTAH UTAMA: Memasukkan fisik card ke dalam FlowLayoutPanel kanan desainer kamu
                flpDaftarPesanan.Controls.Add(cardItem);

                grandTotal += item.sub_total;
            }

            // Jalankan fungsi hitung total untuk memperbarui label nominal di layout kasir kamu
            HitungUlangTotalBelanja();
        }

        private void HitungUlangTotalBelanja()
        {
            double total = _keranjangBelanja.Sum(item => item.sub_total);

            // 🌟 SINKRONISASI OPTIONAL: Jika desainer kasirmu punya label grand total (misal lblAngkaTotal),
            // hilangkan tanda komentar '//' di bawah ini dan samakan namanya agar kasir bisa melihat total nota
            // lblAngkaTotal.Text = $"Rp {total:N0}";
        }

        private void tbSearchProduk_TextChanged(object sender, EventArgs e)
        {
            if (tbSearchProduk.Text != "Cari produk di sini..." && tbSearchProduk.Text != "Cari Produk...")
            {
                MuatKatalogProduk(tbSearchProduk.Text);
            }
        }

        private void AturKomponenOtomatis()
        {
            tbSearchProduk.Text = "Cari Produk...";
            tbSearchProduk.ForeColor = Color.Gray;
            tbSearchProduk.Enter += TextBox1_Enter;
            tbSearchProduk.Leave += TextBox1_Leave;

            // Mengatur arah aliran item agar lurus rapi ke bawah (TopDown)
            flpDaftarPesanan.FlowDirection = FlowDirection.TopDown;
            flpDaftarPesanan.WrapContents = false;
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            if (tbSearchProduk.Text == "Cari produk di sini..." || tbSearchProduk.Text == "Cari Produk...")
            {
                tbSearchProduk.Text = "";
                tbSearchProduk.ForeColor = Color.Black;
            }
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSearchProduk.Text))
            {
                tbSearchProduk.Text = "Cari Produk...";
                tbSearchProduk.ForeColor = Color.Gray;
                MuatKatalogProduk("");
            }
        }
    }
}