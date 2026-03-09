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

            okno.ShowDialog(); ;
        }
        private void OpenWindowEdytuj(object sender, RoutedEventArgs e)
        {
            var okno = new Edytuj();
            okno.EditBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(App.AktualnyKolor));
            okno.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}