using System;
using System.Runtime.InteropServices;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace HolaMundoMVC.Controllers
{
    public class EscuelaController : Controller
    {
         public IActionResult Index()
        {
            // Se agrega el modelo escuela
            var escuela=new Escuela();
            escuela.Nombre= "Platzi Academy";
            escuela.AñoDeCreación = 2005;
            ViewBag.TextoDePrueba = "Cualquier texto";
            return View(escuela);
        }

    }
}