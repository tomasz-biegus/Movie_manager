using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_prog.Model
{
    public class Film
    {
        public int Id { get; set; }
        public string Tytul { get; set; } = string.Empty;
        public string Gatunek { get; set; } = string.Empty;
        public int Rok { get; set; }
        public string Ocena { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

    }
}
