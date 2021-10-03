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
    public class EditSintomaModel : PageModel
    {
        private static IRepositorioSintoma _repoSintoma = new RepositorioSintoma(new Persistencia.AppContext());
        [BindProperty]
        public Sintoma sintoma { get; set; }

        public IActionResult OnGet(int? idSintoma)
        {
            if (idSintoma.HasValue)
                sintoma = _repoSintoma.GetSintoma(idSintoma.Value);
            else
                sintoma = new Sintoma();

            if (sintoma == null)
                return RedirectToPage("./LisSintoma");
            else
                return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            else
            {
                if (sintoma.id > 0)
                    sintoma = _repoSintoma.UpdateSintoma(sintoma);
                else
                {
                    _repoSintoma.AddSintoma(sintoma);
                }
                return RedirectToPage("./ListSintoma");
            }
        }
    }
}
