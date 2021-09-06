using System;
using System.Runtime.InteropServices;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace HolaMundoMVC.Controllers
{
    public class EscuelaController : Controller
    {
        private EscuelaContext _context;

         public IActionResult Index()
        {
            ViewBag.TextoDePrueba = "Cualquier texto";
            var escuela=_context.Escuelas.FirstOrDefault();
            return View(escuela);
        }
        public EscuelaController(EscuelaContext context)
        {
            _context=context;
        }

    }
}