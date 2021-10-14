using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SICAU.App.Dominio;
using SICAU.App.Persistencia;

namespace SICAU.App.Frontend.Pages
{
    [Authorize]
    public class ListDetailSedeModel : PageModel
    {
        public IRepositorioUniversidad _repositorioUniversidad = new RepositorioUniversidad(new Persistencia.AppContext());
        public IEnumerable<Sede> Sedes {get;set;}
        public string criterio;
        public void OnGet(int idUniversidad)
        {
            Sedes = _repositorioUniversidad.GetSedes(idUniversidad);
        }
    }
}
