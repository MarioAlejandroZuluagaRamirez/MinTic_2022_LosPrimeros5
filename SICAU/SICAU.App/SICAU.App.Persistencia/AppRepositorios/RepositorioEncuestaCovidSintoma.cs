using System.Collections.Generic;
using SICAU.App.Dominio;
using System.Linq;

namespace SICAU.App.Persistencia
{
    public class RepositorioEncuestaCovidSintoma : IRepositorioEncuestaCovidSintoma
    {
        private readonly AppContext _appContext;

        public RepositorioEncuestaCovidSintoma(AppContext appContext)
        {
            _appContext = appContext;
        }

        EncuestaCovidSintoma IRepositorioEncuestaCovidSintoma.AddEncuestaCovidSintoma(EncuestaCovidSintoma encuestaCovidSintoma)
        {
            var encuestaCovidSintomaAdicionado = _appContext.encuestaCovidSintomas.Add(encuestaCovidSintoma);
            _appContext.SaveChanges();
            return encuestaCovidSintomaAdicionado.Entity;
        }

        void IRepositorioEncuestaCovidSintoma.DeleteEncuestaCovidSintoma(int idEncuestaCovidSintoma)
        {
            var encuestaCovidSintomaEncontrado = _appContext.encuestaCovidSintomas.FirstOrDefault(p => p.id == idEncuestaCovidSintoma);
            if (encuestaCovidSintomaEncontrado == null)
                return;
            _appContext.encuestaCovidSintomas.Remove(encuestaCovidSintomaEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<EncuestaCovidSintoma> IRepositorioEncuestaCovidSintoma.GetAllEncuestaCovidSintoma()
        {
            return _appContext.encuestaCovidSintomas;
        }

        EncuestaCovidSintoma IRepositorioEncuestaCovidSintoma.GetEncuestaCovidSintoma(int idEncuestaCovidSintomaEncontrado)
        {
            return _appContext.encuestaCovidSintomas.FirstOrDefault(p => p.id == idEncuestaCovidSintomaEncontrado);
        }

        EncuestaCovidSintoma IRepositorioEncuestaCovidSintoma.UpdateEncuestaCovidSintoma(EncuestaCovidSintoma encuestaCovidSintoma)
        {
            var encuestaCovidSintomaEncontrado = _appContext.encuestaCovidSintomas.FirstOrDefault(p => p.id == encuestaCovidSintoma.id);
            if (encuestaCovidSintomaEncontrado != null)
            {
                encuestaCovidSintomaEncontrado.id = encuestaCovidSintoma.id;
                encuestaCovidSintomaEncontrado.encuestaCovid = encuestaCovidSintoma.encuestaCovid;
                encuestaCovidSintomaEncontrado.sintoma = encuestaCovidSintoma.sintoma;
                 _appContext.SaveChanges();
            }
            return encuestaCovidSintomaEncontrado;
        }
    }
}