using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Firefighters.Web.Data.Entities
{
    public class Siniestro
    {
        [Display(Name = "Nro. Siniestro")]
        public int SiniestroID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public DateTime FechaSiniestro { get; set; }

        [Display(Name = "Denunciante")]
        [MaxLength(50, ErrorMessage = "El {0} no debe tener mas de {1} caracteres.")]
        public string Denunciante { get; set; }

        [Display(Name = "Damnificado")]
        [MaxLength(50, ErrorMessage = "El {0} no debe tener mas de {1} caracteres.")]
        public string Damnificado { get; set; }

        [Display(Name = "Dirección / Ubicaci{on")]
        [MaxLength(50, ErrorMessage = "El {0} no debe tener mas de {1} caracteres.")]
        public string DirLocalidad { get; set; }

        //TODO:Falta Agregar Tipos de Emergencia
        //TODO:Falta agregar Comprobantes adjuntos asociados al siniestro.
    }
}
