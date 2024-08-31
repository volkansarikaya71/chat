using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kripto
{
    
    internal class Kripto_olusturucu
    {
        public static int asciiDegeri;
        public static string ikilik_sistem_degeri,ikilik_sistem,kripto;
        public static char[] karakterler;
        public static void Metini_harf_yap(string metini_harfe_donustur)
        {
            ikilik_sistem = "";
            kripto = "";
            foreach (char karakter in metini_harfe_donustur)
            {
                asciiDegeri = (int)karakter;
                ikilik_sisteme_cevir(asciiDegeri);
            }
            //sondaki virgül silme
            ikilik_sistem = ikilik_sistem.Substring(0, ikilik_sistem.Length - 1);
            metini_siflere(ikilik_sistem);
        }
        public  static void ikilik_sisteme_cevir(int sayi)
        {
            ikilik_sistem_degeri = "";
            while (sayi > 0)
            {
                ikilik_sistem_degeri += (sayi % 2) ;
                sayi = sayi / 2;
            }
            metni_ters_cevir(ikilik_sistem_degeri);
        }
        public static void metni_ters_cevir(string ters_cevrircek_metin)
        {
            karakterler = ters_cevrircek_metin.ToCharArray();
            Array.Reverse(karakterler);
            ikilik_sistem += new string(karakterler);
            ikilik_sistem += ",";
        }
        public static void metini_siflere(string ikilik_sistemdeki_metin)
        {
            foreach (char karakter in ikilik_sistemdeki_metin)
            {
                if(karakter=='0')
                { kripto += "*"; }
                else if(karakter=='1')
                { kripto += "?"; }
                else if (karakter == ',')
                { kripto += "!"; }
            }
        }
    }

    internal class Kripto_cozucu
    {
        public static string ikilik_sistem,kriptonun_cozulmus_hali;
        public static string[] harflerin_ikilik_sistemindeki_karsiliklari;
        public static void metinin_sifresini_coz(string sifreli_metin)
        {
            ikilik_sistem = "";
            kriptonun_cozulmus_hali="";
            foreach (char karakter in sifreli_metin)
            {
                if (karakter == '*')
                { ikilik_sistem += "0"; }
                else if (karakter == '?')
                { ikilik_sistem += "1"; }
                else if (karakter == '!')
                { ikilik_sistem += ","; }
            }
            sifreyi_coz_harfe_cevir(ikilik_sistem);
        }
        public static void sifreyi_coz_harfe_cevir(string ikilik_sistemdeki_virgullu_sayilar)
        {
            harflerin_ikilik_sistemindeki_karsiliklari = ikilik_sistemdeki_virgullu_sayilar.Split(',');
            foreach (string sayi in harflerin_ikilik_sistemindeki_karsiliklari)
            {
                int onlukSayi = Convert.ToInt32(sayi, 2);
                char karakter = (char)onlukSayi;
                kriptonun_cozulmus_hali += karakter;
            }
        }

    }

}
