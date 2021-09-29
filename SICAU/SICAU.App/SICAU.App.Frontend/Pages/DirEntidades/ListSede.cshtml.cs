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
    public class ListSedeModel : PageModel
    {
        public IRepositorioSede _repositorioSede = new RepositorioSede(new Persistencia.AppContext());
        public IEnumerable<Sede> sedes {get;set;}
        public string criterio;
        public void OnGet(string criterio)
        {
            sedes = _repositorioSede.GetByNames(criterio);
        }
    }
}
