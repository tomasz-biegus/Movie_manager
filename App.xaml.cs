using System.Configuration;
using System.Data;
using System.Windows;

namespace Projekt_prog
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string AktualnyKolor { get; set; } = "#CDCDCD";

        public static void ZmienMotyw(bool ciemny)
        {
            var uri = ciemny
                ? new Uri("Motywy/MotywCiemny.xaml", UriKind.Relative)
                : new Uri("Motywy/MotywJasny.xaml", UriKind.Relative);

            var nowyMotyw = new ResourceDictionary { Source = uri };

            // Znajdź i zamień obecny motyw
            var stary = Current.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source != null &&
                                 d.Source.OriginalString.Contains("Motyw"));

            if (stary != null)
                Current.Resources.MergedDictionaries.Remove(stary);

            Current.Resources.MergedDictionaries.Add(nowyMotyw);
        }
    }
    
    
      
    

}
