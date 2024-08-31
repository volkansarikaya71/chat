using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace vssms
{
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(esc.MainForm_FormClosing2);
        }
        public int rasgelesayi;
        public bool epostaknt,kullanicikontrol;
        private void geri_img_Click(object sender, EventArgs e)
        {
            girisekrani();
        }

        public void girisekrani()
        {
            GirisEkrani girisEkrani = new GirisEkrani();
            girisEkrani.Show();
            this.Hide();
        }
        public void randomSecurityCode()
        {
            Random rastgele = new Random();
            rasgelesayi = rastgele.Next(100000,999999);
        }
        private void Eposta_send_img_Click(object sender, EventArgs e)
        {
            epostakontrol();
            if (epostaknt == true && kullanicikontrol == true)
            {
                epostagonder();
                Eposta_text.Enabled = false;
                eposta_img.Enabled = false;
                eposta_label.Enabled = false;
                Eposta_send_img.Enabled = false;

                securitycode_text.Visible = true;
                securitycode_img.Visible = true;
                securitycode_label.Visible = true;

                Sifreyi_Goster_Gizle_img.Visible = true;

                sifre_text.Visible = true;
                sifre_img.Visible = true;
                sifre_label.Visible = true;
                save_img.Visible=true;

            }

        }


        private void SifremiUnuttum_Load(object sender, EventArgs e)
        {
            randomSecurityCode();
        }

        public void epostakontrol()
        {
            if (Eposta_text.Text.IndexOf("@hotmail.com") != -1 || Eposta_text.Text.IndexOf("@gmail.com") != -1)
            {
                epostaknt = true;
                boyle_bir_eposta_var_mi();
            }
            else
            {
                epostaknt = false;
                MessageBox.Show("epostanız @hotmail.com veya @gmail.com olmalıdır.");
            }
        }

        public void epostagonder()
        {
            MailMessage mesaj = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("vsdeneme71@gmail.com", "ejhh jtis uklo jbqi");
            istemci.Port = 587;
            istemci.Host = "smtp.gmail.com";
            istemci.EnableSsl = true;
            mesaj.To.Add(Eposta_text.Text);
            mesaj.From = new MailAddress("vsdeneme71@gmail.com");
            mesaj.Subject = "SecurityCode";
            mesaj.Body = rasgelesayi.ToString();
            istemci.Send(mesaj);
        }
        public void boyle_bir_eposta_var_mi()
        {
            Data.DataBase.mysqlbaglan.Open();
            Data.DataBase.komut.CommandText = "SELECT * FROM kullanicilar where Eposta='" + Eposta_text.Text + "' ";
            Data.DataBase.dr = Data.DataBase.komut.ExecuteReader();
            if (Data.DataBase.dr.Read())
            {
                kullanicikontrol = true;
                Data.DataBase.mysqlbaglan.Close();
                Data.DataBase.mysqlbaglan.Open();
                Data.DataBase.komut.CommandText = "UPDATE kullanicilar set SecurityCode='"+rasgelesayi.ToString()+"' where Eposta='" + Eposta_text.Text + "' ";
                Data.DataBase.dr = Data.DataBase.komut.ExecuteReader();
            }
            else
            {
                kullanicikontrol = false;
                MessageBox.Show("Böyle bir eposta adresi bulunmamaktadir.");
            }
            Data.DataBase.mysqlbaglan.Close();
        }

        private void save_img_Click(object sender, EventArgs e)
        {
            securitycode_ile_sifre_guncelle();
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

        public void securitycode_ile_sifre_guncelle()
        {
            Data.DataBase.mysqlbaglan.Open();
            Data.DataBase.komut.CommandText = "SELECT * FROM kullanicilar where SecurityCode='" + securitycode_text.Text+ "' ";
            Data.DataBase.dr = Data.DataBase.komut.ExecuteReader();
            if (Data.DataBase.dr.Read())
            {
                kullanicikontrol = true;
                Data.DataBase.mysqlbaglan.Close();
                Data.DataBase.mysqlbaglan.Open();
                Data.DataBase.komut.CommandText = "UPDATE kullanicilar set Password='" + sifre_text.Text + "' where Eposta='" + Eposta_text.Text + "' ";
                Data.DataBase.dr = Data.DataBase.komut.ExecuteReader();
                MessageBox.Show("Şifreniz Güncellenmistir.");
                girisekrani();
                Data.DataBase.mysqlbaglan.Close();
            }
            else
            {
                kullanicikontrol = false;
                MessageBox.Show("Girdiginiz Securtiy kodunuz yanlıstır.");
            }
            Data.DataBase.mysqlbaglan.Close();
        }

    }
}
