using System;
using System.Threading;

namespace Test_psaní_19._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadejte text, který chcete opisova");
            string text = Console.ReadLine();
            double cas_zacatek_sec, cas_konec_sec, cas_zacatek_min, cas_konec_min, cas, pocetChyb = 0;
            Console.WriteLine("Vítej v testu psaní");
            Console.WriteLine("-------------\nZobrazí se ti text a zkus ho opsat co nejpřesněji a nakonec ukonči stisknutím klávesi Enter\n---------");
            Thread.Sleep(1500);
            Console.WriteLine(text);    

            DateTime time_zacatek_sec = DateTime.Now;
            DateTime time_zacatek_min = DateTime.Now;
            cas_zacatek_sec = time_zacatek_sec.Second;
            cas_zacatek_min = time_zacatek_min.Minute;
        
            string naceteny_text = Console.ReadLine();

            DateTime time_konec_sec = DateTime.Now;
            DateTime time_konec_min = DateTime.Now;
            cas_konec_sec = time_konec_sec.Second;
            cas_konec_min = time_konec_min.Minute;
            cas = cas_konec_sec - cas_zacatek_sec;
            if (naceteny_text.Length < text.Length)
            {
                do
                {
                    naceteny_text += "0";
                } while (naceteny_text.Length != text.Length);
            }
            else if (naceteny_text.Length > text.Length)
            {
                char splitter = naceteny_text[text.Length];
                string[] nasText = naceteny_text.Split(splitter);
                naceteny_text = nasText[0];
                pocetChyb = nasText[1].Length;
                if (naceteny_text.Length < text.Length)
                {
                    do
                    {
                        naceteny_text += "0";
                        pocetChyb--;
                    } while (naceteny_text.Length != text.Length);
                }
            }

            if (cas_zacatek_min != cas_konec_min)
            {
                double cas_min = cas_konec_min - cas_zacatek_min;
                cas_min *= 60;
                cas = cas_min - cas;
            }
            for (int i = 0; i < text.Length; i++)
            {
                char zank_puv, zank_kon;
                zank_puv = text[i];
                zank_kon = naceteny_text[i];
                if (zank_kon != zank_puv)
                { 
                    pocetChyb++;    
                }
            }
            if (pocetChyb == 0)
            {
                Console.WriteLine("Opsal jsi celý text bez jediné chyby za čas: {0} sekund", cas);
                cas /= 60;
                double wpm = text.Length / cas;
                Console.WriteLine("Tvoje rychlost je: {0} WPM", Math.Round(wpm));
            }
            else if (pocetChyb > 0 && pocetChyb < 6)
            {
                Console.WriteLine("Opsal jsi celý text s {0} chybami za čas: {1} sekund",pocetChyb, cas);
                cas /= 60;
                double wpm = text.Length / cas;
                Console.WriteLine("Tvoje rychlost je: {0} WPM", Math.Round(wpm));
            }
            else
            {
                Console.WriteLine("Opsal jsi celý text s {0} chybami za čas: {1} sekund",pocetChyb, cas);
            }
            Console.ReadKey();
        }
        
    }
}
