namespace CFMART.Views.Kasir
{
    partial class FormDashboardKasir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDashboardKasir));
            pnlHeaderKasir = new Panel();
            btnBiodata = new Button();
            btnRingkasan = new Button();
            btnKasir = new Button();
            btnLogoutKasir = new Button();
            lblKasir = new Label();
            lblLogo = new Label();
            pnlLogoKasir = new Panel();
            pnlMain = new Panel();
            btnKonfirmasi = new Button();
            pnlHeaderKasir.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeaderKasir
            // 
            pnlHeaderKasir.BackColor = Color.LightSlateGray;
            pnlHeaderKasir.Controls.Add(btnKonfirmasi);
            pnlHeaderKasir.Controls.Add(btnBiodata);
            pnlHeaderKasir.Controls.Add(btnRingkasan);
            pnlHeaderKasir.Controls.Add(btnKasir);
            pnlHeaderKasir.Controls.Add(btnLogoutKasir);
            pnlHeaderKasir.Controls.Add(lblKasir);
            pnlHeaderKasir.Controls.Add(lblLogo);
            pnlHeaderKasir.Controls.Add(pnlLogoKasir);
            pnlHeaderKasir.Dock = DockStyle.Top;
            pnlHeaderKasir.Location = new Point(0, 0);
            pnlHeaderKasir.Margin = new Padding(2);
            pnlHeaderKasir.Name = "pnlHeaderKasir";
            pnlHeaderKasir.Size = new Size(1480, 116);
            pnlHeaderKasir.TabIndex = 0;
            // 
            // btnBiodata
            // 
            btnBiodata.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBiodata.BackColor = Color.SlateGray;
            btnBiodata.FlatStyle = FlatStyle.Flat;
            btnBiodata.Font = new Font("Dubai Medium", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBiodata.ForeColor = Color.White;
            btnBiodata.Location = new Point(1098, 29);
            btnBiodata.Margin = new Padding(2);
            btnBiodata.Name = "btnBiodata";
            btnBiodata.Size = new Size(141, 62);
            btnBiodata.TabIndex = 15;
            btnBiodata.Text = "Biodata";
            btnBiodata.UseVisualStyleBackColor = false;
            btnBiodata.Click += btnBiodata_Click;
            // 
            // btnRingkasan
            // 
            btnRingkasan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRingkasan.BackColor = Color.SlateGray;
            btnRingkasan.FlatStyle = FlatStyle.Flat;
            btnRingkasan.Font = new Font("Dubai Medium", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRingkasan.ForeColor = Color.White;
            btnRingkasan.Location = new Point(945, 29);
            btnRingkasan.Margin = new Padding(2);
            btnRingkasan.Name = "btnRingkasan";
            btnRingkasan.Size = new Size(149, 62);
            btnRingkasan.TabIndex = 14;
            btnRingkasan.Text = "Ringkasan";
            btnRingkasan.UseVisualStyleBackColor = false;
            btnRingkasan.Click += btnRingkasan_Click;
            // 
            // btnKasir
            // 
            btnKasir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnKasir.BackColor = Color.SlateGray;
            btnKasir.FlatStyle = FlatStyle.Flat;
            btnKasir.Font = new Font("Dubai Medium", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKasir.ForeColor = Color.White;
            btnKasir.Location = new Point(489, 29);
            btnKasir.Margin = new Padding(2);
            btnKasir.Name = "btnKasir";
            btnKasir.Size = new Size(151, 62);
            btnKasir.TabIndex = 13;
            btnKasir.Text = "Kasir";
            btnKasir.UseVisualStyleBackColor = false;
            btnKasir.Click += btnKasir_Click;
            // 
            // btnLogoutKasir
            // 
            btnLogoutKasir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogoutKasir.BackColor = Color.FromArgb(192, 0, 0);
            btnLogoutKasir.Font = new Font("Dubai Medium", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogoutKasir.ForeColor = Color.White;
            btnLogoutKasir.Location = new Point(1253, 27);
            btnLogoutKasir.Margin = new Padding(2);
            btnLogoutKasir.Name = "btnLogoutKasir";
            btnLogoutKasir.Size = new Size(195, 62);
            btnLogoutKasir.TabIndex = 4;
            btnLogoutKasir.Text = "Logout";
            btnLogoutKasir.UseVisualStyleBackColor = false;
            btnLogoutKasir.Click += btnLogoutKasir_Click;
            // 
            // lblKasir
            // 
            lblKasir.AutoSize = true;
            lblKasir.Font = new Font("Dubai", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKasir.ForeColor = SystemColors.ButtonHighlight;
            lblKasir.Location = new Point(352, 45);
            lblKasir.Margin = new Padding(2, 0, 2, 0);
            lblKasir.Name = "lblKasir";
            lblKasir.Size = new Size(50, 30);
            lblKasir.TabIndex = 12;
            lblKasir.Text = "Kasir";
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.BackColor = Color.Transparent;
            lblLogo.Font = new Font("Dubai", 25.8749962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogo.ForeColor = Color.OrangeRed;
            lblLogo.Location = new Point(126, 14);
            lblLogo.Margin = new Padding(2, 0, 2, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(235, 88);
            lblLogo.TabIndex = 10;
            lblLogo.Text = "CFMART";
            // 
            // pnlLogoKasir
            // 
            pnlLogoKasir.BackColor = Color.SlateGray;
            pnlLogoKasir.BackgroundImage = (Image)resources.GetObject("pnlLogoKasir.BackgroundImage");
            pnlLogoKasir.BackgroundImageLayout = ImageLayout.Stretch;
            pnlLogoKasir.Dock = DockStyle.Left;
            pnlLogoKasir.Location = new Point(0, 0);
            pnlLogoKasir.Margin = new Padding(2);
            pnlLogoKasir.Name = "pnlLogoKasir";
            pnlLogoKasir.Size = new Size(122, 116);
            pnlLogoKasir.TabIndex = 11;
            // 
            // pnlMain
            // 
            pnlMain.BackgroundImage = (Image)resources.GetObject("pnlMain.BackgroundImage");
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 116);
            pnlMain.Margin = new Padding(2);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1480, 655);
            pnlMain.TabIndex = 13;
            // 
            // btnKonfirmasi
            // 
            btnKonfirmasi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnKonfirmasi.BackColor = Color.SlateGray;
            btnKonfirmasi.FlatStyle = FlatStyle.Flat;
            btnKonfirmasi.Font = new Font("Dubai", 10.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKonfirmasi.ForeColor = Color.White;
            btnKonfirmasi.Location = new Point(645, 29);
            btnKonfirmasi.Margin = new Padding(2);
            btnKonfirmasi.Name = "btnKonfirmasi";
            btnKonfirmasi.Size = new Size(296, 62);
            btnKonfirmasi.TabIndex = 16;
            btnKonfirmasi.Text = "Konfirmasi Pembayaran";
            btnKonfirmasi.UseVisualStyleBackColor = false;
            // 
            // FormDashboardKasir
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1480, 771);
            Controls.Add(pnlMain);
            Controls.Add(pnlHeaderKasir);
            Margin = new Padding(2);
            Name = "FormDashboardKasir";
            Text = "FormDashboardKasir";
            pnlHeaderKasir.ResumeLayout(false);
            pnlHeaderKasir.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeaderKasir;
        private Label lblKasir;
        private Label lblLogo;
        private Panel pnlLogoKasir;
        private Panel pnlMain;
        private Button btnLogoutKasir;
        private Button btnBiodata;
        private Button btnRingkasan;
        private Button btnKasir;
        private Button btnKonfirmasi;
    }
}