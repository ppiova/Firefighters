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

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy HH:mm:ss}")]
        [Display(Name = "Fecha y Hora")]
        public DateTime FechaSiniestro { get; set; }

        [Display(Name = "Denunciante")]
        [MaxLength(50, ErrorMessage = "El {0} no debe tener mas de {1} caracteres.")]
        public string Denunciante { get; set; }

        [Display(Name = "Teléfono Denunciante")]
        [MaxLength(50, ErrorMessage = "El {0} no debe tener mas de {1} caracteres.")]
        public string TelDeununciante { get; set; }

        [Display(Name = "Damnificado")]
        [MaxLength(50, ErrorMessage = "El {0} no debe tener mas de {1} caracteres.")]
        public string Damnificado { get; set; }

        [Display(Name = "Teléfono Damnificado")]
        [MaxLength(50, ErrorMessage = "El {0} no debe tener mas de {1} caracteres.")]
        public string TelDamnificado { get; set; }

        [Display(Name = "Dirección / Ubicación")]
        [MaxLength(50, ErrorMessage = "El {0} no debe tener mas de {1} caracteres.")]
        public string DirUbicación { get; set; }

        public Localidad Localidad { get; set; }

        [Display(Name = "Ruta / KM")]
        [MaxLength(10, ErrorMessage = "El {0} no debe tener mas de {1} caracteres.")]
        public string RutaKm { get; set; }

        [Display(Name = "Observaciones")]
        [MaxLength(500, ErrorMessage = "El {0} no debe tener mas de {1} caracteres.")]
        public string Observaciones { get; set; }


        public Emergencia Emergencia { get; set; }
        

        public ICollection<SiniestroComprobante> SiniestroComprobante { get; set; }
    }
}
