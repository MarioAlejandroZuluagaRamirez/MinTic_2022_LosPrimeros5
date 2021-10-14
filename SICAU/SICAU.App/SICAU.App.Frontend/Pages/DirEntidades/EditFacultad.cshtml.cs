using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SICAU.App.Dominio;
using SICAU.App.Persistencia;

namespace SICAU.App.Frontend.Pages
{
    public class EditFacultadModel : PageModel
    {
        private static IRepositorioSede _repoSede = new RepositorioSede(new Persistencia.AppContext());
        private static IRepositorioFacultad _repoFacultad = new RepositorioFacultad(new Persistencia.AppContext());
        [BindProperty]
        public Sede sede { get; set; }
        [BindProperty]
        public Facultad facultad { get; set; }
        public List<SelectListItem> itemsSede { get; set; }
        public IEnumerable<Sede> sedes { get; set; }
        public string idSede { get; set; }
        public IActionResult OnGet(int? idFacultad)
        {
            if (idFacultad.HasValue)
                facultad = _repoFacultad.GetFacultad(idFacultad.Value);
            else
                facultad  = new ();

            sedes = _repoSede.GetAllSede();
            //itemsSede = new();
            //foreach (Sede sede in sedes)
            //{
            //    itemsSede.Add(new SelectListItem { Text = sede.sede, Value = sede.id.ToString(), Selected = sede.id == facultad.sede.id ? true : false });
            //}

            if (facultad == null)
                return RedirectToPage("./ListSede");
            else
                return Page();
        }
        public IActionResult OnPost(int? idSede)
        {
            if (facultad.id == 0)
            {
                _repoSede.AdicionarFacultad(idSede.Value, facultad);
            }
            else
            {
                _repoFacultad.AsignaFacultad(facultad.id, idSede.Value);
                _repoFacultad.UpdateFacultad(facultad);
            }
            return RedirectToPage("./ListFacultad");
        }
    }
}
