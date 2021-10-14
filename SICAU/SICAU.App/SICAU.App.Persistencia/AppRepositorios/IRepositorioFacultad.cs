using System.Collections.Generic;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public interface IRepositorioFacultad
    {
        IEnumerable<Facultad> GetAllFacultad();
        IEnumerable<Facultad> GetByNames(string criterio);
        Facultad AddFacultad(Facultad facultad);
        Facultad UpdateFacultad(Facultad facultad);
        void DeleteFacultad(int idFacultad);
        Facultad GetFacultad(int idFacultad);
        Facultad AsignaFacultad(int idFacultad, int idSede);
    }
}