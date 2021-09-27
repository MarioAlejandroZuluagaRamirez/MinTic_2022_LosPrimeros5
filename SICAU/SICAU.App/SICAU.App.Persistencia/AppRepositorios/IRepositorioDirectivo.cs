using System.Collections.Generic;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public interface IRepositorioDirectivo
    {
        IEnumerable<Directivo> GetAllDirectivo();
        IEnumerable<Directivo> GetByNames(string Criterio);
        Directivo AddDirectivo(Directivo directivo);
        Directivo UpdateDirectivo(Directivo directivo);
        void DeleteDirectivo(int idDirectivo);
        Directivo GetDirectivo(int idDirectivo);
    }
}