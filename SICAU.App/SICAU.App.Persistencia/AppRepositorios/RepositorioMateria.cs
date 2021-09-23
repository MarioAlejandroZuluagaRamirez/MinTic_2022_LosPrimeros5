using System.Collections.Generic;
using SICAU.App.Dominio;
using System.Linq;

namespace SICAU.App.Persistencia
{
    public class RepositorioMateria : IRepositorioMateria
    {
        private readonly AppContext _appContext;

        public RepositorioMateria(AppContext appContext)
        {
            _appContext = appContext;
        }
        Materia IRepositorioMateria.AddMateria(Materia materia)
        {
            var materiaAdicionado = _appContext.materias.Add(materia);
            _appContext.SaveChanges();
            return materiaAdicionado.Entity;
        }

        void IRepositorioMateria.DeleteMateria(int idMateria)
        {
            var materiaEncontrado = _appContext.materias.FirstOrDefault(p => p.id == idMateria);
            if (materiaEncontrado == null)
                return;
            _appContext.materias.Remove(materiaEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Materia> IRepositorioMateria.GetAllMateria()
        {
            return _appContext.materias;
        }

        Materia IRepositorioMateria.GetMateria(int idMateria)
        {
            return _appContext.materias.FirstOrDefault(p => p.id == idMateria);
        }

        Materia IRepositorioMateria.UpdateMateria(Materia materia)
        {
            var materiaEncontrado = _appContext.materias.FirstOrDefault(p => p.id == materia.id);
            if (materiaEncontrado != null)
            {
                materiaEncontrado.id = materia.id;
                materiaEncontrado.materia = materia.materia;
                 _appContext.SaveChanges();
            }
            return materiaEncontrado;
        }
    }
}