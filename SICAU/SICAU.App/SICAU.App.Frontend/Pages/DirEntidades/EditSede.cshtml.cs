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
    public class EditSedeModel : PageModel
    {
        private static IRepositorioSede _repoSede = new RepositorioSede(new Persistencia.AppContext());
        private static IRepositorioUniversidad _repoUniversidad = new RepositorioUniversidad(new Persistencia.AppContext());
        [BindProperty]
        public Sede  sede{ get; set; }
        [BindProperty]
        public Universidad universidad { get; set; }
        public IEnumerable<Universidad> universidades { get; set; }
        public string idUniversidad { get;  set; }
        public IActionResult OnGet(int? idSede)
        {
            if (idSede.HasValue)
                sede = _repoSede.GetSede(idSede.Value);
            else
                sede= new Sede();

            universidades = _repoUniversidad.GetAllUniversidad();

            if (sede == null)
                return RedirectToPage("./ListSede");
            else
                return Page();
        }
        public IActionResult OnPost(int? idUniversidad)
        {
            if (sede.id == 0)
            {
                _repoUniversidad.AdicionarSede(idUniversidad.Value, sede);
            }
            else
            {
                _repoSede.AsignaUniversidad(sede.id, idUniversidad.Value);
                _repoSede.UpdateSede(sede);      
                    //universidad = _repoUniversidad.GetUniversidad(idUniversidad.Value);
                //sede.universidad = universidad;
                //sede = _repoSede.UpdateSede(sede);
            }
            return RedirectToPage("./ListSede");
        }
    }
}
