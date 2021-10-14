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
    public class EditProfesorModel : PageModel
    {
       public static IRepositorioProfesor _repoProfesor = new RepositorioProfesor(new Persistencia.AppContext());
        [BindProperty]
        public Profesor profesor {get;set;}
          
        public IActionResult OnGet(int? idProfesor)
        {
            if (idProfesor.HasValue){                       
                profesor = _repoProfesor.GetProfesor(idProfesor.Value);                 
            }else
            {
                profesor = new Profesor();               
            }
            if (profesor == null)
            {
                return RedirectToPage("./ListProfesor");
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
                if(profesor.id > 0)
                {                                   
                    profesor = _repoProfesor.UpdateProfesor(profesor);
                }else
                {                     
                    _repoProfesor.AddProfesor(profesor);
                }     
                return RedirectToPage("./ListProfesor");
            }     
        }
    }
}

