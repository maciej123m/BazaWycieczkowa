using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza_Wycieczkowa
{
    class Lokal
    {
        public int id { get; set; }
        public string miasto { get; set; }
        public string adres { get; set; }
        public int ilosc_pracownikow { get; set; }
        public int wielkosc_m2 { get; set; }
        public string nazwa { get; set; }

        public Lokal (int id, string miasto, string adres, int ilosc_pracownikow, int wielkosc_m2,string nazwa)
        {
            this.id = id;
            this.miasto = miasto;
            this.adres = adres;
            this.ilosc_pracownikow = ilosc_pracownikow;
            this.wielkosc_m2 = wielkosc_m2;
            this.nazwa = nazwa;
        }
    }
}
