using CFMART.Controllers;
using CFMART.Models; // 🌟 Memanggil model ItemKeranjang yang baru
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CFMART.Views.Kasir
{
    public partial class UCItemKeranjang : UserControl
    {
        // Menyimpan data model internal untuk baris item ini
        private readonly ProdukController _produkController = new ProdukController();
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
        public event Action OnDataPerluRefresh;
        private void BtnTambahItem_Click(object sender, EventArgs e)
        {
            if (_itemData == null) return;

            // Cek stok di database sebelum tambah
            if (_produkController.KurangiStok(_itemData.id_produk, 1))
            {
                _itemData.quantity += 1;
                lblQuantity.Text = _itemData.quantity.ToString();
                lblHargaItem.Text = "Rp " + _itemData.sub_total.ToString("N0");
                OnKuantitasBerubah?.Invoke(_itemData);
                OnDataPerluRefresh?.Invoke();
            }
            else { MessageBox.Show("Stok tidak cukup!"); }
        }

        // =========================================================================
        // ➖ TOMBOL KURANGI QUANTITY (btnMinusItem)
        // =========================================================================
        private void BtnMinusItem_Click(object sender, EventArgs e)
        {
            if (_itemData == null) return;

            if (_itemData.quantity > 1)
            {
                _produkController.TambahStok(_itemData.id_produk, 1); // Kembalikan stok
                _itemData.quantity -= 1;
                lblQuantity.Text = _itemData.quantity.ToString();
                lblHargaItem.Text = "Rp " + _itemData.sub_total.ToString("N0");
                OnKuantitasBerubah?.Invoke(_itemData);
                OnDataPerluRefresh?.Invoke();
            }
            else { BtnHapusItem_Click(sender, e); }
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


        private void lblCatatanItem_Click(object sender, EventArgs e)
        {

        }
    }
}