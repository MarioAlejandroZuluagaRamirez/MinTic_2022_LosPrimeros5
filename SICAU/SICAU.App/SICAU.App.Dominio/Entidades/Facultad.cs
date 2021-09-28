namespace SICAU.App.Dominio
{
    public class Facultad
    {
        public int id {get;set;}
        public string facultad {get;set;}
        public Universidad universidad { get; set; }
    }
}