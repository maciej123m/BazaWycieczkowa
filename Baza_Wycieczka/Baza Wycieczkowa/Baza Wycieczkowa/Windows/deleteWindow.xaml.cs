using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Logika interakcji dla klasy deleteWindow.xaml
    /// </summary>
    public partial class deleteWindow : Window
    {
        public deleteWindow()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e) {
          
        }

        private void delete_button_Click(object sender, RoutedEventArgs e) {
            var s = (tab_c.SelectedItem as TabItem).Name;
            string queryString = "";
            OleDbCommand command;
            OleDbDataReader reader;
            switch (s) {
                case "rezerwacje":
                    Data.conn.Open();
                    queryString = $"Delete from Baza where id={id_text.Text};";
                    command = new OleDbCommand(queryString, Data.conn);
                    command.ExecuteNonQuery();
                    Data.conn.Close();
                    Data.refreshAllTables();
                    break;
                case "Piloci":
                    queryString = "Select pilot_1, pilot_2 from Samolot";
                    Data.conn.Open();
                    command = new OleDbCommand(queryString, Data.conn);
                    reader = command.ExecuteReader();
                    while (reader.Read()) {
                        int i = reader.GetInt32(0);
                        if (i == int.Parse(id_text.Text)) {
                            error_label.Content = "To ID jest połączone z innym rekordem w tabeli";
                            Data.conn.Close();
                            return;
                        }

                        i = reader.GetInt32(1);
                        if (i == int.Parse(id_text.Text)) {
                            error_label.Content = "To ID jest połączone z innym rekordem w tabeli";
                            Data.conn.Close();
                            return;
                        }
                    }

                    queryString = $"Delete from Pilot where id={id_text.Text};";
                    command = new OleDbCommand(queryString, Data.conn);
                    command.ExecuteNonQuery();
                    Data.conn.Close();
                    Data.refreshAllTables();
                    break;
                case "Hotel":
                    queryString = "Select hotel from Wycieczka";
                    Data.conn.Open();
                    command = new OleDbCommand(queryString,Data.conn);
                    reader = command.ExecuteReader();
                    while (reader.Read()) {
                        int i = reader.GetInt32(0);
                        if (i == int.Parse(id_text.Text)) {
                            error_label.Content = "To ID jest połączone z innym rekordem w tabeli";
                            Data.conn.Close();
                            return;
                        } 
                    }

                    queryString = $"Delete from Hotel where id={id_text.Text};";
                    command = new OleDbCommand(queryString, Data.conn);
                    command.ExecuteNonQuery();
                    Data.conn.Close();
                    Data.refreshAllTables();
                    break;
                case "lokal":
                    queryString = "Select lokal from Wycieczka";
                    Data.conn.Open();
                    command = new OleDbCommand(queryString, Data.conn);
                    reader = command.ExecuteReader();
                    while (reader.Read()) {
                        int i = reader.GetInt32(0);
                        if (i == int.Parse(id_text.Text)) {
                            error_label.Content = "To ID jest połączone z innym rekordem w tabeli";
                            Data.conn.Close();
                            return;
                        }
                    }

                    queryString = $"Delete from Lokal where id={id_text.Text};";
                    command = new OleDbCommand(queryString, Data.conn);
                    command.ExecuteNonQuery();
                    Data.conn.Close();
                    Data.refreshAllTables();
                    break;
                case "wycieczki":
                    queryString = $"Delete from Baza where id_wycieczki={id_text.Text};";
                    Data.conn.Open();
                    command = new OleDbCommand(queryString, Data.conn);
                    command.ExecuteNonQuery();
                    queryString = $"Delete from Wycieczka where id={id_text.Text};";
                    command = new OleDbCommand(queryString, Data.conn);
                    command.ExecuteNonQuery();
                    Data.conn.Close();
                    Data.refreshAllTables();
                    break;

                case "ubezpieczenia":
                    queryString = "Select ubezpieczenie from Wycieczka";
                    Data.conn.Open();
                    command = new OleDbCommand(queryString, Data.conn);
                    reader = command.ExecuteReader();
                    while (reader.Read()) {
                        int i = reader.GetInt32(0);
                        if (i == int.Parse(id_text.Text)) {
                            error_label.Content = "To ID jest połączone z innym rekordem w tabeli";
                            Data.conn.Close();
                            return;
                        }
                    }

                    queryString = $"Delete from ubezpieczenie where id={id_text.Text};";
                    command = new OleDbCommand(queryString, Data.conn);
                    command.ExecuteNonQuery();
                    Data.conn.Close();
                    Data.refreshAllTables();
                    break;

                case "samoloty":
                    queryString = "Select samolot from Wycieczka";
                    Data.conn.Open();
                    command = new OleDbCommand(queryString, Data.conn);
                    reader = command.ExecuteReader();
                    while (reader.Read()) {
                        int i = reader.GetInt32(0);
                        if (i == int.Parse(id_text.Text)) {
                            error_label.Content = "To ID jest połączone z innym rekordem w tabeli";
                            Data.conn.Close();
                            return;
                        }
                    }

                    queryString = $"Delete from Samolot where id={id_text.Text};";
                    command = new OleDbCommand(queryString, Data.conn);
                    command.ExecuteNonQuery();
                    Data.conn.Close();
                    Data.refreshAllTables();
                    break;

                case "lotniska":
                    queryString = "Select lotsnisko_wylotu from Wycieczka";
                    Data.conn.Open();
                    command = new OleDbCommand(queryString, Data.conn);
                    reader = command.ExecuteReader();
                    while (reader.Read()) {
                        int i = reader.GetInt32(0);
                        if (i == int.Parse(id_text.Text)) {
                            error_label.Content = "To ID jest połączone z innym rekordem w tabeli";
                            Data.conn.Close();
                            return;
                        }
                    }

                    queryString = $"Delete from Lotnisko where id={id_text.Text};";
                    command = new OleDbCommand(queryString, Data.conn);
                    command.ExecuteNonQuery();
                    Data.conn.Close();
                    Data.refreshAllTables();

                    break;
                case "transporty":
                    queryString = "Select transport_na_lotnisko from Wycieczka";
                    Data.conn.Open();
                    command = new OleDbCommand(queryString, Data.conn);
                    reader = command.ExecuteReader();
                    while (reader.Read()) {
                        int i = reader.GetInt32(0);
                        if (i == int.Parse(id_text.Text)) {
                            error_label.Content = "To ID jest połączone z innym rekordem w tabeli";
                            Data.conn.Close();
                            return;
                        }
                    }

                    queryString = $"Delete from Transport_na_lotnisko where id={id_text.Text};";
                    command = new OleDbCommand(queryString, Data.conn);
                    command.ExecuteNonQuery();
                    Data.conn.Close();
                    Data.refreshAllTables();
                    break;

            }
        }
    }
}
