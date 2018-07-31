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
    public class EstudiantesController : ApiController
    {

        Connection con = new Connection();

        [HttpGet]
        [Route("estudiantes")]
        public HttpResponseMessage getEstudiantes(HttpRequestMessage request)
        {
            try
            {

                List<Estudiante> estudiantesList = con.Cnn.Query<Estudiante>(@"select [IdLector],[Nombre], [Direccion], [Carrera], [Edad] 
                                            from [dbo].[Estudiante]").AsList();

                EstudiantesResponse response = new EstudiantesResponse();
                response.estudiantes = estudiantesList;

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
