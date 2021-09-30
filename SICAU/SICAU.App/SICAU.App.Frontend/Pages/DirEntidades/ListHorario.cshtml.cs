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
    public class ListHorarioModel : PageModel
    {
        public IRepositorioHorario _repositorioHorario = new RepositorioHorario(new Persistencia.AppContext());
        public IEnumerable<Horario> horarios {get;set;}
        public IActionResult OnGet(int idSalon)
        {
            horarios = _repositorioHorario.GetBySalon(idSalon);
        
            if (horarios==null)
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
