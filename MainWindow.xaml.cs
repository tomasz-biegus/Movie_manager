using Projekt_prog.Dane;
using Projekt_prog.Model;
using Projekt_prog.WMW.ModeleWidokow;
using Projekt_prog.WMW.Widoki;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt_prog
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenWindowDodaj(object sender, RoutedEventArgs e)
        {
            var okno = new Dodaj();
            okno.AddBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(App.AktualnyKolor));

            okno.ShowDialog();
            var mainVM = DataContext as MainViewModel;
            mainVM?.OdswiezWidok();
        }
        private void OpenWindowEdytuj(object sender, RoutedEventArgs e)
        {
            Film? wybrany = null;

            var homeView = FindVisualChild<HomeView>(this);
            var obejrzaneView = FindVisualChild<ObejrzaneView>(this);

            if (homeView != null && homeView.FilmyList.SelectedItem is Film film1)
                wybrany = film1;
            else if (obejrzaneView != null && obejrzaneView.FilmyList.SelectedItem is Film film2)
                wybrany = film2;

            if (wybrany == null)
            {
                MessageBox.Show("Wybierz film z listy!", "Błąd",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var okno = new Edytuj(wybrany);
            okno.EditBorder.Background =
                new SolidColorBrush((Color)ColorConverter.ConvertFromString(App.AktualnyKolor));
            okno.ShowDialog();

            var mainVM = DataContext as MainViewModel;
            mainVM?.OdswiezWidok();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // metoda do usuwania filmu, sprawdza który widok jest aktywny i usuwa wybrany film z bazy danych
        private void UsunFilm(object sender, RoutedEventArgs e)
        {
 
            var homeView = FindVisualChild<HomeView>(this);
            var obejrzaneView = FindVisualChild<ObejrzaneView>(this);

            Film? wybrany = null;

            if (homeView != null && homeView.FilmyList.SelectedItem is Film film1)
                wybrany = film1;
            else if (obejrzaneView != null && obejrzaneView.FilmyList.SelectedItem is Film film2)
                wybrany = film2;

            if (wybrany == null)
            {
                MessageBox.Show("Wybierz film z listy!", "Błąd",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var wynik = MessageBox.Show($"Czy na pewno chcesz usunąć \"{wybrany.Tytul}\"?",
                "Potwierdzenie", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (wynik == MessageBoxResult.Yes)
            {
                using (var db = new AppDbContext())
                {
                    var film = db.Filmy.FirstOrDefault(f => f.Id == wybrany.Id);
                    if (film != null)
                    {
                        db.Filmy.Remove(film);
                        db.SaveChanges();
                    }
                }

                var mainVM = DataContext as MainViewModel;
                mainVM?.OdswiezWidok();
            }
        }

        private static T? FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T result)
                    return result;
                var found = FindVisualChild<T>(child);
                if (found != null)
                    return found;
            }
            return null;
        }
    }
}