using System;
using System.Collections.Generic;

namespace CorEscuela.Entidades
{
    public class Alumno
    {
        public string Nombre { get; set; }
        public string UniqueId { get; private set; }  = Guid.NewGuid().ToString();
        public List<Evaluación> Evaluaciones { get; set; }

    }
}