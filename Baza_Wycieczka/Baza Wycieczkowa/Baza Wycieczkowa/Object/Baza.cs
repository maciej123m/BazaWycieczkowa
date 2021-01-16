using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza_Wycieczkowa
{
    public class Baza
    {
        public int id { get; set; }
        public int id_klienta { get; set; }
        public int id_wycieczki { get; set; }


        public Baza (int id, int id_klienta, int id_wycieczki)
        {
            this.id = id;
            this.id_klienta = id_klienta;
            this.id_wycieczki = id_wycieczki;

        }
    }
}
