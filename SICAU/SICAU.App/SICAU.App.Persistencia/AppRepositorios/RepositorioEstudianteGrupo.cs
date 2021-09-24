using System.Collections.Generic;
using System.Linq;
using SICAU.App.Dominio.Entidades;

namespace SICAU.App.Persistencia
{
    public class RepositorioEstudianteGrupo : IRepositorioEstudianteGrupo
    {
        private readonly AppContext _appContext;

        public RepositorioEstudianteGrupo(AppContext appContext)
        {
            _appContext = appContext;
        }

        EstudianteGrupo IRepositorioEstudianteGrupo.AddEstudianteGrupo(EstudianteGrupo estudianteGrupo)
        {
            var estudianteGrupoAdicionado = _appContext.estudianteGrupos.Add(estudianteGrupo);
            _appContext.SaveChanges();
            return estudianteGrupoAdicionado.Entity;
        }

        void IRepositorioEstudianteGrupo.DeleteEstudianteGrupo(int idEstudianteGrupo)
        {
            var estudianteGrupoEncontrado = _appContext.estudianteGrupos.FirstOrDefault(p => p.id == idEstudianteGrupo);
            if (estudianteGrupoEncontrado == null)
                return;
            _appContext.estudianteGrupos.Remove(estudianteGrupoEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<EstudianteGrupo> GetAllEstudianteGrupo()
        {
            return _appContext.estudianteGrupos;
        }

        EstudianteGrupo IRepositorioEstudianteGrupo.GetEstudianteGrupo(int idEstudianteGrupo)
        {
            return _appContext.estudianteGrupos.FirstOrDefault(p => p.id == idEstudianteGrupo);
        }

        EstudianteGrupo IRepositorioEstudianteGrupo.UpdateEstudianteGrupo(EstudianteGrupo estudianteGrupo)
        {
            var estudianteGrupoEncontrado = _appContext.estudianteGrupos.FirstOrDefault(p => p.id == estudianteGrupo.id);
            if (estudianteGrupoEncontrado != null)
            {
                estudianteGrupoEncontrado.id = estudianteGrupo.id;
                estudianteGrupoEncontrado.estudiante = estudianteGrupo.estudiante;
                estudianteGrupoEncontrado.grupo = estudianteGrupo.grupo;
                _appContext.SaveChanges();
            }
            return estudianteGrupoEncontrado;
        }

    }
}