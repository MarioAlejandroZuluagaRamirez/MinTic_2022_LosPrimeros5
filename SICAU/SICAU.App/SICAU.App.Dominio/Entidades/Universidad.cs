using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SICAU.App.Dominio
{
    public class Universidad
    {
        public int id {get;set;}
        [Required,StringLength(50,ErrorMessage ="El campo solo admite hasta 50 caracteres")]
        public string universidad {get;set;}
    }
}