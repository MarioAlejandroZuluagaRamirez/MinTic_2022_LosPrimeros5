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
    public class EditUniversidadModel : PageModel
    {
        private static IRepositorioUniversidad _repoUniversidad = new RepositorioUniversidad(new Persistencia.AppContext());
        [BindProperty]
        public Universidad universidad {get;set;}

        public IActionResult OnGet(int? idUniversidad)
        {
            if (idUniversidad.HasValue)
                universidad = _repoUniversidad.GetUniversidad(idUniversidad.Value);
            else
                universidad = new Universidad();
            
            if (universidad == null)
                return RedirectToPage("./ListUniversidad");
            else
                return Page(); 
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
                return Page();                
            else
            {
                if(universidad.id > 0)
                    universidad = _repoUniversidad.UpdateUniversidad(universidad);
                else
                {
                    _repoUniversidad.AddUniversidad(universidad);
                }     
                return RedirectToPage("./ListUniversidad");
            }     
        }
    }
}
