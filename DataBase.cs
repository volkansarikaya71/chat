using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace vssms
{

    public static class Data
    {
        public static class DataBase
        {
            public static string Veritabani_Adi = "u717747209_chat";

            public static MySqlConnection mysqlbaglan = new MySqlConnection(//localhost kullanmadıgım için gizli kalması adina sildim");
            public static MySqlCommand komut = mysqlbaglan.CreateCommand();
            public static MySqlDataReader dr;
            public static string teltutucu = " ";
            


        }

        public static class FileZillaData
        {
            public static string ftpAddress = //localhost kullanmadıgım için gizli kalması adina sildim;
            static string ftpUsername = //localhost kullanmadıgım için gizli kalması adina sildim;
            static string ftpPassword = //localhost kullanmadıgım için gizli kalması adina sildim;
            public static string FtpUrl;
            static bool ayni_isimde_resim_var_mi;
            static string yeni_resmin_tam_konumu;
            public static string gosterilcek_resmin_ismi;   

            public static void Klasor_Ekle(string klasor_adi)
            {

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpAddress + klasor_adi);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {

                }

            }
            public static void ResimEkle(string Resim_konumu,string klasor_adi)
            {
                // Dosya adı
                string fileName = Path.GetFileName(Resim_konumu);
                // FTP adresine dosya adını ekleyin
                if(ayni_isimde_resim_var_mi)
                {
                    FtpUrl = ftpAddress + klasor_adi + "/" + "1"+fileName;
                    Ayni_Adda_Resim_var_mi(FtpUrl);
                }
                else
                {
                    FtpUrl = ftpAddress + klasor_adi + "/" + fileName;

                    // Dosyayı yükleyin
                    using (WebClient client = new WebClient())
                    {
                        // Kimlik bilgilerini ayarlayın
                        client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                        // Dosyayı yükleyin
                        client.UploadFile(FtpUrl, WebRequestMethods.Ftp.UploadFile, KullaniciData.Secilen_resmin_bilgisayar_uzerindeki_yolu);

                    }

                }

            }
            public static byte[] Resimi_goster(string resim)
            {

                // FtpWebRequest nesnesi oluşturun
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(resim);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                // Kimlik bilgilerini ayarlayın
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

                // Yanıtı alın
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (Stream responseStream = response.GetResponseStream())
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Resmi bellek içine yükleyin
                    responseStream.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }
            }
            public static void Ayni_Adda_Resim_var_mi(string guncellenecek_resmin_konumu)
            {

                try
                {
                    yeni_resmin_tam_konumu = ftpAddress + KullaniciData.Kullanici_Numarasi + "/" + Path.GetFileName(guncellenecek_resmin_konumu);
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(yeni_resmin_tam_konumu);
                    request.Method = WebRequestMethods.Ftp.GetFileSize;
                    request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    {
                        if (response != null)
                        {
                            //// Eğer dosya bulunursa boyutunu döndüren bir yanıt alırız.
                            ayni_isimde_resim_var_mi = true;
                            ResimEkle(yeni_resmin_tam_konumu, KullaniciData.Kullanici_Numarasi);
                        }

                    }
                }
                catch (WebException ex)
                {
                    if (ex.Response is FtpWebResponse response)
                    {
                        if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable && KullaniciData.kullanici_resmi_mi_degisiyor == true)
                        {
                            ayni_isimde_resim_var_mi = false;
                            DataBase.mysqlbaglan.Open();
                            DataBase.komut.CommandText = "UPDATE kullanicilar set image='" + yeni_resmin_tam_konumu + "' where Number='" + KullaniciData.Kullanici_Numarasi + "' ";
                            DataBase.dr = DataBase.komut.ExecuteReader();
                            DataBase.mysqlbaglan.Close();
                            ResimEkle(yeni_resmin_tam_konumu, KullaniciData.Kullanici_Numarasi);
                            KullaniciData.kullanici_resmi_mi_degisiyor = false;
                        }
                        if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                        {
                            ayni_isimde_resim_var_mi = false;
                            ResimEkle(yeni_resmin_tam_konumu, KullaniciData.Kullanici_Numarasi);
                        }
                    }
                }
            }

            public static void Resim_indir(string eklenecek_resim,string tel_no,string dosyakonumu)
            {
                try
                {
                    //MessageBox.Show(eklenecek_resim + " eklenecek resim");
                    FtpUrl = ftpAddress + tel_no + "/" + eklenecek_resim;
                    //MessageBox.Show(FtpUrl + " ftp url");

                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FtpUrl);
                    request.Method = WebRequestMethods.Ftp.DownloadFile;
                    request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

                    string hedefYol = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dosyakonumu, eklenecek_resim);
                    Directory.CreateDirectory(Path.GetDirectoryName(hedefYol));

                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    using (Stream responseStream = response.GetResponseStream())
                    using (FileStream fileStream = new FileStream(hedefYol, FileMode.Create))
                    {
                        responseStream.CopyTo(fileStream);
                    }
                    gosterilcek_resmin_ismi = eklenecek_resim;
                    //MessageBox.Show("Resim başarıyla indirildi ve kaydedildi.");
                }
                catch (WebException ex)
                {
                    var response = (FtpWebResponse)ex.Response;
                    if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    {
                        MessageBox.Show("Dosya bulunamadı veya erişim izni yok.");
                    }
                    else if (response.StatusCode == FtpStatusCode.ActionAbortedLocalProcessingError)
                    {
                        MessageBox.Show("Geçici bir hata oluştu. Lütfen tekrar deneyin.");
                    }
                    else
                    {
                        MessageBox.Show("FTP Hatası: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }


            }


        }


    }

        
    
}
