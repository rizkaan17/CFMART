namespace CFMART
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            btnMasukAdmin = new Button();
            TBPassword = new TextBox();
            PasswordAdmin = new Label();
            TBusername = new TextBox();
            UsernameAdmin = new Label();
            kelolaAdmin = new Label();
            PortalAdmin = new Label();
            label1 = new Label();
            LeleAdmin = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.BackColor = Color.SlateGray;
            pictureBox1.Location = new Point(694, 58);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(756, 848);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.None;
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Location = new Point(1010, 214);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Padding = new Padding(15);
            pictureBox3.Size = new Size(133, 122);
            pictureBox3.TabIndex = 22;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.BackColor = Color.SlateGray;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(906, 755);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(49, 46);
            pictureBox2.TabIndex = 21;
            pictureBox2.TabStop = false;
            // 
            // btnMasukAdmin
            // 
            btnMasukAdmin.Anchor = AnchorStyles.None;
            btnMasukAdmin.BackColor = Color.SlateGray;
            btnMasukAdmin.Font = new Font("Dubai", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMasukAdmin.ForeColor = Color.White;
            btnMasukAdmin.Location = new Point(769, 746);
            btnMasukAdmin.Name = "btnMasukAdmin";
            btnMasukAdmin.Size = new Size(602, 63);
            btnMasukAdmin.TabIndex = 20;
            btnMasukAdmin.Text = "Masuk sebagai admin";
            btnMasukAdmin.UseVisualStyleBackColor = false;
            btnMasukAdmin.Click += this.btnMasukAdmin_Click;
            // 
            // TBPassword
            // 
            TBPassword.Anchor = AnchorStyles.None;
            TBPassword.Location = new Point(771, 679);
            TBPassword.Name = "TBPassword";
            TBPassword.Size = new Size(602, 39);
            TBPassword.TabIndex = 19;
            // 
            // PasswordAdmin
            // 
            PasswordAdmin.Anchor = AnchorStyles.None;
            PasswordAdmin.AutoSize = true;
            PasswordAdmin.BackColor = Color.SlateGray;
            PasswordAdmin.Font = new Font("Dubai Medium", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PasswordAdmin.ForeColor = Color.White;
            PasswordAdmin.Location = new Point(766, 634);
            PasswordAdmin.Name = "PasswordAdmin";
            PasswordAdmin.Size = new Size(135, 40);
            PasswordAdmin.TabIndex = 18;
            PasswordAdmin.Text = "Password :";
            // 
            // TBusername
            // 
            TBusername.Anchor = AnchorStyles.None;
            TBusername.Location = new Point(772, 563);
            TBusername.Name = "TBusername";
            TBusername.Size = new Size(601, 39);
            TBusername.TabIndex = 17;
            // 
            // UsernameAdmin
            // 
            UsernameAdmin.Anchor = AnchorStyles.None;
            UsernameAdmin.AutoSize = true;
            UsernameAdmin.BackColor = Color.SlateGray;
            UsernameAdmin.Font = new Font("Dubai Medium", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UsernameAdmin.ForeColor = Color.White;
            UsernameAdmin.Location = new Point(767, 519);
            UsernameAdmin.Name = "UsernameAdmin";
            UsernameAdmin.Size = new Size(139, 40);
            UsernameAdmin.TabIndex = 16;
            UsernameAdmin.Text = "Username :";
            // 
            // kelolaAdmin
            // 
            kelolaAdmin.Anchor = AnchorStyles.None;
            kelolaAdmin.AutoSize = true;
            kelolaAdmin.BackColor = Color.SlateGray;
            kelolaAdmin.Font = new Font("Dubai", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            kelolaAdmin.Location = new Point(906, 443);
            kelolaAdmin.Name = "kelolaAdmin";
            kelolaAdmin.Size = new Size(317, 40);
            kelolaAdmin.TabIndex = 15;
            kelolaAdmin.Text = "Masuk untuk mengelola sistem";
            kelolaAdmin.Click += kelolaAdmin_Click;
            // 
            // PortalAdmin
            // 
            PortalAdmin.Anchor = AnchorStyles.None;
            PortalAdmin.AutoSize = true;
            PortalAdmin.BackColor = Color.FromArgb(123, 70, 71);
            PortalAdmin.Font = new Font("Dubai Medium", 10.124999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PortalAdmin.ForeColor = Color.FromArgb(255, 128, 0);
            PortalAdmin.Location = new Point(983, 148);
            PortalAdmin.Name = "PortalAdmin";
            PortalAdmin.Padding = new Padding(5);
            PortalAdmin.Size = new Size(188, 55);
            PortalAdmin.TabIndex = 13;
            PortalAdmin.Text = "Portal Admin";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(792, 280);
            label1.Name = "label1";
            label1.Size = new Size(0, 32);
            label1.TabIndex = 12;
            // 
            // LeleAdmin
            // 
            LeleAdmin.Anchor = AnchorStyles.None;
            LeleAdmin.BackColor = Color.SlateGray;
            LeleAdmin.Font = new Font("Dubai", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LeleAdmin.ForeColor = Color.White;
            LeleAdmin.Location = new Point(1000, 350);
            LeleAdmin.Name = "LeleAdmin";
            LeleAdmin.Size = new Size(152, 73);
            LeleAdmin.TabIndex = 23;
            LeleAdmin.Text = "Admin";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(192F, 192F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.SlateGray;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(2139, 987);
            Controls.Add(LeleAdmin);
            Controls.Add(kelolaAdmin);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(btnMasukAdmin);
            Controls.Add(TBPassword);
            Controls.Add(PasswordAdmin);
            Controls.Add(TBusername);
            Controls.Add(UsernameAdmin);
            Controls.Add(PortalAdmin);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private Button btnMasukAdmin;
        private TextBox TBPassword;
        private Label PasswordAdmin;
        private TextBox TBusername;
        private Label UsernameAdmin;
        private Label kelolaAdmin;
        private Label PortalAdmin;
        private Label label1;
        private Label LeleAdmin;
    }
}
