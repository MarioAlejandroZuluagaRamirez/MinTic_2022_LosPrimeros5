using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SICAU.App.Persistencia;
using SICAU.App.Dominio;

namespace SICAU.App.Frontend.Pages
{
    public class DetailDirectivoModel : PageModel
    {
        public IRepositorioDirectivo _repositorioDirectivo = new RepositorioDirectivo(new Persistencia.AppContext());
        public Directivo directivo {get;set;}
        public IActionResult OnGet(int idDirectivo)
        {
            directivo = _repositorioDirectivo.GetDirectivo(idDirectivo);
        
            if (directivo==null)
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
