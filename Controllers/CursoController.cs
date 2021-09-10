using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundoMVC.Controllers
{
    public class CursoController : Controller
    {
        public IActionResult Index(string Id)
        {
            if (!string.IsNullOrWhiteSpace(Id))
            {
                var items =
                    from item in _context.Cursos
                    where item.Id == Id select item;

                return View(items.SingleOrDefault());
            }
            else
            {
                return View("MultiCurso", _context.Cursos);
            }
        }

        public IActionResult MultiCurso()
        {
            return View("MultiCurso", _context.Cursos);
        }

        public IActionResult Create()
        {
            ViewBag.FechaAsignatura = DateTime.Now;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            ViewBag.FechaAsignatura = DateTime.Now;

            if (curso != null && ModelState.IsValid)
            {
                var escuela = _context.Escuelas.FirstOrDefault();
                curso.EscuelaId = escuela.Id;
                _context.Cursos.Add (curso);
                _context.SaveChanges();
                ViewBag.MensajeExtra = "Curso Creado!";
                return View("Index",curso);
            }
            else
            {
                return View(curso);
            }
        }

        private EscuelaContext _context;

        public CursoController(EscuelaContext context)
        {
            _context = context;
        }
    }
}
