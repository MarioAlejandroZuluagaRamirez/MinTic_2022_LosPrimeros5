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