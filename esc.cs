using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vssms
{
    internal class esc
    {
        public static void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kullanıcıya uygulamayı kapatmak isteyip istemediğini sor
            DialogResult result = MessageBox.Show("Uygulamayı kapatmak istiyor musunuz?", "Uygulama Kapatma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                // Kapatma işlemini iptal et
                e.Cancel = true;
            }
            else
            {
                online_mi.online(KullaniciData.Kullanici_Numarasi, "0");


                Environment.Exit(0);
                // Kaynakları serbest bırak veya veritabanı güncellemelerini yap
                // Örneğin: Veritabanı bağlantısını kapat, dosyaları kaydet, vb.
                // CleanupResources();
            }
        }
        public static void MainForm_FormClosing2(object sender, FormClosingEventArgs e)
        {
            // Kullanıcıya uygulamayı kapatmak isteyip istemediğini sor
            DialogResult result = MessageBox.Show("Uygulamayı kapatmak istiyor musunuz?", "Uygulama Kapatma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                // Kapatma işlemini iptal et
                e.Cancel = true;
            }
            else
            {
                Environment.Exit(0);
                // Kaynakları serbest bırak veya veritabanı güncellemelerini yap
                // Örneğin: Veritabanı bağlantısını kapat, dosyaları kaydet, vb.
                // CleanupResources();
            }
        }
    }
}
