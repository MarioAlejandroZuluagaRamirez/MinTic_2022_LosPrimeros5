using System.Collections.Generic;

namespace SICAU.App.Dominio
{
    public class Sede
    {
        public int id {get;set;}
        public string sede {get;set;}
        public string ubicacion {get;set;}
        public Universidad universidad {get;set;}
    }
}