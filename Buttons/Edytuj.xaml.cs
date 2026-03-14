using Projekt_prog.Dane;
using Projekt_prog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekt_prog
{
    /// <summary>
    /// Logika interakcji dla klasy Edytuj.xaml
    /// </summary>
    public partial class Edytuj : Window
    {

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private Film? _film;

        public Edytuj(Film film)
        {
            InitializeComponent();
            _film = film;

            TytulBox.Text = _film.Tytul;
            RokBox.Text = _film.Rok.ToString();
            UstawComboBox(GatunekBox, _film.Gatunek);
            UstawComboBox(OcenaBox, _film.Ocena);
            UstawComboBox(StatusBox, _film.Status);
        }

        private void UstawComboBox(ComboBox comboBox, string wartosc)
        {
            foreach (ComboBoxItem item in comboBox.Items)
            {
                if (item.Content?.ToString() == wartosc)
                {
                    comboBox.SelectedItem = item;
                    break;
                }
            }
        }

        private void Zapisz_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TytulBox.Text))
            {
                MessageBox.Show("Podaj tytuł filmu!", "Błąd",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var db = new AppDbContext())
            {
                var film = db.Filmy.FirstOrDefault(f => f.Id == _film.Id);
                if (film != null)
                {
                    film.Tytul = TytulBox.Text;
                    film.Gatunek = (GatunekBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? string.Empty;
                    film.Rok = int.TryParse(RokBox.Text, out int rok) ? rok : 0;
                    film.Ocena = (OcenaBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? string.Empty;
                    film.Status = (StatusBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? string.Empty;
                    db.SaveChanges();
                }
            }

            this.Close();
        }

        private void RokBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(char.IsDigit);
        }

        private void RokBox_LostFocus(object sender, RoutedEventArgs e)
        {
            int maxRok = DateTime.Now.Year + 10;
            if (int.TryParse(RokBox.Text, out int rok))
            {
                if (rok < 900)
                {
                    MessageBox.Show("Rok nie może być mniejszy niż 900.", "Błąd",
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
