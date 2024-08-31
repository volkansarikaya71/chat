using AxWMPLib;
using MySql.Data.MySqlClient;
using Mysqlx.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WMPLib;
using vssms.Properties;
using System.IO.Pipes;
using NAudio.Wave;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using MySqlX.XDevAPI.Common;
using static System.Net.WebRequestMethods;
using static vssms.Data;
using System.Reflection;
using kripto;


namespace vssms
{
    public partial class Chat : Form
    {
        private Panel satirPanel;
        public AxWindowsMediaPlayer mediaPlayer;

        public WaveInEvent waveIn;
        private WaveFileWriter waveFileWriter;
        private string outputFileName ;

        public Chat()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(esc.MainForm_FormClosing);
        }
        public int msjadeti,sms_attigim_kiside_ekli_miyim,x_konumu_tutucu, x_konumu_tutucu_goruldu, y_konumu_tutucu,text_harf_sayici, x_konumu_resim,onceki_tool_yuksekligi,ses_kaydedici_saniye_tutucu;
        public string gecici_telefon_tutucu,birlestirici,eklenecek_resim,Gosterilcek_Resim,sms_atilan_kullanici_resmi, textbox_id_tutucu;
        public List<string[]> veriler = new List<string[]>();
        public bool ses_buttonu_tiklandi_mi=true,text_duzenleyici_acik_mi=false,emoji_butonuna_tiklanildi_mi=true;
        public System.Drawing.Image goruldu_resmi;
        public System.Windows.Forms.TextBox mesajTextBox;
        public System.Windows.Forms.Button playButton, emojiButton;
        public System.Windows.Forms.PictureBox resim_goster_resimbox, winrar_goster_resimbox,mesaj_sil_resimbox,text_msj_duzenle;
        private string[] emojiArray;




        private void Chat_Load(object sender, EventArgs e)
        {
            //anadosyaya_resimekle_kontrol_edip_ac(Sms_Atılacak_Kullanici_Data.Sms_Atilacak_Kullanici_resmi, Sms_Atılacak_Kullanici_Data.Sms_Atilacak_Kullanici_Numarasi);
            sms_atilan_kullanici_resmi = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "image", Path.GetFileName(Sms_Atılacak_Kullanici_Data.Sms_Atilacak_Kullanici_resmi));
            Sms_atilan_kullanici_resmi_img.ImageLocation = sms_atilan_kullanici_resmi;
            Sms_atilan_kullanici_adi_label.Text = Sms_Atılacak_Kullanici_Data.Sms_Atilacak_Kullanici_ismi;
            msjlari_goster();
            okundumu_kontrol();
            if(!Sms_Atılacak_Kullanici_Data.Sms_atilacak_Kullanicininin_online_mi)
            { online_mi_label.Text = "Son online Saati: "+Sms_Atılacak_Kullanici_Data.Sms_atilacak_kullanicinin_son_online_olma_saati.ToString("dd.MM.yyyy HH:mm:ss"); }
            else { online_mi_label.Text ="online"; }
            // Formun KeyPreview özelliğini etkinleştir
            this.KeyPreview = true;

            // Emoji sınıfındaki tüm const alanları almak
            var emojiType = typeof(Emoji);
            var fields = emojiType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            // Emojileri bir diziye ekleme
            emojiArray = fields.Select(f => (string)f.GetValue(null)).ToArray();
            foreach (var field in fields)
            {
                string emoji = (string)field.GetValue(null);
                emojiButton = new System.Windows.Forms.Button
                {
                    Text = emoji,
                    Width = 50,
                    Height = 50,
                    Font = new System.Drawing.Font("Segoe UI Emoji", 20)
                };
                emojiButton.Click += EmojiButton_Click;
                emoji_panel.Controls.Add(emojiButton);
            }



        }
        public void okundumu_kontrol()
        {
            Data.DataBase.mysqlbaglan.Open();
            birlestirici = Sms_Atılacak_Kullanici_Data.Sms_Atilacak_Kullanici_Numarasi + "arkadaslari";
            Data.DataBase.komut.CommandText = "SELECT * FROM `" + birlestirici + "` WHERE Number = '" + KullaniciData.Kullanici_Numarasi + "'";
            Data.DataBase.dr = Data.DataBase.komut.ExecuteReader();
            if (Data.DataBase.dr.Read())
            {
                KullaniciData.Sms_Attigim_kisinin_en_son_gordugu_msj = Convert.ToInt32(Data.DataBase.dr["Msjsayisi"]);
            }

            Data.DataBase.mysqlbaglan.Close();
        }

        private void geri_img_Click(object sender, EventArgs e)
        {
            Hesap hesap = new Hesap();
            hesap.Show();
            this.Hide();
        }

        private void video_ekle_img_Click(object sender, EventArgs e)
        {
            //sari unlemleri gizleme
        #pragma warning disable

                Video_Sec.Filter = "Video Files|*.mp4;*.avi;*.mkv;*.mov;*.wmv";
                Video_Sec.Title = "Select a Video File";

            if (Video_Sec.ShowDialog() == DialogResult.OK)
                {
                    string videoPath = Video_Sec.FileName;
                    FileInfo fileInfo = new FileInfo(videoPath);
                    long fileSizeInBytes = fileInfo.Length;
                    long maxFileSize = 10 * 1024 * 1024;//10 mb gecerse 
                if (videoPath.Length > 100)
                {
                    MessageBox.Show("Seçilen dosya yolunun uzunluğu 100 karakterden fazla olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (fileSizeInBytes > maxFileSize)
                {
                    MessageBox.Show("Seçilen video dosyası 10 MB'tan büyük. Lütfen daha küçük bir dosya seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    KullaniciData.Secilen_resmin_bilgisayar_uzerindeki_yolu = Video_Sec.FileName;
                    Data.FileZillaData.Ayni_Adda_Resim_var_mi(Video_Sec.FileName);
                    msj_gonder("", "", Data.FileZillaData.FtpUrl,"","");
                    okundumu_kontrol();
                    msjlari_goster();
                }
            }



            }

        private void Ses_kaydi_img_Click(object sender, EventArgs e)
        {
            //emeji sekmesi acıksa kapatmayı saglıyor
                 if (emoji_butonuna_tiklanildi_mi == false)
                {
                emoji_img_Click(sender, e);
                emoji_butonuna_tiklanildi_mi = true;
                }
                if (ses_buttonu_tiklandi_mi == true)
                {
                    Ses_kaydi_img.BackColor = Color.Red;
                    timer_label.Visible = true;
                    ses_kaydedici_saniye_tutucu = 0;
                    timer1.Start();

                    string dosyaAdi = "kayit_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".wav";
                    outputFileName = Path.Combine("Sound", dosyaAdi);

                    if (waveIn == null)
                    {
                        waveIn = new WaveInEvent();
                        waveIn.DeviceNumber = 0; // Varsayılan mikrofonu kullan
                        waveIn.WaveFormat = new WaveFormat(44100, 1); // 44.1kHz, mono

                        waveFileWriter = new WaveFileWriter(outputFileName, waveIn.WaveFormat);

                        waveIn.DataAvailable += (s, a) =>
                        {
                            waveFileWriter.Write(a.Buffer, 0, a.BytesRecorded);
                        };

                        waveIn.RecordingStopped += (s, a) =>
                        {
                            waveFileWriter.Dispose();
                            waveFileWriter = null;
                            waveIn.Dispose();
                            waveIn = null;
                        };

                        waveIn.StartRecording();
                        //MessageBox.Show("Kayda başlandı.");
                    }
                    ses_buttonu_tiklandi_mi = false;
                }
                else
                {
                    Ses_kaydi_img.BackColor = Color.DarkGray;
                    timer_label.Visible = false;
                    timer1.Stop();

                    if (waveIn != null)
                    {
                        waveIn.StopRecording();

                        // Kullanıcıya dosyayı kaydetmek isteyip istemediğini sor
                        DialogResult result = MessageBox.Show("Kayıt tamamlandı. Dosyayı kaydetmek istiyor musunuz?","Kayıt Tamamlandı",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            // Kullanıcı kaydetmek istiyor
                            //MessageBox.Show($"Kayıt dosyası '{outputFileName}' olarak kaydedildi.");
                            KullaniciData.Secilen_resmin_bilgisayar_uzerindeki_yolu = outputFileName;
                            Data.FileZillaData.Ayni_Adda_Resim_var_mi(outputFileName);
                            msj_gonder("", "", "", Data.FileZillaData.FtpUrl,"");
                            okundumu_kontrol();
                            msjlari_goster();
                        }
                        else
                        {
                            // Kullanıcı kaydetmek istemiyor, dosyayı sil
                            if (System.IO.File.Exists(outputFileName))
                            {
                                System.IO.File.Delete(outputFileName);
                            }
                            MessageBox.Show("Kayıt silindi.");
                        }
                        
                    }
                    ses_buttonu_tiklandi_mi = true;
                
            }


        }


        private void emoji_img_Click(object sender, EventArgs e)
        {

            if (emoji_butonuna_tiklanildi_mi==true)
            {
                emoji_panel.Visible = true;
                emoji_butonuna_tiklanildi_mi = false;
            }
            else 
            {
                emoji_panel.Visible = false;
                emoji_butonuna_tiklanildi_mi = true;
            }
            
        }

        private void winrar_ekle_img_Click(object sender, EventArgs e)
        {
            Winrar_Sec.Filter = "Winrar Files|*.rar;*.zip;";
            Winrar_Sec.Title = "Select a winrar File";

            if (Winrar_Sec.ShowDialog() == DialogResult.OK)
            {
                string winrarPath = Winrar_Sec.FileName;
                FileInfo fileInfo = new FileInfo(winrarPath);
                long fileSizeInBytes = fileInfo.Length;
                long maxFileSize = 10 * 1024 * 1024;//10 mb gecerse 
                if (winrarPath.Length > 100)
                {
                    MessageBox.Show("Seçilen dosya yolunun uzunluğu 100 karakterden fazla olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (fileSizeInBytes > maxFileSize)
                {
                    MessageBox.Show("Seçilen video dosyası 10 MB'tan büyük. Lütfen daha küçük bir dosya seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    KullaniciData.Secilen_resmin_bilgisayar_uzerindeki_yolu = Winrar_Sec.FileName;
                    Data.FileZillaData.Ayni_Adda_Resim_var_mi(Winrar_Sec.FileName);
                    msj_gonder("", "", "", "", Data.FileZillaData.FtpUrl);
                    okundumu_kontrol();
                    msjlari_goster();
                }
            }
        }

        private void Chat_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                e.SuppressKeyPress = true;
                Chat_Load(sender, e);
                //MessageBox.Show("sayfa yenilendi");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

                ses_kaydedici_saniye_tutucu++;
                int minutes = ses_kaydedici_saniye_tutucu / 60;
                int seconds = ses_kaydedici_saniye_tutucu % 60;
                timer_label.Text = minutes+":"+seconds; // Örneğin 02:05 formatında
            if(ses_kaydedici_saniye_tutucu==300)
            {
                mesajTextBox.Text = "5 dk dan fazla ses kaydi alamazsiniz anlayışınız için teşekkür ederiz.";
                Ses_kaydi_img_Click(sender, e);

            }


        }

        private void Msj_Gonder_img_Click(object sender, EventArgs e)
        {
            //emeji sekmesi acıksa kapatmayı saglıyor
            if (emoji_butonuna_tiklanildi_mi == false)
            {
                emoji_img_Click(sender, e);
                emoji_butonuna_tiklanildi_mi = true;
            }
            if (!string.IsNullOrWhiteSpace(Msj_text.Text)&& text_duzenleyici_acik_mi==false)
            { 
                if (Msj_text.Text != " ")
                {
                msj_gonder(Msj_text.Text.TrimEnd(),"","","","");
                }
                okundumu_kontrol();
                Msj_text.Clear();
                msjlari_goster();
            }
            else if(!string.IsNullOrWhiteSpace(Msj_text.Text) && text_duzenleyici_acik_mi == true)
            {
                Kripto_olusturucu.Metini_harf_yap(Msj_text.Text);
                DataBase.mysqlbaglan.Open();
                DataBase.komut.CommandText = "UPDATE  `" + Data.DataBase.teltutucu + "`set Mesaj='" + Kripto_olusturucu.kripto + "' WHERE UserId='" + textbox_id_tutucu + "' ";
                DataBase.dr = DataBase.komut.ExecuteReader();
                DataBase.mysqlbaglan.Close();
                text_duzenleyici_acik_mi = false;
                okundumu_kontrol();
                Msj_text.Clear();
                msjlari_goster();
                
            }
        }
        public void msj_gonderdigim_kiside_ekli_miyim()
        {
            birlestirici = Sms_Atılacak_Kullanici_Data.Sms_Atilacak_Kullanici_Numarasi + "arkadaslari";
            Data.DataBase.mysqlbaglan.Open();
            Data.DataBase.komut.CommandText = "SELECT COUNT(*) FROM `" + birlestirici + "` where Number='" + KullaniciData.Kullanici_Numarasi + "'";
            sms_attigim_kiside_ekli_miyim = Convert.ToInt32(Data.DataBase.komut.ExecuteScalar());
            Data.DataBase.mysqlbaglan.Close();
            if(sms_attigim_kiside_ekli_miyim==0)
            {
                Data.DataBase.mysqlbaglan.Open();
                string arkadasekle = "insert into `" + birlestirici + "`(Number) values (@Number)";
                Data.DataBase.komut = new MySqlCommand(arkadasekle, Data.DataBase.mysqlbaglan);
                Data.DataBase.komut.Parameters.AddWithValue("@Number", KullaniciData.Kullanici_Numarasi);
                Data.DataBase.komut.ExecuteNonQuery();
                Data.DataBase.mysqlbaglan.Close();
            }

        }
        private void Resim_ekle_img_Click(object sender, EventArgs e)
        {

            Resim_Sec.Title = "Resim sec";
            Resim_Sec.Filter = "PNG Dosyaları (*.png)|*.png";
            if (Resim_Sec.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = Path.GetFileName(Resim_Sec.FileName);

                MessageBox.Show(selectedFilePath);
                if (selectedFilePath.Length > 100)
                {
                    MessageBox.Show("Seçilen dosya yolunun uzunluğu 100 karakterden fazla olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    KullaniciData.Secilen_resmin_bilgisayar_uzerindeki_yolu = Resim_Sec.FileName;
                    Data.FileZillaData.Ayni_Adda_Resim_var_mi(Resim_Sec.FileName);

                }
            }
            msj_gonder("",Data.FileZillaData.FtpUrl,"","","");
            okundumu_kontrol();
            msjlari_goster();

        }

        private void Msj_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Msj_Gonder_img_Click(Msj_Gonder_img, EventArgs.Empty);
            }
            
        }

        public void msj_gonder(string mesaj_tutucu,string resim_tutucu,string video_tutucu,string Ses_tutucu,string Winrar_tutucu)
        {
            Kripto_olusturucu.Metini_harf_yap(mesaj_tutucu);
            DateTime Zaman = DateTime.Now;
            //sms atılan kisinin databaseni veriyi ekleme
            Data.DataBase.mysqlbaglan.Open();
            string smsalan = "insert into `" + Data.DataBase.teltutucu + "`(Number,Time,Mesaj,Resim,Video,SesKaydi,Winrar) values (@Number,@Time,@Mesaj,@Resim,@Video,@SesKaydi,@Winrar)";
            Data.DataBase.komut = new MySqlCommand(smsalan, Data.DataBase.mysqlbaglan);
            Data.DataBase.komut.Parameters.AddWithValue("@Number", KullaniciData.Kullanici_Numarasi);
            Data.DataBase.komut.Parameters.AddWithValue("@Time", Zaman);
            Data.DataBase.komut.Parameters.AddWithValue("@Mesaj", Kripto_olusturucu.kripto);
            Data.DataBase.komut.Parameters.AddWithValue("@Resim", resim_tutucu);
            Data.DataBase.komut.Parameters.AddWithValue("@Video", video_tutucu);
            Data.DataBase.komut.Parameters.AddWithValue("@SesKaydi", Ses_tutucu);
            Data.DataBase.komut.Parameters.AddWithValue("@Winrar", Winrar_tutucu);
            Data.DataBase.komut.ExecuteNonQuery();
            Data.DataBase.mysqlbaglan.Close();


        }

                public void msjsayisi_ogrenme()
            {
            Data.DataBase.mysqlbaglan.Open();
            Data.DataBase.komut.CommandText = "SELECT COUNT(*) FROM `" + Data.DataBase.teltutucu+ "`";
            msjadeti = Convert.ToInt32(Data.DataBase.komut.ExecuteScalar());
            Data.DataBase.mysqlbaglan.Close();
            // en son alınan msj satır numarasını veritanına aktarma

            }
        public void Son_okunan_msj_id_veritabanina_aktarma()
        {
            Data.DataBase.mysqlbaglan.Open();
            birlestirici = KullaniciData.Kullanici_Numarasi + "arkadaslari";
            Data.DataBase.komut.CommandText = "UPDATE `" + birlestirici + "` set Msjsayisi='" + msjadeti + "' where Number='" + Sms_Atılacak_Kullanici_Data.Sms_Atilacak_Kullanici_Numarasi + "' ";
            Data.DataBase.dr = Data.DataBase.komut.ExecuteReader();
            Data.DataBase.mysqlbaglan.Close();
        }

        public void anadosyaya_resimekle_kontrol_edip_ac(string resimYolu, string tel_no,string videoYolu,string sesYolu,string winrarYolu)
        {

            string dosyaYolu = string.Empty;
            string yoltutucu="";
            if (!string.IsNullOrWhiteSpace(resimYolu))
            {
                dosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "image", Path.GetFileName(resimYolu));
                yoltutucu = "image";
            }
            else if (!string.IsNullOrWhiteSpace(videoYolu))
            {
                dosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "movie", Path.GetFileName(videoYolu));
                yoltutucu = "movie";
            }
            else if (!string.IsNullOrWhiteSpace(sesYolu))
            {
                dosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Sound", Path.GetFileName(sesYolu));
                yoltutucu = "Sound";
            }
            else if (!string.IsNullOrWhiteSpace(winrarYolu))
            {
                dosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "data", Path.GetFileName(winrarYolu));
                yoltutucu = "data";
            }
            if (System.IO.File.Exists(dosyaYolu))
            {
                // Resim dosyası varsa, işleme devam edin.
                //MessageBox.Show("Resim dosyası mevcut.");
                //MessageBox.Show(dosyaYolu);
                Gosterilcek_Resim = dosyaYolu;
                
            }
            else
            {
                // Resim dosyası yoksa, kullanıcıya bildirin.
                //MessageBox.Show("Resim dosyası bulunamadı.");
                //MessageBox.Show(dosyaYolu);
                Data.FileZillaData.Resim_indir(Path.GetFileName(dosyaYolu), tel_no, yoltutucu);
                Gosterilcek_Resim = dosyaYolu;
            }

        }
        public void veritabanı_dizini()
        {

            veriler.Clear();
            try
            {
                Data.DataBase.mysqlbaglan.Open();
                Data.DataBase.komut.CommandText = "SELECT * FROM `" + Data.DataBase.teltutucu + "`";
                Data.DataBase.dr = Data.DataBase.komut.ExecuteReader();

                while (Data.DataBase.dr.Read())
                {
                    string[] satirVeri = new string[Data.DataBase.dr.FieldCount];
                    for (int i = 0; i < Data.DataBase.dr.FieldCount; i++)
                    {
                        satirVeri[i] = Data.DataBase.dr[i].ToString();
                    }
                    veriler.Add(satirVeri);
                }
            }
            finally
            {
                Data.DataBase.dr.Close();
                Data.DataBase.mysqlbaglan.Close();
            }
        }
        public void msjlari_goster()
        {
            msj_gonderdigim_kiside_ekli_miyim();
            msjsayisi_ogrenme();
            Son_okunan_msj_id_veritabanina_aktarma();
            okundumu_kontrol();
            veritabanı_dizini(); // Tüm verileri bir kez al
            
            x_konumu_tutucu = 2;
            y_konumu_tutucu = 32;
            onceki_tool_yuksekligi = 2;

            if (satirPanel != null)
            {
                // Panelin içindeki tüm kontrolleri panelden kaldır
                while (satirPanel.Controls.Count > 0)
                {
                    Control control = satirPanel.Controls[0];
                    satirPanel.Controls.Remove(control);
                    control.Dispose(); // Kontrolü bellekten serbest bırak
                }

                // Paneli formdan kaldır ve dispose et
                this.Controls.Remove(satirPanel);
                satirPanel.Dispose();
                satirPanel = null; // Paneli null'a ayarlayarak referansı kaldır
            }

                satirPanel = new Panel
            {
                Height = 323,
                Width = 1240,
                Location = new Point(12, 125),
                BackColor = Color.LightSkyBlue,
                AutoScroll = true,
            };

            for (int msjsayaci = 0; msjsayaci < Math.Min(msjadeti, veriler.Count); msjsayaci++)
            {
                var satir = veriler[msjsayaci];
                gecici_telefon_tutucu = satir[1];
                Kripto_cozucu.metinin_sifresini_coz(satir[3]);
                string formattedMessage = InsertLineBreaks(Kripto_cozucu.kriptonun_cozulmus_hali, 400);
                if (gecici_telefon_tutucu == KullaniciData.Kullanici_Numarasi)
                {
                    x_konumu_tutucu = 610;
                    x_konumu_tutucu_goruldu = 1120;
                    x_konumu_resim =700;
                }
                else
                {
                    x_konumu_tutucu = 102;
                    x_konumu_tutucu_goruldu = 2;
                    x_konumu_resim = 102;
                }

                if (msjsayaci < KullaniciData.Sms_Attigim_kisinin_en_son_gordugu_msj )
                {
                    goruldu_resmi = Properties.Resources.okundu;
                    
                }
                else
                {
                    goruldu_resmi = Properties.Resources.okunmadi;
                }

                System.Windows.Forms.PictureBox goruldu_mu_resimbox = new System.Windows.Forms.PictureBox

                {
                    Height = 40,
                    Width = 70,
                    Location = new Point(x_konumu_tutucu_goruldu, y_konumu_tutucu),
                    AutoSize = false,
                    Image = goruldu_resmi,
                    SizeMode = PictureBoxSizeMode.StretchImage,

                };
                if (string.IsNullOrEmpty(satir[3]) && string.IsNullOrEmpty(satir[5]) && string.IsNullOrEmpty(satir[6]) && string.IsNullOrEmpty(satir[7]))
                {
                    anadosyaya_resimekle_kontrol_edip_ac(satir[4], satir[1], satir[5], satir[6], satir[7]);
                    resim_goster_resimbox = new System.Windows.Forms.PictureBox

                    {
                        Height = 140,
                        Width = 400,
                        Location = new Point(x_konumu_resim, y_konumu_tutucu),
                        AutoSize = false,
                        ImageLocation = Gosterilcek_Resim,
                        SizeMode = PictureBoxSizeMode.StretchImage,

                    };

                    satirPanel.Controls.Add(resim_goster_resimbox);
                    onceki_tool_yuksekligi = resim_goster_resimbox.Height;
                }

                if (string.IsNullOrEmpty(satir[4]) && string.IsNullOrEmpty(satir[3]) && string.IsNullOrEmpty(satir[6]) && string.IsNullOrEmpty(satir[7]))
                {
                    anadosyaya_resimekle_kontrol_edip_ac(satir[4], satir[1], satir[5], satir[6], satir[7]);
                    mediaPlayer = new AxWindowsMediaPlayer
                    {
                        Height = 140,
                        Width = 400,
                        Location = new Point(x_konumu_resim, y_konumu_tutucu), // Denetimin form üzerindeki konumu
                        Visible = true,
                        Enabled = true,

                    };
                    satirPanel.Controls.Add(mediaPlayer);
                    mediaPlayer.CreateControl(); // Denetimi yaratın
                    // Video dosyasını ayarlayın
                    mediaPlayer.URL = Gosterilcek_Resim;
                    mediaPlayer.Ctlcontrols.stop();
                    onceki_tool_yuksekligi = mediaPlayer.Height;
                }
                if (string.IsNullOrEmpty(satir[4]) && string.IsNullOrEmpty(satir[3]) && string.IsNullOrEmpty(satir[5]) && string.IsNullOrEmpty(satir[7]))
                {
                    //outputFileName
                    anadosyaya_resimekle_kontrol_edip_ac(satir[4], satir[1], satir[5], satir[6], satir[7]);
                    mediaPlayer = new AxWindowsMediaPlayer
                    {
                        Height = 80,
                        Width = 400,
                        Location = new Point(x_konumu_resim, y_konumu_tutucu), // Denetimin form üzerindeki konumu
                        Visible = true,
                        Enabled = true,

                    };
                    satirPanel.Controls.Add(mediaPlayer);
                    mediaPlayer.CreateControl(); // Denetimi yaratın
                    // Video dosyasını ayarlayın
                    mediaPlayer.URL = Gosterilcek_Resim;
                    mediaPlayer.Ctlcontrols.stop();
                    onceki_tool_yuksekligi = mediaPlayer.Height;
                }
                if (string.IsNullOrEmpty(satir[3]) && string.IsNullOrEmpty(satir[4]) && string.IsNullOrEmpty(satir[5]) && string.IsNullOrEmpty(satir[6]))
                {
                    anadosyaya_resimekle_kontrol_edip_ac(satir[4], satir[1], satir[5], satir[6], satir[7]);
                    winrar_goster_resimbox = new System.Windows.Forms.PictureBox

                    {
                        Height = 100,
                        Width = 400,
                        Location = new Point(x_konumu_resim, y_konumu_tutucu),
                        AutoSize = false,
                        Image = Properties.Resources.rar,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Name = satir[7],
                    };
                    winrar_goster_resimbox.Click += WinrarGosterResimbox_Click;
                    satirPanel.Controls.Add(winrar_goster_resimbox);
                    onceki_tool_yuksekligi = winrar_goster_resimbox.Height;
                }

                if (string.IsNullOrEmpty(satir[4]) && string.IsNullOrEmpty(satir[5]) && string.IsNullOrEmpty(satir[6]) && string.IsNullOrEmpty(satir[7]))
                { 
                    mesajTextBox = new System.Windows.Forms.TextBox

                    {
                        Height = 40,
                        Width = 500,
                        Location = new Point(x_konumu_tutucu, y_konumu_tutucu),
                        AutoSize = false,
                        Text = formattedMessage,
                        BackColor = satirPanel.BackColor,
                        ReadOnly = true,
                        Multiline = false,
                        ScrollBars = ScrollBars.None,
                        WordWrap = true,
                        BorderStyle = BorderStyle.None,

                    };
                    Size textSize = TextRenderer.MeasureText(formattedMessage, mesajTextBox.Font);
                    int textWidth = textSize.Width;

                    if (textWidth > 400)
                    {
                        mesajTextBox.Multiline = true;
                        mesajTextBox.Height *= (textWidth / 200);
                    }
                    onceki_tool_yuksekligi=mesajTextBox.Height;
                    if (x_konumu_tutucu == 610)
                    {
                        mesajTextBox.TextAlign = HorizontalAlignment.Right;

                    }
                    else
                    {
                        mesajTextBox.TextAlign = HorizontalAlignment.Left;

                    }

                    text_msj_duzenle = new System.Windows.Forms.PictureBox

                    {
                        Height = 30,
                        Width = 50,
                        Location = new Point(1080, y_konumu_tutucu - 30),
                        AutoSize = false,
                        Image = Properties.Resources.yaziyi_duzelt,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Name = satir[0],
                    };
                    text_msj_duzenle.Click += Yaziyi_düzelt_Click;
                    satirPanel.Controls.Add(text_msj_duzenle);
                }

                mesaj_sil_resimbox = new System.Windows.Forms.PictureBox

                {
                    Height = 30,
                    Width = 50,
                    Location = new Point(1150, y_konumu_tutucu-30),
                    AutoSize = false,
                    Image = Properties.Resources.sil,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Name = satir[0],
                };
                mesaj_sil_resimbox.Click += obje_Sil_Click;
                satirPanel.Controls.Add(mesaj_sil_resimbox);
                

                System.Windows.Forms.TextBox zamanTextBox = new System.Windows.Forms.TextBox

                    {
                        
                        Height = 35,
                        Width = 500,
                        Location = new Point(x_konumu_tutucu, y_konumu_tutucu + onceki_tool_yuksekligi),
                        AutoSize = false,
                        Text = satir[2].TrimEnd(),
                        BackColor = satirPanel.BackColor,
                        ReadOnly = true,
                        Multiline = false,
                        ScrollBars = ScrollBars.None,
                        BorderStyle = BorderStyle.None
                    };

                    y_konumu_tutucu += onceki_tool_yuksekligi + 30+ zamanTextBox.Height;

                if (y_konumu_tutucu > satirPanel.Height)
                    {
                        satirPanel.AutoScrollMinSize = new Size(0, y_konumu_tutucu);
                    }

                    if (x_konumu_tutucu == 610)
                    {
                      
                        zamanTextBox.TextAlign= HorizontalAlignment.Left;
                    }
                    else
                    {
                        
                        zamanTextBox.TextAlign = HorizontalAlignment.Right;
                    }

                    satirPanel.Controls.Add(mesajTextBox);
                    satirPanel.Controls.Add(zamanTextBox);
                    satirPanel.Controls.Add(goruldu_mu_resimbox);
            }
            this.Controls.Add(satirPanel);
            satirPanel.AutoScrollPosition = new Point(0, satirPanel.VerticalScroll.Maximum);
        }
        private string InsertLineBreaks(string text, int characterLimit)
        {
            for (int i = characterLimit; i < text.Length; i += characterLimit)
            {
                text = text.Insert(i, Environment.NewLine);
                i++; // Satır sonu ekledikten sonra, bir karakter öne almak için i'yi artırıyoruz
            }
            return text;
        }
        private void WinrarGosterResimbox_Click(object sender, EventArgs e)
        {
            PictureBox tiklanan_buton = sender as PictureBox;
            MessageBox.Show(tiklanan_buton.Name);
            Winrar_Kaydet.Filter = "WinRAR Dosyaları|*.rar";
            Winrar_Kaydet.FileName = Path.GetFileName(tiklanan_buton.Name);
            Winrar_Kaydet.Title = "Winrar Kaydet";
            if (Winrar_Kaydet.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show("PictureBox'a tıkladınız!");
                string dosyaYolu = Winrar_Kaydet.FileName;
                System.IO.File.Copy(tiklanan_buton.Name, dosyaYolu);
            }
        }
        private void obje_Sil_Click(object sender, EventArgs e)
        {
            PictureBox tiklanan_obje_id = sender as PictureBox;
            if (tiklanan_obje_id != null)
            {
                // Kullanıcıya onay mesajı göster
                DialogResult result = MessageBox.Show("Bu kaydı silmek istediğinizden emin misiniz?","Kayıt Silme Onayı",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                        DataBase.mysqlbaglan.Open();
                        DataBase.komut.CommandText = "DELETE FROM `" + Data.DataBase.teltutucu + "` WHERE UserId='" + tiklanan_obje_id.Name + "' ";
                        DataBase.dr = DataBase.komut.ExecuteReader();
                        DataBase.mysqlbaglan.Close();
                        okundumu_kontrol();
                        msjlari_goster();
                }
                else
                {

                }
            }
        }
        private void Yaziyi_düzelt_Click(object sender, EventArgs e)
        {
            PictureBox tiklanan_obje_id = sender as PictureBox;
            if (tiklanan_obje_id != null)
            {
                Msj_text.Clear();
                var bulunanDizi = veriler.FirstOrDefault(d => d.Contains(tiklanan_obje_id.Name));
                if (bulunanDizi != null)
                {
                    if (bulunanDizi.Length >= 3)
                    {
                        Kripto_cozucu.metinin_sifresini_coz(bulunanDizi[3]);
                        Msj_text.Text = Kripto_cozucu.kriptonun_cozulmus_hali;
                        text_duzenleyici_acik_mi = true;
                        textbox_id_tutucu = tiklanan_obje_id.Name;
                    }
                }

            }

        }
        private void EmojiButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button clickedButton = sender as System.Windows.Forms.Button;
            if (clickedButton != null)
            {
                Msj_text.Text += clickedButton.Text;
            }
        }
    }


    
}
