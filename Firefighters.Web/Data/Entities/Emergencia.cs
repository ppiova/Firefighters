using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Firefighters.Web.Data.Entities
{
    public class Emergencia
    {
        public int EmergenciaID { get; set; }

        [Display(Name = "Emergencia")]
        [MaxLength(50, ErrorMessage = "El {0} campo no debe tener más de {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        public string TipoEmergencia { get; set; }

        public ICollection<Siniestro> Siniestros { get; set; }
    }
}
