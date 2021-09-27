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
    public class ListProfesorModel : PageModel
    {
        public IRepositorioProfesor _repositorioProfesor = new RepositorioProfesor(new Persistencia.AppContext());
        
        public IEnumerable<Profesor> profesores {get;set;}
        public string criterio;
        public void OnGet(string criterio)
        {
            profesores = _repositorioProfesor.GetByNames(criterio);
        }
    }
}
