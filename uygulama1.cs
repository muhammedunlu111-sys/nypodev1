using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ödev_1_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool ekipmanodunctemi=false;
            Console.WriteLine("ÖDÜNÇ SÜRESİ KONTROLÜ");

            if (ekipmanodunctemi)
            {
                Console.WriteLine("EKİPMAN ŞU ANDA ÖDÜNÇTE");
                Console.ReadKey();
                return;
            }
            Console.Write("EKİPMANI ÖDÜNÇ ALMAK İSTEDİĞİNİZ GÜN SAYISINI YAZINIZ  \n ");
            string istenengün = Console.ReadLine();

            if (!int.TryParse(istenengün, out int günsayisi))
            {
                Console.WriteLine("ÖDÜNÇ ALAMAK İSTEDİĞNİZ GÜN SAYISINI SAYI ŞEKLİNDE GİRİNİZ \n ");
                Console.ReadKey();
                return ;
            }
            if (günsayisi < 1 || günsayisi > 7)
            {
                Console.WriteLine($"{günsayisi} GÜN SAYISI 1 İLE 7 GÜN ARASINDA OLMALIDIR ");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"EKİPMAN {günsayisi} GÜN SİZE ÖDÜNÇ VERİLMİŞTİR ");
            Console.ReadKey();
        }
    
    }
}
