using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geovanni.Biblioteca.WebAPI.Models
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Editorial { get; set; }
        public string Area { get; set; }
    }
}