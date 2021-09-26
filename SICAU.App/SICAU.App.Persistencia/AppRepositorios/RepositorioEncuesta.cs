using System.Collections.Generic;
using SICAU.App.Dominio;
using System.Linq;

namespace SICAU.App.Persistencia
{
    public class RepositorioEncuesta : IRepositorioEncuesta
    {
        private readonly AppContext _appContext;

        public RepositorioEncuesta(AppContext appContext)
        {
            _appContext = appContext;
        }

        Encuesta IRepositorioEncuesta.AddEncuesta(Encuesta encuesta)
        {
            var encuestaAdicionado = _appContext.encuestas.Add(encuesta);
            _appContext.SaveChanges();
            return encuestaAdicionado.Entity;
        }

        void IRepositorioEncuesta.DeleteEncuesta(int idEncuesta)
        {
            var encuestaEncontrado = _appContext.encuestas.FirstOrDefault(p => p.id == idEncuesta);
            if (encuestaEncontrado == null)
                return;
            _appContext.encuestas.Remove(encuestaEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Encuesta> IRepositorioEncuesta.GetAllEncuesta()
        {
            return _appContext.encuestas;
        }

        Encuesta IRepositorioEncuesta.GetEncuesta(int idEncuesta)
        {
            return _appContext.encuestas.FirstOrDefault(p => p.id == idEncuesta);
        }

        Encuesta IRepositorioEncuesta.UpdateEncuesta(Encuesta encuesta)
        {
            var encuestaEncontrado = _appContext.encuestas.FirstOrDefault(p => p.id == encuesta.id);
            if (encuestaEncontrado != null)
            {
                encuestaEncontrado.fechaEncuesta = encuesta.fechaEncuesta;
                encuestaEncontrado.estadoCovid = encuesta.estadoCovid;
                encuestaEncontrado.sintoma = encuesta.sintoma;
                encuestaEncontrado.fechaDiagnostico = encuesta.fechaDiagnostico;
                encuestaEncontrado.persona = encuesta.persona;
                 _appContext.SaveChanges();
            }
            return encuestaEncontrado;
        }
    }
}