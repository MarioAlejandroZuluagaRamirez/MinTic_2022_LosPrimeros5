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
    public class ListUniversidadModel : PageModel
    {
        public IRepositorioUniversidad _repositorioUniversidad = new RepositorioUniversidad(new Persistencia.AppContext());
        
        public IEnumerable<Universidad> universidades {get;set;}
        public string criterio;
        public void OnGet(string criterio)
        {
            universidades = _repositorioUniversidad.GetByNames(criterio);
        }
    }
}
