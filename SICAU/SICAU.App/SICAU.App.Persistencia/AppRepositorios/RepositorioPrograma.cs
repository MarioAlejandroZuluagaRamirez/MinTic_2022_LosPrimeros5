using System.Collections.Generic;
using SICAU.App.Dominio;
using System.Linq;

namespace SICAU.App.Persistencia
{
    public class RepositorioPrograma : IRepositorioPrograma
    {
        private readonly AppContext _appContext;

        public RepositorioPrograma(AppContext appContext)
        {
            _appContext = appContext;
        }

        Programa IRepositorioPrograma.AddPrograma(Programa programa)
        {
            var programaAdicionado = _appContext.programas.Add(programa);
            _appContext.SaveChanges();
            return programaAdicionado.Entity;
        }

        void IRepositorioPrograma.DeletePrograma(int idPrograma)
        {
            var programaEncontrado = _appContext.programas.FirstOrDefault(p => p.id == idPrograma);
            if (programaEncontrado == null)
                return;
            _appContext.programas.Remove(programaEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Programa> IRepositorioPrograma.GetAllPrograma()
        {
            return _appContext.programas;
        }

        Programa IRepositorioPrograma.GetPrograma(int idPrograma)
        {
            return _appContext.programas.FirstOrDefault(p => p.id == idPrograma);
        }

        Programa IRepositorioPrograma.UpdatePrograma(Programa programa)
        {
            var programaEncontrado = _appContext.programas.FirstOrDefault(p => p.id == programa.id);
            if (programaEncontrado != null)
            {
                programaEncontrado.id = programa.id;
                programaEncontrado.facultad = programa.facultad;
                programaEncontrado.programa = programa.programa;
                _appContext.SaveChanges();
            }
            return programaEncontrado;
        }

    }
}

