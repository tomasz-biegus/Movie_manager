using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt_prog.Model;

namespace Projekt_prog.Repositories
{
    public interface IFilmRepository
    {
        IEnumerable<Film> PobierzWszystkie();
        Film? PobierzPoId(int id);
        void Dodaj(Film film);
        void Aktualizuj(Film film);
        void Usun(int id);
        void Zapisz();
    }
}
