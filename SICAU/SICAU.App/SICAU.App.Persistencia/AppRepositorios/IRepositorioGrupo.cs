using System.Collections.Generic;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public interface IRepositorioGrupo
    {
        IEnumerable<Grupo> GetAllGrupo();
        Grupo AddGrupo(Grupo grupo);
        Grupo UpdateGrupo(Grupo grupo);
        void DeleteGrupo(int idGrupo);
        Grupo GetGrupo(int idGrupo);
    }
}