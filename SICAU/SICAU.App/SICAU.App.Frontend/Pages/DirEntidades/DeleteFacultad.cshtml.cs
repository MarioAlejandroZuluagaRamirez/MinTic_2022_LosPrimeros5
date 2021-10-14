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
    public class DeleteFacultadModel : PageModel
    {
        private static IRepositorioFacultad _repoFacultad = new RepositorioFacultad(new Persistencia.AppContext());
        [BindProperty]
        public Facultad facultad { get; set; }

        public IActionResult OnGet(int idFacultad)
        {
            facultad = _repoFacultad.GetFacultad(idFacultad);
            if (facultad == null)
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
            _repoFacultad.DeleteFacultad(facultad.id);
            return RedirectToPage("ListFacultad");
        }
    }
}
