using System;
using System.Collections.Generic;

namespace CorEscuela.Entidades
{
    public class Asignatura
    {
        public string Nombre { get; set; }
        public string UniqueId { get; private set; }
        public List<Evaluación> Evaluacion {get;set;}

        public Asignatura() => UniqueId = Guid.NewGuid().ToString();
    }
}