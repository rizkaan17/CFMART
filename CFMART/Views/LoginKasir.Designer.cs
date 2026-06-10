namespace CFMART.Views
{
    partial class LoginKasir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginKasir));
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            button1 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            PortalKasir = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(PortalKasir);
            panel1.Font = new Font("Dubai", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(616, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(756, 848);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(251, 719);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(46, 51);
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.SlateGray;
            button1.ForeColor = Color.White;
            button1.Location = new Point(80, 713);
            button1.Name = "button1";
            button1.Size = new Size(602, 63);
            button1.TabIndex = 8;
            button1.Text = "Masuk sebagai kasir";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(61, 579);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(641, 38);
            textBox2.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(64, 481);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(641, 38);
            textBox1.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Dubai", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(61, 537);
            label4.Name = "label4";
            label4.Size = new Size(95, 30);
            label4.TabIndex = 5;
            label4.Text = "Password :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Dubai", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(61, 439);
            label3.Name = "label3";
            label3.Size = new Size(99, 30);
            label3.TabIndex = 4;
            label3.Text = "Username :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Dubai", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(256, 325);
            label2.Name = "label2";
            label2.Size = new Size(237, 30);
            label2.TabIndex = 3;
            label2.Text = "Masuk untuk mengelola sistem";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Dubai", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(310, 280);
            label1.Name = "label1";
            label1.Size = new Size(111, 54);
            label1.TabIndex = 2;
            label1.Text = "KASIR";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(290, 131);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(149, 150);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // PortalKasir
            // 
            PortalKasir.Anchor = AnchorStyles.None;
            PortalKasir.AutoSize = true;
            PortalKasir.BackColor = Color.FromArgb(123, 70, 71);
            PortalKasir.Font = new Font("Dubai Medium", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PortalKasir.ForeColor = Color.FromArgb(255, 128, 0);
            PortalKasir.Location = new Point(301, 82);
            PortalKasir.Name = "PortalKasir";
            PortalKasir.Size = new Size(125, 34);
            PortalKasir.TabIndex = 0;
            PortalKasir.Text = "Portal Kasir";
            // 
            // LoginKasir
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1924, 1002);
            Controls.Add(panel1);
            Name = "LoginKasir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginKasir";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label PortalKasir;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label2;
        private Button button1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label4;
        private PictureBox pictureBox2;
    }
}