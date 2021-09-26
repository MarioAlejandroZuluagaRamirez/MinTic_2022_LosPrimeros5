using System.Collections.Generic;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public interface IRepositorioEncuestaCovidSintoma
    {
        IEnumerable<EncuestaCovidSintoma> GetAllEncuestaCovidSintoma();
        EncuestaCovidSintoma AddEncuestaCovidSintoma(EncuestaCovidSintoma encuestaCovidSintomade);
        EncuestaCovidSintoma UpdateEncuestaCovidSintoma(EncuestaCovidSintoma encuestaCovidSintoma);
        void DeleteEncuestaCovidSintoma(int idEncuestaCovidSintoma);
        EncuestaCovidSintoma GetEncuestaCovidSintoma(int idEncuestaCovidSintoma);
    }
}