using System.Collections.Generic;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public interface IRepositorioFacultad
    {
        IEnumerable<Facultad> GetAllFacultad();
        Facultad AddFacultad(Facultad facultad);
        Facultad UpdateFacultad(Facultad facultad);
        void DeleteFacultad(int idFacultad);
        Facultad GetFacultad(int idFacultad);
    }
}