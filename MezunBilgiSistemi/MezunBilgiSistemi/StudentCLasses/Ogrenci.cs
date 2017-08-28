using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
    public class  Ogrenci
    {
        public Ogrenci()
        {
           this.staj = new Staj();
           this. mezunbilgi = new MezunBilgi();
        }
        public string Ad { get; set; }
        public string Adres { get; set; }
        public int telNo { get; set; }
        public string ePosta { get; set; }
        public string Uyruk { get; set; }
        public int dogumTarihiYil { get; set; }
        public int ogrenciNo { get; set; }
        public string yabanciDil { get; set; }
        public string ilgiAlani { get; set; }
        public Staj staj { get; set; }
        public MezunBilgi mezunbilgi { get; set; }

        public String bilgileriGetir()
        {
            return (Ad + " | " + Adres + " | " + telNo + " | " + ePosta + " | " +
                    Uyruk + " | " + dogumTarihiYil + " | " +
                      yabanciDil + " | " + ilgiAlani + " | "+staj.deparOrGorev+ " | "+staj.sirketAd+ " | "+staj.stajTarihi+ " | "+mezunbilgi.okulAd+ " | "+
                      mezunbilgi.bolumAd+ " | "+mezunbilgi.notOrtalamasi+ " | "+ mezunbilgi.baslangicTarihi+ " | "+mezunbilgi.bitisTarihi);
        }
    }
}
