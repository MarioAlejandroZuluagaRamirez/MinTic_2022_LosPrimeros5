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
    public class ListSintomaModel : PageModel
    {
        public IRepositorioSintoma _repositorioSintoma = new RepositorioSintoma(new Persistencia.AppContext());
        public IEnumerable<Sintoma> sintomas {get;set;}
        public string criterio;
        public void OnGet(string criterio)
        {
            sintomas = _repositorioSintoma.GetByNames(criterio);
        }
    }
}
