using System;
using System.Collections.Generic;

namespace CorEscuela.Entidades
{
    public class Escuela
    {

        public string Nombre { get; set; }
        public int AñoDeCreación { get; set; }
        public string Pais { get; set; }

        public string UniqueId { get; private set; } = Guid.NewGuid().ToString();  
        public string Ciudad { get; set; }
        public TipoEscuela TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }


        public Escuela(string nombre, int añoCreacion, TipoEscuela tipo, string pais = "", string ciudad = "")
        {
            this.Nombre = nombre;
            this.AñoDeCreación = añoCreacion;
            (Pais, Ciudad) = (pais, ciudad);
        }

        public Escuela(string Nombre, int Año) => (this.Nombre, this.AñoDeCreación) = (Nombre, Año);



        public override string ToString()
        {
            return $"\nNombre: \"{Nombre}\" \nTipo: {TipoEscuela} {System.Environment.NewLine}Pais: {Pais} \nCiudad: {Ciudad}";
        }

    }
}