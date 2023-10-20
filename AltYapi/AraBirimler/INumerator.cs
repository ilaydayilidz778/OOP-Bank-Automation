using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltYapi.AraBirimler
{
    public interface INumerator
    {
        public IMusteri Musteri { get; set; } //Anlık işlemde olan Müşteri
        public BindingList<IMusteri> BekleyenMusteriler { get; set; } //İşem için bekleyen müsteriler
        public int VipSayac { get; set; }
        public int GiseSayac { get; set; }
        public int BireyselSayac { get; set; }
        public int NumaraUret(IMusteri Musteri);
        public string SiradakiniGetir();
    }
}
