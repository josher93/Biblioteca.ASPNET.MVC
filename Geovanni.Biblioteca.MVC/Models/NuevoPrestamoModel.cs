using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Geovanni.Biblioteca.MVC.Models
{
    public class NuevoPrestamoModel
    {
        //public List<Libro> Libros { get; set; }
        //public List<Estudiante> Estudiantes { get; set; }

        public int IdLibro { get; set; }
        public int IdEstudiante { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaPrestamo { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaDevolucion{ get; set; }
    }
}