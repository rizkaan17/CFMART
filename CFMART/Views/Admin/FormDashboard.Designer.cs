namespace CFMART.Views.Admin
{
    partial class FormDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDashboard));
            panelHeader = new Panel();
            lblAdmin = new Label();
            lblLogo = new Label();
            pnlLOGO = new Panel();
            btnKeluar = new Button();
            panelSidebar = new Panel();
            btnBiodata = new Button();
            lblSistem = new Label();
            btnKaryawan = new Button();
            btnProduk = new Button();
            btnDashboard = new Button();
            lblMenu = new Label();
            panelMain = new Panel();
            panelHeader.SuspendLayout();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.SlateGray;
            panelHeader.BorderStyle = BorderStyle.Fixed3D;
            panelHeader.Controls.Add(lblAdmin);
            panelHeader.Controls.Add(lblLogo);
            panelHeader.Controls.Add(pnlLOGO);
            panelHeader.Controls.Add(btnKeluar);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(2139, 149);
            panelHeader.TabIndex = 0;
            // 
            // lblAdmin
            // 
            lblAdmin.AutoSize = true;
            lblAdmin.Font = new Font("Dubai", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAdmin.ForeColor = SystemColors.ButtonHighlight;
            lblAdmin.Location = new Point(453, 59);
            lblAdmin.Name = "lblAdmin";
            lblAdmin.Size = new Size(80, 40);
            lblAdmin.TabIndex = 9;
            lblAdmin.Text = "Admin";
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.BackColor = Color.Transparent;
            lblLogo.Font = new Font("Dubai", 25.8749962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogo.ForeColor = Color.OrangeRed;
            lblLogo.Location = new Point(159, 19);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(312, 117);
            lblLogo.TabIndex = 7;
            lblLogo.Text = "CFMART";
            // 
            // pnlLOGO
            // 
            pnlLOGO.BackColor = Color.SlateGray;
            pnlLOGO.BackgroundImage = (Image)resources.GetObject("pnlLOGO.BackgroundImage");
            pnlLOGO.BackgroundImageLayout = ImageLayout.Stretch;
            pnlLOGO.Dock = DockStyle.Left;
            pnlLOGO.Location = new Point(0, 0);
            pnlLOGO.Name = "pnlLOGO";
            pnlLOGO.Size = new Size(158, 145);
            pnlLOGO.TabIndex = 8;
            // 
            // btnKeluar
            // 
            btnKeluar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnKeluar.BackColor = Color.FromArgb(192, 0, 0);
            btnKeluar.Font = new Font("Dubai Medium", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKeluar.ForeColor = Color.White;
            btnKeluar.Location = new Point(1869, 30);
            btnKeluar.Name = "btnKeluar";
            btnKeluar.Size = new Size(254, 79);
            btnKeluar.TabIndex = 3;
            btnKeluar.Text = "Keluar";
            btnKeluar.UseVisualStyleBackColor = false;
            btnKeluar.Click += btnKeluar_Click;
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.SlateGray;
            panelSidebar.BorderStyle = BorderStyle.Fixed3D;
            panelSidebar.Controls.Add(btnBiodata);
            panelSidebar.Controls.Add(lblSistem);
            panelSidebar.Controls.Add(btnKaryawan);
            panelSidebar.Controls.Add(btnProduk);
            panelSidebar.Controls.Add(btnDashboard);
            panelSidebar.Controls.Add(lblMenu);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 149);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(500, 838);
            panelSidebar.TabIndex = 2;
            // 
            // btnBiodata
            // 
            btnBiodata.BackColor = Color.LightSlateGray;
            btnBiodata.Font = new Font("Dubai Medium", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBiodata.ForeColor = Color.White;
            btnBiodata.Location = new Point(24, 421);
            btnBiodata.Name = "btnBiodata";
            btnBiodata.Size = new Size(449, 56);
            btnBiodata.TabIndex = 6;
            btnBiodata.Text = "Biodata";
            btnBiodata.UseVisualStyleBackColor = false;
            btnBiodata.Click += btnBiodata_Click;
            // 
            // lblSistem
            // 
            lblSistem.AutoSize = true;
            lblSistem.Font = new Font("Dubai", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSistem.ForeColor = Color.LightSteelBlue;
            lblSistem.Location = new Point(24, 378);
            lblSistem.Name = "lblSistem";
            lblSistem.Size = new Size(96, 40);
            lblSistem.TabIndex = 5;
            lblSistem.Text = "SISTEM";
            // 
            // btnKaryawan
            // 
            btnKaryawan.BackColor = Color.LightSlateGray;
            btnKaryawan.Font = new Font("Dubai Medium", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKaryawan.ForeColor = Color.White;
            btnKaryawan.Location = new Point(24, 304);
            btnKaryawan.Name = "btnKaryawan";
            btnKaryawan.Size = new Size(449, 56);
            btnKaryawan.TabIndex = 3;
            btnKaryawan.Text = "Karyawan";
            btnKaryawan.UseVisualStyleBackColor = false;
            btnKaryawan.Click += btnKaryawan_Click;
            // 
            // btnProduk
            // 
            btnProduk.BackColor = Color.LightSlateGray;
            btnProduk.Font = new Font("Dubai Medium", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProduk.ForeColor = Color.White;
            btnProduk.Location = new Point(24, 239);
            btnProduk.Name = "btnProduk";
            btnProduk.Size = new Size(449, 56);
            btnProduk.TabIndex = 2;
            btnProduk.Text = "Produk";
            btnProduk.UseVisualStyleBackColor = false;
            btnProduk.Click += btnProduk_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.LightSlateGray;
            btnDashboard.Font = new Font("Dubai Medium", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(24, 176);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(449, 56);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // lblMenu
            // 
            lblMenu.AutoSize = true;
            lblMenu.Font = new Font("Dubai", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMenu.ForeColor = Color.LightSteelBlue;
            lblMenu.Location = new Point(24, 133);
            lblMenu.Name = "lblMenu";
            lblMenu.Size = new Size(83, 40);
            lblMenu.TabIndex = 0;
            lblMenu.Text = "MENU";
            // 
            // panelMain
            // 
            panelMain.BackColor = SystemColors.ControlLightLight;
            panelMain.BackgroundImage = (Image)resources.GetObject("panelMain.BackgroundImage");
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(500, 149);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1639, 838);
            panelMain.TabIndex = 3;
            // 
            // FormDashboard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(2139, 987);
            Controls.Add(panelMain);
            Controls.Add(panelSidebar);
            Controls.Add(panelHeader);
            Name = "FormDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormDashboard";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelSidebar.ResumeLayout(false);
            panelSidebar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Panel panelSidebar;
        private Label lblMenu;
        private Button btnDashboard;
        private Button btnProduk;
        private Label lblLogo;
        private Button btnBiodata;
        private Label lblSistem;
        private Button btnKaryawan;
        private Button btnKeluar;
        private Panel pnlLOGO;
        private Panel panelMain;
        private Label lblAdmin;
    }
}