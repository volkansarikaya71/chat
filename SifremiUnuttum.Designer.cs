namespace vssms
{
    partial class SifremiUnuttum
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
            this.eposta_label = new System.Windows.Forms.Label();
            this.Eposta_text = new System.Windows.Forms.TextBox();
            this.securitycode_label = new System.Windows.Forms.Label();
            this.securitycode_text = new System.Windows.Forms.TextBox();
            this.SifreYenile_label = new System.Windows.Forms.Label();
            this.sifre_label = new System.Windows.Forms.Label();
            this.sifre_text = new System.Windows.Forms.TextBox();
            this.Eposta_send_img = new System.Windows.Forms.PictureBox();
            this.sifre_img = new System.Windows.Forms.PictureBox();
            this.geri_img = new System.Windows.Forms.PictureBox();
            this.eposta_img = new System.Windows.Forms.PictureBox();
            this.securitycode_img = new System.Windows.Forms.PictureBox();
            this.save_img = new System.Windows.Forms.PictureBox();
            this.kullaniciisim_img = new System.Windows.Forms.PictureBox();
            this.Sifreyi_Goster_Gizle_img = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Eposta_send_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sifre_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.geri_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eposta_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.securitycode_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.save_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kullaniciisim_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sifreyi_Goster_Gizle_img)).BeginInit();
            this.SuspendLayout();
            // 
            // eposta_label
            // 
            this.eposta_label.AutoSize = true;
            this.eposta_label.Location = new System.Drawing.Point(338, 268);
            this.eposta_label.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.eposta_label.Name = "eposta_label";
            this.eposta_label.Size = new System.Drawing.Size(173, 36);
            this.eposta_label.TabIndex = 41;
            this.eposta_label.Text = "E-posta Adresiniz:";
            // 
            // Eposta_text
            // 
            this.Eposta_text.Font = new System.Drawing.Font("Adobe Caslon Pro", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Eposta_text.Location = new System.Drawing.Point(533, 265);
            this.Eposta_text.Margin = new System.Windows.Forms.Padding(12, 22, 12, 22);
            this.Eposta_text.MaxLength = 100;
            this.Eposta_text.Name = "Eposta_text";
            this.Eposta_text.Size = new System.Drawing.Size(287, 33);
            this.Eposta_text.TabIndex = 40;
            // 
            // securitycode_label
            // 
            this.securitycode_label.AutoSize = true;
            this.securitycode_label.Location = new System.Drawing.Point(364, 399);
            this.securitycode_label.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.securitycode_label.Name = "securitycode_label";
            this.securitycode_label.Size = new System.Drawing.Size(145, 36);
            this.securitycode_label.TabIndex = 37;
            this.securitycode_label.Text = "Güvenlik kodu:";
            this.securitycode_label.Visible = false;
            // 
            // securitycode_text
            // 
            this.securitycode_text.Font = new System.Drawing.Font("Adobe Caslon Pro", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.securitycode_text.Location = new System.Drawing.Point(533, 399);
            this.securitycode_text.Margin = new System.Windows.Forms.Padding(12, 22, 12, 22);
            this.securitycode_text.MaxLength = 6;
            this.securitycode_text.Name = "securitycode_text";
            this.securitycode_text.Size = new System.Drawing.Size(287, 33);
            this.securitycode_text.TabIndex = 36;
            this.securitycode_text.Visible = false;
            // 
            // SifreYenile_label
            // 
            this.SifreYenile_label.AutoSize = true;
            this.SifreYenile_label.Location = new System.Drawing.Point(590, 192);
            this.SifreYenile_label.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.SifreYenile_label.Name = "SifreYenile_label";
            this.SifreYenile_label.Size = new System.Drawing.Size(136, 36);
            this.SifreYenile_label.TabIndex = 33;
            this.SifreYenile_label.Text = "Şifremi Sıfırla";
            // 
            // sifre_label
            // 
            this.sifre_label.AutoSize = true;
            this.sifre_label.Location = new System.Drawing.Point(364, 446);
            this.sifre_label.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.sifre_label.Name = "sifre_label";
            this.sifre_label.Size = new System.Drawing.Size(87, 36);
            this.sifre_label.TabIndex = 49;
            this.sifre_label.Text = "Sifreniz:";
            this.sifre_label.Visible = false;
            // 
            // sifre_text
            // 
            this.sifre_text.Font = new System.Drawing.Font("Adobe Caslon Pro", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sifre_text.Location = new System.Drawing.Point(533, 446);
            this.sifre_text.Margin = new System.Windows.Forms.Padding(12, 22, 12, 22);
            this.sifre_text.MaxLength = 50;
            this.sifre_text.Name = "sifre_text";
            this.sifre_text.Size = new System.Drawing.Size(287, 33);
            this.sifre_text.TabIndex = 48;
            this.sifre_text.UseSystemPasswordChar = true;
            this.sifre_text.Visible = false;
            // 
            // Eposta_send_img
            // 
            this.Eposta_send_img.Image = global::vssms.Properties.Resources.Eposta_yolla;
            this.Eposta_send_img.Location = new System.Drawing.Point(635, 311);
            this.Eposta_send_img.Margin = new System.Windows.Forms.Padding(12, 22, 12, 22);
            this.Eposta_send_img.Name = "Eposta_send_img";
            this.Eposta_send_img.Size = new System.Drawing.Size(62, 44);
            this.Eposta_send_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Eposta_send_img.TabIndex = 51;
            this.Eposta_send_img.TabStop = false;
            this.Eposta_send_img.Click += new System.EventHandler(this.Eposta_send_img_Click);
            // 
            // sifre_img
            // 
            this.sifre_img.Image = global::vssms.Properties.Resources.password_add;
            this.sifre_img.Location = new System.Drawing.Point(304, 432);
            this.sifre_img.Margin = new System.Windows.Forms.Padding(12, 22, 12, 22);
            this.sifre_img.Name = "sifre_img";
            this.sifre_img.Size = new System.Drawing.Size(62, 44);
            this.sifre_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sifre_img.TabIndex = 50;
            this.sifre_img.TabStop = false;
            this.sifre_img.Visible = false;
            // 
            // geri_img
            // 
            this.geri_img.Image = global::vssms.Properties.Resources.geri;
            this.geri_img.Location = new System.Drawing.Point(21, 18);
            this.geri_img.Margin = new System.Windows.Forms.Padding(12, 22, 12, 22);
            this.geri_img.Name = "geri_img";
            this.geri_img.Size = new System.Drawing.Size(62, 44);
            this.geri_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.geri_img.TabIndex = 47;
            this.geri_img.TabStop = false;
            this.geri_img.Click += new System.EventHandler(this.geri_img_Click);
            // 
            // eposta_img
            // 
            this.eposta_img.Image = global::vssms.Properties.Resources.email;
            this.eposta_img.Location = new System.Drawing.Point(278, 254);
            this.eposta_img.Margin = new System.Windows.Forms.Padding(12, 22, 12, 22);
            this.eposta_img.Name = "eposta_img";
            this.eposta_img.Size = new System.Drawing.Size(62, 44);
            this.eposta_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.eposta_img.TabIndex = 46;
            this.eposta_img.TabStop = false;
            // 
            // securitycode_img
            // 
            this.securitycode_img.Image = global::vssms.Properties.Resources.SecurityCode;
            this.securitycode_img.Location = new System.Drawing.Point(304, 385);
            this.securitycode_img.Margin = new System.Windows.Forms.Padding(12, 22, 12, 22);
            this.securitycode_img.Name = "securitycode_img";
            this.securitycode_img.Size = new System.Drawing.Size(62, 44);
            this.securitycode_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.securitycode_img.TabIndex = 44;
            this.securitycode_img.TabStop = false;
            this.securitycode_img.Visible = false;
            // 
            // save_img
            // 
            this.save_img.Image = global::vssms.Properties.Resources.save;
            this.save_img.Location = new System.Drawing.Point(877, 513);
            this.save_img.Margin = new System.Windows.Forms.Padding(12, 22, 12, 22);
            this.save_img.Name = "save_img";
            this.save_img.Size = new System.Drawing.Size(133, 91);
            this.save_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.save_img.TabIndex = 42;
            this.save_img.TabStop = false;
            this.save_img.Visible = false;
            this.save_img.Click += new System.EventHandler(this.save_img_Click);
            // 
            // kullaniciisim_img
            // 
            this.kullaniciisim_img.Image = global::vssms.Properties.Resources.Sifre_Sifirlama;
            this.kullaniciisim_img.Location = new System.Drawing.Point(504, 7);
            this.kullaniciisim_img.Margin = new System.Windows.Forms.Padding(12, 22, 12, 22);
            this.kullaniciisim_img.Name = "kullaniciisim_img";
            this.kullaniciisim_img.Size = new System.Drawing.Size(287, 163);
            this.kullaniciisim_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.kullaniciisim_img.TabIndex = 32;
            this.kullaniciisim_img.TabStop = false;
            // 
            // Sifreyi_Goster_Gizle_img
            // 
            this.Sifreyi_Goster_Gizle_img.Image = global::vssms.Properties.Resources.goster;
            this.Sifreyi_Goster_Gizle_img.Location = new System.Drawing.Point(838, 442);
            this.Sifreyi_Goster_Gizle_img.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Sifreyi_Goster_Gizle_img.Name = "Sifreyi_Goster_Gizle_img";
            this.Sifreyi_Goster_Gizle_img.Size = new System.Drawing.Size(32, 40);
            this.Sifreyi_Goster_Gizle_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Sifreyi_Goster_Gizle_img.TabIndex = 52;
            this.Sifreyi_Goster_Gizle_img.TabStop = false;
            this.Sifreyi_Goster_Gizle_img.Visible = false;
            this.Sifreyi_Goster_Gizle_img.Click += new System.EventHandler(this.Sifreyi_Goster_Gizle_img_Click);
            // 
            // SifremiUnuttum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.Sifreyi_Goster_Gizle_img);
            this.Controls.Add(this.Eposta_send_img);
            this.Controls.Add(this.sifre_img);
            this.Controls.Add(this.sifre_label);
            this.Controls.Add(this.sifre_text);
            this.Controls.Add(this.geri_img);
            this.Controls.Add(this.eposta_img);
            this.Controls.Add(this.securitycode_img);
            this.Controls.Add(this.save_img);
            this.Controls.Add(this.eposta_label);
            this.Controls.Add(this.Eposta_text);
            this.Controls.Add(this.securitycode_label);
            this.Controls.Add(this.securitycode_text);
            this.Controls.Add(this.SifreYenile_label);
            this.Controls.Add(this.kullaniciisim_img);
            this.Font = new System.Drawing.Font("Adobe Caslon Pro", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "SifremiUnuttum";
            this.Text = "SifremiUnuttum";
            this.Load += new System.EventHandler(this.SifremiUnuttum_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Eposta_send_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sifre_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.geri_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eposta_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.securitycode_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.save_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kullaniciisim_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sifreyi_Goster_Gizle_img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox geri_img;
        private System.Windows.Forms.PictureBox eposta_img;
        private System.Windows.Forms.PictureBox securitycode_img;
        private System.Windows.Forms.PictureBox save_img;
        private System.Windows.Forms.Label eposta_label;
        private System.Windows.Forms.TextBox Eposta_text;
        private System.Windows.Forms.Label securitycode_label;
        private System.Windows.Forms.TextBox securitycode_text;
        private System.Windows.Forms.Label SifreYenile_label;
        private System.Windows.Forms.PictureBox kullaniciisim_img;
        private System.Windows.Forms.PictureBox sifre_img;
        private System.Windows.Forms.Label sifre_label;
        private System.Windows.Forms.TextBox sifre_text;
        private System.Windows.Forms.PictureBox Eposta_send_img;
        private System.Windows.Forms.PictureBox Sifreyi_Goster_Gizle_img;
    }
}