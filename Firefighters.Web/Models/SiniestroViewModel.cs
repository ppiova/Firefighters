using Firefighters.Web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Firefighters.Web.Models
{
    public class SiniestroViewModel : Siniestro
    {
        [Display(Name = "Localidad")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una Localidad.")]
        public int LocalidadID { get; set; }
        public IEnumerable<SelectListItem> Localidades { get; set; }

        [Display(Name = "Tipo de Emergencia")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Tipo de Emergencia.")]
        public int EmergenciaID { get; set; }
        public IEnumerable<SelectListItem> Emergencias { get; set; }


    }
}
