using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geovanni.Biblioteca.WebAPI.Models
{
    public class LibrosResponse: IResponse
    {
        public List<Libro> libros { get; set; }
    }
}