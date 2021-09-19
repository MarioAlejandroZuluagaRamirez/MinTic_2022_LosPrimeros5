using System.Collections.Generic;
using SICAU.App.Dominio;
using System.Linq;

namespace SICAU.App.Persistencia
{
    public class RepositorioEncuestaCovid : IRepositorioEncuestaCovid
    {
        private readonly AppContext _appContext;

        public RepositorioEncuestaCovid(AppContext appContext)
        {
            _appContext = appContext;
        }

        EncuestaCovid IRepositorioEncuestaCovid.AddEncuestaCovid(EncuestaCovid encuestaCovid)
        {
            var encuestaCovidAdicionado = _appContext.encuestaCovids.Add(encuestaCovid);
            _appContext.SaveChanges();
            return encuestaCovidAdicionado.Entity;
        }

        void IRepositorioEncuestaCovid.DeleteEncuestaCovid(int idEncuestaCovid)
        {
            var encuestaCovidEncontrado = _appContext.encuestaCovids.FirstOrDefault(p => p.id == idEncuestaCovid);
            if (encuestaCovidEncontrado == null)
                return;
            _appContext.encuestaCovids.Remove(encuestaCovidEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<EncuestaCovid> IRepositorioEncuestaCovid.GetAllEncuestaCovid()
        {
            return _appContext.encuestaCovids;
        }

        EncuestaCovid IRepositorioEncuestaCovid.GetEncuestaCovid(int idEncuestaCovid)
        {
            return _appContext.encuestaCovids.FirstOrDefault(p => p.id == idEncuestaCovid);
        }

        EncuestaCovid IRepositorioEncuestaCovid.UpdateEncuestaCovid(EncuestaCovid encuestaCovid)
        {
            var encuestaCovidEncontrado = _appContext.encuestaCovids.FirstOrDefault(p => p.id == encuestaCovid.id);
            if (encuestaCovidEncontrado != null)
            {
                encuestaCovidEncontrado.id = encuestaCovid.id;
                encuestaCovidEncontrado.fechaEncuesta = encuestaCovid.fechaEncuesta;
                encuestaCovidEncontrado.estadoCovid = encuestaCovid.estadoCovid;
                encuestaCovidEncontrado.fechaDiagnostico = encuestaCovid.fechaDiagnostico;
                encuestaCovidEncontrado.persona = encuestaCovid.persona;
                encuestaCovidEncontrado.sintoma = encuestaCovid.sintoma;
                 _appContext.SaveChanges();
            }
            return encuestaCovidEncontrado;
        }

    }
}