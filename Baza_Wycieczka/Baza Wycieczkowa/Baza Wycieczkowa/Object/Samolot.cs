using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza_Wycieczkowa
{
    class Samolot
    {
        public int id { get; set; }
        public int liczba_miejsc { get; set; }
        public string model { get; set; }
        public int wielkosc_baku { get; set; }
        public int waga_nosna { get; set; }
        public string pilot_1 { get; set; }
        public string pilot_2 { get; set; }
        
        public Samolot(int id, int liczba_miejsc, string model, int wielkosc_baku, int waga_nosna, string pilot_1, string pilot_2)
        {
            this.id = id;
            this.liczba_miejsc = liczba_miejsc;
            this.model = model;
            this.wielkosc_baku = wielkosc_baku;
            this.waga_nosna = waga_nosna;
            this.pilot_1 = pilot_1;
            this.pilot_2 = pilot_2;

        }
    }
}
