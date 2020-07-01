using System;
using System.Collections.Generic;
using CorEscuela.Util;

namespace CorEscuela.Entidades
{
    public class Escuela:ObjetoEscuelaBase, ILugar
    {

        public int AñoDeCreación { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Dirección { get; set; }
        public TipoEscuela TipoEscuela { get; set; }
        public static List<Curso> Cursos { get; set; }

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

        public void LimpiarLugar()
        {
            Printer.DibujarLinea();
            Console.WriteLine("Limpiando Escuela");

            foreach (var curso in Escuela.Cursos)
            {
                curso.LimpiarLugar();
            }

            Console.WriteLine($"Escuela {Nombre} limpia");

        }
    }
}