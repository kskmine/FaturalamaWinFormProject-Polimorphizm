using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturalamaPol
{
    abstract class Kategori
    {
        public abstract void kdv_al(int kdv_orani);

        public string Urun_Adi { get; set; }
        public float Urun_Fiyati { get; set; }
        public int Urun_Miktari { get; set; }
        public string Markasi { get; set; }
    }
}
