using Projekt_prog.Model;
using Projekt_prog.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_prog.WMW.ModeleWidokow
{
    class ObejrzaneViewModel : ObsObject
    {
        private readonly IFilmRepository _repo;
        public ObservableCollection<Film> Filmy { get; set; }

        public ObejrzaneViewModel()
        {
            _repo = new FilmRepository();
            WczytajFilmy();
        }

        private void WczytajFilmy()
        {
            var filmy = _repo.PobierzWszystkie()
                             .Where(f => f.Status == "Obejrzany")
                             .ToList();
            Filmy = new ObservableCollection<Film>(filmy);
            OnPropertyChanged(nameof(Filmy));
        }
    }
}