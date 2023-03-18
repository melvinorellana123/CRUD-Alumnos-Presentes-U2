using Asistencia_de_Alumnos_U2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Asistencia_de_Alumnos_U2.Interfaces;

namespace Asistencia_de_Alumnos_U2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioAlumnos _repositorioAlumnos;

        public HomeController(ILogger<HomeController> logger, IRepositorioAlumnos repositorioAlumnos)
        {
            _logger = logger;
            _repositorioAlumnos = repositorioAlumnos;
        }

        public IActionResult Index()
        {
            var todosLosAlumnos = _repositorioAlumnos.ObtenerAlumnos();
            var alumnosVieweModel = new AlumnoViewModel
            {
                alumnos = todosLosAlumnos
            };
            return View(alumnosVieweModel);
        }

        public IActionResult Crear()
        {
            return View("FormularioCrear");
        }
        
        [HttpPost]
        public IActionResult Crear(Alumno alumno)
        {
            _repositorioAlumnos.AgregarAlumno(alumno);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(Guid Id)
        {
            var alumno = _repositorioAlumnos.ObtenerAlumno(Id);
            return View("FormularioEditar", alumno);
        }
        
        [HttpPost]
        
        public IActionResult Editar(Alumno alumno)
        {
            _repositorioAlumnos.ActualizarAlumno(alumno);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Eliminar(Guid Id)
        {
            _repositorioAlumnos.EliminarAlumno(Id);
            return RedirectToAction("Index");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}