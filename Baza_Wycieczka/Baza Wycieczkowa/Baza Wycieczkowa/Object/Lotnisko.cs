using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza_Wycieczkowa
{
    class Lotnisko
    {
        public int id { get; set; }
        public string adres { get; set; }
        public int przepustowosc { get; set; }
        public int liczba_pasow_startowych { get; set; }
        public int ilosc_obslugiwanych_samolotow_na_godzine { get; set; }
        public int wielkosc_km2 { get; set; }
        public string kraj { get; set; }

        public string nazwa { get; set; }

        public Lotnisko(int id, string adres, int przepustowosc, int liczba_pasow_startowych, int ilosc_obslugiwanych_samolotow_na_godzine, int wielkosc_km2, string kraj, string nazwa)
        {
            this.id = id;
            this.adres = adres;
            this.przepustowosc = przepustowosc;
            this.liczba_pasow_startowych = liczba_pasow_startowych;
            this.ilosc_obslugiwanych_samolotow_na_godzine = ilosc_obslugiwanych_samolotow_na_godzine;
            this.wielkosc_km2 = wielkosc_km2;
            this.kraj = kraj;
            this.nazwa = nazwa;
        }
    }
}
