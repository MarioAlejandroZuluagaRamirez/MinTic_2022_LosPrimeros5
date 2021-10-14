using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public class RepositorioFacultad : IRepositorioFacultad
    {
        private readonly AppContext _appContext;
        public IEnumerable<Facultad> facultades;
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
            return _appContext.facultades.Include(s => s.sede).ToList();
        }

        Facultad IRepositorioFacultad.GetFacultad(int idFacultad)
        {
            return _appContext.facultades.Include(s => s.sede).First(p => p.id == idFacultad);
        }
        IEnumerable<Facultad> IRepositorioFacultad.GetByNames(string criterio)
        {
            var facultades = _appContext.facultades.Include(s => s.sede).ToList();

            if (facultades != null
            && !string.IsNullOrEmpty(criterio))
            {
                facultades = _appContext.facultades.Where(p => p.facultad.Contains(criterio)).ToList();
            }

            //foreach (Facultad facultad in facultades)
            //{
            //    _appContext.Entry(facultad).Reference(s => s.sede).Load();
            //}
            return facultades;
        }
        Facultad IRepositorioFacultad.UpdateFacultad(Facultad facultad)
        {
            var facultadEncontrado = _appContext.facultades.First(p => p.id == facultad.id);
            if (facultadEncontrado != null)
            {
                facultadEncontrado.id = facultad.id;
                facultadEncontrado.facultad= facultad.facultad;
                 _appContext.SaveChanges();
            }
            return facultadEncontrado;
        }
        public Facultad AsignaFacultad(int idFacultad, int idSede)
        {
            Facultad facultad = _appContext.facultades.First(f => f.id == idFacultad);
            Sede sede = _appContext.sedes.First(s => s.id == idSede);
            facultad.sede = sede;
            _appContext.SaveChanges();
            return facultad;
        }
    }
}
