using Projekt_prog.Model;
using System;
using Projekt_prog.Repositories;
using System.Collections.ObjectModel;

namespace Projekt_prog.WMW.ModeleWidokow
{
    class DoObejrzeniaViewModel : ObsObject
    {
        private readonly IFilmRepository _repo;
        public ObservableCollection<Film> Filmy { get; set; }

        public DoObejrzeniaViewModel()
        {
            _repo = new FilmRepository();
            WczytajFilmy();
        }

        private void WczytajFilmy()
        {
            var filmy = _repo.PobierzWszystkie()
                             .Where(f => f.Status != "Obejrzany")
                             .ToList();
            Filmy = new ObservableCollection<Film>(filmy);
            OnPropertyChanged(nameof(Filmy));
        }
    }
}