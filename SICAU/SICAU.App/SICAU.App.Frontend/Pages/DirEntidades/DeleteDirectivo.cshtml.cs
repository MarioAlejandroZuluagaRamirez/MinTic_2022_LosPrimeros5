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
    public class DeleteDirectivoModel : PageModel
    {
        private static IRepositorioDirectivo _repoDirectivo = new RepositorioDirectivo(new Persistencia.AppContext());
        [BindProperty]
        public Directivo directivo{get;set;}

        public IActionResult OnGet(int idDirectivo)
        {
            directivo = _repoDirectivo.GetDirectivo(idDirectivo);
            if (directivo == null)
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
            _repoDirectivo.DeleteDirectivo(directivo.id);
            return RedirectToPage("ListDirectivo");
        }
    }
}
