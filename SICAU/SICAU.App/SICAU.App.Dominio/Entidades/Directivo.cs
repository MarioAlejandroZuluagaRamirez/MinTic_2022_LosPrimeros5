using System.ComponentModel.DataAnnotations;

namespace SICAU.App.Dominio
{
    public class Directivo:Persona
    {
        public string unidad {get;set;}
        public Sede sede {get;set;}
    }
}