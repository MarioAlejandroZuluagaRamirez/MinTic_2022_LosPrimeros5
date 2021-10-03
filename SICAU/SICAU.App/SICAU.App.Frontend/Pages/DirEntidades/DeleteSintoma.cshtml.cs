using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SICAU.App.Dominio;
using SICAU.App.Persistencia;

namespace SICAU.App.Frontend.Pages
{
    public class DeleteSintomaModel : PageModel
    {
        private static IRepositorioSintoma _repoSintoma = new RepositorioSintoma(new Persistencia.AppContext());
        [BindProperty]
        public Sintoma sintoma { get; set; }

        public IActionResult OnGet(int idSintoma)
        {
            sintoma = _repoSintoma.GetSintoma(idSintoma);
            if (sintoma == null)
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
            _repoSintoma.DeleteSintoma(sintoma.id);
            return RedirectToPage("ListSintoma");
        }
    }
}
