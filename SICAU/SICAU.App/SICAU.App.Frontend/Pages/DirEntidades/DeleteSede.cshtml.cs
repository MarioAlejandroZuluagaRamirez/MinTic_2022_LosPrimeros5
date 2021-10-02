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
    public class DeleteSedeModel : PageModel
    {
        private static IRepositorioSede _repoSede = new RepositorioSede(new Persistencia.AppContext());
        [BindProperty]
        public Sede sede { get; set; }

        public IActionResult OnGet(int idSede)
        {
            sede = _repoSede.GetSede(idSede);
            if (sede == null)
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
            _repoSede.DeleteSede(sede.id);
            return RedirectToPage("ListSede");
        }
    }
}
