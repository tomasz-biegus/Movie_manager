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
            Dodaj objdodajWindow = new Dodaj();
            objdodajWindow.Show();
        }
        private void OpenWindowEdytuj(object sender, RoutedEventArgs e)
        {
            Edytuj objedytujWindow = new Edytuj();
            objedytujWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}