namespace vssms
{
    partial class Chat
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
            this.Msj_text = new System.Windows.Forms.TextBox();
            this.Sms_atilan_kullanici_adi_label = new System.Windows.Forms.Label();
            this.Resim_Sec = new System.Windows.Forms.OpenFileDialog();
            this.Video_Sec = new System.Windows.Forms.OpenFileDialog();
            this.online_mi_label = new System.Windows.Forms.Label();
            this.timer_label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Winrar_Sec = new System.Windows.Forms.OpenFileDialog();
            this.Winrar_Kaydet = new System.Windows.Forms.SaveFileDialog();
            this.emoji_img = new System.Windows.Forms.PictureBox();
            this.winrar_ekle_img = new System.Windows.Forms.PictureBox();
            this.Ses_kaydi_img = new System.Windows.Forms.PictureBox();
            this.video_ekle_img = new System.Windows.Forms.PictureBox();
            this.Resim_ekle_img = new System.Windows.Forms.PictureBox();
            this.geri_img = new System.Windows.Forms.PictureBox();
            this.Msj_Gonder_img = new System.Windows.Forms.PictureBox();
            this.Sms_atilan_kullanici_resmi_img = new System.Windows.Forms.PictureBox();
            this.emoji_panel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.emoji_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winrar_ekle_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ses_kaydi_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.video_ekle_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Resim_ekle_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.geri_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Msj_Gonder_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sms_atilan_kullanici_resmi_img)).BeginInit();
            this.SuspendLayout();
            // 
            // Msj_text
            // 
            this.Msj_text.Location = new System.Drawing.Point(12, 454);
            this.Msj_text.Multiline = true;
            this.Msj_text.Name = "Msj_text";
            this.Msj_text.Size = new System.Drawing.Size(1030, 108);
            this.Msj_text.TabIndex = 12;
            this.Msj_text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Msj_text_KeyPress);
            // 
            // Sms_atilan_kullanici_adi_label
            // 
            this.Sms_atilan_kullanici_adi_label.AutoSize = true;
            this.Sms_atilan_kullanici_adi_label.Location = new System.Drawing.Point(868, 35);
            this.Sms_atilan_kullanici_adi_label.Name = "Sms_atilan_kullanici_adi_label";
            this.Sms_atilan_kullanici_adi_label.Size = new System.Drawing.Size(65, 36);
            this.Sms_atilan_kullanici_adi_label.TabIndex = 13;
            this.Sms_atilan_kullanici_adi_label.Text = "label1";
            // 
            // Resim_Sec
            // 
            this.Resim_Sec.FileName = "openFileDialog1";
            // 
            // Video_Sec
            // 
            this.Video_Sec.FileName = "openFileDialog2";
            // 
            // online_mi_label
            // 
            this.online_mi_label.AutoSize = true;
            this.online_mi_label.Location = new System.Drawing.Point(400, 44);
            this.online_mi_label.Name = "online_mi_label";
            this.online_mi_label.Size = new System.Drawing.Size(76, 36);
            this.online_mi_label.TabIndex = 39;
            this.online_mi_label.Text = "Zaman";
            // 
            // timer_label
            // 
            this.timer_label.AutoSize = true;
            this.timer_label.Location = new System.Drawing.Point(890, 565);
            this.timer_label.Name = "timer_label";
            this.timer_label.Size = new System.Drawing.Size(53, 36);
            this.timer_label.TabIndex = 40;
            this.timer_label.Text = "0.00";
            this.timer_label.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Winrar_Sec
            // 
            this.Winrar_Sec.FileName = "openFileDialog3";
            // 
            // emoji_img
            // 
            this.emoji_img.BackColor = System.Drawing.SystemColors.ControlDark;
            this.emoji_img.Image = global::vssms.Properties.Resources.emoji;
            this.emoji_img.Location = new System.Drawing.Point(800, 530);
            this.emoji_img.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.emoji_img.Name = "emoji_img";
            this.emoji_img.Size = new System.Drawing.Size(36, 32);
            this.emoji_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.emoji_img.TabIndex = 43;
            this.emoji_img.TabStop = false;
            this.emoji_img.Click += new System.EventHandler(this.emoji_img_Click);
            // 
            // winrar_ekle_img
            // 
            this.winrar_ekle_img.BackColor = System.Drawing.SystemColors.ControlDark;
            this.winrar_ekle_img.Image = global::vssms.Properties.Resources.winrar;
            this.winrar_ekle_img.Location = new System.Drawing.Point(848, 530);
            this.winrar_ekle_img.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.winrar_ekle_img.Name = "winrar_ekle_img";
            this.winrar_ekle_img.Size = new System.Drawing.Size(36, 32);
            this.winrar_ekle_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.winrar_ekle_img.TabIndex = 41;
            this.winrar_ekle_img.TabStop = false;
            this.winrar_ekle_img.Click += new System.EventHandler(this.winrar_ekle_img_Click);
            // 
            // Ses_kaydi_img
            // 
            this.Ses_kaydi_img.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Ses_kaydi_img.Image = global::vssms.Properties.Resources.mikrofon;
            this.Ses_kaydi_img.Location = new System.Drawing.Point(896, 530);
            this.Ses_kaydi_img.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Ses_kaydi_img.Name = "Ses_kaydi_img";
            this.Ses_kaydi_img.Size = new System.Drawing.Size(36, 32);
            this.Ses_kaydi_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Ses_kaydi_img.TabIndex = 38;
            this.Ses_kaydi_img.TabStop = false;
            this.Ses_kaydi_img.Click += new System.EventHandler(this.Ses_kaydi_img_Click);
            // 
            // video_ekle_img
            // 
            this.video_ekle_img.Image = global::vssms.Properties.Resources.video1;
            this.video_ekle_img.Location = new System.Drawing.Point(992, 530);
            this.video_ekle_img.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.video_ekle_img.Name = "video_ekle_img";
            this.video_ekle_img.Size = new System.Drawing.Size(36, 32);
            this.video_ekle_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.video_ekle_img.TabIndex = 37;
            this.video_ekle_img.TabStop = false;
            this.video_ekle_img.Click += new System.EventHandler(this.video_ekle_img_Click);
            // 
            // Resim_ekle_img
            // 
            this.Resim_ekle_img.Image = global::vssms.Properties.Resources.resim_ekle1;
            this.Resim_ekle_img.Location = new System.Drawing.Point(944, 530);
            this.Resim_ekle_img.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Resim_ekle_img.Name = "Resim_ekle_img";
            this.Resim_ekle_img.Size = new System.Drawing.Size(36, 32);
            this.Resim_ekle_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Resim_ekle_img.TabIndex = 36;
            this.Resim_ekle_img.TabStop = false;
            this.Resim_ekle_img.Click += new System.EventHandler(this.Resim_ekle_img_Click);
            // 
            // geri_img
            // 
            this.geri_img.Image = global::vssms.Properties.Resources.geri;
            this.geri_img.Location = new System.Drawing.Point(12, 6);
            this.geri_img.Margin = new System.Windows.Forms.Padding(12, 22, 12, 22);
            this.geri_img.Name = "geri_img";
            this.geri_img.Size = new System.Drawing.Size(62, 44);
            this.geri_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.geri_img.TabIndex = 32;
            this.geri_img.TabStop = false;
            this.geri_img.Click += new System.EventHandler(this.geri_img_Click);
            // 
            // Msj_Gonder_img
            // 
            this.Msj_Gonder_img.Image = global::vssms.Properties.Resources.Sms_Gonder;
            this.Msj_Gonder_img.Location = new System.Drawing.Point(1040, 454);
            this.Msj_Gonder_img.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Msj_Gonder_img.Name = "Msj_Gonder_img";
            this.Msj_Gonder_img.Size = new System.Drawing.Size(212, 108);
            this.Msj_Gonder_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Msj_Gonder_img.TabIndex = 11;
            this.Msj_Gonder_img.TabStop = false;
            this.Msj_Gonder_img.Click += new System.EventHandler(this.Msj_Gonder_img_Click);
            // 
            // Sms_atilan_kullanici_resmi_img
            // 
            this.Sms_atilan_kullanici_resmi_img.Image = global::vssms.Properties.Resources.user_ping;
            this.Sms_atilan_kullanici_resmi_img.Location = new System.Drawing.Point(1040, 6);
            this.Sms_atilan_kullanici_resmi_img.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Sms_atilan_kullanici_resmi_img.Name = "Sms_atilan_kullanici_resmi_img";
            this.Sms_atilan_kullanici_resmi_img.Size = new System.Drawing.Size(201, 108);
            this.Sms_atilan_kullanici_resmi_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Sms_atilan_kullanici_resmi_img.TabIndex = 10;
            this.Sms_atilan_kullanici_resmi_img.TabStop = false;
            // 
            // emoji_panel
            // 
            this.emoji_panel.AutoScroll = true;
            this.emoji_panel.Location = new System.Drawing.Point(13, 573);
            this.emoji_panel.Name = "emoji_panel";
            this.emoji_panel.Size = new System.Drawing.Size(1029, 100);
            this.emoji_panel.TabIndex = 44;
            this.emoji_panel.Visible = false;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.emoji_panel);
            this.Controls.Add(this.emoji_img);
            this.Controls.Add(this.winrar_ekle_img);
            this.Controls.Add(this.timer_label);
            this.Controls.Add(this.online_mi_label);
            this.Controls.Add(this.Ses_kaydi_img);
            this.Controls.Add(this.video_ekle_img);
            this.Controls.Add(this.Resim_ekle_img);
            this.Controls.Add(this.geri_img);
            this.Controls.Add(this.Sms_atilan_kullanici_adi_label);
            this.Controls.Add(this.Msj_text);
            this.Controls.Add(this.Msj_Gonder_img);
            this.Controls.Add(this.Sms_atilan_kullanici_resmi_img);
            this.Font = new System.Drawing.Font("Adobe Caslon Pro", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "Chat";
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.Chat_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Chat_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.emoji_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winrar_ekle_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ses_kaydi_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.video_ekle_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Resim_ekle_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.geri_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Msj_Gonder_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sms_atilan_kullanici_resmi_img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox Sms_atilan_kullanici_resmi_img;
        private System.Windows.Forms.PictureBox Msj_Gonder_img;
        private System.Windows.Forms.TextBox Msj_text;
        private System.Windows.Forms.Label Sms_atilan_kullanici_adi_label;
        private System.Windows.Forms.PictureBox geri_img;
        private System.Windows.Forms.PictureBox Resim_ekle_img;
        private System.Windows.Forms.OpenFileDialog Resim_Sec;
        private System.Windows.Forms.PictureBox video_ekle_img;
        private System.Windows.Forms.PictureBox Ses_kaydi_img;
        private System.Windows.Forms.OpenFileDialog Video_Sec;
        private System.Windows.Forms.Label online_mi_label;
        private System.Windows.Forms.Label timer_label;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox winrar_ekle_img;
        private System.Windows.Forms.OpenFileDialog Winrar_Sec;
        private System.Windows.Forms.SaveFileDialog Winrar_Kaydet;
        private System.Windows.Forms.PictureBox emoji_img;
        private System.Windows.Forms.FlowLayoutPanel emoji_panel;
    }
}