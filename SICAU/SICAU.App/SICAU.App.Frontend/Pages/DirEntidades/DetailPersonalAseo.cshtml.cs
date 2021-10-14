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
    public class DetailPersonalAseoModel : PageModel
    {
        public IRepositorioPersonalAseo _repositorioPersonalAseo = new RepositorioPersonalAseo(new Persistencia.AppContext());
        public PersonalAseo personalAseo {get;set;}
        public IActionResult OnGet(int idPersonalAseo)
        {
            personalAseo = _repositorioPersonalAseo.GetPersonalAseo(idPersonalAseo);
        
            if (personalAseo==null)
            {
                return RedirectToPage("/NotFound");
            }
            else
            {
                return Page();
            }
        }
    }
}
