using System;
using System.Collections.Generic;

namespace CorEscuela.Entidades
{
    public class Curso
    {
        public string Nombre { get; set; }
        public string UniqueId { get; private set; }
        public TiposJornada Jornada { get; set; }

        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }

        public Curso()
        {
            UniqueId = Guid.NewGuid().ToString();      //Con Control + punto "." puedo abrir e importar una clase parado sobre la palabra clave
        }

        public Curso(string nombre, TiposJornada tipoJornada)
        {
            this.Nombre = nombre;
            this.Jornada = tipoJornada;
            this.UniqueId = Guid.NewGuid().ToString();
        }
    }

}