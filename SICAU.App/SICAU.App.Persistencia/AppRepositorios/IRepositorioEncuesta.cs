using System.Collections.Generic;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public interface IRepositorioEncuesta
    {
        IEnumerable<Encuesta> GetAllEncuesta();
        Encuesta AddEncuesta(Encuesta encuesta);
        Encuesta UpdateEncuesta(Encuesta encuesta);
        void DeleteEncuesta(int idEncuesta);
        Encuesta GetEncuesta(int idEncuesta);
    }
}