using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Firefighters.Web.Data.Entities
{
    public class Area
    {       

        [Display(Name = "Nro. Area")]
        [Range(0, Int16.MaxValue, ErrorMessage = "El {0} campo no debe tener más de {2} caractéres.")] 
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        public Int16 AreaID { get; set; }

        [Display(Name = "Area")]
        [MaxLength(20, ErrorMessage = "El {0} campo no debe tener más de {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        public string AreaName { get; set; }

        [Display(Name = "Lleva Inventario")]
        public bool LlevaInventario { get; set; }
        
        public ICollection<Elemento> Elementos { get; set; }


    }
}
