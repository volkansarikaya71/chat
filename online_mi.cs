using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vssms
{
    internal class online_mi
    {
        public static void online(string number,string online_mi)
        {
            Data.DataBase.mysqlbaglan.Open();
            string guncelle = "UPDATE kullanicilar SET Online = @Online, OflineTime = @OflineTime WHERE Number = @Number";
            Data.DataBase.komut = new MySqlCommand(guncelle, Data.DataBase.mysqlbaglan);
            Data.DataBase.komut.Parameters.AddWithValue("@Number", number);
            Data.DataBase.komut.Parameters.AddWithValue("@Online", online_mi);
            Data.DataBase.komut.Parameters.AddWithValue("@OflineTime",KullaniciData.son_online_olma_zamani);
            Data.DataBase.komut.ExecuteNonQuery();
            Data.DataBase.mysqlbaglan.Close();
        }
        public static void okundu_mu(string number, string okudu)
        {
            Data.DataBase.mysqlbaglan.Open();
            string birlestir = number+"arkadaslari";
            string guncelle = "UPDATE `"+ birlestir + "` SET Okundu = @Okundu WHERE Number = @Number ";
            Data.DataBase.komut = new MySqlCommand(guncelle, Data.DataBase.mysqlbaglan);
            Data.DataBase.komut.Parameters.AddWithValue("@Number", Sms_Atılacak_Kullanici_Data.Sms_Atilacak_Kullanici_Numarasi);
            Data.DataBase.komut.Parameters.AddWithValue("@Okundu", okudu);
            Data.DataBase.komut.ExecuteNonQuery();
            Data.DataBase.mysqlbaglan.Close();
        }
        public static void msj_attim_okudu_mu(string number, string okudu)
        {
            Data.DataBase.mysqlbaglan.Open();
            string birlestir = Sms_Atılacak_Kullanici_Data.Sms_Atilacak_Kullanici_Numarasi + "arkadaslari";
            string guncelle = "UPDATE `" + birlestir + "` SET Okundu = @Okundu WHERE Number = @Number ";
            Data.DataBase.komut = new MySqlCommand(guncelle, Data.DataBase.mysqlbaglan);
            Data.DataBase.komut.Parameters.AddWithValue("@Number", number);
            Data.DataBase.komut.Parameters.AddWithValue("@Okundu", okudu);
            Data.DataBase.komut.ExecuteNonQuery();
            Data.DataBase.mysqlbaglan.Close();
        }

    }
}
