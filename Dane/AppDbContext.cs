using Microsoft.EntityFrameworkCore;
using Projekt_prog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_prog.Dane
{
    public class AppDbContext : DbContext
    {
        public DbSet<Film> Filmy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=filmy.db");
        }
    }
}
