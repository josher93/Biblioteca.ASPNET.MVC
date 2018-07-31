using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geovanni.Biblioteca.MVC.Models
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Editorial { get; set; }
        public string Area { get; set; }
    }
}