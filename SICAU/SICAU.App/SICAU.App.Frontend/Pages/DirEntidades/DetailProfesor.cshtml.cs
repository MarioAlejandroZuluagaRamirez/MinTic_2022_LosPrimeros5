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
    public class DetailProfesorModel : PageModel
    {
        public IRepositorioProfesor _repositorioProfesor = new RepositorioProfesor(new Persistencia.AppContext());
        public Profesor profesor {get;set;}
        public IActionResult OnGet(int idProfesor)
        {
            profesor = _repositorioProfesor.GetProfesor(idProfesor);
        
            if (profesor==null)
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
