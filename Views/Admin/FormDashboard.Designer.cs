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
            panelSidebar = new Panel();
            lblMenu = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            button5 = new Button();
            label2 = new Label();
            button6 = new Button();
            panel1 = new Panel();
            panelHeader.SuspendLayout();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.LightSlateGray;
            panelHeader.Controls.Add(panel1);
            panelHeader.Controls.Add(button6);
            panelHeader.Controls.Add(label2);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(2152, 64);
            panelHeader.TabIndex = 0;
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.LightSlateGray;
            panelSidebar.Controls.Add(button5);
            panelSidebar.Controls.Add(label1);
            panelSidebar.Controls.Add(button4);
            panelSidebar.Controls.Add(button3);
            panelSidebar.Controls.Add(button2);
            panelSidebar.Controls.Add(button1);
            panelSidebar.Controls.Add(lblMenu);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 64);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(331, 741);
            panelSidebar.TabIndex = 2;
            // 
            // lblMenu
            // 
            lblMenu.AutoSize = true;
            lblMenu.Font = new Font("Dubai", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMenu.ForeColor = Color.LightSteelBlue;
            lblMenu.Location = new Point(12, 24);
            lblMenu.Name = "lblMenu";
            lblMenu.Size = new Size(83, 40);
            lblMenu.TabIndex = 0;
            lblMenu.Text = "MENU";
            // 
            // button1
            // 
            button1.BackColor = Color.LightSlateGray;
            button1.Font = new Font("Dubai Medium", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(12, 67);
            button1.Name = "button1";
            button1.Size = new Size(301, 56);
            button1.TabIndex = 1;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.LightSlateGray;
            button2.Font = new Font("Dubai Medium", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(12, 130);
            button2.Name = "button2";
            button2.Size = new Size(301, 56);
            button2.TabIndex = 2;
            button2.Text = "Produk";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.LightSlateGray;
            button3.Font = new Font("Dubai Medium", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(12, 195);
            button3.Name = "button3";
            button3.Size = new Size(301, 56);
            button3.TabIndex = 3;
            button3.Text = "Karyawan";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.LightSlateGray;
            button4.Font = new Font("Dubai Medium", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(12, 257);
            button4.Name = "button4";
            button4.Size = new Size(301, 56);
            button4.TabIndex = 4;
            button4.Text = "Laporan";
            button4.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Dubai", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LightSteelBlue;
            label1.Location = new Point(12, 346);
            label1.Name = "label1";
            label1.Size = new Size(96, 40);
            label1.TabIndex = 5;
            label1.Text = "SISTEM";
            // 
            // button5
            // 
            button5.BackColor = Color.LightSlateGray;
            button5.Font = new Font("Dubai Medium", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.White;
            button5.Location = new Point(12, 389);
            button5.Name = "button5";
            button5.Size = new Size(301, 56);
            button5.TabIndex = 6;
            button5.Text = "Biodata";
            button5.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Dubai", 13.8749981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Tomato;
            label2.Location = new Point(134, 2);
            label2.Name = "label2";
            label2.Size = new Size(167, 63);
            label2.TabIndex = 7;
            label2.Text = "CFMART";
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button6.BackColor = Color.IndianRed;
            button6.Font = new Font("Dubai", 10.124999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.Maroon;
            button6.Location = new Point(1990, 9);
            button6.Name = "button6";
            button6.Size = new Size(150, 46);
            button6.TabIndex = 3;
            button6.Text = "Keluar";
            button6.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Location = new Point(1915, 9);
            panel1.Name = "panel1";
            panel1.Size = new Size(59, 46);
            panel1.TabIndex = 8;
            // 
            // FormDashboard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(2152, 805);
            Controls.Add(panelSidebar);
            Controls.Add(panelHeader);
            Name = "FormDashboard";
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
        private Button button1;
        private Button button2;
        private Label label2;
        private Button button5;
        private Label label1;
        private Button button4;
        private Button button3;
        private Button button6;
        private Panel panel1;
    }
}