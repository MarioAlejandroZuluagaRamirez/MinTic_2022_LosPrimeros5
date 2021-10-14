using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SICAU.App.Dominio;
using SICAU.App.Persistencia;

namespace SICAU.App.FrontEnd.Pages
{
    public class DeletePersonalAseoModel : PageModel
    {
        private static IRepositorioPersonalAseo _repoPersonalAseo = new RepositorioPersonalAseo(new Persistencia.AppContext());
        [BindProperty]
        public PersonalAseo personalAseo{get;set;}

        public IActionResult OnGet(int idPersonalAseo)
        {
            personalAseo = _repoPersonalAseo.GetPersonalAseo(idPersonalAseo);
            if (personalAseo == null)
            {
                return RedirectToPage("/NotFound");
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost()
        {
            _repoPersonalAseo.DeletePersonalAseo(personalAseo.id);
            return RedirectToPage("ListPersonalAseo");
        }
    }
}
