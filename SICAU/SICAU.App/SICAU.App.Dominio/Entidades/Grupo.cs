using System.Collections.Generic;

namespace SICAU.App.Dominio
{
    public class Grupo
    {
        public int id {get;set;}
        public string numeroGrupo {get;set;}
        public Profesor profesor {get;set;}
        public Materia materia {get;set;}
        public Horario horario {get;set;}
    }
}