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

namespace Baza_Wycieczkowa
{
    /// <summary>
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            try {
                Data.loginy = Data.loadLogins();
            }
            catch (Exception ex) {
                MessageBox.Show("Failed to connect to data source");
                this.Close();
            }
            InitializeComponent();
           
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in Data.loginy) {
                if (item.login == textBox_login.Text) {
                    if (item.haslo == textBox_hasło.Password) {
                        Data.currentUserUpr = item.poziom_uprawnien;
                        Data.id_uz = item.id;
                        MainWindow window = new MainWindow();
                        window.Show();
                        this.Close();
                    }
                }
            }

            label_error.Foreground = Brushes.Red;
            label_error.Content = "nie znaleziono użytkowanika";
        }

        private void rej_button_Click(object sender, RoutedEventArgs e)
        {
            rejWindow win = new rejWindow();
            win.Show();
            this.Close();
        }
    }
}
