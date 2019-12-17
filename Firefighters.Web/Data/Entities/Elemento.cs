using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Firefighters.Web.Data.Entities
{
    public class Elemento
    {
        [Display(Name = "Código")]
        //[Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        public int ElementoID { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(50, ErrorMessage = "La {0} no debe tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "La {0} es obligatorio.")]
        public string Descripcion { get; set; }

        [Display(Name = "Nro. Serie")]
        [MaxLength(50, ErrorMessage = "El {0} no debe tener mas de {1} caracteres.")]
        public string NroSerie { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fabricación")]
    
        public DateTime? FabricacionFecha { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Compra")]
        public DateTime? CompraFecha { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Vencimiento")]
        public DateTime? VencimientoFecha { get; set; }

        [Display(Name = "Observaciones")]
        [MaxLength(500, ErrorMessage = "El {0} no debe tener mas de {1} caracteres.")]
        public string Observaciones { get; set; }

        [Display(Name = "ACTIVO")]
        public bool Activo { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Baja")]
        public DateTime? BajaFecha { get; set; }


        public Area Area { get; set; }
        public Ubicacion Ubicacion { get; set; }
        public Marca Marca { get; set; }
        public Modelo Modelo { get; set; }

        public Estado? Estado { get; set; }
        public Titular? Titular { get; set; }

        public ICollection<ElementoImage> ElementoImages { get; set; }
        public ICollection<ElementoComprobante> ElementoComprobantes { get; set; }

    }
  
}
