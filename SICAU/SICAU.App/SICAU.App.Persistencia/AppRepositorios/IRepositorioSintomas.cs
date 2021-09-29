using System.Collections.Generic;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public interface IRepositorioSintoma
    {
        IEnumerable<Sintoma> GetAllSintoma();
        IEnumerable<Sintoma> GetByNames(string criterio);
        Sintoma AddSintoma(Sintoma sintoma);
        Sintoma UpdateSintoma(Sintoma sintoma);
        void DeleteSintoma(int idSintoma);
        Sintoma GetSintoma(int idSintoma);
    }
}