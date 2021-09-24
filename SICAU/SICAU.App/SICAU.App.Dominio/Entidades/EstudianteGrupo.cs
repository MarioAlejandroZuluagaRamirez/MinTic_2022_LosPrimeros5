using System.Text.RegularExpressions;

namespace SICAU.App.Dominio.Entidades
{
    public class EstudianteGrupo
    {
        public int id {get;set;}
        public Estudiante estudiante {get;set;}
        public Grupo grupo {get;set;}
    }
}