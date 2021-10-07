using System.Collections.Generic;
using System.Linq;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public class RepositorioSintoma : IRepositorioSintoma
    {
        private readonly AppContext _appContext;
        public IEnumerable<Sintoma> sintomas;
        public RepositorioSintoma(AppContext appContext)
        {
            _appContext = appContext;
        }
        public RepositorioSintoma(IEnumerable<Sintoma> sintomas)
        {
            this.sintomas = sintomas;
        }

        Sintoma IRepositorioSintoma.AddSintoma(Sintoma sintoma)
        {
            var sintomaAdicionado = _appContext.sintomas.Add(sintoma);
            _appContext.SaveChanges();
            return sintomaAdicionado.Entity;
        }

        void IRepositorioSintoma.DeleteSintoma(int idSintoma)
        {
            var sintomaEncontrado = _appContext.sintomas.FirstOrDefault(p => p.id == idSintoma);
            if (sintomaEncontrado == null)
                return;
            _appContext.sintomas.Remove(sintomaEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Sintoma> IRepositorioSintoma.GetAllSintoma()
        {
            return _appContext.sintomas;
        }

        Sintoma IRepositorioSintoma.GetSintoma(int idSintoma)
        {
            return _appContext.sintomas.FirstOrDefault(p => p.id == idSintoma);
        }
        IEnumerable<Sintoma> IRepositorioSintoma.GetByNames(string criterio)
        {
            var sintomas = _appContext.sintomas.ToList();

            if (sintomas != null 
            && !string.IsNullOrEmpty(criterio))
            {
                sintomas = _appContext.sintomas.Where(p => p.sintoma.Contains(criterio)).ToList();
            }
            return sintomas;
        }

        Sintoma IRepositorioSintoma.UpdateSintoma(Sintoma sintoma)
        {
            var sintomaEncontrado = _appContext.sintomas.FirstOrDefault(p => p.id == sintoma.id);
            if (sintomaEncontrado != null)
            {
                sintomaEncontrado.id = sintoma.id;
                sintomaEncontrado.sintoma = sintoma.sintoma;
                _appContext.SaveChanges();
            }
            return sintomaEncontrado;
        }

    }
}