using System.Collections.Generic;
using SICAU.App.Dominio;
using System.Linq;

namespace SICAU.App.Persistencia
{
    public class RepositorioSintoma : IRepositorioSintoma
    {
        private readonly AppContext _appContext;

        public RepositorioSintoma(AppContext appContext)
        {
            _appContext = appContext;
        }

        Sintoma IRepositorioSintoma.AddSintoma(Sintoma sintoma)
        {
            var sintomaAdicionado = _appContext.sintomas.Add(sintoma);
            _appContext.SaveChanges();
            return sintomaAdicionado.Entity;
        }

        void IRepositorioSintoma.DeleteSintoma(int idSintoma)
        {
            var sintomaAdicionado = _appContext.sintomas.FirstOrDefault(p => p.id == idSintoma);
            if (sintomaAdicionado == null)
                return;
            _appContext.sintomas.Remove(sintomaAdicionado);
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

        Sintoma IRepositorioSintoma.UpdateSintoma(Sintoma sintoma)
        {
            var sintomaAdicionado = _appContext.sintomas.FirstOrDefault(p => p.id == sintoma.id);
            if (sintomaAdicionado != null)
            {
                sintomaAdicionado.sintoma = sintoma.sintoma;
                _appContext.SaveChanges();
            }
            return sintomaAdicionado;
        }
    }
}