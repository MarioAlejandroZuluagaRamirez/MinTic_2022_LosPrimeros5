using System.Collections.Generic;
using SICAU.App.Dominio;
using System.Linq;

namespace SICAU.App.Persistencia
{
    public class RepositorioUniversidad : IRepositorioUniversidad
    {
        private readonly AppContext _appContext;

        public RepositorioUniversidad(AppContext appContext)
        {
            _appContext = appContext;
        }

        Universidad IRepositorioUniversidad.AddUniversidad(Universidad universidad)
        {
            var universidadAdicionado = _appContext.universidades.Add(universidad);
            _appContext.SaveChanges();
            return universidadAdicionado.Entity;
        }

        void IRepositorioUniversidad.DeleteUniversidad(int idUniversidad)
        {
            var universidadEncontrado = _appContext.universidades.FirstOrDefault(p => p.id == idUniversidad);
            if (universidadEncontrado == null)
                return;
            _appContext.universidades.Remove(universidadEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Universidad> IRepositorioUniversidad.GetAllUniversidad()
        {
            return _appContext.universidades;
        }

        Universidad IRepositorioUniversidad.GetUniversidad(int idUniversidad)
        {
            return _appContext.universidades.FirstOrDefault(p => p.id == idUniversidad);
        }

        Universidad IRepositorioUniversidad.UpdateUniversidad(Universidad universidad)
        {
            var universidadEncontrado = _appContext.universidades.FirstOrDefault(p => p.id == universidad.id);
            if (universidadEncontrado != null)
            {
                universidadEncontrado.id = universidad.id;
                universidadEncontrado.universidad = universidad.universidad;
                _appContext.SaveChanges();
            }
            return universidadEncontrado;
        }

    }
}