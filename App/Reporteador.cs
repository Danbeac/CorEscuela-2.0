using System;
using System.Linq;
using System.Collections.Generic;
using CorEscuela.Entidades;

namespace CorEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;

        public Reporteador(Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObjEsc)
        {
            if (dicObjEsc == null)
            {
                throw new ArgumentException(nameof(dicObjEsc));
            }
            {
                _diccionario = dicObjEsc;
            }
        }

        public IEnumerable<Evaluación> GetListaEvaluaciones()
        {

            if (_diccionario.TryGetValue(LlavesDiccionario.Evaluación,
                                        out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluación>();
            }
            {
                return new List<Evaluación>();
            }
        }

        
        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluación> ListEvaluaciones)
        {
            ListEvaluaciones = GetListaEvaluaciones();

            return (from Evaluación Eval in ListEvaluaciones
                select Eval.Asignatura.Nombre).Distinct();
        }

        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out var dummy);
        }

        public Dictionary<string,IEnumerable<Evaluación>> GetEvalXAsig()
        {   
            var DiccRta = new Dictionary<string,IEnumerable<Evaluación>>();

            var ListAsig = GetListaAsignaturas(out var listEvaluaciones);

            foreach (var asig in ListAsig)
            {
                var EvalxAsig = from eval in listEvaluaciones
                                where eval.Asignatura.Nombre == asig
                                select eval;

                DiccRta.Add(asig,EvalxAsig);
            }

            return DiccRta;
        }
    }
}