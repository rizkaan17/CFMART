namespace CFMART.Views.Kasir
{
    partial class UCRingkasan
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCRingkasan));
            dgvPesananTerbaru = new DataGridView();
            lblPesananTerbaru = new Label();
            pnlKaryawanAktif = new Panel();
            pbOrang = new PictureBox();
            lblProdukTerlaris = new Label();
            lblTerlaris = new Label();
            pnlPendapatan = new Panel();
            pbDolar = new PictureBox();
            lblPendapatan = new Label();
            lblAngkaPendapatan = new Label();
            pnlTotalPesanan = new Panel();
            pbTas = new PictureBox();
            lblTotalPesanan = new Label();
            lblTransaksi = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPesananTerbaru).BeginInit();
            pnlKaryawanAktif.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbOrang).BeginInit();
            pnlPendapatan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbDolar).BeginInit();
            pnlTotalPesanan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbTas).BeginInit();
            SuspendLayout();
            // 
            // dgvPesananTerbaru
            // 
            dgvPesananTerbaru.AllowUserToAddRows = false;
            dgvPesananTerbaru.AllowUserToDeleteRows = false;
            dgvPesananTerbaru.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPesananTerbaru.BackgroundColor = Color.LightSlateGray;
            dgvPesananTerbaru.BorderStyle = BorderStyle.None;
            dgvPesananTerbaru.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPesananTerbaru.Location = new Point(130, 669);
            dgvPesananTerbaru.Name = "dgvPesananTerbaru";
            dgvPesananTerbaru.ReadOnly = true;
            dgvPesananTerbaru.RowHeadersWidth = 82;
            dgvPesananTerbaru.Size = new Size(1911, 358);
            dgvPesananTerbaru.TabIndex = 13;
            // 
            // lblPesananTerbaru
            // 
            lblPesananTerbaru.AutoSize = true;
            lblPesananTerbaru.BackColor = Color.Transparent;
            lblPesananTerbaru.Font = new Font("Dubai", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPesananTerbaru.ForeColor = Color.White;
            lblPesananTerbaru.Location = new Point(140, 562);
            lblPesananTerbaru.Name = "lblPesananTerbaru";
            lblPesananTerbaru.Size = new Size(365, 73);
            lblPesananTerbaru.TabIndex = 12;
            lblPesananTerbaru.Text = "Riwayat Transaksi";
            // 
            // pnlKaryawanAktif
            // 
            pnlKaryawanAktif.Anchor = AnchorStyles.Top;
            pnlKaryawanAktif.BackColor = Color.LightSlateGray;
            pnlKaryawanAktif.Controls.Add(pbOrang);
            pnlKaryawanAktif.Controls.Add(lblProdukTerlaris);
            pnlKaryawanAktif.Controls.Add(lblTerlaris);
            pnlKaryawanAktif.Location = new Point(1372, 98);
            pnlKaryawanAktif.Name = "pnlKaryawanAktif";
            pnlKaryawanAktif.Size = new Size(331, 433);
            pnlKaryawanAktif.TabIndex = 11;
            // 
            // pbOrang
            // 
            pbOrang.BackColor = Color.LightSalmon;
            pbOrang.BackgroundImage = (Image)resources.GetObject("pbOrang.BackgroundImage");
            pbOrang.BackgroundImageLayout = ImageLayout.Center;
            pbOrang.Location = new Point(42, 45);
            pbOrang.Name = "pbOrang";
            pbOrang.Size = new Size(92, 89);
            pbOrang.TabIndex = 5;
            pbOrang.TabStop = false;
            // 
            // lblProdukTerlaris
            // 
            lblProdukTerlaris.AutoSize = true;
            lblProdukTerlaris.Font = new Font("Dubai", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProdukTerlaris.ForeColor = Color.LightGray;
            lblProdukTerlaris.Location = new Point(42, 218);
            lblProdukTerlaris.Name = "lblProdukTerlaris";
            lblProdukTerlaris.Size = new Size(203, 49);
            lblProdukTerlaris.TabIndex = 2;
            lblProdukTerlaris.Text = "Produk Terlaris";
            // 
            // lblTerlaris
            // 
            lblTerlaris.AutoSize = true;
            lblTerlaris.Font = new Font("Dubai", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTerlaris.ForeColor = Color.White;
            lblTerlaris.Location = new Point(42, 137);
            lblTerlaris.Name = "lblTerlaris";
            lblTerlaris.Size = new Size(67, 90);
            lblTerlaris.TabIndex = 1;
            lblTerlaris.Text = "5";
            // 
            // pnlPendapatan
            // 
            pnlPendapatan.Anchor = AnchorStyles.Top;
            pnlPendapatan.BackColor = Color.LightSlateGray;
            pnlPendapatan.Controls.Add(pbDolar);
            pnlPendapatan.Controls.Add(lblPendapatan);
            pnlPendapatan.Controls.Add(lblAngkaPendapatan);
            pnlPendapatan.Location = new Point(949, 98);
            pnlPendapatan.Name = "pnlPendapatan";
            pnlPendapatan.Size = new Size(331, 433);
            pnlPendapatan.TabIndex = 10;
            // 
            // pbDolar
            // 
            pbDolar.BackColor = Color.Cornsilk;
            pbDolar.BackgroundImage = (Image)resources.GetObject("pbDolar.BackgroundImage");
            pbDolar.BackgroundImageLayout = ImageLayout.Center;
            pbDolar.Location = new Point(42, 45);
            pbDolar.Name = "pbDolar";
            pbDolar.Size = new Size(92, 89);
            pbDolar.TabIndex = 5;
            pbDolar.TabStop = false;
            // 
            // lblPendapatan
            // 
            lblPendapatan.AutoSize = true;
            lblPendapatan.Font = new Font("Dubai", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPendapatan.ForeColor = Color.LightGray;
            lblPendapatan.Location = new Point(42, 218);
            lblPendapatan.Name = "lblPendapatan";
            lblPendapatan.Size = new Size(258, 49);
            lblPendapatan.TabIndex = 2;
            lblPendapatan.Text = "Pendapatan Hari ini";
            // 
            // lblAngkaPendapatan
            // 
            lblAngkaPendapatan.AutoSize = true;
            lblAngkaPendapatan.Font = new Font("Dubai", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAngkaPendapatan.ForeColor = Color.White;
            lblAngkaPendapatan.Location = new Point(42, 137);
            lblAngkaPendapatan.Name = "lblAngkaPendapatan";
            lblAngkaPendapatan.Size = new Size(226, 90);
            lblAngkaPendapatan.TabIndex = 1;
            lblAngkaPendapatan.Text = "Rp 1,7 jt";
            // 
            // pnlTotalPesanan
            // 
            pnlTotalPesanan.Anchor = AnchorStyles.Top;
            pnlTotalPesanan.BackColor = Color.LightSlateGray;
            pnlTotalPesanan.Controls.Add(pbTas);
            pnlTotalPesanan.Controls.Add(lblTotalPesanan);
            pnlTotalPesanan.Controls.Add(lblTransaksi);
            pnlTotalPesanan.Location = new Point(550, 98);
            pnlTotalPesanan.Name = "pnlTotalPesanan";
            pnlTotalPesanan.Size = new Size(331, 433);
            pnlTotalPesanan.TabIndex = 9;
            // 
            // pbTas
            // 
            pbTas.BackColor = Color.LightSalmon;
            pbTas.BackgroundImage = (Image)resources.GetObject("pbTas.BackgroundImage");
            pbTas.BackgroundImageLayout = ImageLayout.Center;
            pbTas.Location = new Point(58, 45);
            pbTas.Name = "pbTas";
            pbTas.Size = new Size(92, 89);
            pbTas.TabIndex = 4;
            pbTas.TabStop = false;
            // 
            // lblTotalPesanan
            // 
            lblTotalPesanan.AutoSize = true;
            lblTotalPesanan.Font = new Font("Dubai", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalPesanan.ForeColor = Color.LightGray;
            lblTotalPesanan.Location = new Point(42, 218);
            lblTotalPesanan.Name = "lblTotalPesanan";
            lblTotalPesanan.Size = new Size(225, 49);
            lblTotalPesanan.TabIndex = 2;
            lblTotalPesanan.Text = "Transaksi hari ini";
            // 
            // lblTransaksi
            // 
            lblTransaksi.AutoSize = true;
            lblTransaksi.Font = new Font("Dubai", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTransaksi.ForeColor = Color.White;
            lblTransaksi.Location = new Point(42, 137);
            lblTransaksi.Name = "lblTransaksi";
            lblTransaksi.Size = new Size(125, 90);
            lblTransaksi.TabIndex = 1;
            lblTransaksi.Text = "142";
            lblTransaksi.Click += lblAngkaTotal_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Dubai", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(130, 15);
            label1.Name = "label1";
            label1.Size = new Size(634, 73);
            label1.TabIndex = 14;
            label1.Text = "Ringkasan penjualan dan laporan";
            // 
            // UCRingkasan
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(label1);
            Controls.Add(dgvPesananTerbaru);
            Controls.Add(lblPesananTerbaru);
            Controls.Add(pnlKaryawanAktif);
            Controls.Add(pnlPendapatan);
            Controls.Add(pnlTotalPesanan);
            Name = "UCRingkasan";
            Size = new Size(2165, 1058);
            ((System.ComponentModel.ISupportInitialize)dgvPesananTerbaru).EndInit();
            pnlKaryawanAktif.ResumeLayout(false);
            pnlKaryawanAktif.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbOrang).EndInit();
            pnlPendapatan.ResumeLayout(false);
            pnlPendapatan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbDolar).EndInit();
            pnlTotalPesanan.ResumeLayout(false);
            pnlTotalPesanan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbTas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPesananTerbaru;
        private Label lblPesananTerbaru;
        private Panel pnlKaryawanAktif;
        private PictureBox pbOrang;
        private Label lblProdukTerlaris;
        private Label lblTerlaris;
        private Panel pnlPendapatan;
        private PictureBox pbDolar;
        private Label lblPendapatan;
        private Label lblAngkaPendapatan;
        private Panel pnlTotalPesanan;
        private PictureBox pbTas;
        private Label lblTotalPesanan;
        private Label lblTransaksi;
        private Label label1;
    }
}
