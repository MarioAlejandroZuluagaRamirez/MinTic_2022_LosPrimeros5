using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SICAU.App.Dominio;
using SICAU.App.Persistencia;

namespace SICAU.App.FrontEnd.Pages
{
    [Authorize]
    public class DeleteEstudianteModel : PageModel
    {
       private static IRepositorioEstudiante _repoEstudiante = new RepositorioEstudiante(new Persistencia.AppContext());
        [BindProperty]
        public Estudiante estudiante{get;set;}

        public IActionResult OnGet(int idEstudiante)
        {
            estudiante = _repoEstudiante.GetEstudiante(idEstudiante);
            if (estudiante == null)
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
            _repoEstudiante.DeleteEstudiante(estudiante.id);
            return RedirectToPage("ListEstudiante");
        }
    }
}
