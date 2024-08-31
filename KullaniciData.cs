using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vssms
{
    public static class KullaniciData
    {
        public static string Kullanici_Numarasi = " ";
        public static string Kullanici_ismi = " ";
        public static string Kullanici_resmi = " ";
        public static bool online_mi=false,kullanici_resmi_mi_degisiyor=false;
        public static int Sms_Attigim_kisinin_en_son_gordugu_msj ;
        public static string Secilen_resmin_bilgisayar_uzerindeki_yolu = "";
        public static DateTime son_online_olma_zamani;
    }
}
