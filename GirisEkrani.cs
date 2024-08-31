using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace vssms
{
    public partial class GirisEkrani : Form
    {
        public GirisEkrani()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(esc.MainForm_FormClosing2);
        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Data.DataBase.mysqlbaglan.Open();
            Data.DataBase.komut.CommandText = "SELECT * FROM kullanicilar where Number='" + kullanici_tel_no_text.Text + "' AND Password='" + kullanici_sifre_text.Text + "'";
            Data.DataBase.dr = Data.DataBase.komut.ExecuteReader();
            if (Data.DataBase.dr.Read())
            {
                KullaniciData.Kullanici_Numarasi = Data.DataBase.dr["Number"].ToString();
                KullaniciData.Kullanici_ismi = Data.DataBase.dr["Name"].ToString();
                KullaniciData.Kullanici_resmi = Data.DataBase.dr["Image"].ToString();
                Data.DataBase.mysqlbaglan.Close();
                online_mi.online(kullanici_tel_no_text.Text,"1");
                Hesap hesap = new Hesap();
                hesap.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Kullanıcı tel numarası yada şifre yanlış");
            }
            Data.DataBase.mysqlbaglan.Close();
        }

        private void Sifreyi_Goster_Gizle_img_Click(object sender, EventArgs e)
        {
            if(kullanici_sifre_text.UseSystemPasswordChar == false)
            {
                kullanici_sifre_text.UseSystemPasswordChar = true;
                Sifreyi_Goster_Gizle_img.Image = Properties.Resources.goster;
                kullanici_sifre_text.PasswordChar = '*';
            }
            else 
            {
                kullanici_sifre_text.UseSystemPasswordChar = false;
                Sifreyi_Goster_Gizle_img.Image = Properties.Resources.gizle;
                kullanici_sifre_text.PasswordChar = '\0';
            }
        }

        private void new_user_add_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Kayitol kayitol = new Kayitol();
            kayitol.Show();
            this.Hide();
        }

        private void password_unuttum_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifremiUnuttum sifremiunuttum = new SifremiUnuttum();
            sifremiunuttum.Show();
            this.Hide();
        }

        private void kullanici_ismi_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void kullanici_sifre_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                pictureBox1_Click(pictureBox1, EventArgs.Empty);
            }
        }

    }
}
