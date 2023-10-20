using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltYapi.AraBirimler
{
    public interface IBanka
    {
        public BindingList<IMusteri> Musteriler { get; set; }
        public INumerator Numerator { get; set; }

    }
}
