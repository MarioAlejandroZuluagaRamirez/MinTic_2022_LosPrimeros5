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
    public class ListProgramaModel : PageModel
    {
        public IRepositorioPrograma _repositorioPrograma = new RepositorioPrograma(new Persistencia.AppContext());
        public IEnumerable<Programa> programas {get; set; }
        public string criterio;
        public void OnGet(string criterio)
        {
            programas = _repositorioPrograma.GetByNames(criterio);
        }
    }
}
