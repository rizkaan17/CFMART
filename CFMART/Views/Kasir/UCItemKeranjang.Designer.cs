namespace CFMART.Views.Kasir
{
    partial class UCItemKeranjang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCItemKeranjang));
            lblNamaItem = new Label();
            lblQuantity = new Label();
            lblHargaItem = new Label();
            btnTambahItem = new Button();
            btnMinusItem = new Button();
            btnHapusItem = new Button();
            SuspendLayout();
            // 
            // lblNamaItem
            // 
            lblNamaItem.AutoSize = true;
            lblNamaItem.BackColor = Color.Transparent;
            lblNamaItem.Font = new Font("Dubai", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNamaItem.ForeColor = Color.White;
            lblNamaItem.Location = new Point(14, 18);
            lblNamaItem.Margin = new Padding(4, 0, 4, 0);
            lblNamaItem.Name = "lblNamaItem";
            lblNamaItem.Size = new Size(168, 54);
            lblNamaItem.TabIndex = 0;
            lblNamaItem.Text = "Nama Item";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.BackColor = Color.Transparent;
            lblQuantity.Font = new Font("Dubai", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuantity.ForeColor = Color.White;
            lblQuantity.Location = new Point(386, 18);
            lblQuantity.Margin = new Padding(4, 0, 4, 0);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(40, 54);
            lblQuantity.TabIndex = 1;
            lblQuantity.Text = "3";
            // 
            // lblHargaItem
            // 
            lblHargaItem.AutoSize = true;
            lblHargaItem.BackColor = Color.Transparent;
            lblHargaItem.Font = new Font("Dubai", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHargaItem.ForeColor = Color.White;
            lblHargaItem.Location = new Point(612, 13);
            lblHargaItem.Margin = new Padding(4, 0, 4, 0);
            lblHargaItem.Name = "lblHargaItem";
            lblHargaItem.Size = new Size(84, 54);
            lblHargaItem.TabIndex = 2;
            lblHargaItem.Text = "Rp. -";
            // 
            // btnTambahItem
            // 
            btnTambahItem.BackColor = Color.SlateGray;
            btnTambahItem.Font = new Font("Dubai", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTambahItem.ForeColor = Color.White;
            btnTambahItem.Location = new Point(282, 15);
            btnTambahItem.Margin = new Padding(4);
            btnTambahItem.Name = "btnTambahItem";
            btnTambahItem.Size = new Size(75, 53);
            btnTambahItem.TabIndex = 3;
            btnTambahItem.Text = "+";
            btnTambahItem.UseVisualStyleBackColor = false;
            // 
            // btnMinusItem
            // 
            btnMinusItem.BackColor = Color.SlateGray;
            btnMinusItem.Font = new Font("Dubai", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMinusItem.ForeColor = Color.White;
            btnMinusItem.Location = new Point(450, 17);
            btnMinusItem.Margin = new Padding(4);
            btnMinusItem.Name = "btnMinusItem";
            btnMinusItem.Size = new Size(75, 51);
            btnMinusItem.TabIndex = 4;
            btnMinusItem.Text = "-";
            btnMinusItem.UseVisualStyleBackColor = false;
            // 
            // btnHapusItem
            // 
            btnHapusItem.BackColor = Color.SlateGray;
            btnHapusItem.Font = new Font("Dubai", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHapusItem.ForeColor = Color.White;
            btnHapusItem.Location = new Point(842, 17);
            btnHapusItem.Margin = new Padding(4);
            btnHapusItem.Name = "btnHapusItem";
            btnHapusItem.Size = new Size(75, 55);
            btnHapusItem.TabIndex = 5;
            btnHapusItem.Text = "x";
            btnHapusItem.UseVisualStyleBackColor = false;
            // 
            // UCItemKeranjang
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(btnHapusItem);
            Controls.Add(btnMinusItem);
            Controls.Add(btnTambahItem);
            Controls.Add(lblHargaItem);
            Controls.Add(lblQuantity);
            Controls.Add(lblNamaItem);
            Margin = new Padding(4);
            Name = "UCItemKeranjang";
            Size = new Size(962, 102);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNamaItem;
        private Label lblQuantity;
        private Label lblHargaItem;
        private Button btnTambahItem;
        private Button btnMinusItem;
        private Button btnHapusItem;
    }
}
