using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza_Wycieczkowa
{
    class Wycieczka
    {
        public int id { get; set; }
        public string termin_od { get; set; }
        public string termin_do { get; set; }
        public string samolot { get; set; }
        public int cena { get; set; }
        public int ilosc_miejsc { get; set; }
        public string ubezpieczenie { get; set; }
        public string transport_na_lotnisko { get; set; }
        public string lokal { get; set; }
        public string hotel { get; set; }
        public string lotnisko_wylotowe { get; set; }

        public Wycieczka(int id, string termin_od, string termin_do, string samolot, int cena, int ilosc_miejsc, string ubezpieczenie, string transport_na_lotnisko, string lokal, string hotel, string lotnisko_wylotowe)
        {
            this.id = id;
            this.termin_od = termin_od;
            this.termin_do = termin_do;
            this.samolot = samolot;
            this.cena = cena;
            this.ilosc_miejsc = ilosc_miejsc;
            this.ubezpieczenie = ubezpieczenie;
            this.transport_na_lotnisko = transport_na_lotnisko;
            this.lokal = lokal;
            this.hotel = hotel;
            this.lotnisko_wylotowe = lotnisko_wylotowe;
        }

    }
}
