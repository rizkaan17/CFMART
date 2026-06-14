using System.Diagnostics;
using CFMART;

namespace CFMART
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    partial class DashboardPelanggan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardPelanggan));
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            btnCheckout = new Button();
            btnKeranjang = new Button();
            btnKatalog = new Button();
            CFMART = new Label();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            txtSearch = new TextBox();
            btnSemua = new Button();
            btnMakanan = new Button();
            btnMinuman = new Button();
            panelAirMineral = new Panel();
            lblstokairmineral = new Label();
            button3 = new Button();
            label19 = new Label();
            label20 = new Label();
            pictureBox8 = new PictureBox();
            label21 = new Label();
            panelEsJeruk = new Panel();
            lblstokesjeruk = new Label();
            button4 = new Button();
            label16 = new Label();
            label17 = new Label();
            pictureBox7 = new PictureBox();
            label18 = new Label();
            panelEsTeh = new Panel();
            lblstokesteh = new Label();
            button6 = new Button();
            label13 = new Label();
            label14 = new Label();
            pictureBox6 = new PictureBox();
            label15 = new Label();
            panelMangutLele = new Panel();
            lblstokmangutlele = new Label();
            button2 = new Button();
            label10 = new Label();
            label11 = new Label();
            pictureBox5 = new PictureBox();
            label12 = new Label();
            panelLeleBakar = new Panel();
            labelstoklelebakar = new Label();
            button1 = new Button();
            label7 = new Label();
            label8 = new Label();
            pictureBox2 = new PictureBox();
            label9 = new Label();
            panelLeleGoreng = new Panel();
            lblstoklelegoreng = new Label();
            button5 = new Button();
            label5 = new Label();
            label6 = new Label();
            pictureBox4 = new PictureBox();
            label4 = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelAirMineral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            panelEsJeruk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            panelEsTeh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panelMangutLele.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panelLeleBakar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelLeleGoreng.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.SlateGray;
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(btnCheckout);
            panel1.Controls.Add(btnKeranjang);
            panel1.Controls.Add(btnKatalog);
            panel1.Controls.Add(CFMART);
            panel1.Location = new Point(-4, -4);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(2030, 79);
            panel1.TabIndex = 0;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Dock = DockStyle.Left;
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(90, 79);
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = Color.LightSlateGray;
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Location = new Point(753, 18);
            btnCheckout.Margin = new Padding(4, 5, 4, 5);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(175, 45);
            btnCheckout.TabIndex = 4;
            btnCheckout.Text = "Checkout";
            btnCheckout.UseVisualStyleBackColor = false;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // btnKeranjang
            // 
            btnKeranjang.BackColor = Color.LightSlateGray;
            btnKeranjang.ForeColor = Color.White;
            btnKeranjang.Location = new Point(580, 18);
            btnKeranjang.Margin = new Padding(4, 5, 4, 5);
            btnKeranjang.Name = "btnKeranjang";
            btnKeranjang.Size = new Size(175, 45);
            btnKeranjang.TabIndex = 3;
            btnKeranjang.Text = "Keranjang";
            btnKeranjang.UseVisualStyleBackColor = false;
            btnKeranjang.Click += btnKeranjang_Click;
            // 
            // btnKatalog
            // 
            btnKatalog.BackColor = Color.LightSlateGray;
            btnKatalog.ForeColor = Color.White;
            btnKatalog.Location = new Point(413, 18);
            btnKatalog.Margin = new Padding(4, 5, 4, 5);
            btnKatalog.Name = "btnKatalog";
            btnKatalog.Size = new Size(168, 45);
            btnKatalog.TabIndex = 1;
            btnKatalog.Text = "Katalog";
            btnKatalog.UseVisualStyleBackColor = false;
            // 
            // CFMART
            // 
            CFMART.AutoSize = true;
            CFMART.Font = new Font("Dubai", 26.2499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CFMART.ForeColor = Color.OrangeRed;
            CFMART.Location = new Point(92, 13);
            CFMART.Margin = new Padding(4, 0, 4, 0);
            CFMART.Name = "CFMART";
            CFMART.Size = new Size(158, 60);
            CFMART.TabIndex = 0;
            CFMART.Text = "CFMART";
            // 
            // panel2
            // 
            panel2.BackColor = Color.SlateGray;
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(txtSearch);
            panel2.Location = new Point(78, 111);
            panel2.Name = "panel2";
            panel2.Size = new Size(986, 57);
            panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(24, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(41, 37);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.White;
            txtSearch.Font = new Font("Dubai Light", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(82, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(879, 33);
            txtSearch.TabIndex = 1;
            txtSearch.Text = "Cari lele bakar, goreng, ...";
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnSemua
            // 
            btnSemua.BackColor = Color.Tomato;
            btnSemua.Location = new Point(94, 190);
            btnSemua.Name = "btnSemua";
            btnSemua.Size = new Size(122, 39);
            btnSemua.TabIndex = 3;
            btnSemua.Text = "Semua";
            btnSemua.UseVisualStyleBackColor = false;
            btnSemua.TextChanged += btnSemua_Click;
            btnSemua.Click += btnSemua_Click;
            // 
            // btnMakanan
            // 
            btnMakanan.BackColor = Color.SlateGray;
            btnMakanan.Location = new Point(246, 190);
            btnMakanan.Name = "btnMakanan";
            btnMakanan.Size = new Size(122, 39);
            btnMakanan.TabIndex = 4;
            btnMakanan.Text = "Makanan";
            btnMakanan.UseVisualStyleBackColor = false;
            btnMakanan.Click += btnMakanan_Click;
            // 
            // btnMinuman
            // 
            btnMinuman.BackColor = Color.SlateGray;
            btnMinuman.Location = new Point(400, 190);
            btnMinuman.Name = "btnMinuman";
            btnMinuman.Size = new Size(122, 39);
            btnMinuman.TabIndex = 5;
            btnMinuman.Text = "Minuman";
            btnMinuman.UseVisualStyleBackColor = false;
            btnMinuman.Click += btnMinuman_Click;
            // 
            // panelAirMineral
            // 
            panelAirMineral.BackColor = Color.SlateGray;
            panelAirMineral.Controls.Add(lblstokairmineral);
            panelAirMineral.Controls.Add(button3);
            panelAirMineral.Controls.Add(label19);
            panelAirMineral.Controls.Add(label20);
            panelAirMineral.Controls.Add(pictureBox8);
            panelAirMineral.Controls.Add(label21);
            panelAirMineral.Location = new Point(781, 262);
            panelAirMineral.Margin = new Padding(2);
            panelAirMineral.Name = "panelAirMineral";
            panelAirMineral.Size = new Size(201, 200);
            panelAirMineral.TabIndex = 14;
            // 
            // lblstokairmineral
            // 
            lblstokairmineral.AutoSize = true;
            lblstokairmineral.Font = new Font("Dubai", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblstokairmineral.Location = new Point(45, 171);
            lblstokairmineral.Name = "lblstokairmineral";
            lblstokairmineral.Size = new Size(28, 25);
            lblstokairmineral.TabIndex = 13;
            lblstokairmineral.Text = "20";
            // 
            // button3
            // 
            button3.BackColor = Color.MidnightBlue;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Dubai", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(148, 151);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(28, 36);
            button3.TabIndex = 12;
            button3.TabStop = false;
            button3.Text = "+";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click_1;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Dubai Medium", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = Color.White;
            label19.Location = new Point(6, 172);
            label19.Margin = new Padding(2, 0, 2, 0);
            label19.Name = "label19";
            label19.Size = new Size(49, 24);
            label19.TabIndex = 8;
            label19.Text = "Stok: ";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Dubai", 10.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.ForeColor = Color.MidnightBlue;
            label20.Location = new Point(6, 151);
            label20.Margin = new Padding(2, 0, 2, 0);
            label20.Name = "label20";
            label20.Size = new Size(78, 25);
            label20.TabIndex = 9;
            label20.Text = "Rp. 12.000";
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = Color.Transparent;
            pictureBox8.BackgroundImage = (Image)resources.GetObject("pictureBox8.BackgroundImage");
            pictureBox8.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox8.Location = new Point(0, 0);
            pictureBox8.Margin = new Padding(2);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(201, 123);
            pictureBox8.TabIndex = 6;
            pictureBox8.TabStop = false;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Dubai Medium", 10.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.ForeColor = Color.White;
            label21.Location = new Point(6, 125);
            label21.Margin = new Padding(2, 0, 2, 0);
            label21.Name = "label21";
            label21.Size = new Size(94, 25);
            label21.TabIndex = 7;
            label21.Text = "Air Mineral";
            // 
            // panelEsJeruk
            // 
            panelEsJeruk.BackColor = Color.SlateGray;
            panelEsJeruk.Controls.Add(lblstokesjeruk);
            panelEsJeruk.Controls.Add(button4);
            panelEsJeruk.Controls.Add(label16);
            panelEsJeruk.Controls.Add(label17);
            panelEsJeruk.Controls.Add(pictureBox7);
            panelEsJeruk.Controls.Add(label18);
            panelEsJeruk.Location = new Point(1028, 262);
            panelEsJeruk.Margin = new Padding(2);
            panelEsJeruk.Name = "panelEsJeruk";
            panelEsJeruk.Size = new Size(201, 200);
            panelEsJeruk.TabIndex = 15;
            // 
            // lblstokesjeruk
            // 
            lblstokesjeruk.AutoSize = true;
            lblstokesjeruk.Font = new Font("Dubai", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblstokesjeruk.Location = new Point(48, 171);
            lblstokesjeruk.Name = "lblstokesjeruk";
            lblstokesjeruk.Size = new Size(28, 25);
            lblstokesjeruk.TabIndex = 14;
            lblstokesjeruk.Text = "20";
            // 
            // button4
            // 
            button4.BackColor = Color.MidnightBlue;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Dubai", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(151, 151);
            button4.Margin = new Padding(2);
            button4.Name = "button4";
            button4.Size = new Size(28, 36);
            button4.TabIndex = 13;
            button4.TabStop = false;
            button4.Text = "+";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click_1;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Dubai Medium", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.White;
            label16.Location = new Point(6, 172);
            label16.Margin = new Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new Size(49, 24);
            label16.TabIndex = 8;
            label16.Text = "Stok: ";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Dubai", 10.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.MidnightBlue;
            label17.Location = new Point(6, 151);
            label17.Margin = new Padding(2, 0, 2, 0);
            label17.Name = "label17";
            label17.Size = new Size(78, 25);
            label17.TabIndex = 9;
            label17.Text = "Rp. 12.000";
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.Transparent;
            pictureBox7.BackgroundImage = (Image)resources.GetObject("pictureBox7.BackgroundImage");
            pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox7.Location = new Point(0, 0);
            pictureBox7.Margin = new Padding(2);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(201, 123);
            pictureBox7.TabIndex = 6;
            pictureBox7.TabStop = false;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Dubai Medium", 10.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.White;
            label18.Location = new Point(6, 125);
            label18.Margin = new Padding(2, 0, 2, 0);
            label18.Name = "label18";
            label18.Size = new Size(72, 25);
            label18.TabIndex = 7;
            label18.Text = "Es Jeruk";
            // 
            // panelEsTeh
            // 
            panelEsTeh.BackColor = Color.SlateGray;
            panelEsTeh.Controls.Add(lblstokesteh);
            panelEsTeh.Controls.Add(button6);
            panelEsTeh.Controls.Add(label13);
            panelEsTeh.Controls.Add(label14);
            panelEsTeh.Controls.Add(pictureBox6);
            panelEsTeh.Controls.Add(label15);
            panelEsTeh.Location = new Point(64, 492);
            panelEsTeh.Margin = new Padding(2);
            panelEsTeh.Name = "panelEsTeh";
            panelEsTeh.Size = new Size(201, 200);
            panelEsTeh.TabIndex = 16;
            // 
            // lblstokesteh
            // 
            lblstokesteh.AutoSize = true;
            lblstokesteh.Font = new Font("Dubai", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblstokesteh.Location = new Point(47, 171);
            lblstokesteh.Name = "lblstokesteh";
            lblstokesteh.Size = new Size(28, 25);
            lblstokesteh.TabIndex = 14;
            lblstokesteh.Text = "20";
            // 
            // button6
            // 
            button6.BackColor = Color.MidnightBlue;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Font = new Font("Dubai", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(154, 151);
            button6.Margin = new Padding(2);
            button6.Name = "button6";
            button6.Size = new Size(28, 36);
            button6.TabIndex = 10;
            button6.TabStop = false;
            button6.Text = "+";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click_1;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Dubai Medium", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.White;
            label13.Location = new Point(6, 172);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(49, 24);
            label13.TabIndex = 8;
            label13.Text = "Stok: ";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Dubai", 10.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.MidnightBlue;
            label14.Location = new Point(6, 151);
            label14.Margin = new Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new Size(78, 25);
            label14.TabIndex = 9;
            label14.Text = "Rp. 12.000";
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.BackgroundImage = (Image)resources.GetObject("pictureBox6.BackgroundImage");
            pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox6.Location = new Point(0, 0);
            pictureBox6.Margin = new Padding(2);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(201, 123);
            pictureBox6.TabIndex = 6;
            pictureBox6.TabStop = false;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Dubai Medium", 10.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.White;
            label15.Location = new Point(6, 125);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(59, 25);
            label15.TabIndex = 7;
            label15.Text = "Es Teh";
            // 
            // panelMangutLele
            // 
            panelMangutLele.BackColor = Color.SlateGray;
            panelMangutLele.Controls.Add(lblstokmangutlele);
            panelMangutLele.Controls.Add(button2);
            panelMangutLele.Controls.Add(label10);
            panelMangutLele.Controls.Add(label11);
            panelMangutLele.Controls.Add(pictureBox5);
            panelMangutLele.Controls.Add(label12);
            panelMangutLele.Location = new Point(539, 262);
            panelMangutLele.Margin = new Padding(2);
            panelMangutLele.Name = "panelMangutLele";
            panelMangutLele.Size = new Size(201, 200);
            panelMangutLele.TabIndex = 17;
            // 
            // lblstokmangutlele
            // 
            lblstokmangutlele.AutoSize = true;
            lblstokmangutlele.Font = new Font("Dubai", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblstokmangutlele.Location = new Point(46, 171);
            lblstokmangutlele.Name = "lblstokmangutlele";
            lblstokmangutlele.Size = new Size(28, 25);
            lblstokmangutlele.TabIndex = 12;
            lblstokmangutlele.Text = "20";
            // 
            // button2
            // 
            button2.BackColor = Color.MidnightBlue;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Dubai", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(151, 151);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(28, 36);
            button2.TabIndex = 11;
            button2.TabStop = false;
            button2.Text = "+";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Dubai Medium", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(6, 172);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(49, 24);
            label10.TabIndex = 8;
            label10.Text = "Stok: ";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Dubai", 10.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.MidnightBlue;
            label11.Location = new Point(6, 151);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(78, 25);
            label11.TabIndex = 9;
            label11.Text = "Rp. 22.000";
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.BackgroundImage = (Image)resources.GetObject("pictureBox5.BackgroundImage");
            pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.Location = new Point(0, 0);
            pictureBox5.Margin = new Padding(2);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(201, 123);
            pictureBox5.TabIndex = 6;
            pictureBox5.TabStop = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Dubai Medium", 10.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.White;
            label12.Location = new Point(6, 125);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(100, 25);
            label12.TabIndex = 7;
            label12.Text = "Mangut Lele";
            // 
            // panelLeleBakar
            // 
            panelLeleBakar.BackColor = Color.SlateGray;
            panelLeleBakar.Controls.Add(labelstoklelebakar);
            panelLeleBakar.Controls.Add(button1);
            panelLeleBakar.Controls.Add(label7);
            panelLeleBakar.Controls.Add(label8);
            panelLeleBakar.Controls.Add(pictureBox2);
            panelLeleBakar.Controls.Add(label9);
            panelLeleBakar.Location = new Point(297, 262);
            panelLeleBakar.Margin = new Padding(2);
            panelLeleBakar.Name = "panelLeleBakar";
            panelLeleBakar.Size = new Size(201, 200);
            panelLeleBakar.TabIndex = 13;
            // 
            // labelstoklelebakar
            // 
            labelstoklelebakar.AutoSize = true;
            labelstoklelebakar.Font = new Font("Dubai", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelstoklelebakar.Location = new Point(47, 172);
            labelstoklelebakar.Name = "labelstoklelebakar";
            labelstoklelebakar.Size = new Size(28, 25);
            labelstoklelebakar.TabIndex = 11;
            labelstoklelebakar.Text = "20";
            // 
            // button1
            // 
            button1.BackColor = Color.MidnightBlue;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Dubai", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(154, 151);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(28, 36);
            button1.TabIndex = 10;
            button1.TabStop = false;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Dubai Medium", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(6, 172);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(49, 24);
            label7.TabIndex = 8;
            label7.Text = "Stok: ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Dubai", 10.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.MidnightBlue;
            label8.Location = new Point(6, 151);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(78, 25);
            label8.TabIndex = 9;
            label8.Text = "Rp. 18.000";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Margin = new Padding(2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(201, 123);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Dubai Medium", 10.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(6, 125);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(87, 25);
            label9.TabIndex = 7;
            label9.Text = "Lele Bakar";
            // 
            // panelLeleGoreng
            // 
            panelLeleGoreng.BackColor = Color.SlateGray;
            panelLeleGoreng.Controls.Add(lblstoklelegoreng);
            panelLeleGoreng.Controls.Add(button5);
            panelLeleGoreng.Controls.Add(label5);
            panelLeleGoreng.Controls.Add(label6);
            panelLeleGoreng.Controls.Add(pictureBox4);
            panelLeleGoreng.Controls.Add(label4);
            panelLeleGoreng.Location = new Point(64, 262);
            panelLeleGoreng.Margin = new Padding(2);
            panelLeleGoreng.Name = "panelLeleGoreng";
            panelLeleGoreng.Size = new Size(201, 200);
            panelLeleGoreng.TabIndex = 12;
            // 
            // lblstoklelegoreng
            // 
            lblstoklelegoreng.AutoSize = true;
            lblstoklelegoreng.Font = new Font("Dubai", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblstoklelegoreng.Location = new Point(49, 172);
            lblstoklelegoreng.Name = "lblstoklelegoreng";
            lblstoklelegoreng.Size = new Size(28, 25);
            lblstoklelegoreng.TabIndex = 10;
            lblstoklelegoreng.Text = "20";
            // 
            // button5
            // 
            button5.BackColor = Color.MidnightBlue;
            button5.FlatStyle = FlatStyle.Popup;
            button5.Font = new Font("Dubai", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(154, 151);
            button5.Margin = new Padding(2);
            button5.Name = "button5";
            button5.Size = new Size(28, 36);
            button5.TabIndex = 8;
            button5.TabStop = false;
            button5.Text = "+";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Dubai Medium", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(6, 172);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(49, 24);
            label5.TabIndex = 8;
            label5.Text = "Stok: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Dubai", 10.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.MidnightBlue;
            label6.Location = new Point(6, 151);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(78, 25);
            label6.TabIndex = 9;
            label6.Text = "Rp. 12.000";
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Location = new Point(0, 0);
            pictureBox4.Margin = new Padding(2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(201, 123);
            pictureBox4.TabIndex = 6;
            pictureBox4.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Dubai Medium", 10.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(6, 125);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(99, 25);
            label4.TabIndex = 7;
            label4.Text = "Lele Goreng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Dubai Medium", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Silver;
            label3.Location = new Point(39, 232);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(104, 27);
            label3.TabIndex = 11;
            label3.Text = "Pilih Produk";
            // 
            // DashboardPelanggan
            // 
            AutoScaleDimensions = new SizeF(10F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlText;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1370, 749);
            Controls.Add(panelAirMineral);
            Controls.Add(panelEsJeruk);
            Controls.Add(panelEsTeh);
            Controls.Add(panelMangutLele);
            Controls.Add(panelLeleBakar);
            Controls.Add(panelLeleGoreng);
            Controls.Add(label3);
            Controls.Add(btnMinuman);
            Controls.Add(btnMakanan);
            Controls.Add(btnSemua);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Dubai Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            Margin = new Padding(4, 5, 4, 5);
            Name = "DashboardPelanggan";
            Text = "DashboardPelanggan";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelAirMineral.ResumeLayout(false);
            panelAirMineral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            panelEsJeruk.ResumeLayout(false);
            panelEsJeruk.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            panelEsTeh.ResumeLayout(false);
            panelEsTeh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panelMangutLele.ResumeLayout(false);
            panelMangutLele.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panelLeleBakar.ResumeLayout(false);
            panelLeleBakar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelLeleGoreng.ResumeLayout(false);
            panelLeleGoreng.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label CFMART;
        private Button btnKatalog;
        private Button btnKeranjang;
        private Button btnCheckout;
        private Panel panel2;
        private PictureBox pictureBox1;
        private TextBox txtSearch;
        private Button btnSemua;
        private Button btnMakanan;
        private Button btnMinuman;
        private PictureBox pictureBox3;
        private Panel panelAirMineral;
        private Label label19;
        private Label label20;
        private PictureBox pictureBox8;
        private Label label21;
        private Panel panelEsJeruk;
        private Label label16;
        private Label label17;
        private PictureBox pictureBox7;
        private Label label18;
        private Panel panelEsTeh;
        private Label label13;
        private Label label14;
        private PictureBox pictureBox6;
        private Label label15;
        private Panel panelMangutLele;
        private Label label10;
        private Label label11;
        private PictureBox pictureBox5;
        private Label label12;
        private Panel panelLeleBakar;
        private Label label7;
        private Label label8;
        private PictureBox pictureBox2;
        private Label label9;
        private Panel panelLeleGoreng;
        private Button button5;
        private Label label5;
        private Label label6;
        private PictureBox pictureBox4;
        private Label label4;
        private Label label3;
        private Button button3;
        private Button button4;
        private Button button2;
        private Button button1;
        private Button button6;
        private Label lblstokairmineral;
        private Label lblstokesjeruk;
        private Label lblstokesteh;
        private Label lblstokmangutlele;
        private Label labelstoklelebakar;
        private Label lblstoklelegoreng;

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
  
};