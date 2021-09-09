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
        // public IActionResult Index(){
            
        //     ViewBag.CosaDinamica="La Monja";
        //     ViewBag.FechaAsignatura = DateTime.Now;

        //     return View(_context.Asignaturas.FirstOrDefault());

        // }

        [Route("Asignatura/Index")]
        [Route("Asignatura/Index/{asignaturaId}")]
        public IActionResult Index(string asignaturaId){

            if(!string.IsNullOrWhiteSpace(asignaturaId))
            {
                var asignatura = from asig in _context.Asignaturas
                                where asig.Id == asignaturaId
                                select asig;

                return View(asignatura.SingleOrDefault());
            }else{
                return View("MultiAsignatura", _context.Asignaturas);
            }


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