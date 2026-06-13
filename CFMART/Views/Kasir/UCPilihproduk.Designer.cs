namespace CFMART.Views.Kasir
{
    partial class UCPilihproduk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCPilihproduk));
            pnlBack = new Panel();
            lblPilihProduk = new Label();
            textBox1 = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            label1 = new Label();
            panel5 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            dataGridView1 = new DataGridView();
            pnlBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pnlBack
            // 
            pnlBack.BackColor = Color.LightSlateGray;
            pnlBack.Controls.Add(textBox1);
            pnlBack.Location = new Point(52, 64);
            pnlBack.Name = "pnlBack";
            pnlBack.Size = new Size(1406, 104);
            pnlBack.TabIndex = 0;
            // 
            // lblPilihProduk
            // 
            lblPilihProduk.AutoSize = true;
            lblPilihProduk.BackColor = Color.Transparent;
            lblPilihProduk.Font = new Font("Dubai", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPilihProduk.ForeColor = Color.White;
            lblPilihProduk.Location = new Point(52, -12);
            lblPilihProduk.Name = "lblPilihProduk";
            lblPilihProduk.Size = new Size(256, 73);
            lblPilihProduk.TabIndex = 0;
            lblPilihProduk.Text = "Pilih Produk";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.DarkGray;
            textBox1.Location = new Point(101, 33);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(1256, 39);
            textBox1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSlateGray;
            panel1.Location = new Point(52, 202);
            panel1.Name = "panel1";
            panel1.Size = new Size(441, 350);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightSlateGray;
            panel2.Location = new Point(532, 202);
            panel2.Name = "panel2";
            panel2.Size = new Size(441, 350);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightSlateGray;
            panel3.Location = new Point(1017, 202);
            panel3.Name = "panel3";
            panel3.Size = new Size(441, 350);
            panel3.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Dubai", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(1517, 63);
            label1.Name = "label1";
            label1.Size = new Size(515, 73);
            label1.TabIndex = 3;
            label1.Text = "Daftar Pesanan Pelanggan";
            // 
            // panel5
            // 
            panel5.BackColor = Color.LightSlateGray;
            panel5.Location = new Point(52, 590);
            panel5.Name = "panel5";
            panel5.Size = new Size(441, 350);
            panel5.TabIndex = 2;
            // 
            // panel6
            // 
            panel6.BackColor = Color.LightSlateGray;
            panel6.Location = new Point(532, 590);
            panel6.Name = "panel6";
            panel6.Size = new Size(441, 350);
            panel6.TabIndex = 2;
            // 
            // panel7
            // 
            panel7.BackColor = Color.LightSlateGray;
            panel7.Location = new Point(1017, 590);
            panel7.Name = "panel7";
            panel7.Size = new Size(441, 350);
            panel7.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = Color.LightSlateGray;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(1517, 187);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(620, 802);
            dataGridView1.TabIndex = 0;
            // 
            // UCPilihproduk
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(dataGridView1);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(label1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(lblPilihProduk);
            Controls.Add(pnlBack);
            Name = "UCPilihproduk";
            Size = new Size(2165, 1058);
            pnlBack.ResumeLayout(false);
            pnlBack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlBack;
        private Label lblPilihProduk;
        private TextBox textBox1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private DataGridView dataGridView1;
    }
}
