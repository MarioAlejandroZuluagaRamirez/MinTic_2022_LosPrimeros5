using System.Collections.Generic;
using SICAU.App.Dominio;
using System.Linq;

namespace SICAU.App.Persistencia
{
    public class RepositorioPersona : IRepositorioPersona
    {
        private readonly AppContext _appContext;

        public RepositorioPersona(AppContext appContext)
        {
            _appContext = appContext;
        }

        Persona IRepositorioPersona.AddPersona(Persona persona)
        {
            var personaAdicionado = _appContext.personas.Add(persona);
            _appContext.SaveChanges();
            return personaAdicionado.Entity;
        }

        void IRepositorioPersona.DeletePersona(int idPersona)
        {
            var personaEncontrado = _appContext.personas.FirstOrDefault(p => p.id == idPersona);
            if (personaEncontrado == null)
                return;
            _appContext.personas.Remove(personaEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Persona> IRepositorioPersona.GetAllPersona()
        {
            return _appContext.personas;
        }

        Persona IRepositorioPersona.GetPersona(int idPersona)
        {
            return _appContext.personas.FirstOrDefault(p => p.id == idPersona);
        }

        Persona IRepositorioPersona.UpdatePersona(Persona persona)
        {
            var personaEncontrado = _appContext.personas.FirstOrDefault(p => p.id == persona.id);
            if (personaEncontrado != null)
            {
                personaEncontrado.id = persona.id;
                personaEncontrado.nombre = persona.nombre;
                personaEncontrado.apellido = persona.apellido;
                personaEncontrado.identificacion = persona.identificacion;
                personaEncontrado.fechaNacimiento = persona.fechaNacimiento;
                personaEncontrado.estadoCovid = persona.estadoCovid;
                 _appContext.SaveChanges();
            }
            return personaEncontrado;
        }

    }
}