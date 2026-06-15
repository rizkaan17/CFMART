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
            lblNamaItem.Location = new Point(10, 9);
            lblNamaItem.Name = "lblNamaItem";
            lblNamaItem.Size = new Size(126, 40);
            lblNamaItem.TabIndex = 0;
            lblNamaItem.Text = "Nama Item";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.BackColor = Color.Transparent;
            lblQuantity.Font = new Font("Dubai", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuantity.ForeColor = Color.White;
            lblQuantity.Location = new Point(293, 7);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(30, 40);
            lblQuantity.TabIndex = 1;
            lblQuantity.Text = "3";
            // 
            // lblHargaItem
            // 
            lblHargaItem.AutoSize = true;
            lblHargaItem.BackColor = Color.Transparent;
            lblHargaItem.Font = new Font("Dubai", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHargaItem.ForeColor = Color.White;
            lblHargaItem.Location = new Point(467, 7);
            lblHargaItem.Name = "lblHargaItem";
            lblHargaItem.Size = new Size(63, 40);
            lblHargaItem.TabIndex = 2;
            lblHargaItem.Text = "Rp. -";
            // 
            // btnTambahItem
            // 
            btnTambahItem.BackColor = Color.SlateGray;
            btnTambahItem.Font = new Font("Dubai", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTambahItem.ForeColor = Color.White;
            btnTambahItem.Location = new Point(217, 12);
            btnTambahItem.Name = "btnTambahItem";
            btnTambahItem.Size = new Size(58, 34);
            btnTambahItem.TabIndex = 3;
            btnTambahItem.Text = "+";
            btnTambahItem.UseVisualStyleBackColor = false;
            // 
            // btnMinusItem
            // 
            btnMinusItem.BackColor = Color.SlateGray;
            btnMinusItem.Font = new Font("Dubai", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMinusItem.ForeColor = Color.White;
            btnMinusItem.Location = new Point(339, 10);
            btnMinusItem.Name = "btnMinusItem";
            btnMinusItem.Size = new Size(58, 34);
            btnMinusItem.TabIndex = 4;
            btnMinusItem.Text = "-";
            btnMinusItem.UseVisualStyleBackColor = false;
            // 
            // btnHapusItem
            // 
            btnHapusItem.BackColor = Color.SlateGray;
            btnHapusItem.Font = new Font("Dubai", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHapusItem.ForeColor = Color.White;
            btnHapusItem.Location = new Point(648, 11);
            btnHapusItem.Name = "btnHapusItem";
            btnHapusItem.Size = new Size(58, 34);
            btnHapusItem.TabIndex = 5;
            btnHapusItem.Text = "x";
            btnHapusItem.UseVisualStyleBackColor = false;
            // 
            // UCItemKeranjang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(btnHapusItem);
            Controls.Add(btnMinusItem);
            Controls.Add(btnTambahItem);
            Controls.Add(lblHargaItem);
            Controls.Add(lblQuantity);
            Controls.Add(lblNamaItem);
            Name = "UCItemKeranjang";
            Size = new Size(720, 55);
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
