using System;
using System.Collections.Generic;
using System.Text;

namespace CFMART.Models.Context
{
    public class DataProdukCari
    {
        public string Nama { get; set; }
        public int Harga { get; set; }
        public Image Gambar { get; set; }
    }

    public class PanelHasilCari : UserControl
    {
        private Label lblJudul;
        private Button btnClose;
        private FlowLayoutPanel panelList;
        public event Action<string, int> OnTambahKeranjangKlik;
        public event Action OnCloseKlik;

        public PanelHasilCari()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Size = new Size(500, 350);
            this.BackColor = Color.FromArgb(40, 50, 65); // Warna tema gelap
            this.BorderStyle = BorderStyle.FixedSingle;

            // Header Judul Panel
            lblJudul = new Label();
            lblJudul.Text = "Hasil Pencarian:";
            lblJudul.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblJudul.ForeColor = Color.White;
            lblJudul.Location = new Point(15, 12);
            lblJudul.AutoSize = true;

            // Tombol Close (X)
            btnClose = new Button();
            btnClose.Text = "X";
            btnClose.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.BackColor = Color.FromArgb(60, 70, 85);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Size = new Size(30, 30);
            btnClose.Location = new Point(455, 8);
            btnClose.Click += (s, e) => OnCloseKlik?.Invoke();

            // Kontainer List Makanan (Bisa di-scroll kalau banyak)
            panelList = new FlowLayoutPanel();
            panelList.Location = new Point(15, 50);
            panelList.Size = new Size(470, 280);
            panelList.AutoScroll = true;
            panelList.FlowDirection = FlowDirection.TopDown;
            panelList.WrapContents = false;

            this.Controls.Add(lblJudul);
            this.Controls.Add(btnClose);
            this.Controls.Add(panelList);
        }

        public void SetJudul(string keyword)
        {
            lblJudul.Text = $"Hasil Pencarian: \"{keyword}\"";
        }

        public void TampilkanHasil(List<DataProdukCari> listProduk)
        {
            panelList.Controls.Clear();

            foreach (var prod in listProduk)
            {
                // Kontainer per Baris Item
                Panel row = new Panel();
                row.Size = new Size(440, 90);
                row.BackColor = Color.FromArgb(48, 58, 75);
                row.Margin = new Padding(0, 0, 0, 8);

                // Gambar Produk
                PictureBox pb = new PictureBox();
                pb.Size = new Size(100, 74);
                pb.Location = new Point(8, 8);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Image = prod.Gambar;

                // Nama Produk
                Label lblNama = new Label();
                lblNama.Text = prod.Nama;
                lblNama.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                lblNama.ForeColor = Color.White;
                lblNama.Location = new Point(115, 12);
                lblNama.Size = new Size(180, 20);

                // Harga Produk
                Label lblHarga = new Label();
                lblHarga.Text = $"Rp. {prod.Harga:N0}";
                lblHarga.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                lblHarga.ForeColor = Color.LightGray;
                lblHarga.Location = new Point(115, 38);
                lblHarga.Size = new Size(100, 20);

                // Tombol Beli / Masukkan Keranjang
                Button btnBeli = new Button();
                btnBeli.Text = "Masukkan ke Keranjang";
                btnBeli.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                btnBeli.ForeColor = Color.White;
                btnBeli.BackColor = Color.FromArgb(70, 80, 95);
                btnBeli.FlatStyle = FlatStyle.Flat;
                btnBeli.Size = new Size(130, 30);
                btnBeli.Location = new Point(295, 30);
                btnBeli.Click += (s, e) => OnTambahKeranjangKlik?.Invoke(prod.Nama, prod.Harga);

                row.Controls.Add(pb);
                row.Controls.Add(lblNama);
                row.Controls.Add(lblHarga);
                row.Controls.Add(btnBeli);

                panelList.Controls.Add(row);
            }
        }
    }
}
