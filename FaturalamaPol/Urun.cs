using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturalamaPol
{
    class Urun:Kategori
    {
        public override void kdv_al(int kdv_orani)
        {
            if (kdv_orani==1)
            {
                Urun_Fiyati = (float)(Urun_Fiyati * 1.20);
            }
            else
            {
                Urun_Fiyati = (float)(Urun_Fiyati * 1.18);
            }
        }
    }
}
