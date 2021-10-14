using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SICAU.App.Dominio;
using SICAU.App.Persistencia;

namespace SICAU.App.Frontend.Pages
{
    [Authorize]
    public class ListPersonalAseoModel : PageModel
    {
        public IRepositorioPersonalAseo _repositorioPersonalAseo = new RepositorioPersonalAseo(new Persistencia.AppContext());
        public IEnumerable<PersonalAseo> personalAseos {get;set;}
        public string criterio;
        public void OnGet(string criterio)
        {
            personalAseos = _repositorioPersonalAseo.GetByNames(criterio);
        }
    }
}
