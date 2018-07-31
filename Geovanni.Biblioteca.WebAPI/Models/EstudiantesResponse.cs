using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geovanni.Biblioteca.WebAPI.Models
{
    public class EstudiantesResponse : IResponse
    {
        public List<Estudiante> estudiantes { get; set; }
    }
}