using System.Collections.Generic;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public interface IRepositorioDirectivo
    {
        IEnumerable<Directivo> GetAllDirectivo();
        Directivo AddDirectivo(Directivo directivo);
        Directivo UpdateDirectivo(Directivo directivo);
        void DeleteDirectivo(int idDirectivo);
        Directivo GetDirectivo(int idDirectivo);
    }
}