using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza_Wycieczkowa
{
    public class KlientData
    {
        public int id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public int wiek { get; set; }
        public string pesel { get; set; }
        public string nr_dowodu_osobistego { get; set; }
        public bool paszport { get; set; }

        public KlientData(int id, string imie, string nazwisko, int wiek, string pesel, string nr_dowodu_osobistego, bool paszport)
        {
            this.id = id;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.wiek = wiek;
            this.pesel = pesel;
            this.nr_dowodu_osobistego = nr_dowodu_osobistego;
            this.paszport = paszport;
        }
    }
}
