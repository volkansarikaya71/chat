using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Mysqlx.Session;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vssms.Properties;
using static vssms.Data;

namespace vssms
{
    public partial class Hesap : Form
    {
        private Panel Panel;
        public Hesap()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(esc.MainForm_FormClosing);
        }
        public string Eklenecek_tel_no, Eklenecek_kullanici_ismi, Gosterilcek_isim, Gosterilcek_numara, iki_numarayi_birlestirme,birlestirici, Eklenecek_kullanici_resmi, Gosterilcek_Resim;
        public int arkadas_sayisi, kullanicinin_son_okunan_msj_id, SmsAtanin_son_okunan_msj_id,Sonuc, y_konum_tutucu_panel;
        public bool Tablo_Var_Mi;
        public List<string[]> kullanici_tablosu_verileri = new List<string[]>();
        public List<string[]> arkadas_resmi_ismi_tablasu = new List<string[]>();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            online_mi.online(KullaniciData.Kullanici_Numarasi, "0");
            girisekrani();
        }

        public void girisekrani()
        {
            GirisEkrani girisEkrani = new GirisEkrani();
            girisEkrani.Show();
            this.Hide();
        }

        private void Hesap_Load(object sender, EventArgs e)
        {
            //kullanici resmini indirip gösterme
            kullanicibilgileri(KullaniciData.Kullanici_resmi);
            arkadas_sayisi_ogrenme();
            arkadaslarimi_goster();
            online_mi.online(KullaniciData.Kullanici_Numarasi, "1");
            DateTime Zaman = DateTime.Now;
            KullaniciData.son_online_olma_zamani = Zaman;
            this.KeyPreview = true;

        }
        public void anadosyaya_resimekle_kontrol_edip_ac(string resimYolu,string tel_no)
        {
            resimYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "image", Path.GetFileName(resimYolu));

            if (System.IO.File.Exists(resimYolu))
            {
                // Resim dosyası varsa, işleme devam edin.
                //MessageBox.Show("Resim dosyası mevcut.");
                //MessageBox.Show(resimYolu);
                Gosterilcek_Resim = resimYolu;
            }
            else
            {
                // Resim dosyası yoksa, kullanıcıya bildirin.
                //MessageBox.Show("Resim dosyası bulunamadı.");
                //MessageBox.Show(resimYolu);
                Data.FileZillaData.Resim_indir(Path.GetFileName(resimYolu), tel_no,"image");
                Gosterilcek_Resim = resimYolu;
            }

        }

        public void kullanicibilgileri(string resimler)
        {
            anadosyaya_resimekle_kontrol_edip_ac(resimler, KullaniciData.Kullanici_Numarasi);
            kullanici_img.ImageLocation = Gosterilcek_Resim;
            kullanici_name_text.Text = KullaniciData.Kullanici_ismi;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Gosterilen_adimi_Guncelle();
            Numara_text.Visible = true;
            numara_label.Visible = true;
            numara_img.Visible = true;
            if (Numara_text.Text != "")
            {
                Data.DataBase.mysqlbaglan.Open();
                Data.DataBase.komut.CommandText = "SELECT * FROM kullanicilar where Number='" + Numara_text.Text + "'";
                Data.DataBase.dr = Data.DataBase.komut.ExecuteReader();
                if (Data.DataBase.dr.Read())
                {
                    Eklenecek_tel_no = Data.DataBase.dr["Number"].ToString();
                    Eklenecek_kullanici_ismi = Data.DataBase.dr["Name"].ToString();
                    Eklenecek_kullanici_resmi = Data.DataBase.dr["Image"].ToString();
                    Data.DataBase.mysqlbaglan.Close();
                    arkadasekle();
                    Numara_text.Visible = false;
                    numara_label.Visible = false;
                    numara_img.Visible = false;
                    Numara_text.Clear();
                }
                else
                {
                    MessageBox.Show("Böyle bir numara bulunmamaktadir.");
                }
                Data.DataBase.mysqlbaglan.Close();
            }

        }

        private void resim_guncelle_Click(object sender, EventArgs e)
        {
            KullaniciData.kullanici_resmi_mi_degisiyor = true;
            Gosterilen_adimi_Guncelle();
            openFileDialog1.Title = "Resim sec";
            openFileDialog1.Filter = "PNG Dosyaları (*.png)|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath2 = Path.GetFileName(openFileDialog1.FileName);

                MessageBox.Show(selectedFilePath2);
                if (selectedFilePath2.Length > 100)
                {
                    MessageBox.Show("Seçilen dosya yolunun uzunluğu 100 karakterden fazla olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    KullaniciData.Secilen_resmin_bilgisayar_uzerindeki_yolu = openFileDialog1.FileName;
                    Data.FileZillaData.Ayni_Adda_Resim_var_mi(openFileDialog1.FileName);

                    string resimYolu2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "image", Path.GetFileName(openFileDialog1.FileName));
                    Data.FileZillaData.Resim_indir(Path.GetFileName(openFileDialog1.FileName), KullaniciData.Kullanici_Numarasi,"image");

                    kullanici_img.ImageLocation = resimYolu2;
                    //Gosterilen_resmi_Guncelle();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            kullanici_name_text.Enabled = true;
        }

        private void kullanici_name_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Gosterilen_adimi_Guncelle();
            }
            
        }

        private void Numara_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(ArkadasEkle_btn, EventArgs.Empty);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        public void arkadasekle()
        {
            Data.DataBase.mysqlbaglan.Open();
            birlestirici = KullaniciData.Kullanici_Numarasi + "arkadaslari";
            Data.DataBase.komut.CommandText = "SELECT * FROM  `" + birlestirici + "` where Number='" + Numara_text.Text + "'";
            Data.DataBase.dr = Data.DataBase.komut.ExecuteReader();
            if (Data.DataBase.dr.Read())
            {
                MessageBox.Show("Bu numara zaten arkadaşınız.");
            }
            else
            {
                Data.DataBase.mysqlbaglan.Close();
                Data.DataBase.mysqlbaglan.Open();
                birlestirici = KullaniciData.Kullanici_Numarasi + "arkadaslari";
                string arkadasekle = "insert into `" + birlestirici + "`(Number) values (@Number)";
                Data.DataBase.komut = new MySqlCommand(arkadasekle, Data.DataBase.mysqlbaglan);
                Data.DataBase.komut.Parameters.AddWithValue("@Number", Eklenecek_tel_no);
                Data.DataBase.komut.ExecuteNonQuery();
                MessageBox.Show("Arkadaş eklediniz.");
            }
            Data.DataBase.mysqlbaglan.Close();
            arkadas_sayisi_ogrenme();
            arkadaslarimi_goster();
        }

        public void arkadas_sayisi_ogrenme()
        {
            Data.DataBase.mysqlbaglan.Open();
            birlestirici = KullaniciData.Kullanici_Numarasi + "arkadaslari";
            Data.DataBase.komut.CommandText = "SELECT COUNT(*) FROM `" + birlestirici + "`";
            arkadas_sayisi = Convert.ToInt32(Data.DataBase.komut.ExecuteScalar());
            Data.DataBase.mysqlbaglan.Close();
        }

        private void Hesap_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                e.SuppressKeyPress = true;
                Hesap_Load(sender, e);
                //MessageBox.Show("sayfa yenilendi");
            }
        }

        public void arkadaslarimdan_gelen_bildirim_sayisi_ogrenme()
        {
            Data.DataBase.mysqlbaglan.Open();
            birlestirici = Gosterilcek_numara + "arkadaslari";
            Data.DataBase.komut.CommandText = "SELECT * FROM `" + birlestirici + "` where Number='" +KullaniciData.Kullanici_Numarasi + "' ";
            Data.DataBase.dr = Data.DataBase.komut.ExecuteReader();
            if (Data.DataBase.dr.Read())
            {
                SmsAtanin_son_okunan_msj_id = Convert.ToInt16(Data.DataBase.dr["Msjsayisi"]);
            }
            Data.DataBase.mysqlbaglan.Close();
        }

        public void kullanici_arkadaslari_tutucu()
        {
            kullanici_tablosu_verileri.Clear();  
            try
            {
                Data.DataBase.mysqlbaglan.Open();
                birlestirici = KullaniciData.Kullanici_Numarasi + "arkadaslari";
                Data.DataBase.komut.CommandText = "SELECT * FROM `" + birlestirici + "`";
                Data.DataBase.dr = Data.DataBase.komut.ExecuteReader();

                while (Data.DataBase.dr.Read())
                {
                    string[] satirVeri = new string[Data.DataBase.dr.FieldCount];
                    for (int i = 0; i < Data.DataBase.dr.FieldCount; i++)
                    {
                        satirVeri[i] = Data.DataBase.dr[i].ToString();
                    }
                    kullanici_tablosu_verileri.Add(satirVeri);
                }
            }
            finally
            {
                Data.DataBase.dr.Close();
                Data.DataBase.mysqlbaglan.Close();
                kullanici_arkadaslarini_anatablodan_verilerini_cekme();
            }
        }
        public void kullanici_arkadaslarini_anatablodan_verilerini_cekme()
        {
            arkadas_resmi_ismi_tablasu.Clear();
            for (int msjsayaci = 0; msjsayaci < kullanici_tablosu_verileri.Count; msjsayaci++)
            {
                var satir = kullanici_tablosu_verileri[msjsayaci];
                try
                {
                Data.DataBase.mysqlbaglan.Open();
                Data.DataBase.komut.CommandText = "SELECT * FROM kullanicilar WHERE Number = '" + satir[1] + "'";
                Data.DataBase.dr = Data.DataBase.komut.ExecuteReader();

                    while (Data.DataBase.dr.Read())
                    {
                        string[] satirVeri2 = new string[Data.DataBase.dr.FieldCount];
                        for (int i = 0; i < Data.DataBase.dr.FieldCount; i++)
                        {
                            satirVeri2[i] = Data.DataBase.dr[i].ToString();
                        }
                        arkadas_resmi_ismi_tablasu.Add(satirVeri2);
                    }
                }
                finally
                {
                    Data.DataBase.dr.Close();
                    Data.DataBase.mysqlbaglan.Close();
                }

            }

        }


        public void arkadaslarimi_goster()
        {
            kullanici_arkadaslari_tutucu();

            if (Panel != null)
            {
                // Panelin içindeki tüm kontrolleri panelden kaldır
                while (Panel.Controls.Count > 0)
                {
                    Control control = Panel.Controls[0];
                    Panel.Controls.Remove(control);
                    control.Dispose(); // Kontrolü bellekten serbest bırak
                }

                // Paneli formdan kaldır ve dispose et
                this.Controls.Remove(Panel);
                Panel.Dispose();
                Panel = null; // Paneli null'a ayarlayarak referansı kaldır
            }

            Panel = new Panel
            {
                Height = 230,
                Width = 990,
                Location = new Point(120, 251),
                BackColor = Color.LightSkyBlue,
                AutoScroll = true,
            };
            y_konum_tutucu_panel = 2;

            for (int msjsayaci = 0; msjsayaci < arkadas_resmi_ismi_tablasu.Count; msjsayaci++)
            {
                var satir = arkadas_resmi_ismi_tablasu[msjsayaci];

                kullanicinin_son_okunan_msj_id = Convert.ToInt32(satir[2]);
                Gosterilcek_numara = satir[1];
                Gosterilcek_isim = satir[3];
                Gosterilcek_Resim = satir[5];
                Sms_Atılacak_Kullanici_Data.Sms_atilacak_Kullanicininin_online_mi = Convert.ToInt32(satir[7]) != 0;
                Sms_Atılacak_Kullanici_Data.Sms_atilacak_kullanicinin_son_online_olma_saati = DateTime.Parse(satir[8]);
                arkadaslarimdan_gelen_bildirim_sayisi_ogrenme();


                PictureBox online_mi_resimbox = new System.Windows.Forms.PictureBox

                {
                    Height = 40,
                    Width = 60,
                    Location = new Point(0, y_konum_tutucu_panel),
                    AutoSize = false,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                if (Sms_Atılacak_Kullanici_Data.Sms_atilacak_Kullanicininin_online_mi)
                {
                    online_mi_resimbox.Image = Properties.Resources.online;
                }
                else
                {
                    online_mi_resimbox.Image = Properties.Resources.ofline;
                }
                anadosyaya_resimekle_kontrol_edip_ac(Gosterilcek_Resim, Gosterilcek_numara);
                PictureBox resim_goster_resimbox = new System.Windows.Forms.PictureBox

                {
                    Height = 40,
                    Width = 60,
                    Location = new Point(220, y_konum_tutucu_panel),
                    AutoSize = false,
                    ImageLocation= Gosterilcek_Resim,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                Label isim_labelbox = new System.Windows.Forms.Label
                {
                    Height = 40,
                    Width = 180,
                    Location = new Point(420, y_konum_tutucu_panel),
                    AutoSize = false,
                    Text = Gosterilcek_isim,
                    BackColor = Panel.BackColor,
                    TextAlign = ContentAlignment.MiddleLeft
                };
                Button button = new System.Windows.Forms.Button
                {
                    Height = 40,
                    Width = 60,
                    Location = new Point(620, y_konum_tutucu_panel),
                    Text = "Msj At",
                    Name= Gosterilcek_numara,
                    AutoSize = false,
                    BackColor = Panel.BackColor,
                    FlatStyle = FlatStyle.Flat
                };
                button.Click += new EventHandler(ButtonClickHandler);
                Sonuc = SmsAtanin_son_okunan_msj_id - kullanicinin_son_okunan_msj_id;
                if (Sonuc > 0)
                {
                    PictureBox bildirim_resimbox = new System.Windows.Forms.PictureBox

                    {
                        Height = 40,
                        Width = 60,
                        Location = new Point(720, y_konum_tutucu_panel),
                        AutoSize = false,
                        Image = Properties.Resources.bildirim,
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    Label bildirim_adedi_labelbox = new System.Windows.Forms.Label

                    {
                        Height = 40,
                        Width = 60,
                        Location = new Point(820, y_konum_tutucu_panel),
                        AutoSize = false,
                        Text = Sonuc.ToString(),
                        BackColor = Panel.BackColor,
                        TextAlign = ContentAlignment.MiddleLeft
                    };
                    Panel.Controls.Add(bildirim_resimbox);
                    Panel.Controls.Add(bildirim_adedi_labelbox);
                }

                
                Button arkadas_sil_button = new System.Windows.Forms.Button
                {
                Height = 40,
                Width = 60,
                Location = new Point(900, y_konum_tutucu_panel),
                Text = "Sil",
                Name = Gosterilcek_numara,
                AutoSize = false,
                BackColor = Panel.BackColor,
                FlatStyle = FlatStyle.Flat
                 };
                arkadas_sil_button.Click += new EventHandler(ButtonClickHandler);
                
                y_konum_tutucu_panel += online_mi_resimbox.Height + 5;     
                Panel.Controls.Add(online_mi_resimbox);
                Panel.Controls.Add(resim_goster_resimbox);
                Panel.Controls.Add(isim_labelbox);
                Panel.Controls.Add(button);
                Panel.Controls.Add(arkadas_sil_button);
            }
            this.Controls.Add(Panel);
        }
    



    private void ButtonClickHandler(object sender, EventArgs e)
        {
            Button tiklanan_buton = sender as Button;
            Sms_Atılacak_Kullanici_Data.Sms_Atilacak_Kullanici_Numarasi = tiklanan_buton.Name;

            if (tiklanan_buton != null)
            {
                if (tiklanan_buton.Text == "Msj At")
                {
                    Panel parentPanel = tiklanan_buton.Parent as Panel;
                    Gosterilen_adimi_Guncelle();
                    iki_numara_arasinda_acilmis_tablo_var_mi();//iki numara birlestirip bu adda taplo varmı diye kontrol eder.
                }
                else if (tiklanan_buton.Text == "Sil")
                {
                    string silinecek_kullanici_numarasi = tiklanan_buton.Name;
                    ArkadasSil(silinecek_kullanici_numarasi); 
                }

            }
        }
        public void ArkadasSil(string silinecek_numara)
        {
            DataBase.mysqlbaglan.Open();
            birlestirici = KullaniciData.Kullanici_Numarasi + "arkadaslari";
            DataBase.komut.CommandText = "DELETE FROM `" + birlestirici + "`  where Number='" + silinecek_numara + "' ";
            DataBase.dr = DataBase.komut.ExecuteReader();
            DataBase.mysqlbaglan.Close();
            arkadas_sayisi_ogrenme();
            arkadaslarimi_goster();
        }

            public void iki_numara_arasinda_acilmis_tablo_var_mi()
        {
            Data.DataBase.mysqlbaglan.Open();
            string sql = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @TabloAdi AND TABLE_SCHEMA = @VeritabaniAdi";
            using (MySqlCommand komut = new MySqlCommand(sql, Data.DataBase.mysqlbaglan))
            {
                birlestirici = KullaniciData.Kullanici_Numarasi + Sms_Atılacak_Kullanici_Data.Sms_Atilacak_Kullanici_Numarasi;
                komut.Parameters.AddWithValue("@TabloAdi", birlestirici);
                komut.Parameters.AddWithValue("@VeritabaniAdi", Data.DataBase.Veritabani_Adi);
                int count = Convert.ToInt32(komut.ExecuteScalar());
                Tablo_Var_Mi = count > 0;
            }
            Data.DataBase.mysqlbaglan.Close();
            if (Tablo_Var_Mi)
            {
                Data.DataBase.teltutucu = birlestirici;
                Sms_atilacak_kullanici_bilgileri();
                online_mi.okundu_mu(KullaniciData.Kullanici_Numarasi, "1");
                Smsekranini_ac();
            }
            else
            {
                Data.DataBase.mysqlbaglan.Open();
                string sql2 = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @TabloAdi AND TABLE_SCHEMA = @VeritabaniAdi";
                using (MySqlCommand komut = new MySqlCommand(sql2, Data.DataBase.mysqlbaglan))
                {
                    birlestirici = Sms_Atılacak_Kullanici_Data.Sms_Atilacak_Kullanici_Numarasi + KullaniciData.Kullanici_Numarasi;
                    komut.Parameters.AddWithValue("@TabloAdi",birlestirici );
                    komut.Parameters.AddWithValue("@VeritabaniAdi", Data.DataBase.Veritabani_Adi);
                    int count = Convert.ToInt32(komut.ExecuteScalar());
                    Tablo_Var_Mi = count > 0;
                }
                Data.DataBase.mysqlbaglan.Close();
                if (Tablo_Var_Mi)
                {
                    Data.DataBase.teltutucu = birlestirici;
                    Sms_atilacak_kullanici_bilgileri();
                    Data.DataBase.mysqlbaglan.Close();
                    online_mi.okundu_mu(KullaniciData.Kullanici_Numarasi, "1");
                    Smsekranini_ac();
                }
                else
                {
                    //asagıdaki ilk kısım msj atcak kisinin data basesine sms atcagı kisiyi ekleme
                    Data.DataBase.mysqlbaglan.Open();
                    birlestirici = KullaniciData.Kullanici_Numarasi + Sms_Atılacak_Kullanici_Data.Sms_Atilacak_Kullanici_Numarasi;
                    string kayit = "CREATE TABLE `" + birlestirici + "`(UserId INT NOT NULL AUTO_INCREMENT,Number VARCHAR(11) NOT NULL,Time DATETIME NOT NULL,Mesaj TEXT NOT NULL,Resim VARCHAR(200) NOT NULL,Video VARCHAR(200) NOT NULL,SesKaydi VARCHAR(200) NOT NULL,Winrar VARCHAR(200) NOT NULL,PRIMARY KEY(UserId)) ENGINE = InnoDB";
                    Data.DataBase.komut = new MySqlCommand(kayit, Data.DataBase.mysqlbaglan);
                    Data.DataBase.komut.ExecuteNonQuery();
                    Data.DataBase.mysqlbaglan.Close();
                    Data.DataBase.teltutucu = birlestirici;
                    online_mi.okundu_mu(KullaniciData.Kullanici_Numarasi, "1");
                    Sms_atilacak_kullanici_bilgileri();
                    Smsekranini_ac();
                }

            }
        }
        public void Sms_atilacak_kullanici_bilgileri()
        {
            Data.DataBase.mysqlbaglan.Open();
            Data.DataBase.komut.CommandText = "SELECT * FROM kullanicilar WHERE Number ='" + Sms_Atılacak_Kullanici_Data.Sms_Atilacak_Kullanici_Numarasi + "' ";
            Data.DataBase.dr = Data.DataBase.komut.ExecuteReader();
            if (Data.DataBase.dr.Read())
            {
                Sms_Atılacak_Kullanici_Data.Sms_Atilacak_Kullanici_ismi = Data.DataBase.dr["Name"].ToString();
                Sms_Atılacak_Kullanici_Data.Sms_Atilacak_Kullanici_resmi= Data.DataBase.dr["image"].ToString();
            }
            Data.DataBase.mysqlbaglan.Close();
        }
        public void Smsekranini_ac()
        {
            Chat chat = new Chat();
            chat.Show();
            this.Hide();
        }

        public void Gosterilen_adimi_Guncelle()
        {
            kullanici_name_text.Enabled = false;
            DataBase.mysqlbaglan.Open();
            DataBase.komut.CommandText = "UPDATE kullanicilar set Name='" +kullanici_name_text.Text  + "' where Number='" + KullaniciData.Kullanici_Numarasi + "' ";
            DataBase.dr = DataBase.komut.ExecuteReader();
            DataBase.mysqlbaglan.Close();
        }
        public void Gosterilen_resmi_Guncelle(string resimin_konumu)
        {
            DataBase.mysqlbaglan.Open();
            DataBase.komut.CommandText = "UPDATE kullanicilar set image='" + resimin_konumu + "' where Number='" + KullaniciData.Kullanici_Numarasi + "' ";
            DataBase.dr = DataBase.komut.ExecuteReader();
            DataBase.mysqlbaglan.Close();
        }


    }
}
