using System.Collections.Generic;
using System.Linq;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public class RepositorioUniversidad : IRepositorioUniversidad
    {
        private readonly AppContext _appContext;
        // public readonly IEnumerable<Universidad> universidades;

        public RepositorioUniversidad(AppContext appContext)
        {
            _appContext = appContext;
        }

        // public RepositorioUniversidad(IEnumerable<Universidad> universidades)
        // {
        //     this.universidades = universidades;
        // }
        Universidad IRepositorioUniversidad.AddUniversidad(Universidad universidad)
        {
            var universidadAdicionado = _appContext.universidades.Add(universidad);
            _appContext.SaveChanges();
            return universidadAdicionado.Entity;
        }

        void IRepositorioUniversidad.DeleteUniversidad(int idUniversidad)
        {
            var universidadEncontrado = _appContext.universidades.First(p => p.id == idUniversidad);
            if (universidadEncontrado == null)
                return;
            _appContext.universidades.Remove(universidadEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Universidad> IRepositorioUniversidad.GetAllUniversidad()
        {
            return _appContext.universidades;
        }

        IEnumerable<Universidad> IRepositorioUniversidad.GetByNames(string criterio)
        {
            IEnumerable<Universidad> universidades = _appContext.universidades;

            if (universidades != null
            && !string.IsNullOrEmpty(criterio))
            {
                universidades = _appContext.universidades.Where(p => p.universidad.Contains(criterio));
            }
            return universidades;
        }

        Universidad IRepositorioUniversidad.GetUniversidad(int idUniversidad)
        {
            return _appContext.universidades.First(p => p.id == idUniversidad);
        }

        Universidad IRepositorioUniversidad.UpdateUniversidad(Universidad universidad)
        {
            var universidadEncontrado = _appContext.universidades.First(p => p.id == universidad.id);
            if (universidadEncontrado != null)
            {
                universidadEncontrado.id = universidad.id;
                universidadEncontrado.universidad = universidad.universidad;
                _appContext.SaveChanges();
            }
            return universidadEncontrado;
        }
        Universidad IRepositorioUniversidad.AdicionarSede(int idUniversidad, Sede sede)
        {
            var universidadEncontrado = _appContext.universidades.First(p => p.id == idUniversidad);
            Sede nuevaSede = new ();
            nuevaSede = sede;
            (universidadEncontrado.sedes ??= new List<Sede>()).Add(sede);
            _appContext.Update(universidadEncontrado);
            _appContext.SaveChanges();
            return universidadEncontrado;
        }
    }
}