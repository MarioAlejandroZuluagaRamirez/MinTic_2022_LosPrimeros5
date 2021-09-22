using System.Collections.Generic;
using SICAU.App.Dominio;
using System.Linq;

namespace SICAU.App.Persistencia
{
    public class RepositorioSalon : IRepositorioSalon
    {
        private readonly AppContext _appContext;

        public RepositorioSalon(AppContext appContext)
        {
            _appContext = appContext;
        }

        Salon IRepositorioSalon.AddSalon(Salon salon)
        {
            var SalonAdicionado = _appContext.salones.Add(salon);
            _appContext.SaveChanges();
            return SalonAdicionado.Entity;
        }

        void IRepositorioSalon.DeleteSalon(int idSalon)
        {
            var SalonEncontrado = _appContext.salones.FirstOrDefault(s => s.id == idSalon);
            if (SalonEncontrado == null)
                return;
            _appContext.salones.Remove(SalonEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Salon> IRepositorioSalon.GetAllSalon()
        {
            return _appContext.salones;
        }

        Salon IRepositorioSalon.GetSalon(int idSalon)
        {
            return _appContext.salones.FirstOrDefault(s => s.id == idSalon);
        }

        Salon IRepositorioSalon.UpdateSalon(Salon salon)
        {
            var SalonEncontrado = _appContext.salones.FirstOrDefault(s => s.id == salon.id);
            if (SalonEncontrado != null)
            {
                SalonEncontrado.id = salon.id;
                SalonEncontrado.numero = salon.numero;
                SalonEncontrado.capacidad = salon.capacidad;                
                 _appContext.SaveChanges();
            }
            return SalonEncontrado;
        }
    }
}