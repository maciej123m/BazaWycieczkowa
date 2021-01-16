using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza_Wycieczkowa
{
    class HotelData
    {
        public int id { get; set; }
        public int cena { get; set; }
        public int ilosc_miejsc { get; set; }
        public int ilosc_gwiazdek { get; set; }
        public bool spa { get; set; }
        public bool silownia { get; set; }
        public bool basen { get; set; }
        public bool ladowisko_dla_helikopterow { get; set; }
        public string adres { get; set; }
        public string kraj { get; set; }
        public string nazwa { get; set; }


        public HotelData (int id, int cena, int ilosc_miejsc, int ilosc_gwiazdek, bool spa, bool silownia, bool basen, bool ladowisko_dla_helikopterow, string adres, string kraj, string nazwa)
        {
            this.id = id;
            this.cena = cena;
            this.ilosc_miejsc = ilosc_miejsc;
            this.ilosc_gwiazdek = ilosc_gwiazdek;
            this.spa = spa;
            this.silownia = silownia;
            this.basen = basen;
            this.ladowisko_dla_helikopterow = ladowisko_dla_helikopterow;
            this.adres = adres;
            this.kraj= kraj;
            this.nazwa = nazwa;
        }

    }
}
