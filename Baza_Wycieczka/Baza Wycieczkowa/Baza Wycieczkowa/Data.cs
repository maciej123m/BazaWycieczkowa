using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Baza_Wycieczkowa
{
    abstract class Data {
        public static OleDbConnection conn = new OleDbConnection {
            ConnectionString =
                @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\baza.accdb"
        };
      
    public enum uprawnienia {
            admin = 0,
            użytkownik = 1
    }
        //uprawnienia aktualnie zalogowanego użytkownika 
        //TODO(Pamietaj debug!!!)
        public static int currentUserUpr = (int)uprawnienia.admin;
        public static int id_uz = 3;


        public static List<Login> loginy;
        public static List<Baza> rezerwacje;
        public static List<HotelData> hotele;
        public static List<KlientData> klienci;
        public static List<Lokal> lokale;
        public static List<Lotnisko> lotniska;
        public static List<PilociDataSet> piloci;
        public static List<Transport_na_lotnisko> transporty;
        public static List<Ubezpieczenie> ubezpieczenia;
        public static List<Wycieczka> wycieczki;
        public static List<Samolot> samoloty;
        public static List<Wycieczka> main_wycieczki;
        public static void refreshAllTables() {

            Data.hotele = Data.loadHotels();
            Data.lotniska = Data.loadAirports();
            //TODO(usun kiedy okienko dodasz)
            Data.loginy = Data.loadLogins();
            Data.samoloty = Data.loadAirships();
            Data.lokale = Data.loadLocals();
            Data.ubezpieczenia = Data.loadinsurance();
            Data.transporty = Data.loadTransport();
            Data.wycieczki = Data.loadTravels();
            //if (currentUserUpr == (int) uprawnienia.admin) {
            Data.piloci = Data.loadPilots();
            Data.klienci = Data.loadClients();
            Data.rezerwacje = Data.loadRezerwacje();
            //}

            List<Baza> result = new List<Baza>(Data.rezerwacje.FindAll(x => x.id_klienta == Data.id_uz));
            Data.main_wycieczki = new List<Wycieczka>();
            for (int i = 0; i < result.Count; i++) {
                Data.main_wycieczki.Add(Data.wycieczki.Find(x => x.id == result[i].id_wycieczki));
            }

        }

        public static List<PilociDataSet> loadPilots() {

            List<PilociDataSet> tab = new List<PilociDataSet>();
            conn.Open();
            var queryString = "Select * from Pilot";
            OleDbCommand command = new OleDbCommand(queryString, Data.conn);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                var id = reader.GetInt32(0);
                var imie = reader.GetString(1);
                var nazwisko = reader.GetString(2);
                var lic = reader.GetDateTime(3);
                PilociDataSet pilot = new PilociDataSet(id, imie, nazwisko, lic.ToString());
                tab.Add(pilot);
            }

            conn.Close();
            return tab;
        }

        public static List<HotelData> loadHotels() {

            var tab = new List<HotelData>();
            conn.Open();
            var queryString = "Select * from Hotel";
            OleDbCommand command = new OleDbCommand(queryString, Data.conn);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                var id = reader.GetInt32(0);
                var a = reader.GetInt32(1);
                var b = reader.GetInt32(2);
                var c = reader.GetInt32(3);
                var d = reader.GetBoolean(4);
                var e = reader.GetBoolean(5);
                var f = reader.GetBoolean(6);
                var g = reader.GetBoolean(7);
                var h = reader.GetString(8);
                var i = reader.GetString(9);
                var j = reader.GetString(10);
                var data = new HotelData(id, b, a, c,d,e,f,g,h,i,j);
                tab.Add(data);
            }

            conn.Close();
            return tab;
        }

        public static List<KlientData> loadClients() {

            var tab = new List<KlientData>();
            conn.Open();
            var queryString = "Select * from Klient";
            OleDbCommand command = new OleDbCommand(queryString, Data.conn);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                var id = reader.GetInt32(0);
                var a = reader.GetString(1);
                var b = reader.GetString(2);
                var c = reader.GetInt32(3);
                var d = reader.GetString(4);
                var e = reader.GetString(5);
                var f = reader.GetBoolean(6);
                var data = new KlientData(id, a, b, c, d, e, f);
                tab.Add(data);
            }

            conn.Close();
            return tab;
        }

        public static List<Login> loadLogins() {

            var tab = new List<Login>();
            conn.Open();
            var queryString = "Select * from Login";
            OleDbCommand command = new OleDbCommand(queryString, Data.conn);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                var id = reader.GetInt32(0);
                var a = reader.GetString(1);
                var b = reader.GetString(2);
                var c = reader.GetString(3);
              
                var data = new Login(id, a, b, int.Parse(c));
                tab.Add(data);
            }

            conn.Close();
            return tab;
        }

        public static List<Lotnisko> loadAirports() {

            var tab = new List<Lotnisko>();
            conn.Open();
            var queryString = "Select * from Lotnisko";
            OleDbCommand command = new OleDbCommand(queryString, Data.conn);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                var id = reader.GetInt32(0);
                var a = reader.GetString(1);
                var b = reader.GetInt32(2);
                var c = reader.GetInt32(3);
                var d = reader.GetInt32(4);
                var e = reader.GetInt32(5);
                var f = reader.GetString(6);
                var g = reader.GetString(7);
                var data = new Lotnisko(id, a, c, b, d, e, f,g);
                tab.Add(data);
            }

            conn.Close();
            return tab;
        }

        public static List<Samolot> loadAirships() {

            var tab = new List<Samolot>();
            conn.Open();
            var queryString = "Select * from Samolot";
            OleDbCommand command = new OleDbCommand(queryString, Data.conn);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                var id = reader.GetInt32(0);
                var a = reader.GetInt32(1);
                var b = reader.GetString(2);
                var c = reader.GetInt32(3);
                var d = reader.GetInt32(4);

                var e = reader.GetInt32(5);
                var f = reader.GetInt32(6);

                
                var queryPilot1 = $"Select imie,nazwisko from Pilot where id={e}";
                var queryPilot2 = $"Select imie,nazwisko from Pilot where id={f}";

                OleDbCommand commandP1 = new OleDbCommand(queryPilot1, Data.conn);
                var readerP1 = commandP1.ExecuteReader();
                readerP1.Read();
                var pilot = new {imie = readerP1.GetString(0), nazwisko = readerP1.GetString(1)};

                commandP1 = new OleDbCommand(queryPilot2,conn);
                readerP1 = commandP1.ExecuteReader();
                readerP1.Read();
                var pilot2 = new {imie = readerP1.GetString(0), nazwisko = readerP1.GetString(1)};
                var data = new Samolot(id, a, b, c, d, $"{pilot.nazwisko}",
                    $"{pilot2.nazwisko}");// {pilot2.nazwisko}");
                tab.Add(data);
            }

            conn.Close();
            return tab;
        }

        public static List<Transport_na_lotnisko> loadTransport() {

            var tab = new List<Transport_na_lotnisko>();
            conn.Open();
            var queryString = "Select * from Transport_na_lotnisko";
            OleDbCommand command = new OleDbCommand(queryString, Data.conn);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                var id = reader.GetInt32(0);
                var a = reader.GetString(1);
                var b = reader.GetInt32(2);
                var c = reader.GetInt32(3);
                var data = new Transport_na_lotnisko(id, a, b, c);
                tab.Add(data);
            }

            conn.Close();
            return tab;
        }

        public static List<Ubezpieczenie> loadinsurance() {

            var tab = new List<Ubezpieczenie>();
            conn.Open();
            var queryString = "Select * from Ubezpieczenie";
            OleDbCommand command = new OleDbCommand(queryString, Data.conn);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                var id = reader.GetInt32(0);
                var a = reader.GetInt32(1);
                var b = reader.GetString(2);
                var c = reader.GetInt32(3);
                var d = reader.GetString(4);
                var data = new Ubezpieczenie(id, a, b, c,d);
                tab.Add(data);
            }

            conn.Close();
            return tab;
        }

        public static List<Lokal> loadLocals() {
            var tab = new List<Lokal>();
            conn.Open();
            var queryString = "Select * from Lokal";
            OleDbCommand command = new OleDbCommand(queryString, Data.conn);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                var id = reader.GetInt32(0);
                var a = reader.GetString(1);
                var b = reader.GetString(2);
                var c = reader.GetInt32(3);
                var d = reader.GetInt32(4);
                var e = reader.GetString(5);
                var data = new Lokal(id, a, b, c, d,e);
                tab.Add(data);
            }

            conn.Close();
            return tab;
        }

        public static List<Wycieczka> loadTravels() {
            var tab = new List<Wycieczka>();
            conn.Open();
            var queryString = "Select * from Wycieczka";
            OleDbCommand command = new OleDbCommand(queryString, Data.conn);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                var id = reader.GetInt32(0);
                var a = reader.GetDateTime(1);
                var b = reader.GetDateTime(2);

                var c = reader.GetInt32(3);
                var nazwaSamolotu = samoloty.Find(i => i.id == c).model;

                var d = reader.GetInt32(4);
                var e = reader.GetInt32(5);

                var f = reader.GetInt32(6);
                var nazwaUbezpieczyciela = ubezpieczenia.Find(i => i.id == f).firma_ubezpieczeniowa;

                var g = reader.GetInt32(7);
                var nazwaTransportu = transporty.Find(i => i.id == g).srodek_transportu;

                var h = reader.GetInt32(8);
                var nazwaLokalu = lokale.Find(i => i.id == h).nazwa;

                var i2 = reader.GetInt32(9);
                var nazwaHotelu = hotele.Find(i => i.id == i2).nazwa;

                var j = reader.GetInt32(10);
                var nazwaLotniska = lotniska.Find(i => i.id == j).nazwa;

                var data = new Wycieczka(id, a.ToShortDateString(), b.ToShortDateString(), nazwaSamolotu, d, e,
                    nazwaUbezpieczyciela,nazwaTransportu,nazwaLokalu,nazwaHotelu,nazwaLotniska);

                tab.Add(data);
            }

            conn.Close();
            return tab;
        }

        public static List<Baza> loadRezerwacje() {
            var tab = new List<Baza>();
            conn.Open();
            var queryString = "Select * from Baza";
            OleDbCommand command = new OleDbCommand(queryString, Data.conn);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                var id = reader.GetInt32(0);
                var a = reader.GetInt32(1);
                var b = reader.GetInt32(2);
                var data = new Baza(id, a, b);
                tab.Add(data);
            }
            conn.Close();
            return tab;
        }

        public static async Task<string> updateTables() {

            var res = Task.Run(() => {
                string s = "";
                string queryString;
                conn.Open();

                foreach (var item in hotele)
                {
                    queryString =
                        $"Update Hotel set ilosc_miejsc={item.ilosc_miejsc}, cena={item.cena}, ilosc_gwiazdek={item.ilosc_gwiazdek}," +
                        $" spa={item.spa}, silownia={item.silownia}, basen={item.basen}, ladowisko_dla_helikopterow={item.ladowisko_dla_helikopterow}," +
                        $" adres='{item.adres}', kraj='{item.kraj}', nazwa='{item.nazwa}' where id={item.id};";
                    var comm = new OleDbCommand(queryString, conn);
                    comm.ExecuteNonQuery();

                }

                foreach (var item in klienci)
                {
                    queryString =
                        $"Update Klient set imie='{item.imie}', nazwisko='{item.nazwisko}', " +
                        $"wiek={item.wiek}, pesel='{item.pesel}', nr_dowodu_osobistego='{item.nr_dowodu_osobistego}'," +
                        $" paszport={item.paszport} where id={item.id};";
                    var comm = new OleDbCommand(queryString, conn);
                    comm.ExecuteNonQuery();
                }

                foreach (var item in lokale)
                {
                    queryString =
                        $"update Lokal set miasto='{item.miasto}', adres='{item.adres}', ilosc_pracownikow={item.ilosc_pracownikow}, " +
                        $"wielkosc_m2={item.wielkosc_m2}, nazwa='{item.nazwa}' where id={item.id};";
                    var comm = new OleDbCommand(queryString, conn);
                    comm.ExecuteNonQuery();
                }

                foreach (var item in lotniska)
                {
                    queryString =
                        $"update Lotnisko set adres='{item.adres}', przepustowosc={item.przepustowosc}, liczba_pasow_startowych={item.liczba_pasow_startowych}, " +
                        $"wielkosc_km2={item.wielkosc_km2}, kraj='{item.kraj}', nazwa='{item.nazwa}';";
                    var comm = new OleDbCommand(queryString, conn);
                    comm.ExecuteNonQuery();
                }

                foreach (var item in piloci)
                {
                    var date = DateTime.Parse(item.licencja_od);
                    queryString =
                        $"update Pilot set imie='{item.Imie}', nazwisko='{item.Nazwisko}', licencja_od=#{date.Year}-{date.Month}-{date.Day}# where id={item.id}";
                    var comm = new OleDbCommand(queryString, conn);
                    comm.ExecuteNonQuery();
                }

                foreach (var item in samoloty) {
                    int id_1 = -1;
                    int id_2 = -1;
                    bool update = true;

                    var list_p1 = Data.piloci.Find((p) => p.Nazwisko == item.pilot_1);
                    if (list_p1 != null) {
                        id_1 = list_p1.id;
                    }
                    else {
                        s += "Samolot: błędny pierwszy pilot\n";
                        update = false;
                    }

                    var list_p2 = Data.piloci.Find((p) => p.Nazwisko == item.pilot_2);
                    if(list_p2 != null) {
                        id_2 = list_p2.id;
                    }
                    else {
                        s += "Samolot: błędny drugi pilot\n";
                        update = false;
                    }

                    if (update) {
                        queryString =
                            $"update Samolot set liczba_miejsc={item.liczba_miejsc}, model='{item.model}', " +
                            $"wielkosc_baku={item.wielkosc_baku}, waga_nosna={item.waga_nosna}, pilot_1={id_1}, pilot_2={id_2} where id={item.id};";
                        var comm = new OleDbCommand(queryString, conn);
                        comm.ExecuteNonQuery();
                    }
                }

                foreach (var item in transporty)
                {
                    queryString =
                        $"update Transport_na_lotnisko set srodek_transportu='{item.srodek_transportu}', ilosc_miejsc={item.ilosc_miejsc}, " +
                        $"odleglosc_km={item.odleglosc_km} where id={item.id};";
                    var comm = new OleDbCommand(queryString, conn);
                    comm.ExecuteNonQuery();
                }

                foreach (var item in ubezpieczenia)
                {
                    queryString =
                        $"update Ubezpieczenie set cena={item.cena}, firma_ubezpieczeniowa='{item.firma_ubezpieczeniowa}', " +
                        $"ilosc_ubezpieczen={item.ilosc_ubezpieczen}, rejon_ubezpieczenia='{item.rejon_ubezpieczenia}' where id={item.id};";
                    var comm = new OleDbCommand(queryString, conn);
                    comm.ExecuteNonQuery();
                }

                foreach (var item in wycieczki) {
                    bool spr = true;
                    var samolot = samoloty.Find(p => p.model == item.samolot);
                    var ub = ubezpieczenia.Find(p => p.firma_ubezpieczeniowa == item.ubezpieczenie);
                    var transport = transporty.Find(p => p.srodek_transportu == item.transport_na_lotnisko);
                    var lokal = lokale.Find(p => p.nazwa == item.lokal);
                    var lotnisko = lotniska.Find(p => p.nazwa == item.lotnisko_wylotowe);
                    var hotel = hotele.Find(p => p.nazwa == item.hotel);

                    if (samolot == null) {
                        s += "Wycieczka: samolot błędny\n";
                        spr = false;
                    }

                    if (ub == null) {
                        s += "Wycieczka: ubzezpiecznie błędny\n";
                        spr = false;
                    }

                    if (transport == null) {
                        s += "Wycieczka: transport błędny\n";
                        spr = false;
                    }

                    if (lokal == null) {
                        s += "Wycieczka: lokal błędny\n";
                        spr = false;
                    }

                    if (lotnisko == null) {
                        s += "Wycieczka: lotnisko błędny\n";
                        spr = false;
                    }

                    if (hotel == null) {
                        s += "Wycieczka: hotel błędny\n";
                        spr = false;
                    }

                    DateTime date1= DateTime.Now;
                    var date2 = DateTime.Now;

                    try {
                        date1 = DateTime.Parse(item.termin_od);
                        date2 = DateTime.Parse(item.termin_do);
                    }
                    catch (Exception e) {
                        s += "Wycieczka: Daty błędne\n";
                        spr = false;
                    }
                   
                    if (spr) {
                        queryString =
                            $"update Wycieczka set termin_od=#{date1.Year}-{date1.Month}-{date1.Day}#, termin_do=#{date2.Year}-{date2.Month}-{date2.Day}#, samolot={samolot.id}, cena={item.cena}, " +
                            $"ilosc_miejsc={item.ilosc_miejsc}, ubezpieczenie={ub.id}, transport_na_lotnisko={transport.id}, " +
                            $"lokal={lokal.id}, hotel={hotel.id}, lotsnisko_wylotu={lotnisko.id} where id={item.id};";
                        var comm = new OleDbCommand(queryString, conn);
                        comm.ExecuteNonQuery();
                    }

                }
                conn.Close();
                return s;
            });
            return res.Result;
        }
    }
}
