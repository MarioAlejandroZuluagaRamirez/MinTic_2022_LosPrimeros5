using System.Collections.Generic;
using SICAU.App.Dominio;
using System.Linq;

namespace SICAU.App.Persistencia
{
    public class RepositorioDirectivo : IRepositorioDirectivo
    {
        private readonly AppContext _appContext;

        //Oscar
        IEnumerable<Directivo> directivos;

        public RepositorioDirectivo(AppContext appContext)
        {
            _appContext = appContext;
        }

        //Oscar
        public RepositorioDirectivo(IEnumerable<Directivo> directivos)
        {
            this.directivos = directivos;
        }

        Directivo IRepositorioDirectivo.AddDirectivo(Directivo directivo)
        {
            var directivoAdicionado = _appContext.directivos.Add(directivo);
            _appContext.SaveChanges();
            return directivoAdicionado.Entity;
        }

        void IRepositorioDirectivo.DeleteDirectivo(int idDirectivo)
        {
            var directivoEncontrado = _appContext.directivos.FirstOrDefault(p => p.id == idDirectivo);
            if (directivoEncontrado == null)
                return;
            _appContext.directivos.Remove(directivoEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Directivo> IRepositorioDirectivo.GetAllDirectivo()
        {
            return _appContext.directivos;
        }

        Directivo IRepositorioDirectivo.GetDirectivo(int idDirectivo)
        {
            return _appContext.directivos.FirstOrDefault(p => p.id == idDirectivo);
        }

        Directivo IRepositorioDirectivo.UpdateDirectivo(Directivo directivo)
        {
            var directivoEncontrado = _appContext.directivos.FirstOrDefault(p => p.id == directivo.id);
            if (directivoEncontrado != null)
            {
                directivoEncontrado.id = directivo.id;
                directivoEncontrado.nombre = directivo.nombre;
                directivoEncontrado.apellido = directivo.apellido;
                directivoEncontrado.identificacion = directivo.identificacion;
                directivoEncontrado.fechaNacimiento = directivo.fechaNacimiento;
                directivoEncontrado.estadoCovid = directivo.estadoCovid;
                directivoEncontrado.unidad = directivo.unidad;
                directivoEncontrado.sede = directivo.sede;
                 _appContext.SaveChanges();
            }
            return directivoEncontrado;
        }

    }
}

