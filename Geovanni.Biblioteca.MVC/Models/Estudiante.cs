using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geovanni.Biblioteca.MVC.Models
{
    public class Estudiante
    {
        public int idLector { get; set; }
        public object ci { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string carrera { get; set; }
        public int edad { get; set; }
    }
}