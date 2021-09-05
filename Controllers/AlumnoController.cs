using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace HolaMundoMVC.Controllers
{
    public class AlumnoController : Controller
    {
        public IActionResult Index(){
            return View(new Alumno() { Nombre="Pepe Perez" });

        }
         public IActionResult MultiAlumno()
        {
            // Se agrega la lista de asignaturas
            var ListaAlumnos = GenerarAlumnosAlAzar(20);
            
            ViewBag.FechaAsignatura = DateTime.Now;
            return View("MultiAlumno",ListaAlumnos);
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
        string[] nombre1 = { "nom1", "nom2", "nom3", "nom5", "nom6" };
        string[] apellido1 = { "ape1", "ape2", "ape3", "ape4", "ape5" };
        string[] nombre2 = { "nom7", "nom8", "nom9", "nom10", "nom11" };

        var ListaAlumnos = from n1 in nombre1
                            from n2 in nombre2
                            from ap1 in apellido1
                            select new Alumno { Nombre = $"{n1} {n2} {ap1}" };

        return ListaAlumnos.OrderBy((a1) => a1.UniqueId).Take(cantidad).ToList();
        }

    }
}