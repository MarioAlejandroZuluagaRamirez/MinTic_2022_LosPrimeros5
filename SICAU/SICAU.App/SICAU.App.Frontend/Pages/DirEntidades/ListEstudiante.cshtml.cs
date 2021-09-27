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
    public class ListEstudianteModel : PageModel
    {
        public IRepositorioEstudiante _repositorioEstudiante = new RepositorioEstudiante(new Persistencia.AppContext());
        public IEnumerable<Estudiante> estudiantes { get; set; }
        public string criterio;
        public void OnGet(string criterio)
        {
            estudiantes = _repositorioEstudiante.GetByNames(criterio);
        }
    }
}
