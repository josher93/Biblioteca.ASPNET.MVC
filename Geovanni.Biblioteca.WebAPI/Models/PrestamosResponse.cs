﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geovanni.Biblioteca.WebAPI.Models
{
    public class PrestamosResponse : IResponse
    {
        public List<Prestamo> prestamos { get; set; }
    }
}