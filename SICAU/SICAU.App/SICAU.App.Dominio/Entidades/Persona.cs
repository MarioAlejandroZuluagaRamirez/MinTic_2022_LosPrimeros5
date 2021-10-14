using System.ComponentModel.DataAnnotations;
using System;
using System.Runtime.CompilerServices;

namespace SICAU.App.Dominio
{
    public class Persona
    {
        public int id {get;set;}
        [Required,StringLength(50,ErrorMessage ="El campo solo admite hasta 50 caracteres")]
        // [Required]
        // [StringLength(50)]
        // [Display(Name = "Nombres")]
        public string nombre {get;set;}
        [StringLength(50)]
        [Display(Name = "Apellidos")]
        public string apellido {get;set;}
        [Required]
        [StringLength(15)]
        [Display(Name = "Numero de identificacion")]
        public string identificacion {get;set;}
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime fechaNacimiento {get;set;}
        [Required]
        public EstadoCovid estadoCovid {get;set;}
    }
}