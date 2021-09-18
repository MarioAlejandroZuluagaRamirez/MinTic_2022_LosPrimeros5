using System;

namespace SICAU.App.Dominio
{
    public class Persona
    {
        public int id {get;set;}
        public string nombre {get;set;}
        public string apellido {get;set;}
        public string identificacion {get;set;}
        public DateTime fechaNacimiento {get;set;}
        public EstadoCovid estadoCovid {get;set;}
    }
}