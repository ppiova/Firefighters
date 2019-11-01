using Firefighters.Web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Firefighters.Web.Models
{
    public class ElementoViewModel : Elemento
    {

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Areas")]
        [Range(1, Int16.MaxValue, ErrorMessage = "Debe seleccionar un Area.")]
        public Int16 AreaId { get; set; }

        public IEnumerable<SelectListItem> Areas { get; set; }


        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Ubicaciones")]
        [Range(1, Int16.MaxValue, ErrorMessage = "Debe seleccionar una Ubicación.")]
        public Int16 UbicacionId { get; set; }

        public IEnumerable<SelectListItem> Ubicaciones { get; set; }
           
        public IEnumerable<SelectListItem> Estados { get; set; }

        public IEnumerable<SelectListItem> Titulares { get; set; }

    }
}
