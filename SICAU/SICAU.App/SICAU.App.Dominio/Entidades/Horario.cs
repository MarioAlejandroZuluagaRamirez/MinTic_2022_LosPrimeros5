using System;

namespace SICAU.App.Dominio
{
    public class Horario
    {
        public int id {get;set;}
        public DateTime horaIngreso {get;set;}
        public int duracion {get;set;}
        public DiaSemana diaSemana {get;set;}
        public Salon salon {get;set;}
    }
}