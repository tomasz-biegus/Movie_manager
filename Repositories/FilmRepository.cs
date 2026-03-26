using Projekt_prog.Dane;
using Projekt_prog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_prog.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        //wykonuje operacje na bazie danych, korzystając z Entity Framework Core
        private readonly AppDbContext _context;

        public FilmRepository()
        {
            // Inicjalizacja kontekstu bazy danych i zapewnienie, że baza jest utworzona
            _context = new AppDbContext();
            _context.Database.EnsureCreated();
        }

        public IEnumerable<Film> PobierzWszystkie()
        {
            return _context.Filmy.ToList();
        }

        public Film? PobierzPoId(int id)
        {
            return _context.Filmy.FirstOrDefault(f => f.Id == id);
        }

        public void Dodaj(Film film)
        {
            _context.Filmy.Add(film);
        }

        public void Aktualizuj(Film film)
        {
            _context.Filmy.Update(film);
        }

        public void Usun(int id)
        {
            var film = PobierzPoId(id);
            if (film != null)
                _context.Filmy.Remove(film);
        }

        public void Zapisz()
        {
            _context.SaveChanges();
        }
    }
}
