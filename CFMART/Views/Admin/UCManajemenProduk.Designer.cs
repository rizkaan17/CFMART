namespace CFMART.Views.Admin
{
    partial class UCManajemenProduk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCManajemenProduk));
            btnTambahProduk = new Button();
            pnlTambahProduk = new Panel();
            btnBatal2 = new Button();
            btnSimpan2 = new Button();
            lblStok = new Label();
            lblHarga = new Label();
            lblNamaProduk = new Label();
            tbStok = new TextBox();
            tbHarga = new TextBox();
            tbNamaProduk = new TextBox();
            lblTambahProduk = new Label();
            lblManajemenProduk = new Label();
            dgvManajemenProduk = new DataGridView();
            pnlTambahProduk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvManajemenProduk).BeginInit();
            SuspendLayout();
            // 
            // btnTambahProduk
            // 
            btnTambahProduk.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnTambahProduk.BackColor = Color.LightSlateGray;
            btnTambahProduk.FlatStyle = FlatStyle.Popup;
            btnTambahProduk.Font = new Font("Dubai", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTambahProduk.ForeColor = Color.White;
            btnTambahProduk.Location = new Point(1387, 61);
            btnTambahProduk.Name = "btnTambahProduk";
            btnTambahProduk.Size = new Size(320, 55);
            btnTambahProduk.TabIndex = 4;
            btnTambahProduk.Text = "+ Tambah Produk";
            btnTambahProduk.UseVisualStyleBackColor = false;
            // 
            // pnlTambahProduk
            // 
            pnlTambahProduk.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTambahProduk.BackColor = Color.LightSlateGray;
            pnlTambahProduk.Controls.Add(btnBatal2);
            pnlTambahProduk.Controls.Add(btnSimpan2);
            pnlTambahProduk.Controls.Add(lblStok);
            pnlTambahProduk.Controls.Add(lblHarga);
            pnlTambahProduk.Controls.Add(lblNamaProduk);
            pnlTambahProduk.Controls.Add(tbStok);
            pnlTambahProduk.Controls.Add(tbHarga);
            pnlTambahProduk.Controls.Add(tbNamaProduk);
            pnlTambahProduk.Controls.Add(lblTambahProduk);
            pnlTambahProduk.Location = new Point(470, 146);
            pnlTambahProduk.Name = "pnlTambahProduk";
            pnlTambahProduk.Size = new Size(1237, 403);
            pnlTambahProduk.TabIndex = 6;
            // 
            // btnBatal2
            // 
            btnBatal2.BackColor = Color.Firebrick;
            btnBatal2.FlatStyle = FlatStyle.Popup;
            btnBatal2.Font = new Font("Dubai", 10.124999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBatal2.ForeColor = Color.White;
            btnBatal2.Location = new Point(853, 313);
            btnBatal2.Name = "btnBatal2";
            btnBatal2.Size = new Size(130, 67);
            btnBatal2.TabIndex = 14;
            btnBatal2.Text = "Batal";
            btnBatal2.UseVisualStyleBackColor = false;
            // 
            // btnSimpan2
            // 
            btnSimpan2.BackColor = Color.SeaGreen;
            btnSimpan2.FlatStyle = FlatStyle.Popup;
            btnSimpan2.Font = new Font("Dubai", 10.124999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSimpan2.ForeColor = Color.White;
            btnSimpan2.Location = new Point(998, 313);
            btnSimpan2.Name = "btnSimpan2";
            btnSimpan2.Size = new Size(221, 67);
            btnSimpan2.TabIndex = 13;
            btnSimpan2.Text = "Simpan Produk";
            btnSimpan2.UseVisualStyleBackColor = false;
            btnSimpan2.Click += btnSimpan2_Click;
            // 
            // lblStok
            // 
            lblStok.AutoSize = true;
            lblStok.BackColor = Color.Transparent;
            lblStok.Font = new Font("Dubai", 10.124999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStok.ForeColor = Color.White;
            lblStok.Location = new Point(666, 90);
            lblStok.Name = "lblStok";
            lblStok.Size = new Size(71, 45);
            lblStok.TabIndex = 12;
            lblStok.Text = "Stok";
            // 
            // lblHarga
            // 
            lblHarga.AutoSize = true;
            lblHarga.BackColor = Color.Transparent;
            lblHarga.Font = new Font("Dubai", 10.124999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHarga.ForeColor = Color.White;
            lblHarga.Location = new Point(29, 240);
            lblHarga.Name = "lblHarga";
            lblHarga.Size = new Size(144, 45);
            lblHarga.TabIndex = 10;
            lblHarga.Text = "Harga (Rp)";
            // 
            // lblNamaProduk
            // 
            lblNamaProduk.AutoSize = true;
            lblNamaProduk.BackColor = Color.Transparent;
            lblNamaProduk.Font = new Font("Dubai", 10.124999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNamaProduk.ForeColor = Color.White;
            lblNamaProduk.Location = new Point(29, 90);
            lblNamaProduk.Name = "lblNamaProduk";
            lblNamaProduk.Size = new Size(171, 45);
            lblNamaProduk.TabIndex = 9;
            lblNamaProduk.Text = "Nama Produk";
            // 
            // tbStok
            // 
            tbStok.BackColor = Color.White;
            tbStok.Location = new Point(666, 138);
            tbStok.Name = "tbStok";
            tbStok.Size = new Size(512, 39);
            tbStok.TabIndex = 8;
            // 
            // tbHarga
            // 
            tbHarga.BackColor = Color.White;
            tbHarga.Location = new Point(29, 288);
            tbHarga.Name = "tbHarga";
            tbHarga.Size = new Size(512, 39);
            tbHarga.TabIndex = 6;
            // 
            // tbNamaProduk
            // 
            tbNamaProduk.BackColor = Color.White;
            tbNamaProduk.Location = new Point(29, 138);
            tbNamaProduk.Name = "tbNamaProduk";
            tbNamaProduk.Size = new Size(512, 39);
            tbNamaProduk.TabIndex = 5;
            // 
            // lblTambahProduk
            // 
            lblTambahProduk.AutoSize = true;
            lblTambahProduk.BackColor = Color.Transparent;
            lblTambahProduk.Font = new Font("Dubai", 10.124999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTambahProduk.ForeColor = Color.Silver;
            lblTambahProduk.Location = new Point(29, 14);
            lblTambahProduk.Name = "lblTambahProduk";
            lblTambahProduk.Size = new Size(254, 45);
            lblTambahProduk.TabIndex = 4;
            lblTambahProduk.Text = "Tambah/Edit Produk";
            // 
            // lblManajemenProduk
            // 
            lblManajemenProduk.AutoSize = true;
            lblManajemenProduk.BackColor = Color.Transparent;
            lblManajemenProduk.Font = new Font("Dubai", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblManajemenProduk.ForeColor = Color.White;
            lblManajemenProduk.Location = new Point(457, 43);
            lblManajemenProduk.Name = "lblManajemenProduk";
            lblManajemenProduk.Size = new Size(386, 73);
            lblManajemenProduk.TabIndex = 5;
            lblManajemenProduk.Text = "Manajemen Produk";
            // 
            // dgvManajemenProduk
            // 
            dgvManajemenProduk.AllowUserToAddRows = false;
            dgvManajemenProduk.AllowUserToDeleteRows = false;
            dgvManajemenProduk.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvManajemenProduk.BackgroundColor = Color.LightSlateGray;
            dgvManajemenProduk.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvManajemenProduk.Location = new Point(470, 568);
            dgvManajemenProduk.Name = "dgvManajemenProduk";
            dgvManajemenProduk.ReadOnly = true;
            dgvManajemenProduk.RowHeadersWidth = 82;
            dgvManajemenProduk.Size = new Size(1237, 488);
            dgvManajemenProduk.TabIndex = 7;
            // 
            // UCManajemenProduk
            // 
            AutoScaleDimensions = new SizeF(192F, 192F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(dgvManajemenProduk);
            Controls.Add(btnTambahProduk);
            Controls.Add(pnlTambahProduk);
            Controls.Add(lblManajemenProduk);
            Name = "UCManajemenProduk";
            Size = new Size(2165, 1085);
            pnlTambahProduk.ResumeLayout(false);
            pnlTambahProduk.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvManajemenProduk).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTambahProduk;
        private Panel pnlTambahProduk;
        private Button btnBatal2;
        private Button btnSimpan2;
        private Label lblStok;
        private Label lblHarga;
        private Label lblNamaProduk;
        private TextBox tbStok;
        private TextBox tbHarga;
        private TextBox tbNamaProduk;
        private Label lblTambahProduk;
        private Label lblManajemenProduk;
        private DataGridView dgvManajemenProduk;
    }
}
