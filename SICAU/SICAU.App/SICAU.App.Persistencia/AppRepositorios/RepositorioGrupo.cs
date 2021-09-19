using System.Collections.Generic;
using SICAU.App.Dominio;
using System.Linq;

namespace SICAU.App.Persistencia
{
    public class RepositorioGrupo : IRepositorioGrupo
    {
        private readonly AppContext _appContext;

        public RepositorioGrupo(AppContext appContext)
        {
            _appContext = appContext;
        }

        Grupo IRepositorioGrupo.AddGrupo(Grupo grupo)
        {
            var grupoAdicionado = _appContext.grupos.Add(grupo);
            _appContext.SaveChanges();
            return grupoAdicionado.Entity;
        }

        void IRepositorioGrupo.DeleteGrupo(int idGrupo)
        {
            var grupoEncontrado = _appContext.grupos.FirstOrDefault(p => p.id == idGrupo);
            if (grupoEncontrado == null)
                return;
            _appContext.grupos.Remove(grupoEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Grupo> IRepositorioGrupo.GetAllGrupo()
        {
            return _appContext.grupos;
        }

        Grupo IRepositorioGrupo.GetGrupo(int idGrupo)
        {
            return _appContext.grupos.FirstOrDefault(p => p.id == idGrupo);
        }

        Grupo IRepositorioGrupo.UpdateGrupo(Grupo grupo)
        {
            var grupoEncontrado = _appContext.grupos.FirstOrDefault(p => p.id == grupo.id);
            if (grupoEncontrado != null)
            {
                grupoEncontrado.id = grupo.id;
                grupoEncontrado.numeroGrupo = grupo.numeroGrupo;
                grupoEncontrado.profesor = grupo.profesor;
                grupoEncontrado.materia = grupo.materia;
                grupoEncontrado.horario = grupo.horario;
                grupoEncontrado.estudiantes = grupo.estudiantes;
                _appContext.SaveChanges();
            }
            return grupoEncontrado;
        }

    }
}