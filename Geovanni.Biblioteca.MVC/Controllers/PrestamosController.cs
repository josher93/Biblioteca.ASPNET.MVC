using Geovanni.Biblioteca.MVC.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Geovanni.Biblioteca.MVC.Controllers
{
    public class PrestamosController : Controller
    {
        // GET: Prestamos
        public ActionResult Index()
        {
            List<Prestamo> prestamos = new List<Prestamo>();

            try
            {
                var client = new RestClient("http://localhost:35969/");
                var request = new RestRequest("prestamos/", Method.GET);
                request.RequestFormat = DataFormat.Json;
                
                var response = client.Execute<PrestamosResponse>(request);

                if (response.IsSuccessful)
                {
                    prestamos = response.Data.prestamos;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(prestamos);
        }

        public ActionResult NuevoPrestamo()
        {
            NuevoPrestamoModel model = new NuevoPrestamoModel();
            List<Libro> libros = new List<Libro>();
            List<Estudiante> estudiantes = new List<Estudiante>();

            try
            {
                var client = new RestClient("http://localhost:35969/");

                //libros
                var librosReq = new RestRequest("libros/", Method.GET);
                librosReq.RequestFormat = DataFormat.Json;
                var librosResponse = client.Execute<LibrosResponse>(librosReq);

                if (librosResponse.IsSuccessful)
                {
                    libros = librosResponse.Data.libros;
                }

                //estudiantes
                var estudiantesReq = new RestRequest("estudiantes/", Method.GET);
                estudiantesReq.RequestFormat = DataFormat.Json;
                var estudiantesResponse = client.Execute<EstudiantesResponse>(estudiantesReq);

                if (estudiantesResponse.IsSuccessful)
                {
                    estudiantes = estudiantesResponse.Data.estudiantes;
                }

                //Llenado de combos
                IEnumerable<SelectListItem> estudiantesSelect = estudiantes.Select(c => new SelectListItem
                {
                    Value = c.idLector.ToString(),
                    Text = c.nombre

                });

                IEnumerable<SelectListItem> librosSelect = libros.Select(c => new SelectListItem
                {
                    Value = c.IdLibro.ToString(),
                    Text = c.Titulo

                });

                ViewBag.Estudiantes = estudiantesSelect;
                ViewBag.Libros = librosSelect;
                model.FechaDevolucion = DateTime.Now;
                model.FechaPrestamo = DateTime.Now;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult AgregarPrestamo(NuevoPrestamoModel model)
        {

            try
            {
                PrestamoReqBody postBody = new PrestamoReqBody();
                postBody.IdLector = model.IdEstudiante;
                postBody.IdLibro = model.IdLibro;
                postBody.FechaDevolucion = model.FechaDevolucion;
                postBody.FechaPrestamo = model.FechaPrestamo;


                var client = new RestClient("http://localhost:35969/");
                var restRequest = new RestRequest("prestamos/agregar/", Method.POST);
                restRequest.RequestFormat = DataFormat.Json;

                var librosResponse = client.Post<LibrosResponse>(restRequest);
                restRequest.AddBody(postBody);

                var result = client.Post<GenericResponse>(restRequest);

                if (result.IsSuccessful)
                {
                    return Redirect("~/Prestamos/Index/");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Redirect("~/Prestamos/Index/");
        }
    }
}