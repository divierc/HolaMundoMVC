using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace HolaMundoMVC.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index(){
            
            ViewBag.CosaDinamica="La Monja";
            ViewBag.FechaAsignatura = DateTime.Now;

            return View(_context.Asignaturas.FirstOrDefault());

        }
         public IActionResult MultiAsignatura()
        {
            
            return View("MultiAsignatura", _context.Asignaturas);
        }

        private EscuelaContext _context;
        public AsignaturaController(EscuelaContext context)
        {
            _context=context;
        }

    }
}