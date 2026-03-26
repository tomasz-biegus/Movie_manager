using Projekt_prog.Model;
using System;
using Projekt_prog.Repositories;
using System.Collections.ObjectModel;

namespace Projekt_prog.WMW.ModeleWidokow
{
    class DoObejrzeniaViewModel : ObsObject
    {
        //private readonly FilmRepository _repo;
        private readonly IFilmRepository _repo;
        public ObservableCollection<Film> Filmy { get; set; }

        public DoObejrzeniaViewModel()
        {
            // Inicjalizacja repozytorium (można użyć wstrzykiwania zależności, jeśli jest dostępne)
            _repo = new FilmRepository();
            WczytajFilmy();
        }

        private void WczytajFilmy()
        {
            // Pobierz wszystkie filmy, ale wyświetl tylko te, które nie są oznaczone jako "Obejrzany"
            var filmy = _repo.PobierzWszystkie()
                             .Where(f => f.Status != "Obejrzany")
                             .ToList();
            Filmy = new ObservableCollection<Film>(filmy);
            OnPropertyChanged(nameof(Filmy));
        }
    }
}