using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza_Wycieczkowa
{
    class Ubezpieczenie
    {
        public int id { get; set; }
        public int cena { get; set; }
        public string firma_ubezpieczeniowa { get; set; }
        public int ilosc_ubezpieczen { get; set; }
        public string rejon_ubezpieczenia { get; set; }

        public Ubezpieczenie(int id, int cena, string firma_ubezpieczeniowa, int ilosc_ubezpieczen, string rejon_ubezpieczenia)
        {
            this.id = id;
            this.cena = cena;
            this.firma_ubezpieczeniowa = firma_ubezpieczeniowa;
            this.ilosc_ubezpieczen = ilosc_ubezpieczen;
            this.rejon_ubezpieczenia = rejon_ubezpieczenia;
        }

    }
}
