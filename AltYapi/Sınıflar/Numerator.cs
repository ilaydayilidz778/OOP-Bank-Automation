using AltYapi.AraBirimler;
using AltYapi.Enumlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltYapi.Sınıflar
{
    public class Numerator : INumerator
    {
         
        public IMusteri Musteri { get ; set ; }
        public int VipSayac { get; set; } = 1000;
        public int BireyselSayac { get; set; } =5000;
        public int GiseSayac { get; set; } = 3000;
        public BindingList<IMusteri> BekleyenMusteriler { get ; set ; }

        public int NumaraUret(IMusteri musteri)
        {
            if (musteri.MusteriTuru == MusteriTipi.Vip)
            {
                VipSayac++;
                return VipSayac;
            }
            else if (musteri.MusteriTuru == MusteriTipi.Bireysel)
            {
                BireyselSayac++;
                return BireyselSayac;
            }
            else if (musteri.MusteriTuru == MusteriTipi.Gise)
            {
                GiseSayac++;
                return GiseSayac;
            }
            else
                return 0;
        }

        public string SiradakiniGetir()
        {
            StringBuilder sonuc = new StringBuilder();   
            //Sadece Vip Müsterileri Listeye Ekledik.                                                                                                 
           
            
            if(BekleyenMusteriler.Count == 0)
            {
                sonuc.Append("Bekleyen Müşteri Yoktur.");
            }
            else //bekleyen müşteri varsa
            {                                                                                                    //OrderBy Decending
                List<IMusteri> vipListe = BekleyenMusteriler.Where(m => m.MusteriTuru == MusteriTipi.Vip).OrderBy(m => m.SiraNumarasi).ToList();
                List<IMusteri> vipOlmayanlar = BekleyenMusteriler.Where(m => m.MusteriTuru != MusteriTipi.Vip).ToList();
                //List<IMusteri> vipOlmayanlar2 = BekleyenMusteriler.Except(vipListe).ToList(); //Bekleyenler listesinde 

                if(vipListe.Count > 0)
                {
                    sonuc.Append( vipListe[0].MusteriTuru + " " + vipListe[0]);
                    vipListe[0].IslemTammalandiMi = true;
                    BekleyenMusteriler.Remove(vipListe[0]); //Bekleyenlerden Müsteriyi Kaldırdık.
                }
                else if (vipOlmayanlar.Count > 0)
                {
                    sonuc.Append( vipOlmayanlar[0].MusteriTuru + " " + vipOlmayanlar[0]);
                    vipOlmayanlar[0].IslemTammalandiMi = true;
                    BekleyenMusteriler.Remove(vipOlmayanlar[0]); //Bekleyenlerden Müsteriyi Kaldırdık.
                }

            }
            return sonuc.ToString();

        }
       
    }
}
