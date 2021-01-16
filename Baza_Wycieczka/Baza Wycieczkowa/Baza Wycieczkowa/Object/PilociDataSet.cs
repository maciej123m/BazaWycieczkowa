using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza_Wycieczkowa {
    public class PilociDataSet {
        public int id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string licencja_od { get; set; }

        public PilociDataSet(int id, string Imie, string nazwisko, string licencjaOd) {
            this.id = id;
            this.Imie = Imie;
            this.Nazwisko = nazwisko;
            this.licencja_od = licencjaOd;
        }

        public PilociDataSet() {

        }

    }
}