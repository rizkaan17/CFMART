using System;
using System.Drawing;
using System.Windows.Forms;
using CFMART.Models; // 🌟 Memanggil model ItemKeranjang yang baru

namespace CFMART.Views.Kasir
{
    public partial class UCItemKeranjang : UserControl
    {
        // Menyimpan data model internal untuk baris item ini
        private ItemKeranjang _itemData;

        // =========================================================================
        // DELEGATE & EVENTS: Jembatan komunikasi untuk memberi tahu Form Induk Kasir
        // =========================================================================
        public event Action<ItemKeranjang> OnKuantitasBerubah;
        public event Action<ItemKeranjang> OnHapusItemKlik;

        public UCItemKeranjang()
        {
            InitializeComponent();

            // Mengikat event klik tombol desainer ke fungsi internal backend
            btnTambahItem.Click += BtnTambahItem_Click;
            btnMinusItem.Click += BtnMinusItem_Click;
            btnHapusItem.Click += BtnHapusItem_Click;
        }

        /// <summary>
        /// Fungsi utama untuk menyuapi data menu ke komponen label desainer kamu
        /// </summary>
        /// <param name="item">Objek ItemKeranjang dari RAM global</param>
        public void SetData(ItemKeranjang item)
        {
            if (item == null) return;

            // Simpan referensi data ke memori internal User Control
            _itemData = item;

            // Sinkronisasikan ke label komponen bawaan desainer kamu
            lblNamaItem.Text = _itemData.nama_produk;
            lblQuantity.Text = _itemData.quantity.ToString();

            // Menampilkan harga sub-total terformat Rupiah (N0) agar rapi di layar kasir
            lblHargaItem.Text = "Rp " + _itemData.sub_total.ToString("N0");
        }

        // =========================================================================
        // ➕ TOMBOL TAMBAH QUANTITY (btnTambahItem)
        // =========================================================================
        private void BtnTambahItem_Click(object sender, EventArgs e)
        {
            if (_itemData == null) return;

            // Naikkan kuantitas porsi menu sebesar 1
            _itemData.quantity += 1;

            // Segarkan tampilan label lokal baris ini
            lblQuantity.Text = _itemData.quantity.ToString();
            lblHargaItem.Text = "Rp " + _itemData.sub_total.ToString("N0");

            // Lempar pemberitahuan ke form induk kasir agar total akhir nota ikut meroket naik
            OnKuantitasBerubah?.Invoke(_itemData);
        }

        // =========================================================================
        // ➖ TOMBOL KURANGI QUANTITY (btnMinusItem)
        // =========================================================================
        private void BtnMinusItem_Click(object sender, EventArgs e)
        {
            if (_itemData == null) return;

            // Jika sisa porsi tinggal 1 dan diklik minus, arahkan otomatis ke fungsi hapus baris
            if (_itemData.quantity <= 1)
            {
                BtnHapusItem_Click(sender, e);
                return;
            }

            // Kurangi kuantitas porsi menu sebesar 1
            _itemData.quantity -= 1;

            // Segarkan tampilan label lokal baris ini
            lblQuantity.Text = _itemData.quantity.ToString();
            lblHargaItem.Text = "Rp " + _itemData.sub_total.ToString("N0");

            // Lempar pemberitahuan ke form induk kasir agar total akhir nota ikut menyusut turun
            OnKuantitasBerubah?.Invoke(_itemData);
        }

        // =========================================================================
        // ❌ TOMBOL HAPUS BARIS MENU (btnHapusItem)
        // =========================================================================
        private void BtnHapusItem_Click(object sender, EventArgs e)
        {
            if (_itemData == null) return;

            // Beri tahu form induk kasir untuk mendepak item ini dari FlowLayoutPanel dan list RAM global
            OnHapusItemKlik?.Invoke(_itemData);
        }
    }
}