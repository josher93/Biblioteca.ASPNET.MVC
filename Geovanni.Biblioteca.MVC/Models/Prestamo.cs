using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geovanni.Biblioteca.MVC.Models
{
    public class Prestamo
    {
        public int idLector { get; set; }
        public int idLibro { get; set; }
        public string nombre { get; set; }
        public string carrera { get; set; }
        public string titulo { get; set; }
        public DateTime fechaPrestamo { get; set; }
        public DateTime fechaDevolucion { get; set; }
        public DateTime devuelto { get; set; }
    }
}