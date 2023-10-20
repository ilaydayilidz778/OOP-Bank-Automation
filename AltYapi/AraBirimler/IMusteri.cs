using AltYapi.Enumlar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltYapi.AraBirimler
{
    //Numaratöre gitme olayı
    public delegate int NumaraDelege(IMusteri musteri);
    public interface IMusteri
    {
        public bool IslemTammalandiMi { get; set; }
        public event NumaraDelege? NumaratoreGit;
        public int NumaraAl();
        public  MusteriTipi MusteriTuru { get; set; }
        public string TCKimlikNumarasi { get; set; }
        public int SiraNumarasi { get; set; }
    }
}
