using Geovanni.Biblioteca.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;
using System.Data;

namespace Geovanni.Biblioteca.WebAPI.Controllers
{
	public class PrestamosController : ApiController
	{
		Connection con = new Connection();


		[HttpGet]
		[Route("prestamos")]
		public HttpResponseMessage getPrestamos(HttpRequestMessage request)
		{
			try
			{
				
				List<Prestamo> prestamos = con.Cnn.Query<Prestamo>(@"select est.[Nombre], est.[Carrera], lib.[Titulo], pres.[FechaPrestamo],
							pres.[FechaDevolucion] 
							from [dbo].[Prestamo] as pres
							join [dbo].[Estudiante] as est on pres.IdLector = est.IdLector
							join [dbo].[Libro] as lib on pres.IdLibro = lib.IdLibro").AsList();

				PrestamosResponse response = new PrestamosResponse();
				response.prestamos = prestamos;
				return Request.CreateResponse<IResponse>(HttpStatusCode.OK, response);

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong");
			}
		}

		[HttpPost]
		[Route("prestamos/agregar")]
		public HttpResponseMessage addPrestamo(HttpRequestMessage request, [FromBody] PrestamoReq nuevoPrestamo)
		{
			try
			{

				int result = con.Cnn.Execute(@"INSERT INTO [dbo].[Prestamo]
										   ([IdLector],[IdLibro],[FechaPrestamo],[FechaDevolucion] ) VALUES
										   (@idLector
										   ,@idLibro
										   ,@fechaPrestamo
										   ,@fechaDevolucion)", new
				{
					idLector = nuevoPrestamo.IdLector,
					idLibro = nuevoPrestamo.IdLibro,
					fechaPrestamo = nuevoPrestamo.FechaPrestamo,
					fechaDevolucion = nuevoPrestamo.FechaDevolucion

				}, commandType: CommandType.Text);

				if (result > 0)
				{
					GenericResponse response = new GenericResponse();
					response.HttpCode = 200;
					response.Message = "Success";
					return Request.CreateResponse<IResponse>(HttpStatusCode.OK, response);
				}
				else
				{
					return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong");
			}
		}

		[HttpPost]
		[Route("prestamos/devolucion/")]
		public HttpResponseMessage returnedPrestamo(HttpRequestMessage request, [FromBody] PrestamoReq body)
		{
			try
			{

				int result = con.Cnn.Execute(@"UPDATE [dbo].[Prestamo] SET 
												[Devuelto] = GETDATE()
												WHERE [IdLector] = @idLector 
												AND [IdLibro] = @idLibro", new
				{
					idLector = body.IdLector,
					idLibro = body.IdLibro

				}, commandType: CommandType.Text);

				if (result > 0)
				{
					GenericResponse response = new GenericResponse();
					response.HttpCode = 200;
					response.Message = "Success";
					return Request.CreateResponse<IResponse>(HttpStatusCode.OK, response);
				}
				else
				{
					return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong");
			}
		}

	}
}
