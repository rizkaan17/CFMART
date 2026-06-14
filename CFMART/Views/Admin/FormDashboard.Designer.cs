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
            btnLogout = new Button();
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
            panelHeader.Controls.Add(btnLogout);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(2, 2, 2, 2);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1480, 117);
            panelHeader.TabIndex = 0;
            // 
            // lblAdmin
            // 
            lblAdmin.AutoSize = true;
            lblAdmin.Font = new Font("Dubai", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAdmin.ForeColor = SystemColors.ButtonHighlight;
            lblAdmin.Location = new Point(348, 46);
            lblAdmin.Margin = new Padding(2, 0, 2, 0);
            lblAdmin.Name = "lblAdmin";
            lblAdmin.Size = new Size(60, 30);
            lblAdmin.TabIndex = 9;
            lblAdmin.Text = "Admin";
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.BackColor = Color.Transparent;
            lblLogo.Font = new Font("Dubai", 25.8749962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogo.ForeColor = Color.OrangeRed;
            lblLogo.Location = new Point(122, 15);
            lblLogo.Margin = new Padding(2, 0, 2, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(235, 88);
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
            pnlLOGO.Margin = new Padding(2, 2, 2, 2);
            pnlLOGO.Name = "pnlLOGO";
            pnlLOGO.Size = new Size(122, 113);
            pnlLOGO.TabIndex = 8;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = Color.FromArgb(192, 0, 0);
            btnLogout.Font = new Font("Dubai Medium", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1272, 23);
            btnLogout.Margin = new Padding(2, 2, 2, 2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(195, 62);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
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
            panelSidebar.Location = new Point(0, 117);
            panelSidebar.Margin = new Padding(2, 2, 2, 2);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(386, 654);
            panelSidebar.TabIndex = 2;
            // 
            // btnBiodata
            // 
            btnBiodata.BackColor = Color.LightSlateGray;
            btnBiodata.Font = new Font("Dubai Medium", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBiodata.ForeColor = Color.White;
            btnBiodata.Location = new Point(18, 329);
            btnBiodata.Margin = new Padding(2, 2, 2, 2);
            btnBiodata.Name = "btnBiodata";
            btnBiodata.Size = new Size(345, 44);
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
            lblSistem.Location = new Point(18, 295);
            lblSistem.Margin = new Padding(2, 0, 2, 0);
            lblSistem.Name = "lblSistem";
            lblSistem.Size = new Size(73, 30);
            lblSistem.TabIndex = 5;
            lblSistem.Text = "SISTEM";
            // 
            // btnKaryawan
            // 
            btnKaryawan.BackColor = Color.LightSlateGray;
            btnKaryawan.Font = new Font("Dubai Medium", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKaryawan.ForeColor = Color.White;
            btnKaryawan.Location = new Point(18, 238);
            btnKaryawan.Margin = new Padding(2, 2, 2, 2);
            btnKaryawan.Name = "btnKaryawan";
            btnKaryawan.Size = new Size(345, 44);
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
            btnProduk.Location = new Point(18, 187);
            btnProduk.Margin = new Padding(2, 2, 2, 2);
            btnProduk.Name = "btnProduk";
            btnProduk.Size = new Size(345, 44);
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
            btnDashboard.Location = new Point(18, 138);
            btnDashboard.Margin = new Padding(2, 2, 2, 2);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(345, 44);
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
            lblMenu.Location = new Point(18, 104);
            lblMenu.Margin = new Padding(2, 0, 2, 0);
            lblMenu.Name = "lblMenu";
            lblMenu.Size = new Size(63, 30);
            lblMenu.TabIndex = 0;
            lblMenu.Text = "MENU";
            // 
            // panelMain
            // 
            panelMain.BackColor = SystemColors.ControlLightLight;
            panelMain.BackgroundImage = (Image)resources.GetObject("panelMain.BackgroundImage");
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(386, 117);
            panelMain.Margin = new Padding(2, 2, 2, 2);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1094, 654);
            panelMain.TabIndex = 3;
            // 
            // FormDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1480, 771);
            Controls.Add(panelMain);
            Controls.Add(panelSidebar);
            Controls.Add(panelHeader);
            Margin = new Padding(2, 2, 2, 2);
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
        private Button btnLogout;
        private Panel pnlLOGO;
        private Panel panelMain;
        private Label lblAdmin;
    }
}