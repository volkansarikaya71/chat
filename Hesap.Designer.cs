namespace vssms
{
    partial class Hesap
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
            this.components = new System.ComponentModel.Container();
            this.ArkadasEkle_btn = new System.Windows.Forms.Button();
            this.Numara_text = new System.Windows.Forms.TextBox();
            this.numara_label = new System.Windows.Forms.Label();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.resim_guncelle = new System.Windows.Forms.PictureBox();
            this.numara_img = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kullanici_img = new System.Windows.Forms.PictureBox();
            this.kullanici_name_text = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resim_guncelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numara_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kullanici_img)).BeginInit();
            this.SuspendLayout();
            // 
            // ArkadasEkle_btn
            // 
            this.ArkadasEkle_btn.Location = new System.Drawing.Point(509, 213);
            this.ArkadasEkle_btn.Name = "ArkadasEkle_btn";
            this.ArkadasEkle_btn.Size = new System.Drawing.Size(201, 35);
            this.ArkadasEkle_btn.TabIndex = 12;
            this.ArkadasEkle_btn.Text = "Arkadas Ekle";
            this.ArkadasEkle_btn.UseVisualStyleBackColor = true;
            this.ArkadasEkle_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Numara_text
            // 
            this.Numara_text.Location = new System.Drawing.Point(509, 174);
            this.Numara_text.MaxLength = 11;
            this.Numara_text.Name = "Numara_text";
            this.Numara_text.Size = new System.Drawing.Size(201, 33);
            this.Numara_text.TabIndex = 13;
            this.Numara_text.Visible = false;
            this.Numara_text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Numara_text_KeyPress);
            // 
            // numara_label
            // 
            this.numara_label.AutoSize = true;
            this.numara_label.Location = new System.Drawing.Point(353, 177);
            this.numara_label.Name = "numara_label";
            this.numara_label.Size = new System.Drawing.Size(150, 36);
            this.numara_label.TabIndex = 14;
            this.numara_label.Text = "Numara giriniz:";
            this.numara_label.Visible = false;
            // 
            // ımageList1
            // 
            this.ımageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ımageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::vssms.Properties.Resources.isim_degis;
            this.pictureBox2.Location = new System.Drawing.Point(665, 125);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // resim_guncelle
            // 
            this.resim_guncelle.Image = global::vssms.Properties.Resources.resmi_guncelle;
            this.resim_guncelle.Location = new System.Drawing.Point(509, 125);
            this.resim_guncelle.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.resim_guncelle.Name = "resim_guncelle";
            this.resim_guncelle.Size = new System.Drawing.Size(42, 38);
            this.resim_guncelle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.resim_guncelle.TabIndex = 16;
            this.resim_guncelle.TabStop = false;
            this.resim_guncelle.Click += new System.EventHandler(this.resim_guncelle_Click);
            // 
            // numara_img
            // 
            this.numara_img.Image = global::vssms.Properties.Resources.number;
            this.numara_img.Location = new System.Drawing.Point(287, 158);
            this.numara_img.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.numara_img.Name = "numara_img";
            this.numara_img.Size = new System.Drawing.Size(66, 55);
            this.numara_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.numara_img.TabIndex = 15;
            this.numara_img.TabStop = false;
            this.numara_img.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::vssms.Properties.Resources.cikis;
            this.pictureBox1.Location = new System.Drawing.Point(1159, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // kullanici_img
            // 
            this.kullanici_img.Image = global::vssms.Properties.Resources.user_ping;
            this.kullanici_img.Location = new System.Drawing.Point(509, 9);
            this.kullanici_img.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.kullanici_img.Name = "kullanici_img";
            this.kullanici_img.Size = new System.Drawing.Size(201, 108);
            this.kullanici_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.kullanici_img.TabIndex = 9;
            this.kullanici_img.TabStop = false;
            // 
            // kullanici_name_text
            // 
            this.kullanici_name_text.Enabled = false;
            this.kullanici_name_text.Location = new System.Drawing.Point(552, 128);
            this.kullanici_name_text.MaxLength = 30;
            this.kullanici_name_text.Name = "kullanici_name_text";
            this.kullanici_name_text.Size = new System.Drawing.Size(113, 33);
            this.kullanici_name_text.TabIndex = 18;
            this.kullanici_name_text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kullanici_name_text_KeyPress);
            // 
            // Hesap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.kullanici_name_text);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.resim_guncelle);
            this.Controls.Add(this.numara_img);
            this.Controls.Add(this.numara_label);
            this.Controls.Add(this.Numara_text);
            this.Controls.Add(this.ArkadasEkle_btn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.kullanici_img);
            this.Font = new System.Drawing.Font("Adobe Caslon Pro", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "Hesap";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Hesap_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Hesap_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resim_guncelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numara_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kullanici_img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox kullanici_img;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ArkadasEkle_btn;
        private System.Windows.Forms.TextBox Numara_text;
        private System.Windows.Forms.Label numara_label;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.PictureBox numara_img;
        private System.Windows.Forms.PictureBox resim_guncelle;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox kullanici_name_text;
    }
}