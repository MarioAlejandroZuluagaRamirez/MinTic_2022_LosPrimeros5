using System.Collections.Generic;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public interface IRepositorioUniversidad
    {
        IEnumerable<Universidad> GetAllUniversidad();
        IEnumerable<Universidad> GetByNames(string criterio);
        Universidad AddUniversidad(Universidad universidad);
        Universidad UpdateUniversidad(Universidad universidad);
        void DeleteUniversidad(int idUniversidad);
        Universidad GetUniversidad(int idUniversidad);
    }
}