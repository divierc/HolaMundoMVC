using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace HolaMundoMVC.Controllers
{
    public class AlumnoController : Controller
    {
        public IActionResult Index(){
            ViewBag.FechaAsignatura = DateTime.Now;
            return View(_context.Alumnos.FirstOrDefault());

        }
         public IActionResult MultiAlumno()
        {

            return View("MultiAlumno",_context.Alumnos);
        }

        private EscuelaContext _context;
        public AlumnoController(EscuelaContext context)
        {
            _context=context;
        }

    }
}