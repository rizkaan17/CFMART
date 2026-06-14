using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CFMART.Models.Context
{
    // ENCAPSULATION: Membungkus data produk ke dalam class untuk menjaga integritas data.
    public class DataProdukCari
    {
        public string Nama { get; set; } = "Produk";
        public int Harga { get; set; }
        // Memberikan nilai default null agar tidak error saat diakses
        public Image? Gambar { get; set; } 
    }

    public class PanelHasilCari : UserControl
    {
        private Label lblJudul;
        private Button btnClose;
        private FlowLayoutPanel panelList;

        // ABSTRAKSI: UserControl ini menyembunyikan detail UI. 
        // Form luar cukup tahu event-nya saja, tidak perlu tahu cara membuat tombol/label.
        public event Action<string, int> OnTambahKeranjangKlik;
        public event Action OnCloseKlik;

        public PanelHasilCari()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Size = new Size(500, 350);
            this.BackColor = Color.FromArgb(40, 50, 65);
            this.BorderStyle = BorderStyle.FixedSingle;

            lblJudul = new Label { Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 12), AutoSize = true };
            
            btnClose = new Button { Text = "X", Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.White, BackColor = Color.FromArgb(60, 70, 85), FlatStyle = FlatStyle.Flat, Size = new Size(30, 30), Location = new Point(455, 8) };
            btnClose.Click += (s, e) => OnCloseKlik?.Invoke();

            panelList = new FlowLayoutPanel { Location = new Point(15, 50), Size = new Size(470, 280), AutoScroll = true, FlowDirection = FlowDirection.TopDown, WrapContents = false };

            this.Controls.Add(lblJudul);
            this.Controls.Add(btnClose);
            this.Controls.Add(panelList);
        }

        public void SetJudul(string keyword) => lblJudul.Text = $"Hasil Pencarian: \"{keyword}\"";

        // POLYMORPHISM/DYNAMIC RENDERING: 
        // Menggunakan perulangan untuk membuat komponen UI secara dinamis berdasarkan list produk.
        public void TampilkanHasil(List<DataProdukCari> listProduk)
        {
            panelList.Controls.Clear();

            foreach (var prod in listProduk)
            {
                Panel row = new Panel { Size = new Size(440, 90), BackColor = Color.FromArgb(48, 58, 75), Margin = new Padding(0, 0, 0, 8) };

                // Menggunakan Image jika ada, jika tidak kosongkan
                PictureBox pb = new PictureBox { Size = new Size(100, 74), Location = new Point(8, 8), SizeMode = PictureBoxSizeMode.StretchImage, Image = prod.Gambar };

                Label lblNama = new Label { Text = prod.Nama, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.White, Location = new Point(115, 12), Size = new Size(180, 20) };
                Label lblHarga = new Label { Text = $"Rp. {prod.Harga:N0}", Font = new Font("Segoe UI", 9, FontStyle.Regular), ForeColor = Color.LightGray, Location = new Point(115, 38), Size = new Size(100, 20) };

                Button btnBeli = new Button { Text = "Masukkan ke Keranjang", Font = new Font("Segoe UI", 8, FontStyle.Bold), ForeColor = Color.White, BackColor = Color.FromArgb(70, 80, 95), FlatStyle = FlatStyle.Flat, Size = new Size(130, 30), Location = new Point(295, 30) };
                
                // Event handling untuk menambah ke keranjang
                btnBeli.Click += (s, e) => OnTambahKeranjangKlik?.Invoke(prod.Nama, prod.Harga);

                row.Controls.AddRange(new Control[] { pb, lblNama, lblHarga, btnBeli });
                panelList.Controls.Add(row);
            }
        }
    }
}
