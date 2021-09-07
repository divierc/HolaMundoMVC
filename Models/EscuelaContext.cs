using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            // el metodo base haga lo que tiene que hacer
            base.OnModelCreating(modelBuilder);
            // Se agrega el modelo escuela
            var escuela=new Escuela();
            escuela.Nombre= "Platzi Academy";
            escuela.TipoEscuela = TiposEscuela.Primaria;
            escuela.Dirección = "Calle 1 #12-32";
            escuela.Pais= "Colombia";
            escuela.Ciudad = "Bogota";
            escuela.AñoDeCreación = 2005;

            modelBuilder.Entity<Escuela>().HasData(escuela);
            
            modelBuilder.Entity<Asignatura>().HasData(
                    new Asignatura() { Nombre="Matematicas" },
                    new Asignatura() { Nombre="Educacion Fisica" },
                    new Asignatura() { Nombre="Castellano" },
                    new Asignatura() { Nombre="Ciencias Naturales" }
            );

            modelBuilder.Entity<Alumno>().HasData(GenerarAlumnosAlAzar(20).ToArray()); // ToArray porque hasdata lo recibe como un string
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

        return ListaAlumnos.OrderBy((a1) => a1.Id).Take(cantidad).ToList();
        }
        
    }
}