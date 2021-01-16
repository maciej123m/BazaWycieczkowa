using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza_Wycieczkowa
{
    class Login
    {
        public int id { get; set; }
        public string login { get; set; }
        public string haslo { get; set; }
        public int poziom_uprawnien { get; set; }

        public Login(int id, string login, string haslo, int poziom_uprawnien)
        {
            this.id = id;
            this.login = login;
            this.haslo = haslo;
            this.poziom_uprawnien = poziom_uprawnien;
        }
    }

}
