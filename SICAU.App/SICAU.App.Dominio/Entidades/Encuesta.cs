using System;
using System.Collections.Generic;

namespace SICAU.App.Dominio
{
    public class Encuesta
    {
        public int id { get; set; }
        public DateTime fechaEncuesta { get; set; }
        public EstadoCovid estadoCovid { get; set; }
        public List<Sintoma> sintoma { get; set; }
        public DateTime fechaDiagnostico { get; set; }
        public Persona persona { get; set; }
    }
}