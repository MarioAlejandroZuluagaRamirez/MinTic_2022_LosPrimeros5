using System;
using SICAU.App.Dominio;
using SICAU.App.Persistencia;

namespace SICAU.App.Consola
{
    class Program
    {
        private static IRepositorioDirectivo _repoDirectivo = new RepositorioDirectivo(new Persistencia.AppContext());
        private static IRepositorioEncuestaCovid _repoEncuestaCovid = new RepositorioEncuestaCovid (new Persistencia.AppContext());
        private static IRepositorioEstudiante _repoEstudiante = new RepositorioEstudiante(new Persistencia.AppContext());
        private static IRepositorioFacultad _repoFacultad = new RepositorioFacultad(new Persistencia.AppContext());
        private static IRepositorioGrupo _repoGrupo = new RepositorioGrupo(new Persistencia.AppContext());
        private static IRepositorioHorario _repoHorario = new RepositorioHorario (new Persistencia.AppContext());
        private static IRepositorioMateria _repoMateria = new RepositorioMateria (new Persistencia.AppContext());
        private static IRepositorioPersona _repoPersona = new RepositorioPersona(new Persistencia.AppContext());
        private static IRepositorioPersonalAseo _repoPersonalAseo = new RepositorioPersonalAseo(new Persistencia.AppContext());
        private static IRepositorioProfesor _repoProfesor = new RepositorioProfesor(new Persistencia.AppContext());
        private static IRepositorioPrograma _repoPrograma = new RepositorioPrograma(new Persistencia.AppContext());
        private static IRepositorioSalon _repoSalon = new RepositorioSalon(new Persistencia.AppContext());
        private static IRepositorioSede _repoSede = new RepositorioSede(new Persistencia.AppContext());
        private static IRepositorioSintoma _repoSintoma = new RepositorioSintoma(new Persistencia.AppContext());
        private static IRepositorioUniversidad _repoUniversidad = new RepositorioUniversidad(new Persistencia.AppContext());
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
