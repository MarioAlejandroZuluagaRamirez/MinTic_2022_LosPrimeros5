using System.Collections.Generic;
using SICAU.App.Dominio;
using System.Linq;

namespace SICAU.App.Persistencia
{
    public class RepositorioFacultad : IRepositorioFacultad
    {
        private readonly AppContext _appContext;

        public RepositorioFacultad(AppContext appContext)
        {
            _appContext = appContext;
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

