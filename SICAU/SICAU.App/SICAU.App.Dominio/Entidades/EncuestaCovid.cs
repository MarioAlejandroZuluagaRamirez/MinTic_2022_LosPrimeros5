using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SICAU.App.Dominio
{
    public class EncuestaCovid
    {
        public int id { get; set; }
        [Required, DataType(DataType.Date),DisplayFormat(DataFormatString ="0:yyy-MM-dd",ApplyFormatInEditMode =true)]
        public DateTime fechaEncuesta { get; set; }
        [Required]
        public EstadoCovid estadoCovid { get; set; }
        [DisplayFormat(DataFormatString = "yyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime fechaDiagnostico { get; set; }
        [Required]
        public Persona persona { get; set; }
    }
}