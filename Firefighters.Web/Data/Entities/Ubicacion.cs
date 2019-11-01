using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Firefighters.Web.Data.Entities
{
    public class Ubicacion
    {

        [Display(Name = "Nro. Ubicación")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        public Int16 UbicacionID { get; set; }

        [Display(Name = "Ubicación")]
        [MaxLength(20, ErrorMessage = "El {0} campo no debe tener más de {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        public string UbicacionElemento { get; set; }

        public ICollection<Elemento> Elementos { get; set; }
    }
}
