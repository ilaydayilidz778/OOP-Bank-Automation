using AltYapi.AraBirimler;
using AltYapi.Enumlar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltYapi.Sınıflar
{
    public class Musteri : IMusteri
    {
        public MusteriTipi MusteriTuru { get ; set ; }
        public string TCKimlikNumarasi { get ; set ; }
        public int SiraNumarasi { get; set; }
        public bool IslemTammalandiMi { get; set ; }

        public event NumaraDelege? NumaratoreGit;

        public int NumaraAl()
        {
            return NumaratoreGit(this);
        }
        public override string ToString()
        {
            return "Müşteri Türü: " + MusteriTuru + " "+ SiraNumarasi;
        }
    }
}






