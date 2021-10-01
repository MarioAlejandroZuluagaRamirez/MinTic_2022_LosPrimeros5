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
    public class DeleteUniversidadModel : PageModel
    {
        private static IRepositorioUniversidad _repoUniversidad = new RepositorioUniversidad(new Persistencia.AppContext());
        [BindProperty]
        public Universidad universidad{get;set;}

        public IActionResult OnGet(int idUniversidad)
        {
            universidad = _repoUniversidad.GetUniversidad(idUniversidad);
            if (universidad == null)
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
            _repoUniversidad.DeleteUniversidad(universidad.id);
            return RedirectToPage("ListUniversidad");
        }
    }
}
