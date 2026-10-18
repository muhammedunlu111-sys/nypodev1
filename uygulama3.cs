using System;
using System.Collections.Generic;
using System.Linq;

namespace EkipmanTakipSistemi
{
    
    public class Ekipman
    {
        public string DemirbasNumarasi { get; set; }
        public string Adi { get; set; }
        public bool OduncteMi { get; set; }
        public string OduncAlanOgrenciNo { get; set; }

        public override string ToString()
        {
            string durum = OduncteMi ? $"Ödünçte (Öğrenci No: {OduncAlanOgrenciNo})" : "Müsait";
            return $"Demirbaş No: {DemirbasNumarasi} | Adı: {Adi} | Durumu: {durum}";
        }
    }

    public class Ogrenci
    {
        public string OgrenciNo { get; set; }
        public string AdSoyad { get; set; }

        public override string ToString()
        {
            return $"Öğrenci No: {OgrenciNo} - Ad Soyad: {AdSoyad}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
    
            List<Ekipman> ekipmanlar = new List<Ekipman>
            {
                new Ekipman { DemirbasNumarasi = "H001", Adi = "Dizüstü Bilgisayar", OduncteMi = false },
                new Ekipman { DemirbasNumarasi = "H002", Adi = "Projektör", OduncteMi = false },
                new Ekipman { DemirbasNumarasi = "H003", Adi = "Grafik Tablet", OduncteMi = false }
            };

            List<Ogrenci> ogrenciler = new List<Ogrenci>
            {
                new Ogrenci { OgrenciNo = "132530063", AdSoyad = "Muhammed Ünlü" }
                new Ogrenci { OgrenciNo = "13253057", AdSoyad = "Berat Zahit Karastaş" }
            };

            Console.WriteLine("BAŞLANGIÇ EKİPMAN LİSTESİ );
            ekipmanlar.ForEach(e => Console.WriteLine(e));
            Console.WriteLine();

            Console.WriteLine(" 1. ARAMA TESTLERİ ");
            EkipmanBul(ekipmanlar, "H001");
            EkipmanBul(ekipmanlar, "H999");
            Console.WriteLine();

          
            Console.WriteLine("=== 2. İLK ÖDÜNÇ VE İADE DÖNGÜSÜ ===");
            OduncVer(ekipmanlar, ogrenciler, "H001", "132530063"); 
            OduncVer(ekipmanlar, ogrenciler, "H001", "132530057");

            IadeAl(ekipmanlar, "H001");
            Console.WriteLine();


            Console.WriteLine("3. İKİNCİ ÖDÜNÇ VE İADE DÖNGÜSÜ");
            OduncVer(ekipmanlar, ogrenciler, "H001", "132530057")r

    
            OduncVer(ekipmanlar, ogrenciler, "H002", "9999999");

            IadeAl(ekipmanlar, "H001"); 


            IadeAl(ekipmanlar, "H001");
            Console.WriteLine();


            Console.WriteLine("SON DURUM EKİPMAN LİSTESİ ");
            ekipmanlar.ForEach(e => Console.WriteLine(e));
        }

ot
        public static Ekipman EkipmanBul(List<Ekipman> liste, string demirbasNo)
        {
            Ekipman bulunan = liste.FirstOrDefault(e => e.DemirbasNumarasi.Equals(demirbasNo, StringComparison.OrdinalIgnoreCase));

            if (bulunan != null)
            {
                Console.WriteLine($"[Bulundu] {bulunan}");
            }
            else
            {
                Console.WriteLine($"[Bulunamadı] '{demirbasNo}' numaralı ekipman sistemde mevcut değil.");
            }
            return bulunan;
        }

        // Ödünç Verme Metodu
        public static void OduncVer(List<Ekipman> ekipmanListesi, List<Ogrenci> ogrenciListesi, string demirbasNo, string ogrenciNo)
        {
            Console.WriteLine($"\n> Ödünç İşlem Girişimi: Demirbaş ({demirbasNo}) -> Öğrenci ({ogrenciNo})");

            var ekipman = EkipmanBulIc(ekipmanListesi, demirbasNo);
            if (ekipman == null)
            {
                Console.WriteLine("İşlem Başarısız: Ekipman bulunamadı.");
                return;
            }

            if (ekipman.OduncteMi)
            {
                Console.WriteLine($"İşlem Başarısız: Bu ekipman zaten {ekipman.OduncAlanOgrenciNo} numaralı öğrencide ödünçte.");
                return;
            }

            var ogrenci = ogrenciListesi.FirstOrDefault(o => o.OgrenciNo.Equals(ogrenciNo));
            if (ogrenci == null)
            {
                Console.WriteLine("İşlem Başarısız: Sistemde böyle kayıtlı bir öğrenci bulunmuyor.");
                return;
            }

            ekipman.OduncteMi = true;
            ekipman.OduncAlanOgrenciNo = ogrenci.OgrenciNo;
            Console.WriteLine($"[Başarılı] '{ekipman.Adi}' adlı ekipman, '{ogrenci.AdSoyad}' adlı öğrenciye ödünç verildi.");
        }

        // İade Alma Metodu
        public static void IadeAl(List<Ekipman> ekipmanListesi, string demirbasNo)
        {
            Console.WriteLine($"\n> İade İşlem Girişimi: Demirbaş ({demirbasNo})");

            var ekipman = EkipmanBulIc(ekipmanListesi, demirbasNo);
            if (ekipman == null)
            {
                Console.WriteLine("İşlem Başarısız: Ekipman bulunamadı.");
                return;
            }

            if (!ekipman.OduncteMi)
            {
                Console.WriteLine("İşlem Başarısız: Bu ekipman zaten ödünçte değil (zaten depoda/müsait).");
                return;
            }

            Console.WriteLine($"[Başarılı] '{ekipman.Adi}' adlı ekipman (Öğrenci No: {ekipman.OduncAlanOgrenciNo}) tarafından iade alındı.");
            ekipman.OduncteMi = false;
            ekipman.OduncAlanOgrenciNo = null;
        }

      
        private static Ekipman EkipmanBulIc(List<Ekipman> liste, string demirbasNo)
        {
            return liste.FirstOrDefault(e => e.DemirbasNumarasi.Equals(demirbasNo, StringComparison.OrdinalIgnoreCase));
        }
    }
}
