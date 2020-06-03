using System;

namespace CorEscuela.Entidades
{
    public class Evaluación
    {
        public string UniqueId { get; private set; }

        public string Nombre { get; set; }

        public Alumno Alumno { get; set; }

        public String Asignatura { get; set; }

        public float Nota { get; set; }

        public Evaluación() => UniqueId = Guid.NewGuid().ToString();
    }
}