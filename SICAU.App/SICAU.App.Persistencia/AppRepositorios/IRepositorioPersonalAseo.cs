using System.Collections.Generic;
using SICAU.App.Dominio;

namespace SICAU.App.Persistencia
{
    public interface IRepositorioPersonalAseo
    {
        IEnumerable<PersonalAseo> GetAllPersonalAseo();
        PersonalAseo AddPersonalAseo(PersonalAseo personalAseo);
        PersonalAseo UpdatePersonalAseo(PersonalAseo personalAseo);
        void DeletePersonalAseo(int idPersonalAseo);
        PersonalAseo GetPersonalAseo(int idPersonalAseo);
    }
}