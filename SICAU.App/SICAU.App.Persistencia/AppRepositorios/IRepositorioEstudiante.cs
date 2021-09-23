using System.Collections.Generic;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public interface IRepositorioEstudiante
    {
        IEnumerable<Estudiante> GetAllEstudiante();
        Estudiante AddEstudiante(Estudiante estudiante);
        Estudiante UpdateEstudiante(Estudiante estudiante);
        void DeleteEstudiante(int idestudiante);
        Estudiante GetEstudiante(int idestudiante);
    }
}