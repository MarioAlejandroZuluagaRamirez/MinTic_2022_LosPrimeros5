using System.Collections.Generic;
using SICAU.App.Dominio;
using System.Linq;

namespace SICAU.App.Persistencia
{
    public class RepositorioFacultad : IRepositorioFacultad
    {
        private readonly AppContext _appContext;
        IEnumerable<Facultad> facultades;
        public RepositorioFacultad(AppContext appContext)
        {
            _appContext = appContext;
        }
        public RepositorioFacultad(IEnumerable<Facultad> facultades)
        {
            this.facultades = facultades;
        }

        Facultad IRepositorioFacultad.AddFacultad(Facultad facultad)
        {
            var facultadAdicionado = _appContext.facultades.Add(facultad);
            _appContext.SaveChanges();
            return facultadAdicionado.Entity;
        }

        void IRepositorioFacultad.DeleteFacultad(int idFacultad)
        {
            var facultadEncontrado = _appContext.facultades.FirstOrDefault(p => p.id == idFacultad);
            if (facultadEncontrado == null)
                return;
            _appContext.facultades.Remove(facultadEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Facultad> IRepositorioFacultad.GetAllFacultad()
        {
            return _appContext.facultades;
        }

        Facultad IRepositorioFacultad.GetFacultad(int idFacultad)
        {
            return _appContext.facultades.FirstOrDefault(p => p.id == idFacultad);
        }
        IEnumerable<Facultad> IRepositorioFacultad.GetByNames(string criterio)
        {
            var facultades = _appContext.facultades.ToList();

            if (facultades != null
            && !string.IsNullOrEmpty(criterio))
            {
                facultades = _appContext.facultades.Where(p => p.facultad.Contains(criterio)).ToList();
            }

            foreach (Facultad facultad in facultades)
            {
                _appContext.Entry(facultad).Reference(m => m.universidad).Load();
            }
            return facultades;
        }
        Facultad IRepositorioFacultad.UpdateFacultad(Facultad facultad)
        {
            var facultadEncontrado = _appContext.facultades.FirstOrDefault(p => p.id == facultad.id);
            if (facultadEncontrado != null)
            {
                facultadEncontrado.id = facultad.id;
                facultadEncontrado.facultad= facultad.facultad;
                 _appContext.SaveChanges();
            }
            return facultadEncontrado;
        }

    }
}
