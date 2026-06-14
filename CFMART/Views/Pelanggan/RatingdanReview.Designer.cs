namespace CFMART.Views.Pelanggan
{
    partial class RatingdanReview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RatingdanReview));
            panelPilihProduk = new Panel();
            pictureBox3 = new PictureBox();
            CFMART = new Label();
            btnCheckout = new Button();
            btnKeranjang = new Button();
            btnKatalog = new Button();
            lblRatingdnReview = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cmbRating = new ComboBox();
            txtReviewText = new TextBox();
            panelPilihProduk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panelPilihProduk
            // 
            panelPilihProduk.BackColor = Color.SlateGray;
            panelPilihProduk.Controls.Add(btnCheckout);
            panelPilihProduk.Controls.Add(btnKeranjang);
            panelPilihProduk.Controls.Add(btnKatalog);
            panelPilihProduk.Controls.Add(CFMART);
            panelPilihProduk.Controls.Add(pictureBox3);
            panelPilihProduk.Font = new Font("Dubai Medium", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panelPilihProduk.Location = new Point(-1, -1);
            panelPilihProduk.Name = "panelPilihProduk";
            panelPilihProduk.Size = new Size(2030, 79);
            panelPilihProduk.TabIndex = 0;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Dock = DockStyle.Left;
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(90, 79);
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            // 
            // CFMART
            // 
            CFMART.AutoSize = true;
            CFMART.Font = new Font("Dubai", 26.2499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CFMART.ForeColor = Color.OrangeRed;
            CFMART.Location = new Point(81, 10);
            CFMART.Margin = new Padding(4, 0, 4, 0);
            CFMART.Name = "CFMART";
            CFMART.Size = new Size(158, 60);
            CFMART.TabIndex = 8;
            CFMART.Text = "CFMART";
            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = Color.LightSlateGray;
            btnCheckout.Font = new Font("Dubai Medium", 12F, FontStyle.Bold);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Location = new Point(788, 15);
            btnCheckout.Margin = new Padding(4, 5, 4, 5);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(175, 45);
            btnCheckout.TabIndex = 11;
            btnCheckout.Text = "Checkout";
            btnCheckout.UseVisualStyleBackColor = false;
            // 
            // btnKeranjang
            // 
            btnKeranjang.BackColor = Color.LightSlateGray;
            btnKeranjang.Font = new Font("Dubai Medium", 12F, FontStyle.Bold);
            btnKeranjang.ForeColor = Color.White;
            btnKeranjang.Location = new Point(614, 15);
            btnKeranjang.Margin = new Padding(4, 5, 4, 5);
            btnKeranjang.Name = "btnKeranjang";
            btnKeranjang.Size = new Size(175, 45);
            btnKeranjang.TabIndex = 10;
            btnKeranjang.Text = "Keranjang";
            btnKeranjang.UseVisualStyleBackColor = false;
            // 
            // btnKatalog
            // 
            btnKatalog.BackColor = Color.LightSlateGray;
            btnKatalog.Font = new Font("Dubai Medium", 12F, FontStyle.Bold);
            btnKatalog.ForeColor = Color.White;
            btnKatalog.Location = new Point(448, 15);
            btnKatalog.Margin = new Padding(4, 5, 4, 5);
            btnKatalog.Name = "btnKatalog";
            btnKatalog.Size = new Size(168, 45);
            btnKatalog.TabIndex = 9;
            btnKatalog.Text = "Katalog";
            btnKatalog.UseVisualStyleBackColor = false;
            // 
            // lblRatingdnReview
            // 
            lblRatingdnReview.AutoSize = true;
            lblRatingdnReview.BackColor = Color.SlateGray;
            lblRatingdnReview.Font = new Font("Dubai", 26.2499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRatingdnReview.ForeColor = Color.SlateGray;
            lblRatingdnReview.Image = (Image)resources.GetObject("lblRatingdnReview.Image");
            lblRatingdnReview.Location = new Point(392, 81);
            lblRatingdnReview.Margin = new Padding(4, 0, 4, 0);
            lblRatingdnReview.Name = "lblRatingdnReview";
            lblRatingdnReview.Size = new Size(298, 60);
            lblRatingdnReview.TabIndex = 12;
            lblRatingdnReview.Text = "Rating dan Review";
            // 
            // panel2
            // 
            panel2.BackColor = Color.SlateGray;
            panel2.Controls.Add(txtReviewText);
            panel2.Controls.Add(cmbRating);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(193, 166);
            panel2.Name = "panel2";
            panel2.Size = new Size(373, 206);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.BackColor = Color.SlateGray;
            panel3.Controls.Add(label4);
            panel3.Location = new Point(604, 166);
            panel3.Name = "panel3";
            panel3.Size = new Size(388, 337);
            panel3.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Dubai Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(16, 10);
            label2.Name = "label2";
            label2.Size = new Size(61, 27);
            label2.TabIndex = 1;
            label2.Text = "Rating";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Dubai Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(16, 91);
            label3.Name = "label3";
            label3.Size = new Size(65, 27);
            label3.TabIndex = 2;
            label3.Text = "Review";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Dubai Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(22, 10);
            label4.Name = "label4";
            label4.Size = new Size(168, 27);
            label4.TabIndex = 3;
            label4.Text = "Review terbaru anda";
            // 
            // cmbRating
            // 
            cmbRating.FormattingEnabled = true;
            cmbRating.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            cmbRating.Location = new Point(53, 49);
            cmbRating.Name = "cmbRating";
            cmbRating.Size = new Size(275, 23);
            cmbRating.TabIndex = 3;
            // 
            // txtReviewText
            // 
            txtReviewText.Location = new Point(53, 121);
            txtReviewText.Multiline = true;
            txtReviewText.Name = "txtReviewText";
            txtReviewText.ScrollBars = ScrollBars.Vertical;
            txtReviewText.Size = new Size(275, 23);
            txtReviewText.TabIndex = 4;
            // 
            // RatingdanReview
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1370, 749);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(lblRatingdnReview);
            Controls.Add(panelPilihProduk);
            Name = "RatingdanReview";
            Text = "RatingdanReview";
            panelPilihProduk.ResumeLayout(false);
            panelPilihProduk.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelPilihProduk;
        private PictureBox pictureBox3;
        private Label CFMART;
        private Button btnCheckout;
        private Button btnKeranjang;
        private Button btnKatalog;
        private Label lblRatingdnReview;
        private Panel panel2;
        private Panel panel3;
        private Label label3;
        private Label label2;
        private Label label4;
        private TextBox txtReviewText;
        private ComboBox cmbRating;
    }
}