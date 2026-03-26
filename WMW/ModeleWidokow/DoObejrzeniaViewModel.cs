using Projekt_prog.Model;
using Projekt_prog.Repositories;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Projekt_prog.WMW.ModeleWidokow
{
    class DoObejrzeniaViewModel : ObsObject
    {
        // Repozytorium do zarządzania danymi filmów
        private readonly IFilmRepository _repo;
        internal List<Film> _wszystkieFilmy = new();
        public ObservableCollection<Film> Filmy { get; set; } = new ObservableCollection<Film>();

        public DoObejrzeniaViewModel()
        {
            // Inicjalizacja repozytorium i wczytanie filmów
            _repo = new FilmRepository();
            WczytajFilmy();
        }


        private void WczytajFilmy()
        {
            _wszystkieFilmy = _repo.PobierzWszystkie()
                                   .Where(f => f.Status != "Obejrzany")
                                   .ToList();
            Filmy.Clear();
            foreach (var film in _wszystkieFilmy)
                Filmy.Add(film);
        }

        public void Filtruj(string fraza)
        {
            var przefiltrowane = string.IsNullOrWhiteSpace(fraza)
                ? _wszystkieFilmy
                : _wszystkieFilmy.Where(f =>
                    f.Tytul.ToLower().Contains(fraza) ||
                    f.Gatunek.ToLower().Contains(fraza) ||
                    f.Rok.ToString().Contains(fraza)).ToList();

            Filmy.Clear();
            foreach (var film in przefiltrowane)
                Filmy.Add(film);
        }

    }
}