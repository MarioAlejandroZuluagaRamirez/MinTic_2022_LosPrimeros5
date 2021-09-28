using System.Collections.Generic;
using SICAU.App.Dominio;
using System.Linq;

namespace SICAU.App.Persistencia
{
    public class RepositorioSalon : IRepositorioSalon
    {
        private readonly AppContext _appContext;
        IEnumerable<Salon> salones;

        public RepositorioSalon(AppContext appContext)
        {
            _appContext = appContext;
        }
        public RepositorioSalon(IEnumerable<Salon> salones)
        {
            this.salones = salones;
        }

        Salon IRepositorioSalon.AddSalon(Salon salon)
        {
            var salonAdicionado = _appContext.salones.Add(salon);
            _appContext.SaveChanges();
            return salonAdicionado.Entity;
        }

        void IRepositorioSalon.DeleteSalon(int idSalon)
        {
            var salonEncontrado = _appContext.salones.FirstOrDefault(p => p.id == idSalon);
            if (salonEncontrado == null)
                return;
            _appContext.salones.Remove(salonEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Salon> IRepositorioSalon.GetAllSalon()
        {
            return _appContext.salones;
        }

        IEnumerable<Salon> IRepositorioSalon.GetByNames(string criterio)
        {
            IEnumerable<Salon> salones = _appContext.salones;

            if (salones != null
            && !string.IsNullOrEmpty(criterio))
            {
                salones = _appContext.salones.Where(p => p.numero.Contains(criterio));
            }
            return salones;
        }

        Salon IRepositorioSalon.GetSalon(int idSalon)
        {
            return _appContext.salones.FirstOrDefault(p => p.id == idSalon);
        }

        Salon IRepositorioSalon.UpdateSalon(Salon salon)
        {
            var salonEncontrado = _appContext.salones.FirstOrDefault(p => p.id == salon.id);
            if (salonEncontrado != null)
            {
                salonEncontrado.id = salon.id;
                salonEncontrado.sede = salon.sede;
                salonEncontrado.numero = salon.numero;
                salonEncontrado.capacidad = salon.capacidad;
                _appContext.SaveChanges();
            }
            return salonEncontrado;
        }

    }
}