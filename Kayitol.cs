using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vssms.Properties;
using static Mysqlx.Expect.Open.Types.Condition.Types;
using static System.Net.WebRequestMethods;

namespace vssms
{
    public partial class Kayitol : Form
    {
        public Kayitol()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(esc.MainForm_FormClosing2);
        }

        public bool resim, epostaknt, telnumberkontrol,eposta_kullanimda_mi;
        public string birlestirici;

        private void numara_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Kullaniciadi_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void Eposta_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            epostakontrol();
            kullanicikontrolet();
            Eposta_kayitli_mi();
            if (numara_text.Text != "" && numara_text.Text.Length == 11 && telnumberkontrol == false && sifre_text.Text != "" && sifre_text.Text.Length >= 6 && Kullaniciadi_text.Text != "" && Kullaniciadi_text.Text.Length >= 3 && Eposta_text.Text != "" && epostaknt == true && eposta_kullanimda_mi == false && resim == true )
            {
                veriekle();
                MessageBox.Show("Tebrikler.Başarılı bir şekil kayıt oldunuz");
                kullanici_arkadas_tablosu_olusturma();
                girisekrani();
            }
            else if (numara_text.Text == "" || numara_text.Text.Length != 11 || sifre_text.Text == "" || Kullaniciadi_text.Text == "" || Kullaniciadi_text.Text.Length < 3 || Eposta_text.Text == "" || !resim || sifre_text.Text.Length <= 5)
            {
                if (numara_text.Text == "")
                {
                    MessageBox.Show("numaranızı girin");
                }
                if (numara_text.Text.Length != 11)
                {
                    MessageBox.Show("numaranızı 11 haneli degil");
                }
                if (sifre_text.Text == "")
                {
                    MessageBox.Show("sifrenizi girin");
                }
                if (sifre_text.Text.Length <= 5)
                {
                    MessageBox.Show("sifrenizi en az 6 harf olmalıdır.");
                }
                if (Kullaniciadi_text.Text == "")
                {
                    MessageBox.Show("kullanıcı adi girin");
                }
                if (Kullaniciadi_text.Text.Length < 3)
                {
                    MessageBox.Show("kullanıcı adınız en az 3 karekter olmak zorunda");
                }
                if (Eposta_text.Text == "")
                {
                    MessageBox.Show("eposta girin");
                }
                if (resim == false)
                {
                    MessageBox.Show("resim seçin");
                }

            }
        }
        private void geri_img_Click(object sender, EventArgs e)
        {
            girisekrani();
        }
        private void kullaniciisim_img_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Resim sec";
            openFileDialog1.Filter = "PNG Dosyaları (*.png)|*.png";
           if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = Path.GetFileName(openFileDialog1.FileName);
                if (selectedFilePath.Length > 100)
                {
                    MessageBox.Show("Seçilen dosya yolunun uzunluğu 100 karakterden fazla olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    KullaniciData.Secilen_resmin_bilgisayar_uzerindeki_yolu = openFileDialog1.FileName;
                    resim = true;
                    kullaniciisim_img.ImageLocation = openFileDialog1.FileName;
                }

            }
        }
        public void veriekle()
        {
            Data.FileZillaData.Klasor_Ekle(numara_text.Text);
            Data.FileZillaData.ResimEkle(openFileDialog1.FileName, numara_text.Text);
            Data.DataBase.mysqlbaglan.Open();
            string kayit = "insert into kullanicilar(Number,Password,Name,Eposta,image) values (@Number,@Password,@Name,@Eposta,@image)";
            Data.DataBase.komut = new MySqlCommand(kayit, Data.DataBase.mysqlbaglan);
            Data.DataBase.komut.Parameters.AddWithValue("@Number", numara_text.Text);
            Data.DataBase.komut.Parameters.AddWithValue("@Password", sifre_text.Text);
            Data.DataBase.komut.Parameters.AddWithValue("@Name", Kullaniciadi_text.Text);
            Data.DataBase.komut.Parameters.AddWithValue("@Eposta", Eposta_text.Text);
            Data.DataBase.komut.Parameters.AddWithValue("@image", Data.FileZillaData.FtpUrl);
            Data.DataBase.komut.ExecuteNonQuery();
            Data.DataBase.mysqlbaglan.Close();
        }
        public void kullanicikontrolet()
        {
            Data.DataBase.mysqlbaglan.Open();
            Data.DataBase.komut.CommandText = "SELECT * FROM kullanicilar where Number='" + numara_text.Text +"'";
            Data.DataBase.dr = Data.DataBase.komut.ExecuteReader();
            if (Data.DataBase.dr.Read())
            {
                telnumberkontrol = true;
                MessageBox.Show("Bu telefon numarası kullanımda");
                Data.DataBase.mysqlbaglan.Close();
            }
            else
            {
                telnumberkontrol = false;
            }
            Data.DataBase.mysqlbaglan.Close();
        }
        public void Eposta_kayitli_mi()
        {
            Data.DataBase.mysqlbaglan.Open();
            Data.DataBase.komut.CommandText = "SELECT * FROM kullanicilar where Eposta='" + Eposta_text.Text + "'";
            Data.DataBase.dr = Data.DataBase.komut.ExecuteReader();
            if (Data.DataBase.dr.Read())
            {
                eposta_kullanimda_mi = true;
                MessageBox.Show("Bu eposta adresi kullanımda");
                Data.DataBase.mysqlbaglan.Close();
            }
            else
            {
                eposta_kullanimda_mi = false;
            }
            Data.DataBase.mysqlbaglan.Close();
        }

        private void Sifreyi_Goster_Gizle_img_Click(object sender, EventArgs e)
        {
            if (sifre_text.UseSystemPasswordChar == false)
            {
                sifre_text.UseSystemPasswordChar = true;
                Sifreyi_Goster_Gizle_img.Image = Properties.Resources.goster;
                sifre_text.PasswordChar = '*';
            }
            else
            {
                sifre_text.UseSystemPasswordChar = false;
                Sifreyi_Goster_Gizle_img.Image = Properties.Resources.gizle;
                sifre_text.PasswordChar = '\0';
            }

        }

        public void epostakontrol()
        {
            if (Eposta_text.Text.IndexOf("@hotmail.com") != -1 || Eposta_text.Text.IndexOf("@gmail.com") != -1)
            {
                epostaknt = true;
            }
            else { epostaknt = false;
                MessageBox.Show("epostanız @hotmail.com veya @gmail.com olmalıdır.");
            }
        }

        public void girisekrani()
        {
            GirisEkrani girisEkrani = new GirisEkrani();
            girisEkrani.Show();
            this.Hide();
        }
        public void kullanici_arkadas_tablosu_olusturma()
        {
            Data.DataBase.mysqlbaglan.Open();
            birlestirici= numara_text.Text +"arkadaslari";
            string Tablokayit = "CREATE TABLE `" + birlestirici + "` (UserId INT(11) NOT NULL AUTO_INCREMENT,Number VARCHAR(11) NOT NULL,Okundu TINYINT(0) NOT NULL,Msjsayisi INT(11) NOT NULL,PRIMARY KEY(UserId)) ENGINE = InnoDB;";
            Data.DataBase.komut = new MySqlCommand(Tablokayit, Data.DataBase.mysqlbaglan);
            Data.DataBase.komut.ExecuteNonQuery();
            Data.DataBase.mysqlbaglan.Close();
        }



    }
}