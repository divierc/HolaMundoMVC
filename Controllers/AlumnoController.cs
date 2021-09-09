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

         public IActionResult Index(string Id){

            if(!string.IsNullOrWhiteSpace(Id))
            {
                var items = from item in _context.Alumnos
                                where item.Id == Id
                                select item;

                return View(items.SingleOrDefault());
            }else{
                return View("MultiAlumno", _context.Alumnos);
            }


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