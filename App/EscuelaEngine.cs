using System;
using System.Collections.Generic;
using System.Linq;
using CorEscuela.Entidades;

namespace CorEscuela
{
    public sealed class EscuelaEngine //"Sealed" Sella la clase para que permita instanciar pero no heredar
    {
        public Escuela Escuela { get; private set; }

        public EscuelaEngine()
        {



        }
        public void Inicializar()
        {

            this.Escuela = new Escuela("Brazzer Schoool", 2020, TipoEscuela.PornHub, "Italia", ciudad: "Venecia");

            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();
        }

        private void CargarEvaluaciones()
        {
            string[] arraEvaluaciones = { "Parcial Week 1", "Parcial Week 2", "Parcial Week 3", "Parcial Week 4", "Parcial Final" };

            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        List<Evaluación> listEvaluaciones = new List<Evaluación>();

                        foreach (var materia in curso.Asignaturas)
                        {
                            int itinerador = 0;
                            Random numRandomNota = new Random();
                            double RandomNota = numRandomNota.NextDouble() * 5;
                            float NotaFinal = Convert.ToSingle(RandomNota);

                            Evaluación Evaluacion = new Evaluación();

                            while (itinerador <= arraEvaluaciones.Count() - 1)
                            {
                                Evaluacion = new Evaluación
                                {
                                    Nombre = arraEvaluaciones[itinerador],
                                    Nota = NotaFinal,
                                    Asignatura = materia.Nombre,
                                    Alumno = alumno
                                };
                                itinerador++;
                                listEvaluaciones.Add(Evaluacion);

                            }
                        }
                        alumno.Evaluaciones = listEvaluaciones;
                        if (asignatura?.Evaluacion == null)
                        {
                            asignatura.Evaluacion = listEvaluaciones;
                        }
                        else
                        {
                            asignatura.Evaluacion.AddRange(listEvaluaciones);
                        }
                    }
                }
            }
        }
        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                List<Asignatura> ListaAsignaturas = new List<Asignatura>{new Asignatura{Nombre = "Matematicas"},
                                                            new Asignatura{Nombre = "Educacion Fisica"},
                                                            new Asignatura{Nombre = "Castellano"},
                                                            new Asignatura{Nombre = "Ciencias Naturales"}};
                curso.Asignaturas = ListaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar(int Cantidad)
        {
            String[] arrPmrNombre = { "Lucia", "Diego", "Yineth", "Michell", "Daniel", "Paula", "Juanita" };
            String[] arrPmrApellido = { "Castizo", "Sabogal", "Diaz", "Torres", "Bernal", "Gomez", "DelArco" };
            String[] arrSgdNombre = { "Pedro", "Mateo", "Teodoro", "John", "Sebastian", "Juan", "Miguel" };

            var listaAlumnos = from n1 in arrPmrNombre
                               from n2 in arrSgdNombre
                               from a1 in arrPmrApellido
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };
            return listaAlumnos.OrderBy((al => al.UniqueId)).Take(Cantidad).ToList();
        }


        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso> { new Curso{Nombre = "601",Jornada = TiposJornada.Tarde},
                                                new Curso{Nombre = "602", Jornada = TiposJornada.Tarde},
                                                new Curso{Nombre = "603", Jornada = TiposJornada.Tarde},
                                                new Curso { Nombre = "V701", Jornada = TiposJornada.Virtual },
                                                new Curso("V702", TiposJornada.Virtual),
                                                new Curso("801-Vacaional", TiposJornada.Nocturna) };
            Random rmd = new Random();

            foreach (var c in Escuela.Cursos)
            {
                int canRandom = rmd.Next(5, 20);
                c.Alumnos = GenerarAlumnosAlAzar(canRandom);
            }
        }

        public List<ObjetoEscuelaBase> GetObjectosEscuela()
        {
            var listaObj = new List<ObjetoEscuelaBase>();

            listaObj.Add(Escuela);
            listaObj.AddRange(Escuela.Cursos);

            foreach (var Curso in Escuela.Cursos)
            {
                listaObj.AddRange(Curso.Asignaturas);
                listaObj.AddRange(Curso.Alumnos);
            }

            // foreach (var alumno in Curso.Alumnos)
            // {
            //     listaObj.AddRange(alumno.Evaluaciones);
            // }

            return listaObj;
        }

    }

}