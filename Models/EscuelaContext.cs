using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace HolaMundoMVC.Models
{
    public class EscuelaContext : DbContext
    {
        // Se crea la lista de escuelas 
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evaluación> Evaluaciones { get; set; }

        public EscuelaContext(DbContextOptions<EscuelaContext> options): base(options)
        {
            
            
        }
        
        /////////////////////////////////////////////////////
        // Se sobrecarga una funcion con nueva funcionalidad
        /////////////////////////////////////////////////////
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // el metodo base haga lo que tiene que hacer
            base.OnModelCreating(modelBuilder);
            // Se agrega el modelo escuela
            var escuela = new Escuela();
            escuela.Nombre = "Platzi Academy";
            escuela.TipoEscuela = TiposEscuela.Primaria;
            escuela.Dirección = "Calle 1 #12-32";
            escuela.Pais = "Colombia";
            escuela.Ciudad = "Bogota";
            escuela.AñoDeCreación = 2005;

            
            // cargar cursos de la escuela
            var cursos= CargarCursos(escuela);
            // X cada curso cargar una asignatura y asignaturas 
            var asignaturas = CargarAsignaturas(cursos);
            // X cada curso cargar una alumnos
            var alumnos=CargarAlumnos(cursos);
            // ToDo
            var evaluaciones = new List<Evaluación>();
            // Cargar la escuela
            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());
            modelBuilder.Entity<Evaluación>().HasData(evaluaciones.ToArray());



        }

        private List<Asignatura> CargarAsignaturas(List<Curso> Cursos)
        {
            var listaCompleta= new List<Asignatura>();
            foreach (var curso in Cursos)
            {
                var tmpList = new List<Asignatura> {
                    new Asignatura() { CursoId = curso.Id, Nombre = "Matematicas" },
                    new Asignatura() { CursoId = curso.Id, Nombre = "Educacion Fisica" },
                    new Asignatura() { CursoId = curso.Id, Nombre = "Castellano" },
                    new Asignatura() { CursoId = curso.Id, Nombre = "Ciencias Naturales" }
                };
                // Asignaturas por curso
                //curso.Asignaturas= tmpList;
                // Total de asignaturas
                listaCompleta.AddRange(tmpList);
            }
            return listaCompleta;
        }

        private static List<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>() {
                new Curso() { EscuelaId = escuela.Id, Nombre = "101", Jornada = TiposJornada.Mañana },
                new Curso() { EscuelaId = escuela.Id, Nombre = "201", Jornada = TiposJornada.Mañana },
                new Curso() { EscuelaId = escuela.Id, Nombre = "301", Jornada = TiposJornada.Mañana },
                new Curso() { EscuelaId = escuela.Id, Nombre = "401", Jornada = TiposJornada.Mañana },
                new Curso() { EscuelaId = escuela.Id, Nombre = "501", Jornada = TiposJornada.Mañana },
                new Curso() { EscuelaId = escuela.Id, Nombre = "601", Jornada = TiposJornada.Mañana },
                new Curso() { EscuelaId = escuela.Id, Nombre = "701", Jornada = TiposJornada.Mañana },
                new Curso() { EscuelaId = escuela.Id, Nombre = "801", Jornada = TiposJornada.Mañana },
                new Curso() { EscuelaId = escuela.Id, Nombre = "901", Jornada = TiposJornada.Mañana },
                new Curso() { EscuelaId = escuela.Id, Nombre = "102", Jornada = TiposJornada.Tarde }

            };
        }

    private List<Alumno> CargarAlumnos(List<Curso> cursos)
    {
        var listaAlumnos= new List<Alumno>();

        Random rnd = new Random();
        foreach (var curso in cursos)
        {
            // alumnos por curso
            //curso.Alumnos = GenerarAlumnosAlAzar(curso, rnd.Next(5, 20));
            // total de alumnos
            //listaAlumnos.AddRange(curso.Alumnos);
            listaAlumnos.AddRange(GenerarAlumnosAlAzar(curso, rnd.Next(5, 20)));
        }
        return listaAlumnos;
    }

        private List<Alumno> GenerarAlumnosAlAzar(Curso curso,int cantidad)
        {
        string[] nombre1 = { "nom1", "nom2", "nom3", "nom5", "nom6" };
        string[] apellido1 = { "ape1", "ape2", "ape3", "ape4", "ape5" };
        string[] nombre2 = { "nom7", "nom8", "nom9", "nom10", "nom11" };

        var ListaAlumnos = from n1 in nombre1
                            from n2 in nombre2
                            from ap1 in apellido1
                            select new Alumno { 
                                CursoId=curso.Id,
                                Nombre = $"{n1} {n2} {ap1}" };

        return ListaAlumnos.OrderBy((a1) => a1.Id).Take(cantidad).ToList();
        }
        
    }
}