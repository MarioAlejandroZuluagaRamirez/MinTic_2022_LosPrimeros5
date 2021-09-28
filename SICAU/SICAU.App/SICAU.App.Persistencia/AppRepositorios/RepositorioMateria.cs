using System.Collections.Generic;
using SICAU.App.Dominio;
using System.Linq;

namespace SICAU.App.Persistencia
{
    public class RepositorioMateria : IRepositorioMateria
    {
        private readonly AppContext _appContext;
        IEnumerable<Materia> materias;

        public RepositorioMateria(AppContext appContext)
        {
            _appContext = appContext;
        }
        public RepositorioMateria(IEnumerable<Materia> materias)
        {
            this.materias = materias;
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
        IEnumerable<Materia> IRepositorioMateria.GetByNames(string criterio)
        {
            IEnumerable<Materia> materias= _appContext.materias;

            if (materias!= null
            && !string.IsNullOrEmpty(criterio))
            {
                materias = _appContext.materias.Where(p => p.materia.Contains(criterio));
            }
            return materias;
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
                materiaEncontrado.programa = materia.programa;
                _appContext.SaveChanges();
            }
            return materiaEncontrado;
        }

    }
}

