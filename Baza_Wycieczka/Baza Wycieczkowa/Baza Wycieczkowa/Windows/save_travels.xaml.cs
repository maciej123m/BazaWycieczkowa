using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using MaterialDesignThemes.Wpf.Converters;

namespace Baza_Wycieczkowa
{
    /// <summary>
    /// Logika interakcji dla klasy save_travels.xaml
    /// </summary>
    public partial class save_travels : Window {
        private ListView listView;
        public save_travels(ListView listView)
        {
            InitializeComponent();
            ListView.ItemsSource = Data.wycieczki;
            this.listView = listView;
        }

        private void reject_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void accept_Click(object sender, RoutedEventArgs e) {
            var wycieczka = Data.wycieczki.Find(x => x.id == int.Parse(wycieczka_nr.Text));
            if (wycieczka == null) {
                err.Content = "Wprowadzono złe ID wycieczki";
                return;
            }

            int i = 0;
            if (Data.rezerwacje.Count != 0) {
                i = Data.rezerwacje[Data.rezerwacje.Count-1].id + 1;
            }
            string sqlQuery =
                $"insert into Baza values({i}, {Data.id_uz}, {wycieczka_nr.Text});";
            Data.conn.Open();
            var command = new OleDbCommand(sqlQuery,Data.conn);
            command.ExecuteNonQuery();
            Data.conn.Close();
            Data.main_wycieczki.Add(wycieczka);

            listView.ItemsSource = null;
            listView.ItemsSource = Data.main_wycieczki;

            this.Close();
        }
    }
}
