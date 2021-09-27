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
    public class DetailEstudianteModel : PageModel
    {
        public IRepositorioEstudiante _repositorioEstudiante = new RepositorioEstudiante(new Persistencia.AppContext());
        public Estudiante estudiante {get;set;}
        public IActionResult OnGet(int idEstudiante)
        {
            estudiante = _repositorioEstudiante.GetEstudiante(idEstudiante);
        
            if (estudiante==null)
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
