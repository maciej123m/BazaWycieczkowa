using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza_Wycieczkowa
{
    class Transport_na_lotnisko
    {
        public int id { get; set; }
        public string srodek_transportu { get; set; }
        public int ilosc_miejsc { get; set; }
        public int odleglosc_km { get; set; }

        public Transport_na_lotnisko(int id, string srodek_transportu, int ilosc_miejsc, int odleglosc_km)
        {
            this.id = id;
            this.srodek_transportu = srodek_transportu;
            this.ilosc_miejsc = ilosc_miejsc;
            this.odleglosc_km = odleglosc_km;

        }
    }
}
