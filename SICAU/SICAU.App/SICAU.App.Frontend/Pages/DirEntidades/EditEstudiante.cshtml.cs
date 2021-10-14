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
    public class EditEstudianteModel : PageModel
    {
               public static IRepositorioEstudiante _repoEstudiante = new RepositorioEstudiante(new Persistencia.AppContext());
        [BindProperty]
        public Estudiante estudiante {get;set;}
        public IActionResult OnGet(int? idEstudiante)
        {
            if (idEstudiante.HasValue)
            {
                estudiante = _repoEstudiante.GetEstudiante(idEstudiante.Value);
            }else
            {
                estudiante = new Estudiante();
            }
            if (estudiante == null)
            {
                return RedirectToPage("./ListEstudiante");
            }else{
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid){
                return Page();                

            }else
            {                 
                if(estudiante.id > 0)
                {                                   
                    estudiante = _repoEstudiante.UpdateEstudiante(estudiante);
                }else
                {                     
                    _repoEstudiante.AddEstudiante(estudiante);
                }     
                return RedirectToPage("./ListEstudiante");
            }     
        }
    }
}


