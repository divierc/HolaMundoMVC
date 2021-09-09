using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace HolaMundoMVC.Controllers
{
    public class CursoController : Controller
    {

         public IActionResult Index(string Id){

            if(!string.IsNullOrWhiteSpace(Id))
            {
                var items = from item in _context.Cursos
                                where item.Id == Id
                                select item;

                return View(items.SingleOrDefault());
            }else{
                return View("MultiCurso", _context.Cursos);
            }


        }
        public IActionResult MultiCurso()
        {

            return View("MultiCurso",_context.Cursos);
        }

        private EscuelaContext _context;
        public CursoController(EscuelaContext context)
        {
            _context=context;
        }

    }
}