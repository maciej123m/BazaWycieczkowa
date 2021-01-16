using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.OleDb;
using System.Text.RegularExpressions;


namespace Baza_Wycieczkowa
{
    /// <summary>
    /// Logika interakcji dla klasy addWindow.xaml
    /// </summary>
    public partial class addWindow : Window
    {
        public addWindow()
        {
            InitializeComponent();
            S_pilot_1.ItemsSource = Data.piloci.Select(x => x.Nazwisko).ToList();
            S_pilot_2.ItemsSource = Data.piloci.Select(x => x.Nazwisko).ToList();
            W_samolot.ItemsSource = Data.samoloty.Select(x => x.model).ToList();
            W_transport_na_lotnisko.ItemsSource = Data.transporty.Select(x => x.srodek_transportu).ToList();
            W_lokal.ItemsSource = Data.lokale.Select(x => x.nazwa).ToList();
            W_ubezpieczenie.ItemsSource = Data.ubezpieczenia.Select(x => x.firma_ubezpieczeniowa).ToList();
            W_hotel.ItemsSource = Data.hotele.Select(x => x.nazwa).ToList();
            W_transport_na_lotnisko.ItemsSource = Data.transporty.Select(x => x.srodek_transportu).ToList();
            W_lotnisko_wylotowe.ItemsSource = Data.lotniska.Select(x => x.nazwa).ToList();
        }

        private void klient_dodaj_Click(object sender, RoutedEventArgs e) 
        {
            string imie = K_imie.Text;
            string naziwsko = K_nazwisko.Text;
            int wiek = int.Parse(k_wiek.Text);
            bool paszport = (bool)k_paszport.IsChecked;
            string pesel = k_pesel.Text;
            string nr_dowodu = k_nr_dowodu.Text;
            int id = Data.klienci.Count + 1;

            string query =
                $"insert into Klient values({id}, '{imie}', '{naziwsko}', {wiek}, '{pesel}', '{nr_dowodu}', {paszport});";
            Data.conn.Open();
            var command = new OleDbCommand(query, Data.conn);
            command.ExecuteNonQuery();
            Data.conn.Close();
        }

        private void Hotel_dodaj_Click(object sender, RoutedEventArgs e)
        {
            int ilosc_miejsc = int.Parse(H_ilosc_miejsc.Text);
            int cena = int.Parse(H_cena.Text);
            int ilosc_gwiazdek = int.Parse(H_ilosc_gwiazdek.Text);
            bool spa = (bool)H_spa.IsChecked;
            bool silownia = (bool)H_silownia.IsChecked;
            bool basen = (bool)H_basen.IsChecked;
            bool ladowisko_dla_heli = (bool)H_ladowisko_dla_heli.IsChecked;
            string adres = H_adres.Text;
            string kraj = H_kraj.Text;
            int id = Data.hotele[Data.hotele.Count-1].id + 1;
            
            string query =
                $"insert into Hotel values({id}, {ilosc_miejsc}, {cena}, {ilosc_gwiazdek}, {spa}, {silownia}, {basen}, {ladowisko_dla_heli}, '{adres}', '{kraj}','{H_nazwa.Text}');";
            Data.conn.Open();
            var command = new OleDbCommand(query, Data.conn);
            command.ExecuteNonQuery();
            Data.conn.Close();
            label_res.Foreground = Brushes.Green;
            label_res.Content = "Dodano do bazy";
            Data.refreshAllTables();
           
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void L_dodaj_Click_1(object sender, RoutedEventArgs e)
        {
            string miasto = L_miasto.Text;
            string adres = L_adres.Text;
            int ilosc_pracownikow = int.Parse(L_ilosc_pracownikow.Text);
            int wielkosc_m2 = int.Parse(L_wielkosc_km.Text);
            int id = Data.lokale.Count + 1;

            string query =
                $"insert into Lokal values({id}, '{miasto}', '{adres}', {ilosc_pracownikow}, {wielkosc_m2}, '{L_nazwa.Text}');";
            Data.conn.Open();
            var command = new OleDbCommand(query, Data.conn);
            command.ExecuteNonQuery();
            Data.conn.Close();
            label_res.Foreground = Brushes.Green;
            label_res.Content = "Dodano do bazy";
            Data.refreshAllTables();
        }

        private void Lot_dodaj_Click(object sender, RoutedEventArgs e)
        {

            string adres = Lot_adres.Text;
            int przepustowosc = int.Parse(Lot_przepustowosc.Text);
            int liczba_pasow_startowych = int.Parse(Lot_liczba_pasow_startowych.Text);
            int ilosc_obsluchiwanych_samolotow_na_godzine = int.Parse(Lot_ilosc_obslugiwanych_samolotow_na_godzine.Text);
            int wielkosc_km = int.Parse(Lot_wielkosc_km.Text);
            string kraj = Lot_kraj.Text;
            int id = Data.lotniska.Count + 1;

            string query =
                $"insert into Lotnisko values({id}, '{adres}', {przepustowosc}, {liczba_pasow_startowych}, {ilosc_obsluchiwanych_samolotow_na_godzine}, {wielkosc_km}, '{kraj}', '{Lot_nazwa.Text});";
            Data.conn.Open();
            var command = new OleDbCommand(query, Data.conn);
            command.ExecuteNonQuery();
            Data.conn.Close();
            label_res.Foreground = Brushes.Green;
            label_res.Content = "Dodano do bazy";
            Data.refreshAllTables();
        }

        private void Pilot_dodaj_Click(object sender, RoutedEventArgs e)
        {
            string imie = Pilot_imie.Text;
            string nazwisko = Pilot_nazwisko.Text;
            DateTime licencja_od = DateTime.Parse(P_lic_od.Text);
            int id = Data.piloci.Count + 1;
            string query =
                $"insert into Pilot values({id}, '{imie}', '{nazwisko}', licencja_od=#{licencja_od.Year}-{licencja_od.Month}-{licencja_od.Day}#);";
            Data.conn.Open();
            var command = new OleDbCommand(query, Data.conn);
            command.ExecuteNonQuery();
            Data.conn.Close();
            label_res.Foreground = Brushes.Green;
            label_res.Content = "Dodano do bazy";
            Data.refreshAllTables();
        }

        private void Samolot_dodaj_Click(object sender, RoutedEventArgs e)
        {
            int liczba_miejsc = int.Parse(S_liczba_miejsc.Text);
            string model = S_model.Text;
            int wielkosc_baku = int.Parse(S_wielkosc_baku.Text);
            int waga_nosna = int.Parse(S_waga_nosna.Text);
            int id = Data.samoloty.Count + 1;
            int s1 = S_pilot_1.SelectedIndex;
            int s2 = S_pilot_2.SelectedIndex;

            string query =
                $"insert into Samolot values({id}, {liczba_miejsc}, '{model}', {wielkosc_baku}, {waga_nosna}, {s1}, {s2});";

            Data.conn.Open();
            var command = new OleDbCommand(query, Data.conn);
            command.ExecuteNonQuery();
            Data.conn.Close();
            label_res.Foreground = Brushes.Green;
            label_res.Content = "Dodano do bazy";
            Data.refreshAllTables();
        }

        private void Transport_dodaj_Click(object sender, RoutedEventArgs e)
        {
            string srodek_transportu = tran_nazwa.Text;
            int ilosc_miejsc = int.Parse(Trans_ilosc_miejsc.Text);
            int odleglosc = int.Parse(Trans_odlegosc_km.Text);
            int id = Data.transporty.Count + 1;
            string query =
                $"insert into Transport_na_lotnisko values({id}, '{srodek_transportu}', {ilosc_miejsc}, {odleglosc});";
            Data.conn.Open();
            var command = new OleDbCommand(query, Data.conn);
            command.ExecuteNonQuery();
            Data.conn.Close();
            label_res.Foreground = Brushes.Green;
            label_res.Content = "Dodano do bazy";
            Data.refreshAllTables();
        }

        private void Ube_dodaj_Click(object sender, RoutedEventArgs e)
        {
            int cena = int.Parse(Ube_cena.Text);
            string firma_ubezpieczeniowa = Ube_firma_ubezpieczeniowa.Text;
            int ilosc_ubezpieczen = int.Parse(Ube_ilosc_ubezpieczen.Text);
            string rejon_ubezpieczen = Ube_rejon_ubezpieczen.Text;
            int id = Data.ubezpieczenia.Count + 1;
            string query =
                $"insert into Ubezpieczenie values({id}, '{firma_ubezpieczeniowa}', {ilosc_ubezpieczen}, '{rejon_ubezpieczen}');";
            Data.conn.Open();
            var command = new OleDbCommand(query, Data.conn);
            command.ExecuteNonQuery();
            Data.conn.Close();
            label_res.Foreground = Brushes.Green;
            label_res.Content = "Dodano do bazy";
            Data.refreshAllTables();
        }

        private void Wycieczka_dodaj_Click(object sender, RoutedEventArgs e)
        {
            DateTime termin_od = DateTime.Parse(W_termin_od.Text);
            DateTime termin_do = DateTime.Parse(W_termin_do.Text);
            int samolot = W_samolot.SelectedIndex;
            int cena = int.Parse(W_cena.Text);
            int ilosc_miejsc = int.Parse(W_ilosc_miejsc.Text);
            int transport_na_lotnisko = W_transport_na_lotnisko.SelectedIndex;
            int lokal = W_lokal.SelectedIndex;
            int ubezpieczenie = W_ubezpieczenie.SelectedIndex;
            int hotel = W_hotel.SelectedIndex;
            int lotnisko_wylotowe = W_lotnisko_wylotowe.SelectedIndex;

            int id = Data.wycieczki.Count + 1;
            string query =
               $"insert into Wycieczka values({id}, termin_od=#{termin_od.Year}-{termin_od.Month}-{termin_od.Day}#, termin_do=#{termin_do.Year}-{termin_do.Month}-{termin_do.Day}#, {samolot}, {cena}, {ilosc_miejsc}, {ubezpieczenie}, {transport_na_lotnisko}, {lokal}, {hotel}, {lotnisko_wylotowe} );";
            Data.conn.Open();
            var command = new OleDbCommand(query, Data.conn);
            command.ExecuteNonQuery();
            Data.conn.Close();
            label_res.Foreground = Brushes.Green;
            label_res.Content = "Dodano do bazy";
            Data.refreshAllTables();
        }
    }
}
