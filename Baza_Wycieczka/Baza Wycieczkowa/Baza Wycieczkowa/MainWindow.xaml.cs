using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Baza_Wycieczkowa
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow() {
       
            InitializeComponent();
            if (Data.currentUserUpr == (int) Data.uprawnienia.użytkownik) {
                b_dodaj_pilota.IsEnabled = false;
                delete_button.IsEnabled = false;
            }
            Data.refreshAllTables();
            loadInterface();
        }

        private void loadInterface() {
            ListViewMain.ItemsSource = Data.main_wycieczki;
            uzytkownik_label.Content = Data.loginy.Find(p => p.id == Data.id_uz).login;
            uprawnienia_label.Content = (Data.uprawnienia)Data.currentUserUpr;

        }
        private void b_dodaj_pilota_Click(object sender, RoutedEventArgs e) {
            addWindow window = new addWindow();
            window.Show();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (e.Source is TabControl) {
                if (Piloci.IsSelected) {
                    DataGrid.ItemsSource = Data.piloci;
                }
                else if(Hotel.IsSelected) {
                    DataGrid.ItemsSource = Data.hotele;
                }
                else if (klienci.IsSelected) {
                    DataGrid.ItemsSource = Data.klienci;

                }
                else if (lokal.IsSelected) {
                    DataGrid.ItemsSource = Data.lokale;

                }
                else if (lotniska.IsSelected) {
                    DataGrid.ItemsSource = Data.lotniska;

                }
                else if (samoloty.IsSelected) {
                    DataGrid.ItemsSource = Data.samoloty;

                }
                else if (transporty.IsSelected) {
                    DataGrid.ItemsSource = Data.transporty;

                }
                else if (ubezpieczenia.IsSelected) {
                    DataGrid.ItemsSource = Data.ubezpieczenia;

                }
                else if(wycieczki.IsSelected) {
                    DataGrid.ItemsSource = Data.wycieczki;
                }
                else if(rezerwacje.IsSelected) {
                    DataGrid.ItemsSource = Data.rezerwacje;
                }
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e) {
            result_label.Text = Data.updateTables().Result;
            if (result_label.Text.ToString().Length == 0) {
                Data.refreshAllTables();
            }
        }

        private void refreshAllTables_Click(object sender, RoutedEventArgs e)
        {
            Data.refreshAllTables();
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            deleteWindow win = new deleteWindow();
            win.Show();
        }

        private void exit_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void zapisz_wycieczka_Click(object sender, RoutedEventArgs e)
        {
            save_travels win = new save_travels(ListViewMain);
            win.Show();
        }

        private void M_TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ListViewMain.ItemsSource = null;
            ListViewMain.ItemsSource = Data.main_wycieczki;
        }
    }
}
