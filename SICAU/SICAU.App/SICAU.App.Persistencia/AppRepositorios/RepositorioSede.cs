using System.Collections.Generic;
using SICAU.App.Dominio;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SICAU.App.Persistencia
{
    public class RepositorioSede : IRepositorioSede
    {
        private readonly AppContext _appContext;
        IEnumerable<Sede> sedes;

        public RepositorioSede(AppContext appContext)
        {
            _appContext = appContext;
        }

        public RepositorioSede (IEnumerable<Sede> sedes)
        {
            this.sedes = sedes;
        }

        public Sede AsignaUniversidad(int idSede, int idUniversidad)
        {
            Sede sede = _appContext.sedes.FirstOrDefault(p => p.id == idSede);
            Universidad universidad = _appContext.universidades.FirstOrDefault(u => u.id == idUniversidad);
            sede.universidad = universidad;
            _appContext.SaveChanges();
            return sede;
        }

        Sede IRepositorioSede.AddSede(Sede sede)
        {
            var sedeAdicionado = _appContext.sedes.Add(sede);
            _appContext.SaveChanges();

            foreach (var entity in _appContext.ChangeTracker.Entries())
            {
                entity.State = EntityState.Detached;
            }

            return sedeAdicionado.Entity;
        }

        void IRepositorioSede.DeleteSede(int idSede)
        {
            var sedeEncontrado = _appContext.sedes.FirstOrDefault(p => p.id == idSede);
            if (sedeEncontrado == null)
                return;
            _appContext.sedes.Remove(sedeEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Sede> IRepositorioSede.GetAllSede()
        {
            return _appContext.sedes;
        }

        IEnumerable<Sede> IRepositorioSede.GetByNames(string criterio)
        {
            var sedes = _appContext.sedes.ToList();

            if (sedes != null
            && !string.IsNullOrEmpty(criterio))
            {
                sedes = _appContext.sedes.Where(p => p.sede.Contains(criterio) || p.ubicacion.Contains(criterio)).ToList();
            }

            foreach (Sede sede in sedes)
            {
                _appContext.Entry(sede).Reference(u => u.universidad).Load();
            }
            return sedes;
        }

        Sede IRepositorioSede.GetSede(int idSede)
        {
            Sede sede =  _appContext.sedes.FirstOrDefault(p => p.id == idSede);
            _appContext.Entry(sede).Reference(u => u.universidad).Load();
            return sede;
        }

        Sede IRepositorioSede.UpdateSede(Sede sede)
        {
            Sede sedeEncontrado = _appContext.sedes.FirstOrDefault(p => p.id == sede.id);
            if (sedeEncontrado != null)
            {
                sedeEncontrado.id = sede.id;
                sedeEncontrado.sede = sede.sede;
                sedeEncontrado.ubicacion = sede.ubicacion;
                sedeEncontrado.universidad = sede.universidad;
                _appContext.SaveChanges();

                foreach (var entity in _appContext.ChangeTracker.Entries())
                {
                    entity.State = EntityState.Detached;
                }
            }
            return sedeEncontrado;
        }

    }
}