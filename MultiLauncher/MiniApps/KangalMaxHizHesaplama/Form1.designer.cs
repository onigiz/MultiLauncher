namespace MultiLauncher.MiniApps.KangalMaxHizHesaplama
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_BaslangicHizlanmaSure = new System.Windows.Forms.TextBox();
            this.txt_BitisYavaslamaSure = new System.Windows.Forms.TextBox();
            this.txt_ToplamSure = new System.Windows.Forms.TextBox();
            this.txt_ToplamBoy = new System.Windows.Forms.TextBox();
            this.btn_Hesapla = new System.Windows.Forms.Button();
            this.lbl_MaximumHiz = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Baslik = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Başlangıç Hızlanma Süresi (sn):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bitiş Yavaşlama Süresi (sn):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Toplam Süre (sn):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Toplam Boy (m):";
            // 
            // txt_BaslangicHizlanmaSure
            // 
            this.txt_BaslangicHizlanmaSure.Location = new System.Drawing.Point(198, 56);
            this.txt_BaslangicHizlanmaSure.Name = "txt_BaslangicHizlanmaSure";
            this.txt_BaslangicHizlanmaSure.Size = new System.Drawing.Size(100, 20);
            this.txt_BaslangicHizlanmaSure.TabIndex = 4;
            // 
            // txt_BitisYavaslamaSure
            // 
            this.txt_BitisYavaslamaSure.Location = new System.Drawing.Point(198, 82);
            this.txt_BitisYavaslamaSure.Name = "txt_BitisYavaslamaSure";
            this.txt_BitisYavaslamaSure.Size = new System.Drawing.Size(100, 20);
            this.txt_BitisYavaslamaSure.TabIndex = 5;
            // 
            // txt_ToplamSure
            // 
            this.txt_ToplamSure.Location = new System.Drawing.Point(198, 108);
            this.txt_ToplamSure.Name = "txt_ToplamSure";
            this.txt_ToplamSure.Size = new System.Drawing.Size(100, 20);
            this.txt_ToplamSure.TabIndex = 6;
            // 
            // txt_ToplamBoy
            // 
            this.txt_ToplamBoy.Location = new System.Drawing.Point(198, 134);
            this.txt_ToplamBoy.Name = "txt_ToplamBoy";
            this.txt_ToplamBoy.Size = new System.Drawing.Size(100, 20);
            this.txt_ToplamBoy.TabIndex = 7;
            // 
            // btn_Hesapla
            // 
            this.btn_Hesapla.Location = new System.Drawing.Point(198, 160);
            this.btn_Hesapla.Name = "btn_Hesapla";
            this.btn_Hesapla.Size = new System.Drawing.Size(100, 23);
            this.btn_Hesapla.TabIndex = 8;
            this.btn_Hesapla.Text = "Hesapla";
            this.btn_Hesapla.UseVisualStyleBackColor = true;
            this.btn_Hesapla.Click += new System.EventHandler(this.btn_Hesapla_Click);
            // 
            // lbl_MaximumHiz
            // 
            this.lbl_MaximumHiz.AutoSize = true;
            this.lbl_MaximumHiz.Location = new System.Drawing.Point(198, 198);
            this.lbl_MaximumHiz.Name = "lbl_MaximumHiz";
            this.lbl_MaximumHiz.Size = new System.Drawing.Size(13, 13);
            this.lbl_MaximumHiz.TabIndex = 9;
            this.lbl_MaximumHiz.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Maximum Hız (m/dk):";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // Baslik
            // 
            this.Baslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Baslik.ForeColor = System.Drawing.Color.DarkRed;
            this.Baslik.Location = new System.Drawing.Point(144, 15);
            this.Baslik.Name = "Baslik";
            this.Baslik.Size = new System.Drawing.Size(211, 27);
            this.Baslik.TabIndex = 20;
            this.Baslik.Text = "Kangal Max. Hız Hesabı";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(350, 232);
            this.Controls.Add(this.Baslik);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_MaximumHiz);
            this.Controls.Add(this.btn_Hesapla);
            this.Controls.Add(this.txt_ToplamBoy);
            this.Controls.Add(this.txt_ToplamSure);
            this.Controls.Add(this.txt_BitisYavaslamaSure);
            this.Controls.Add(this.txt_BaslangicHizlanmaSure);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Hız Hesaplama";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_BaslangicHizlanmaSure;
        private System.Windows.Forms.TextBox txt_BitisYavaslamaSure;
        private System.Windows.Forms.TextBox txt_ToplamSure;
        private System.Windows.Forms.TextBox txt_ToplamBoy;
        private System.Windows.Forms.Button btn_Hesapla;
        private System.Windows.Forms.Label lbl_MaximumHiz;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Baslik;
    }
}
