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
    public class ListFacultadModel : PageModel
    {
        public IRepositorioFacultad _repositorioFacultad = new RepositorioFacultad(new Persistencia.AppContext());
        public IEnumerable<Facultad> facultades{ get; set; }
        public string criterio;
        public void OnGet(string criterio)
        {
            facultades= _repositorioFacultad.GetByNames(criterio);
        }
    }
}
