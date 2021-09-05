using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace HolaMundoMVC.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index(){
            return View(new Asignatura() { Nombre="Matematicas" });

        }
         public IActionResult MultiAsignatura()
        {
            // Se agrega la lista de asignaturas
            var ListaAsignaturas = new List<Asignatura>(){
                    new Asignatura() { Nombre="Matematicas" },
                    new Asignatura() { Nombre="Educacion Fisica" },
                    new Asignatura() { Nombre="Castellano" },
                    new Asignatura() { Nombre="Ciencias Naturales" }
                };
            
            ViewBag.FechaAsignatura = DateTime.Now;
            return View("MultiAsignatura",ListaAsignaturas);
        }

    }
}