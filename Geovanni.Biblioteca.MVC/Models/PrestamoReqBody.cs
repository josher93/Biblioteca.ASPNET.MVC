using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geovanni.Biblioteca.MVC.Models
{
    public class PrestamoReqBody
    {
        public int IdLector { get; set; }
        public int IdLibro { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public DateTime Devuelto { get; set; }
    }
}