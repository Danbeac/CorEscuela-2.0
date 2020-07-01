using System;
using System.Collections.Generic;
using CorEscuela.Util;

namespace CorEscuela.Entidades
{
    public class Curso: ObjetoEscuelaBase, ILugar
    {
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public string Dirección { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Curso()
        {
            //UniqueId = Guid.NewGuid().ToString();      //Con Control + punto "." puedo abrir e importar una clase parado sobre la palabra clave
        }

        public Curso(string nombre, TiposJornada tipoJornada)
        {
             //this.Nombre = nombre;
            // this.Jornada = tipoJornada;
            // this.UniqueId = Guid.NewGuid().ToString();
        }

        public void LimpiarLugar()
        {
            Printer.DibujarLinea();
            Console.WriteLine("Limpiando Establecimiento...");
            Console.WriteLine($"Curso {Nombre} Limpio");

        }
    }

}