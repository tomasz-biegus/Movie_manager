using Projekt_prog.Dane;
using Projekt_prog.Model;
using System;
using System.Collections.Generic;
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

namespace Projekt_prog
{
    /// <summary>
    /// Logika interakcji dla klasy Dodaj.xaml
    /// </summary>
    public partial class Dodaj : Window
    {
        public Dodaj()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // przycisk zapisz
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // sprawdza czy tytuł jest podany
            if (string.IsNullOrWhiteSpace(TytulBox.Text))
            {
                MessageBox.Show("Podaj tytuł filmu!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var film = new Film
            {
                Tytul = TytulBox.Text,
                Gatunek = (GatunekBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? string.Empty,
                Rok = int.TryParse(RokBox.Text, out int rok) ? rok : 0,
                Ocena = (OcenaBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? string.Empty,
                Status = (StatusBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? string.Empty
            };

            using (var db = new AppDbContext())
            {
                db.Filmy.Add(film);
                db.SaveChanges();
            }

            this.Close();
        }


        // pozwala wpisywać tylko cyfry
        private void RokBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(char.IsDigit);
        }

        // sprawdza czy rok jest w rozsądnym zakresie
        private void RokBox_LostFocus(object sender, RoutedEventArgs e)
        {
            int maxRok = DateTime.Now.Year + 10;

            if (int.TryParse(RokBox.Text, out int rok))
            {
                if (rok < 900)
                {
                    MessageBox.Show($"Rok nie może być mniejszy niż 900.", "Błąd",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    RokBox.Text = string.Empty;
                    RokBox.Focus();
                }
                else if (rok > maxRok)
                {
                    MessageBox.Show($"Rok nie może być większy niż {maxRok}.", "Błąd",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    RokBox.Text = string.Empty;
                    RokBox.Focus();
                }
            }
        }
    }
}
