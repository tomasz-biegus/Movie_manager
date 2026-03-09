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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt_prog.WMW.Widoki
{
    /// <summary>
    /// Logika interakcji dla klasy UstawieniaView.xaml
    /// </summary>
    public partial class UstawieniaView : UserControl
    {
        public UstawieniaView()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow == null) return;

            mainWindow.MainBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CDCDCD"));
            App.AktualnyKolor = "#CDCDCD";
            App.ZmienMotyw(ciemny: false);

        }

        private void TextBlock_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow == null) return;

            mainWindow.MainBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#676767"));
            App.AktualnyKolor = "#676767";
            App.ZmienMotyw(ciemny: true);
        }
    }
}
