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
    public class ListMateriaModel : PageModel
    {
        public IRepositorioMateria _repositorioMateria = new RepositorioMateria(new Persistencia.AppContext());

        public IEnumerable<Materia> materias { get; set; }
        public string criterio;
        public void OnGet(string criterio)
        {
            materias = _repositorioMateria.GetByNames(criterio);
        }
    }
}
