using System.Collections.Generic;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public interface IRepositorioProfesor
    {
        IEnumerable<Profesor> GetAllProfesor();
        IEnumerable<Profesor> GetByNames(string Criterio);
        Profesor AddProfesor(Profesor profesor);
        Profesor UpdateProfesor(Profesor profesor);
        void DeleteProfesor(int idProfesor);
        Profesor GetProfesor(int idProfesor);
    }
}