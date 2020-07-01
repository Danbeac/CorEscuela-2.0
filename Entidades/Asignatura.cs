using System;
using System.Collections.Generic;

namespace CorEscuela.Entidades
{
    public class Asignatura:ObjetoEscuelaBase
    {
        public List<Evaluación> Evaluacion {get;set;}

    }
}