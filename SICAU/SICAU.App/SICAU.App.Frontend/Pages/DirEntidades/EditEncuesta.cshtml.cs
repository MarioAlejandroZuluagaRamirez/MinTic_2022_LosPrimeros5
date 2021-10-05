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
    public class EditEncuestaModel : PageModel
    {
        private static IRepositorioEncuestaCovid _repoEncuestaCovid = new RepositorioEncuestaCovid(new Persistencia.AppContext());
        private static IRepositorioPersona _repoPersona = new RepositorioPersona(new Persistencia.AppContext());
        private static IRepositorioSintoma _repoSintoma = new RepositorioSintoma(new Persistencia.AppContext());
        private static IRepositorioEncuestaCovidSintoma _repoEncuestaCovidSintoma = new RepositorioEncuestaCovidSintoma(new Persistencia.AppContext());
        [BindProperty]
        public EncuestaCovid EncuestaCovid { get; set; }
        [BindProperty]
        public Persona Persona { get; set; }
        [BindProperty]
        public Sintoma Sintoma { get; set; }        
        public IEnumerable<Persona> Personas { get; set; }
        public IEnumerable<EstadoCovid> EstadoCovids { get; set; }
        public List<SelectListItem> Sintomas { get; set; }
        public string IdPersona { get; set; }
        public IActionResult OnGet(int? idEncuestaCovid)
        {

            Sintomas = _repoSintoma.GetAllSintoma().Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.id.ToString(),
                                      Text = a.sintoma
                                  }).ToList();

            if (idEncuestaCovid.HasValue)
                EncuestaCovid = _repoEncuestaCovid.GetEncuestaCovid(idEncuestaCovid.Value);
            else
                EncuestaCovid = new EncuestaCovid();

            Personas = _repoPersona.GetAllPersona();

            if (EncuestaCovid == null)
                return RedirectToPage("./ListEncuesta");
            else
                return Page();
        }
        public IActionResult OnPost(int? idPersona)
        {
            if (EncuestaCovid.id == 0)
            {
                EncuestaCovid = _repoEncuestaCovid.AddEncuestaCovid(EncuestaCovid);
                _repoEncuestaCovid.AsignarPersona(EncuestaCovid.id, idPersona.Value);
            }
            else
            {
                Persona  = _repoPersona.GetPersona(idPersona.Value);
                EncuestaCovid.persona = Persona;
                EncuestaCovid = _repoEncuestaCovid.UpdateEncuestaCovid(EncuestaCovid);
            }
            return RedirectToPage("./ListEncuesta");
        }
        
    }
}
