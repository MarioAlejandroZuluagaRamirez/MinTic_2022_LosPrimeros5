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
    public class ListSalonModel : PageModel
    {
        public IRepositorioSalon _repositorioSalon = new RepositorioSalon(new Persistencia.AppContext());

        public IEnumerable<Salon> salones { get; set; }
        public string criterio;
        public void OnGet(string criterio)
        {
            salones = _repositorioSalon.GetByNames(criterio);
        }
    }
}
