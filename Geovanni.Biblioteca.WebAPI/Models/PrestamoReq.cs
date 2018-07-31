using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geovanni.Biblioteca.WebAPI.Models
{
    public class PrestamoReq
    {
        public int IdLector { get; set; }
        public int IdLibro { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public DateTime Devuelto { get; set; }
    }

    public class DevolverPrestamoReq
    {
        public int IdLector { get; set; }
        public int IdLibro { get; set; }
    }
}