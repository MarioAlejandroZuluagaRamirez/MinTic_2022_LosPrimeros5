using System;
using System.Collections.Generic;

namespace SICAU.App.Dominio
{
    public class EncuestaCovid
    {
        public int id { get; set; }
        public DateTime fechaEncuesta { get; set; }
        public EstadoCovid estadoCovid { get; set; }
        public DateTime fechaDiagnostico { get; set; }
        public Persona persona { get; set; }
    }
}