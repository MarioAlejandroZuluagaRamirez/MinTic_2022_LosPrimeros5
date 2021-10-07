using System.Collections.Generic;
using System.Linq;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public class RepositorioPersonalAseo : IRepositorioPersonalAseo
    {
        private readonly AppContext _appContext;
        public IEnumerable<PersonalAseo> PersonalAseos;
        public RepositorioPersonalAseo(AppContext appContext)
        {
            _appContext = appContext;
        }
        public RepositorioPersonalAseo(IEnumerable<PersonalAseo> personalAseos)
        {
            PersonalAseos = personalAseos;
        }
        public IEnumerable<PersonalAseo> GetByNames(string criterio)
        {
            var personalAseos = _appContext.personalAseos.ToList();

            if (personalAseos != null
            && !string.IsNullOrEmpty(criterio))
            {
                personalAseos = _appContext.personalAseos.Where(p => p.nombre.Contains(criterio) || p.apellido.Contains(criterio)).ToList();
            }
            foreach (PersonalAseo personalAseo in personalAseos)
            {
                _appContext.Entry(personalAseo).Reference(s => s.sede).Load();
            }
            return personalAseos;
        }

        PersonalAseo IRepositorioPersonalAseo.AddPersonalAseo(PersonalAseo personalAseo)
        {
            var personalAseoAdicionado = _appContext.personalAseos.Add(personalAseo);
            _appContext.SaveChanges();
            return personalAseoAdicionado.Entity;
        }

        void IRepositorioPersonalAseo.DeletePersonalAseo(int idPersonalAseo)
        {
            var personalAseoEncontrado = _appContext.personalAseos.FirstOrDefault(p => p.id == idPersonalAseo);
            if (personalAseoEncontrado == null)
                return;
            _appContext.personalAseos.Remove(personalAseoEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<PersonalAseo> IRepositorioPersonalAseo.GetAllPersonalAseo()
        {
            return _appContext.personalAseos;
        }

        PersonalAseo IRepositorioPersonalAseo.GetPersonalAseo(int idPersonalAseo)
        {
            PersonalAseo personalAseo = _appContext.personalAseos.FirstOrDefault(p => p.id == idPersonalAseo);
            _appContext.Entry(personalAseo).Reference(s => s.sede).Load();
            return personalAseo;
        }

        PersonalAseo IRepositorioPersonalAseo.UpdatePersonalAseo(PersonalAseo personalAseo)
        {
            var personalAseoEncontrado = _appContext.personalAseos.FirstOrDefault(p => p.id == personalAseo.id);
            if (personalAseoEncontrado != null)
            {
                personalAseoEncontrado.id = personalAseo.id;
                personalAseoEncontrado.nombre = personalAseo.nombre;
                personalAseoEncontrado.apellido = personalAseo.apellido;
                personalAseoEncontrado.identificacion = personalAseo.identificacion;
                personalAseoEncontrado.fechaNacimiento = personalAseo.fechaNacimiento;
                personalAseoEncontrado.estadoCovid = personalAseo.estadoCovid;
                personalAseoEncontrado.turno = personalAseo.turno;
                personalAseoEncontrado.sede = personalAseo.sede;
                _appContext.SaveChanges();
            }
            return personalAseoEncontrado;
        }
    }
}

