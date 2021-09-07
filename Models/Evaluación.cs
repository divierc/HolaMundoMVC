using System;

namespace HolaMundoMVC.Models
{
    public class Evaluación:ObjetoEscuelaBase
    {
        public string AlumnoId { get; set; }
        public Alumno Alumno { get; set; }
        public string AsignaturaId { get; set; }
        public Asignatura Asignatura  { get; set; }

        public float Nota { get; set; }

        public override string ToString()
        {
            return $"{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}";
        }
    }
}