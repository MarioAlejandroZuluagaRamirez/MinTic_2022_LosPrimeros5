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
    public class EditPersonalAseoModel : PageModel
    {
         public static IRepositorioPersonalAseo _repoPersonalAseo = new RepositorioPersonalAseo(new Persistencia.AppContext());
        [BindProperty]
        public PersonalAseo personalAseo {get;set;}
          
        public IActionResult OnGet(int? idPersonalAseo)
        {
            if (idPersonalAseo.HasValue){                       
                personalAseo = _repoPersonalAseo.GetPersonalAseo(idPersonalAseo.Value);                 
            }else
            {
                personalAseo = new PersonalAseo();               
            }
            if (personalAseo == null)
            {
                return RedirectToPage("./ListPersonalAseo");
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
                if(personalAseo.id > 0)
                {                                   
                    personalAseo = _repoPersonalAseo.UpdatePersonalAseo(personalAseo);
                }else
                {                     
                    _repoPersonalAseo.AddPersonalAseo(personalAseo);
                }     
                return RedirectToPage("./ListPersonalAseo");
            }     
        }
    }
}

