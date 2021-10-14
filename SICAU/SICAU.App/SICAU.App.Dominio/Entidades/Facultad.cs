
using System.ComponentModel.DataAnnotations;

namespace SICAU.App.Dominio
{
    public class Facultad
    {
        public int id {get;set;}
        [Required, StringLength(50, ErrorMessage = "El campo solo admite hasta 50 caracteres")]
        public string facultad {get;set;}
        public Sede sede { get; set; }
    }
}