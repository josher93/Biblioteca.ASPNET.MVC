using Geovanni.Biblioteca.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;

namespace Geovanni.Biblioteca.WebAPI.Controllers
{
    public class LibrosController : ApiController
    {
        Connection con = new Connection();

        [HttpGet]
        [Route("libros")]
        public HttpResponseMessage getEstudiantes(HttpRequestMessage request)
        {
            try
            {

                List<Libro> librosList = con.Cnn.Query<Libro>(@"select [IdLibro], [Titulo], [Editorial], [Area] 
                                                from [dbo].[Libro]").AsList();

                LibrosResponse response = new LibrosResponse();
                response.libros = librosList;

                return Request.CreateResponse<IResponse>(HttpStatusCode.OK, response);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong");
            }
        }
    }
}
