using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UYGULAMA_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

                List<string> numaralar = new List<string> { "05551112233", "05322223344", "05423334455", "05054445566" };

                Console.WriteLine("LİSTE ARAMA TESTİ");

                bool ilkelemansonuc = numaravarmi(numaralar, "05551112233");
                Console.WriteLine($"1. İlk eleman ('05551112233') var mı? -> {ilkelemansonuc}");

                bool sonelemansonuc = numaravarmi(numaralar, "05054445566");
                Console.WriteLine($"2. Son eleman ('05054445566') var mı? -> {sonelemansonuc}");

                bool olmayansonuc = numaravarmi(numaralar, "05999999999");
                Console.WriteLine($"3. Olmayan numara ('05999999999') var mı? -> {olmayansonuc}");

                List<string> bosliste = new List<string>();
                bool boslistesonuc = numaravarmi(bosliste, "05551112233");
                Console.WriteLine($"4. Boş listede arama sonucu -> {boslistesonuc} (Doğrulandı)");
            }

   
    static bool numaravarmi(List<string> liste, string aranan)
            {
                foreach (string numara in liste)
                {
                    
                    if (numara == aranan)
                    {
                        return true; 
                    }
                }

               
                return false;
            }
        }
    }

        foreach (string numara in liste)
        {
            // Listedeki mevcut eleman ile aranan eleman eşleşiyor mu kontrol ediyoruz
            if (numara == aranan)
            {
                return true; // Bulunduğu an aramayı sonlandırıp true döndürüyoruz
            }
        }

        // Döngü hiç eşleşme bulamadan biterse veya liste boşsa false döndürüyoruz
        return false;
    }
}
