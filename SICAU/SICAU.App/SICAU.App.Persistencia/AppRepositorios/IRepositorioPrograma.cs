using System.Collections.Generic;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public interface IRepositorioPrograma
    {
        IEnumerable<Programa> GetAllPrograma();
        Programa AddPrograma(Programa programa);
        Programa UpdatePrograma(Programa programa);
        void DeletePrograma(int idPrograma);
        Programa GetPrograma(int idPrograma);
    }
}