using System;

namespace CorEscuela.Entidades
{
    public class Evaluación : ObjetoEscuelaBase
    {
        public Alumno Alumno { get; set; }

        public String Asignatura { get; set; }

        public float Nota { get; set; }



        public override string ToString(){
            return $"{Nota},{Alumno},{Asignatura}";
        }

    }
}