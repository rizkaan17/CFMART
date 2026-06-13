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
            btnKeluarKasir = new Button();
            lblKasir = new Label();
            lblLogo = new Label();
            pnlLogoKasir = new Panel();
            pnlMain = new Panel();
            pnlHeaderKasir.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeaderKasir
            // 
            pnlHeaderKasir.BackColor = Color.LightSlateGray;
            pnlHeaderKasir.Controls.Add(btnBiodata);
            pnlHeaderKasir.Controls.Add(btnRingkasan);
            pnlHeaderKasir.Controls.Add(btnKasir);
            pnlHeaderKasir.Controls.Add(btnKeluarKasir);
            pnlHeaderKasir.Controls.Add(lblKasir);
            pnlHeaderKasir.Controls.Add(lblLogo);
            pnlHeaderKasir.Controls.Add(pnlLogoKasir);
            pnlHeaderKasir.Dock = DockStyle.Top;
            pnlHeaderKasir.Location = new Point(0, 0);
            pnlHeaderKasir.Name = "pnlHeaderKasir";
            pnlHeaderKasir.Size = new Size(2139, 149);
            pnlHeaderKasir.TabIndex = 0;
            // 
            // btnBiodata
            // 
            btnBiodata.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBiodata.BackColor = Color.SlateGray;
            btnBiodata.FlatStyle = FlatStyle.Flat;
            btnBiodata.Font = new Font("Dubai Medium", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBiodata.ForeColor = Color.White;
            btnBiodata.Location = new Point(1415, 37);
            btnBiodata.Name = "btnBiodata";
            btnBiodata.Size = new Size(254, 79);
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
            btnRingkasan.Location = new Point(1155, 37);
            btnRingkasan.Name = "btnRingkasan";
            btnRingkasan.Size = new Size(254, 79);
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
            btnKasir.Location = new Point(895, 37);
            btnKasir.Name = "btnKasir";
            btnKasir.Size = new Size(254, 79);
            btnKasir.TabIndex = 13;
            btnKasir.Text = "Kasir";
            btnKasir.UseVisualStyleBackColor = false;
            btnKasir.Click += btnKasir_Click;
            // 
            // btnKeluarKasir
            // 
            btnKeluarKasir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnKeluarKasir.BackColor = Color.FromArgb(192, 0, 0);
            btnKeluarKasir.Font = new Font("Dubai Medium", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKeluarKasir.ForeColor = Color.White;
            btnKeluarKasir.Location = new Point(1843, 35);
            btnKeluarKasir.Name = "btnKeluarKasir";
            btnKeluarKasir.Size = new Size(254, 79);
            btnKeluarKasir.TabIndex = 4;
            btnKeluarKasir.Text = "Keluar";
            btnKeluarKasir.UseVisualStyleBackColor = false;
            btnKeluarKasir.Click += btnKeluarKasir_Click;
            // 
            // lblKasir
            // 
            lblKasir.AutoSize = true;
            lblKasir.Font = new Font("Dubai", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKasir.ForeColor = SystemColors.ButtonHighlight;
            lblKasir.Location = new Point(458, 58);
            lblKasir.Name = "lblKasir";
            lblKasir.Size = new Size(66, 40);
            lblKasir.TabIndex = 12;
            lblKasir.Text = "Kasir";
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.BackColor = Color.Transparent;
            lblLogo.Font = new Font("Dubai", 25.8749962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogo.ForeColor = Color.OrangeRed;
            lblLogo.Location = new Point(164, 18);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(312, 117);
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
            pnlLogoKasir.Name = "pnlLogoKasir";
            pnlLogoKasir.Size = new Size(158, 149);
            pnlLogoKasir.TabIndex = 11;
            // 
            // pnlMain
            // 
            pnlMain.BackgroundImage = (Image)resources.GetObject("pnlMain.BackgroundImage");
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 149);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(2139, 838);
            pnlMain.TabIndex = 13;
            // 
            // FormDashboardKasir
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(2139, 987);
            Controls.Add(pnlMain);
            Controls.Add(pnlHeaderKasir);
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
        private Button btnKeluarKasir;
        private Button btnBiodata;
        private Button btnRingkasan;
        private Button btnKasir;
    }
}