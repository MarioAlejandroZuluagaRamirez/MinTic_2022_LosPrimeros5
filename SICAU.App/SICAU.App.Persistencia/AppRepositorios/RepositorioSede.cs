using System.Collections.Generic;
using SICAU.App.Dominio;
using System.Linq;

namespace SICAU.App.Persistencia
{
    public class RepositorioSede : IRepositorioSede
    {
        private readonly AppContext _appContext;

        public RepositorioSede(AppContext appContext)
        {
            _appContext = appContext;
        }

        Sede IRepositorioSede.AddSede(Sede sede)
        {
            var SedeAdicionado = _appContext.sedes.Add(sede);
            _appContext.SaveChanges();
            return SedeAdicionado.Entity;
        }

        void IRepositorioSede.DeleteSede(int idSede)
        {
            var SedeEncontrado = _appContext.sedes.FirstOrDefault(s => s.id == idSede);
            if (SedeEncontrado == null)
                return;
            _appContext.sedes.Remove(SedeEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Sede> IRepositorioSede.GetAllSede()
        {
            return _appContext.sedes;
        }

        Sede IRepositorioSede.GetSede(int idSede)
        {
            return _appContext.sedes.FirstOrDefault(s => s.id == idSede);
        }

        Sede IRepositorioSede.UpdateSede(Sede sede)
        {
            var SedeEncontrado = _appContext.sedes.FirstOrDefault(s => s.id == sede.id);
            if (SedeEncontrado != null)
            {
                SedeEncontrado.id = sede.id;
                SedeEncontrado.nombre = sede.nombre;
                SedeEncontrado.descripcion = sede.descripcion;
                SedeEncontrado.ubicacion = sede.ubicacion;
                
                 _appContext.SaveChanges();
            }
            return SedeEncontrado;
        }
    }
}