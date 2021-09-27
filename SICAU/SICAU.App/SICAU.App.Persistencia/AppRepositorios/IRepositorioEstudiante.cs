using System.Collections.Generic;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public interface IRepositorioEstudiante
    {
        IEnumerable<Estudiante> GetAllEstudiante();
        IEnumerable<Estudiante> GetByNames(string criterio);
        Estudiante AddEstudiante(Estudiante estudiante);
        Estudiante UpdateEstudiante(Estudiante estudiante);
        void DeleteEstudiante(int idEstudiante);
        Estudiante GetEstudiante(int idEstudiante);
    }
}