using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Firefighters.Web.Data.Entities
{
    public class Elemento
    {
        [Display(Name = "Nro. Elemento")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        public int Id { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(50, ErrorMessage = "La {0} no debe tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "La {0} es obligatorio.")]
        public string Descripcion { get; set; }

        [Display(Name = "Modelo")]
        [MaxLength(50, ErrorMessage = "El {0} no debe tener mas de {1} caracteres.")]
        public string Modelo { get; set; }

        [Display(Name = "Marca")]
        [MaxLength(50, ErrorMessage = "La {0} no debe tener mas de {1} caracteres.")]
        public string Marca { get; set; }

        [Display(Name = "Nro. Serie")]
        [MaxLength(50, ErrorMessage = "El {0} no debe tener mas de {1} caracteres.")]
        public string NroSerie { get; set; }

        [Display(Name = "Código")]
        [MaxLength(50, ErrorMessage = "El {0} no debe tener mas de {1} caracteres.")]
        public string Codigo { get; set; }

        [Display(Name = "Fecha Fabricación")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FabricacionFecha { get; set; }

        [Display(Name = "Fecha Compra")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CompraFecha { get; set; }

        [Display(Name = "Fecha Vencimiento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? VencimientoFecha { get; set; }

        [Display(Name = "Observaciones")]
        [MaxLength(500, ErrorMessage = "El {0} no debe tener mas de {1} caracteres.")]
        public string Observaciones { get; set; }

        [Display(Name = "ACTIVO")]
        public bool Activo { get; set; }

        [Display(Name = "Fecha Baja")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BajaFecha { get; set; }


        public Area Area { get; set; }
        public Ubicacion Ubicacion { get; set; }
        
        public Int16 IdEstado { get; set; }
        public Int16 IdTitular { get; set; }
    }
}
