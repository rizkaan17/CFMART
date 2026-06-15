namespace CFMART.Views.Pelanggan
{
    partial class KeranjangBelanja
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeranjangBelanja));
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            CFMART = new Label();
            btnCheckout = new Button();
            btnKeranjang = new Button();
            btnKatalog = new Button();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel2 = new Panel();
            btncekout = new Button();
            btnkrjng = new Button();
            btnktlg = new Button();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            dgvkeranjang = new DataGridView();
            lbltotalpesanan = new Label();
            btnhapus = new Button();
            btnubahpesanan = new Button();
            btnlanjutcheckout = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvkeranjang).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 100);
            panel1.TabIndex = 0;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(100, 50);
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // CFMART
            // 
            CFMART.Location = new Point(0, 0);
            CFMART.Name = "CFMART";
            CFMART.Size = new Size(100, 23);
            CFMART.TabIndex = 0;
            // 
            // btnCheckout
            // 
            btnCheckout.Location = new Point(0, 0);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(75, 23);
            btnCheckout.TabIndex = 0;
            // 
            // btnKeranjang
            // 
            btnKeranjang.Location = new Point(0, 0);
            btnKeranjang.Name = "btnKeranjang";
            btnKeranjang.Size = new Size(75, 23);
            btnKeranjang.TabIndex = 0;
            // 
            // btnKatalog
            // 
            btnKatalog.Location = new Point(0, 0);
            btnKatalog.Name = "btnKatalog";
            btnKatalog.Size = new Size(75, 23);
            btnKatalog.TabIndex = 0;
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(200, 100);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.SlateGray;
            panel2.Controls.Add(btncekout);
            panel2.Controls.Add(btnkrjng);
            panel2.Controls.Add(btnktlg);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(-3, -2);
            panel2.Name = "panel2";
            panel2.Size = new Size(2030, 79);
            panel2.TabIndex = 3;
            panel2.Paint += panel2_Paint;
            // 
            // btncekout
            // 
            btncekout.BackColor = Color.LightSlateGray;
            btncekout.Font = new Font("Dubai Medium", 12F, FontStyle.Bold);
            btncekout.ForeColor = Color.White;
            btncekout.Location = new Point(771, 16);
            btncekout.Margin = new Padding(4, 5, 4, 5);
            btncekout.Name = "btncekout";
            btncekout.Size = new Size(175, 45);
            btncekout.TabIndex = 11;
            btncekout.Text = "Checkout";
            btncekout.UseVisualStyleBackColor = false;
            // 
            // btnkrjng
            // 
            btnkrjng.BackColor = Color.LightSlateGray;
            btnkrjng.Font = new Font("Dubai Medium", 12F, FontStyle.Bold);
            btnkrjng.ForeColor = Color.White;
            btnkrjng.Location = new Point(598, 16);
            btnkrjng.Margin = new Padding(4, 5, 4, 5);
            btnkrjng.Name = "btnkrjng";
            btnkrjng.Size = new Size(175, 45);
            btnkrjng.TabIndex = 10;
            btnkrjng.Text = "Keranjang";
            btnkrjng.UseVisualStyleBackColor = false;
            // 
            // btnktlg
            // 
            btnktlg.BackColor = Color.LightSlateGray;
            btnktlg.Font = new Font("Dubai Medium", 12F, FontStyle.Bold);
            btnktlg.ForeColor = Color.White;
            btnktlg.Location = new Point(431, 16);
            btnktlg.Margin = new Padding(4, 5, 4, 5);
            btnktlg.Name = "btnktlg";
            btnktlg.Size = new Size(168, 45);
            btnktlg.TabIndex = 9;
            btnktlg.Text = "Katalog";
            btnktlg.UseVisualStyleBackColor = false;
            btnktlg.Click += button3_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Dubai", 26.2499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.OrangeRed;
            label3.Location = new Point(83, 11);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(158, 60);
            label3.TabIndex = 8;
            label3.Text = "CFMART";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(90, 79);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // dgvkeranjang
            // 
            dgvkeranjang.BackgroundColor = Color.SlateGray;
            dgvkeranjang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvkeranjang.Location = new Point(313, 172);
            dgvkeranjang.Name = "dgvkeranjang";
            dgvkeranjang.Size = new Size(543, 363);
            dgvkeranjang.TabIndex = 4;
            dgvkeranjang.CellContentClick += dataGridView1_CellContentClick;
            // 
            // lbltotalpesanan
            // 
            lbltotalpesanan.AutoSize = true;
            lbltotalpesanan.Font = new Font("Dubai", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbltotalpesanan.ForeColor = Color.White;
            lbltotalpesanan.Location = new Point(237, 137);
            lbltotalpesanan.Name = "lbltotalpesanan";
            lbltotalpesanan.Size = new Size(169, 32);
            lbltotalpesanan.TabIndex = 5;
            lbltotalpesanan.Text = "Total Pesanan: Rp 0";
            lbltotalpesanan.Click += label2_Click;
            // 
            // btnhapus
            // 
            btnhapus.BackColor = Color.Red;
            btnhapus.Font = new Font("Dubai Medium", 11.25F, FontStyle.Bold);
            btnhapus.Location = new Point(525, 493);
            btnhapus.Name = "btnhapus";
            btnhapus.Size = new Size(91, 31);
            btnhapus.TabIndex = 6;
            btnhapus.Text = "Hapus";
            btnhapus.UseVisualStyleBackColor = false;
            btnhapus.Click += button4_Click_1;
            // 
            // btnubahpesanan
            // 
            btnubahpesanan.Font = new Font("Dubai Medium", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnubahpesanan.Location = new Point(622, 493);
            btnubahpesanan.Name = "btnubahpesanan";
            btnubahpesanan.Size = new Size(224, 31);
            btnubahpesanan.TabIndex = 7;
            btnubahpesanan.Text = "Ubah Pesanan";
            btnubahpesanan.UseVisualStyleBackColor = true;
            btnubahpesanan.Click += button5_Click;
            // 
            // btnlanjutcheckout
            // 
            btnlanjutcheckout.BackColor = Color.SlateGray;
            btnlanjutcheckout.Font = new Font("Dubai Medium", 11.25F, FontStyle.Bold);
            btnlanjutcheckout.Location = new Point(313, 554);
            btnlanjutcheckout.Name = "btnlanjutcheckout";
            btnlanjutcheckout.Size = new Size(543, 37);
            btnlanjutcheckout.TabIndex = 8;
            btnlanjutcheckout.Text = "Lanjut Checkout";
            btnlanjutcheckout.UseVisualStyleBackColor = false;
            btnlanjutcheckout.Click += button6_Click;
            // 
            // KeranjangBelanja
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 25, 35);
            ClientSize = new Size(1370, 749);
            Controls.Add(btnlanjutcheckout);
            Controls.Add(btnubahpesanan);
            Controls.Add(btnhapus);
            Controls.Add(lbltotalpesanan);
            Controls.Add(dgvkeranjang);
            Controls.Add(panel2);
            Margin = new Padding(4, 3, 4, 3);
            Name = "KeranjangBelanja";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KeranjangBelanja";
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvkeranjang).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label CFMART;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnKeranjang;
        private System.Windows.Forms.Button btnKatalog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label label3;
        private Button btncekout;
        private Button btnkrjng;
        private Button btnktlg;
        private DataGridView dgvkeranjang;
        private Label lbltotalpesanan;
        private Button btnhapus;
        private Button btnubahpesanan;
        private Button btnlanjutcheckout;
    }
}