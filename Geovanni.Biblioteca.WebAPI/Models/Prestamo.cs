using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geovanni.Biblioteca.WebAPI.Models
{
    public class Prestamo
    {
        public int IdLector { get; set; }
        public int IdLibro { get; set; }
        public string Nombre { get; set; }
        public string Carrera { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public DateTime Devuelto { get; set; }
    }
}