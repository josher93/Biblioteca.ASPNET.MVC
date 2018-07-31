using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geovanni.Biblioteca.WebAPI.Models
{
    public class GenericResponse : IResponse
    {
        public int HttpCode { get; set; }
        public string InternalCode { get; set; }
        public string Message { get; set; }
    }
}