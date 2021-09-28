using System.Collections.Generic;

namespace SICAU.App.Dominio
{
    public class Salon 
    {
        public int id { get; set; }
        public string numero { get; set; }
        public int capacidad { get; set; }
        public Sede sede { get; set; }
    }
}