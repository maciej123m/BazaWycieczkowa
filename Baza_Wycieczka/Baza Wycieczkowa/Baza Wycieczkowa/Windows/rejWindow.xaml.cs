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
    /// Logika interakcji dla klasy rejWindow.xaml
    /// </summary>
    public partial class rejWindow : Window
    {
        public rejWindow()
        {
            InitializeComponent();
        }

        private void rej_Click(object sender, RoutedEventArgs e) {
            string query = $"insert into Login values({Data.loginy[Data.loginy.Count-1].id+1},'{login_textbox_rej.Text}', '{password_textbox_rej.Password}', 1);";
            Data.conn.Open();
            var command = new OleDbCommand(query,Data.conn);
            command.ExecuteNonQuery();
            Data.conn.Close();
            Data.currentUserUpr = 1;
            Data.id_uz = Data.loginy[Data.loginy.Count - 1].id + 1;
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
