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
    public class EditDirectivoModel : PageModel
    {
        public static IRepositorioDirectivo _repoDirectivo = new RepositorioDirectivo(new Persistencia.AppContext());
        [BindProperty]
        public Directivo directivo {get;set;}
          
        public IActionResult OnGet(int? idDirectivo)
        {
            if (idDirectivo.HasValue){                       
                directivo = _repoDirectivo.GetDirectivo(idDirectivo.Value);                 
            }else
            {
                directivo = new Directivo();               
            }
            if (directivo == null)
            {
                return RedirectToPage("./ListDirectivo");
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
                if(directivo.id > 0)
                {                                   
                    directivo = _repoDirectivo.UpdateDirectivo(directivo);
                }else
                {                     
                    _repoDirectivo.AddDirectivo(directivo);
                }     
                return RedirectToPage("./ListDirectivo");
            }     
        }
    }
}

