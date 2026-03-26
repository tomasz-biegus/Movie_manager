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
        // Pobieranie danych z repozytorium i filtrowanie tylko tych, które są oznaczone jako "Obejrzany"
        private readonly IFilmRepository _repo;
        public ObservableCollection<Film> Filmy { get; set; }

        public ObejrzaneViewModel()
        {
            // Inicjalizacja repozytorium i wczytanie filmów
            _repo = new FilmRepository();
            WczytajFilmy();
        }

        private void WczytajFilmy()
        {
            // Pobierz wszystkie filmy z repozytorium, a następnie przefiltruj tylko te, które mają status "Obejrzany"
            var filmy = _repo.PobierzWszystkie()
                             .Where(f => f.Status == "Obejrzany")
                             .ToList();
            Filmy = new ObservableCollection<Film>(filmy);
            OnPropertyChanged(nameof(Filmy));
        }
    }
}