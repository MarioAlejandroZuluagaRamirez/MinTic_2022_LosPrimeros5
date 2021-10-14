using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SICAU.App.Dominio
{
    public class Sede
    {
        public int id {get;set;}
        [Required,StringLength(50,ErrorMessage = "El campo solo admite hasta 50 caracteres")]        
        public string sede {get;set;}
        [StringLength(100,ErrorMessage = "El campo solo admite hasta 100 caracteres")]
        public string ubicacion {get;set;}
        [Required]
        public Universidad universidad {get;set;}

        public List<Facultad> facultades { get; set; }
    }
}