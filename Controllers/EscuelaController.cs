using System;
using System.Runtime.InteropServices;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace HolaMundoMVC.Controllers
{
    public class EscuelaController : Controller
    {
        // Variables
       

         public IActionResult Index()
        {
            ViewBag.TextoDePrueba = "Cualquier texto";
            // Solo se trae la primera fila
            var escuela=_context.Escuelas.FirstOrDefault();
            return View(escuela);
        }

        private EscuelaContext _context;
        public EscuelaController(EscuelaContext context)
        {
            _context=context;
        }

    }
}