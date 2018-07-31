using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geovanni.Biblioteca.MVC.Models
{
    public class GenericResponse
    {
        public int HttpCode { get; set; }
        public string InternalCode { get; set; }
        public string Message { get; set; }
    }
}