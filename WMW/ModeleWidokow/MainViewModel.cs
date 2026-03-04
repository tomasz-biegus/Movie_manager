using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_prog.WMW.ModeleWidokow
{
    class MainViewModel : ObsObject
    {

        public Relay DoObejrzeniaViewCommand { get; set; }

        public Relay ObejrzaneViewCommand { get; set; }

        public DoObejrzeniaViewModel DoObejrzeniaVM { get; set; }

        public ObejrzaneViewModel ObejrzaneVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

    

    public MainViewModel()
        {
            DoObejrzeniaVM = new DoObejrzeniaViewModel();
            ObejrzaneVM = new ObejrzaneViewModel();
            CurrentView = DoObejrzeniaVM;

            DoObejrzeniaViewCommand = new Relay(o =>
            {
                CurrentView = DoObejrzeniaVM;
            });
            ObejrzaneViewCommand = new Relay(o =>
            {
                CurrentView = ObejrzaneVM;
            });
        }

    }
}

