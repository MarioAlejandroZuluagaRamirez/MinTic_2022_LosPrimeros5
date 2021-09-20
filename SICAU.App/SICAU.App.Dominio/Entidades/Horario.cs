using System;

namespace SICAU.App.Dominio
{
    public class Horario
    {
        public int id { get; set; }
        public DateTime horaIngreso { get; set; }
        public Materia materia { get; set; }
        public DiaSemana diasemana { get; set; }
        public int duracion { get; set; }
        public Persona persona { get; set; }
        public Salon salon { get; set; }
    }
}