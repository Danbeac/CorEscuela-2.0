using System;
using System.Collections.Generic;
using System.Linq;
using CorEscuela.Entidades;
using CorEscuela.Util;
using CorEscuela.App;
using static System.Console;

namespace CorEscuela
{
    class Program
    {
        static void Main(string[] args)
        {


            var Engine = new EscuelaEngine();
            Engine.Inicializar();
            Printer.PrintTitle("BIENVENIDOS A LA ESCUELA");
            Printer.Beep();

            string rta = SeleccionReporte();
            GenerarReporte(rta);

            // var lista = Engine.GetObjectosEscuela();

            // ImprimirCursosEscuela(Engine.Escuela);
            // ImprimirEvaluaciones(Engine.Escuela);

            // Engine.Escuela.LimpiarLugar();
            // //ImprimirDatosDiccionario();
            // var dicttmp = Engine.GetDiccionarioObjetos();
            // Engine.ImprimirDiccionario(dicttmp,true);

            // var Reporteador = new Reporteador(dicttmp);
            // var EvalList = Reporteador.GetListaEvaluaciones();
            // var AsigList = Reporteador.GetListaAsignaturas();
            // var ListEvalxAsig = Reporteador.GetEvalXAsig();
        }

        private static void GenerarReporte(string reporte)
        {
            var Engine = new EscuelaEngine();
            var dicttmp = Engine.GetDiccionarioObjetos();

            var Reporteador = new Reporteador(dicttmp);


            switch (reporte)
            {
                case "1":
                    Console.WriteLine("Inicializando Reporte Evaluaciones..");
                    Reporteador.GetListaEvaluaciones();
                    Console.WriteLine("Terminado Reporte Evaluaciones.");
                    break; 
                case "2":
                    Console.WriteLine("Inicializando Reporte Asignaturas..");
                    Reporteador.GetListaAsignaturas();
                    Console.WriteLine("Terminado Reporte Asignaturas.");
                    break;
                case "3":
                    Console.WriteLine("Inicializando Reporte Evaluaciones por asignatura..");
                    Reporteador.GetEvalXAsig();
                    Console.WriteLine("Terminado Reporte Evaluaciones por asignatura.");
                    break;
                case "4":
                    Console.WriteLine("Inicializando Reporte Promedio de alumnos por asignatura..");
                    Reporteador.GetPromeAlumnPorAsignatura();
                    Console.WriteLine("Terminado Reporte Promedio de alumnos por asignatura.");
                    break;
                default:
                    Console.WriteLine("No se ha seleccionado una opcion valida para algún Reporte");
                    break;
            }
        }

        private static string SeleccionReporte()
        {
            string Respond = "";

            Printer.PrintTitle("BIENVENIDO AL ASISTENTE DE REPORTES");
            Console.WriteLine("Seleccione una de las siguientes opciones: ");
            string[] Opciones = { "[1] Lista de Evaluaciones", "[2] Lista de Asignaturas", "[3] Lista de Evaluaciones por Asignatura", "[4]Lista Promedio de Alumnos por Asignatura" };
            mostrarMensaje(Opciones);
            Respond = Console.ReadLine();

            return Respond;
        }

        private static void mostrarMensaje(string[] opciones)
        {
            foreach (var opc in opciones)
            {
                Console.WriteLine(opc);
            }
        }

        private static void ImprimirEvaluaciones(Escuela escuela)
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var materia in curso.Asignaturas)
                {
                    foreach (var evaluation in materia.Evaluacion)
                    {
                        WriteLine($"{evaluation.Nombre} - {evaluation.Alumno.Nombre} - {evaluation.Asignatura} {evaluation.Nota}");
                    }
                }
            }
        }

        public static bool Apuntador(Curso CursoObjeto)
        {
            if (CursoObjeto.Nombre == "601")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            // Printer.DibujarLinea(90);
            // WriteLine("                           Cursos de la escuela                     ");
            // Printer.DibujarLinea(90);
            Printer.PrintTitle("Cursos de la escuela");
            if (Escuela.Cursos == null)
            {
                return;
            }
            else
            {
                foreach (var curso in Escuela.Cursos)
                {
                    Console.WriteLine($"Nombre:{curso.Nombre} - ID:{curso.UniqueId} - Jornada:{curso.Jornada}");
                }
                Printer.DibujarLinea(80);
            }
        }




        #region Impresion Cursos

        public static void ImprimirCursosDoWhile(Curso[] arregloCursos)
        {
            int Contador = 0;

            Console.Write("======Inicio de Imprimir Cursos por Do While====== \n");

            do
            {
                Console.WriteLine($"Nombre:{arregloCursos[Contador].Nombre} - {arregloCursos[Contador].UniqueId}");
                Contador++;
            } while (Contador < arregloCursos.Length);

            Console.Write("======Fin de Imprimir Cursos por Do While====== \n");
        }

        public static void ImprimirCursosFor(Curso[] arregloCursos)
        {
            Console.Write("======Inicio de Imprimir Cursos por For====== \n");
            for (int i = 0; i < arregloCursos.Length; i++)
            {
                Console.WriteLine($"Nombre:{arregloCursos[i].Nombre} - {arregloCursos[i].UniqueId}");
            }
            Console.Write("======Fin de Imprimir Cursos por For====== \n");

        }

        public static void ImprimirCursosForEach(Curso[] arraycursos)
        {
            Console.Write("======Inicio de Imprimir Cursos por ForEach====== \n");

            foreach (var curso in arraycursos)
            {
                Console.WriteLine($"Nombre:{curso.Nombre} - {curso.UniqueId}");
            }

            Console.Write("======Fin de Imprimir Cursos por ForEach====== \n");

        }

        private static void ImprimirCursosWhile(Curso[] arregloCursos)
        {
            int Contador = 0;

            Console.Write("======Inicio de Imprimir Cursos por While====== \n");

            while (Contador < arregloCursos.Length)
            {
                Console.WriteLine($"Nombre:{arregloCursos[Contador].Nombre} - {arregloCursos[Contador].UniqueId}");
                Contador += 1;
            }
            Console.Write("======Fin de Imprimir Cursos por While======\n");
        }
        #endregion

        private static void ImprimirDatosDiccionario()
        {

            Dictionary<int, string> Diccionario = new Dictionary<int, string>();

            Diccionario.Add(1, "Daniel Bernal");
            Diccionario.Add(2, "Santiago Espinosa");
            Diccionario.Add(3, "Leonidas Barriga");

            Printer.PrintTitle("Impresion de Datos Diccionario");

            foreach (var KeyValPar in Diccionario)
            {
                WriteLine($"Key: {KeyValPar.Key} Valor: {KeyValPar.Value}");
            }

            WriteLine(Diccionario[1]);

            Diccionario[4] = "Mario Yepes";
            WriteLine(Diccionario[4]);
        }



    }
}