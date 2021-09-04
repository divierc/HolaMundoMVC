using System;
using System.Runtime.InteropServices;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace HolaMundoMVC.Controllers
{
    public class AsignaturaController : Controller
    {
         public IActionResult Index()
        {
            // Se agrega el modelo escuela
            var asignatura=new Asignatura();
            asignatura.Nombre = "Matematicas";
            
            ViewBag.FechaAsignatura = DateTime.Now;
            return View(asignatura);
        }

    }
}