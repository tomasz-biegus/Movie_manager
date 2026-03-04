using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_prog.WMW.ModeleWidokow
{
    class DoObejrzeniaViewModel : ObsObject
    {

        public HomeViewModel HomeVM { get; set; }

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



        public DoObejrzeniaViewModel()
        {
            HomeVM = new HomeViewModel();
            CurrentView = HomeVM;

        }
    }
}
