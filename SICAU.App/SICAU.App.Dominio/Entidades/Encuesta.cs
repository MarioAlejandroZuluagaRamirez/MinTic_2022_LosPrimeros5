using System;
using System.Collections.Generic;

namespace SICAU.App.Dominio
{
    public class Encuesta
    {
        public DateTime fechaEncuesta {get;set;}
        public EstadoCovid estadoCovid {get;set;}
        public List<string> sintomas {get;set;}
        public DateTime fechaDiagnostico {get;set;}
        public Persona persona {get;set;}
    }
}