using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projekt_prog.WMW.ModeleWidokow
{
    class MainViewModel : ObsObject
    {
        // Komendy do przełączania widoków
        public Relay DoObejrzeniaViewCommand { get; set; }

        public Relay ObejrzaneViewCommand { get; set; }

        public Relay UstawieniaViewCommand { get; set; }

        public DoObejrzeniaViewModel DoObejrzeniaVM { get; set; }

        public ObejrzaneViewModel ObejrzaneVM { get; set; }

        public UstawieniaViewModel UstawieniaVM { get; set; }


        private object _currentView;

        public object CurrentView
        {
            // Zwraca aktualnie wyświetlany widok
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public void OdswiezWidok()
        {
            // Odświeża aktualny widok, tworząc nową instancję odpowiedniego ViewModelu
            if (CurrentView is DoObejrzeniaViewModel)
            {
                DoObejrzeniaVM = new DoObejrzeniaViewModel();
                CurrentView = DoObejrzeniaVM;
            }
            else if (CurrentView is ObejrzaneViewModel)
            {
                ObejrzaneVM = new ObejrzaneViewModel();
                CurrentView = ObejrzaneVM;
            }
        }

        public MainViewModel()
        {
            DoObejrzeniaVM = new DoObejrzeniaViewModel();
            ObejrzaneVM = new ObejrzaneViewModel();
            UstawieniaVM = new UstawieniaViewModel();

            CurrentView = DoObejrzeniaVM;

            DoObejrzeniaViewCommand = new Relay(o =>
            {
                CurrentView = DoObejrzeniaVM;
                var mw = Application.Current.MainWindow as MainWindow;
                if (mw != null) mw.WyszukiwarkaBox.Text = string.Empty;
            });

            ObejrzaneViewCommand = new Relay(o =>
            {
                CurrentView = ObejrzaneVM;
                var mw = Application.Current.MainWindow as MainWindow;
                if (mw != null) mw.WyszukiwarkaBox.Text = string.Empty;
            });

            UstawieniaViewCommand = new Relay(o =>
            {
                CurrentView = UstawieniaVM;
                var mw = Application.Current.MainWindow as MainWindow;
                if (mw != null) mw.WyszukiwarkaBox.Text = string.Empty;
            });
        }

    }
}

