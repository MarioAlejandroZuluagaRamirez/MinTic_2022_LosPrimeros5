using System.Collections.Generic;
using SICAU.App.Dominio;
using System.Linq;

namespace SICAU.App.Persistencia
{
    public class RepositorioPersonalAseo : IRepositorioPersonalAseo
    {
        private readonly AppContext _appContext;

        public RepositorioPersonalAseo(AppContext appContext)
        {
            _appContext = appContext;
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
            return _appContext.personalAseos.FirstOrDefault(p => p.id == idPersonalAseo);
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

