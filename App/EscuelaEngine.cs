using System;
using System.Collections.Generic;
using System.Linq;
using CorEscuela.Entidades;
using CorEscuela.Util;

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

        private List<Alumno> GenerarAlumnosAlAzar(int Cantidad)
        {
            String[] arrPmrNombre = { "Lucia", "Diego", "Yineth", "Daniel"};
            String[] arrPmrApellido = { "Castizo", "Sabogal", "Diaz", "Bernal" };
            String[] arrSgdNombre = { "Pedro", "Mateo", "Teodoro", "John" };

            var listaAlumnos = from n1 in arrPmrNombre
                               from n2 in arrSgdNombre
                               from a1 in arrPmrApellido
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };
            return listaAlumnos.OrderBy((al => al.UniqueId)).Take(Cantidad).ToList();
        }
        #region SobreCarga de Metodos
        // Con 3 parametro de salida
        public IReadOnlyList<ObjetoEscuelaBase> GetObjectosEscuela(out int conteoEvaluaciones,
                                                          out int conteoAlumnos,
                                                          out int conteoAsignaturas,
                                                          bool traeEvaluaciones = true,
                                                          bool traeAlumnos = true,
                                                          bool traeAsignaturas = true,
                                                          bool traeCursos = true
                                                          )
        {
            return GetObjectosEscuela(out conteoEvaluaciones, out conteoAlumnos, out conteoAsignaturas, out int dummy);
        }
        // Con 2 parametro de salida
        public IReadOnlyList<ObjetoEscuelaBase> GetObjectosEscuela(out int conteoEvaluaciones,
                                                          out int conteoAlumnos,
                                                          bool traeEvaluaciones = true,
                                                          bool traeAlumnos = true,
                                                          bool traeAsignaturas = true,
                                                          bool traeCursos = true
                                                          )
        {
            return GetObjectosEscuela(out conteoEvaluaciones, out conteoAlumnos, out int dummy, out dummy);
        }
        // Con 1 parametro de salida
        public IReadOnlyList<ObjetoEscuelaBase> GetObjectosEscuela(out int conteoEvaluaciones,
                                                          bool traeEvaluaciones = true,
                                                          bool traeAlumnos = true,
                                                          bool traeAsignaturas = true,
                                                          bool traeCursos = true
                                                          )
        {
            return GetObjectosEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }
        // Sin parametro de salida
        public IReadOnlyList<ObjetoEscuelaBase> GetObjectosEscuela(
                                                          bool traeEvaluaciones = true,
                                                          bool traeAlumnos = true,
                                                          bool traeAsignaturas = true,
                                                          bool traeCursos = true
                                                          )
        {
            return GetObjectosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjectosEscuela(out int conteoEvaluaciones,
                                                          out int conteoAlumnos,
                                                          out int conteoAsignaturas,
                                                          out int conteoCursos,
                                                          bool traeEvaluaciones = true,
                                                          bool traeAlumnos = true,
                                                          bool traeAsignaturas = true,
                                                          bool traeCursos = true
                                                          )
        {
            var listaObj = new List<ObjetoEscuelaBase>();
            conteoEvaluaciones = conteoAlumnos = conteoAsignaturas = conteoCursos = 0;

            listaObj.Add(Escuela);

            if (traeCursos)
                listaObj.AddRange(Escuela.Cursos);
            conteoCursos = Escuela.Cursos.Count;

            foreach (var Curso in Escuela.Cursos)
            {
                if (traeAsignaturas)
                    listaObj.AddRange(Curso.Asignaturas);
                conteoAsignaturas += Curso.Asignaturas.Count;

                if (traeAlumnos)
                    listaObj.AddRange(Curso.Alumnos);
                conteoAlumnos += Curso.Alumnos.Count;

                if (traeEvaluaciones)
                {
                    foreach (var alumno in Curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }

            return listaObj.AsReadOnly();
        }

        public Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {

            var Diccionario = new Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>>();
            var evaltmp = new List<Evaluación>();
            var asigtmp = new List<Asignatura>();
            var alumtmp = new List<Alumno>();

            Diccionario.Add(LlavesDiccionario.Curso, Escuela.Cursos);

            foreach (var c in Escuela.Cursos)
            {
                asigtmp.AddRange(c.Asignaturas);
                alumtmp.AddRange(c.Alumnos);

                foreach (var a in c.Alumnos)
                {
                    evaltmp.AddRange(a.Evaluaciones);
                }

            }

            Diccionario.Add(LlavesDiccionario.Evaluación, evaltmp);
            Diccionario.Add(LlavesDiccionario.Asignatura, asigtmp);
            Diccionario.Add(LlavesDiccionario.Alumno, alumtmp);

            //Cast
            //Diccionario.Add(LlavesDiccionario.Curso, Escuela.Cursos.Cast<ObjetoEscuelaBase>());

            return Diccionario;

        }

        public void ImprimirDiccionario(Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>> diccionario,
                                        bool impEval = false)
        {
            foreach (var objDicc in diccionario)
            {

                Printer.PrintTitle(objDicc.Key.ToString());

                foreach (var val in objDicc.Value)
                {
                    switch (objDicc.Key)
                    {
                        case LlavesDiccionario.Evaluación:
                            if (impEval)
                            {
                                Console.WriteLine(val);
                            }
                            break;
                        case LlavesDiccionario.Alumno:
                            Console.WriteLine("Alumno: " + val.Nombre);
                            break;
                        case LlavesDiccionario.Curso:
                            var cursotmp = val as Curso;
                            if (cursotmp != null)
                            {
                                int count = cursotmp.Alumnos.Count();
                                Console.WriteLine("Curso: " + val.Nombre + " Cantidad: " + count);
                            }
                            break;
                        default:
                            Console.WriteLine(val);
                            break;
                    }

                }
            }
        }

        #endregion

        #region Metodos de Carga
        private void CargarEvaluaciones()
        {
            string[] arraEvaluaciones = { "Parcial Week 1", "Parcial Week 2", "Parcial Week 3", "Parcial Week 4", "Parcial Final" };
            Random numRandomNota = new Random();

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
                            
                            double RandomNota = numRandomNota.NextDouble() * 5;
                            float NotaFinal = 
                            
                            MathF.Round(Convert.ToSingle(RandomNota),2);

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


        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso> { new Curso{Nombre = "601",Jornada = TiposJornada.Tarde},
                                                new Curso{Nombre = "602", Jornada = TiposJornada.Tarde},
                                                new Curso{Nombre = "603", Jornada = TiposJornada.Tarde},
                                                new Curso { Nombre = "V701", Jornada = TiposJornada.Virtual },
                                                new Curso("V702", TiposJornada.Virtual),
                                                new Curso("801-Vacacional", TiposJornada.Nocturna) };
            Random rmd = new Random();

            foreach (var c in Escuela.Cursos)
            {
                int canRandom = rmd.Next(1, 10);
                c.Alumnos = GenerarAlumnosAlAzar(canRandom);
            }
        }



    }
    #endregion

}