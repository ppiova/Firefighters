using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Firefighters.Web.Data.Entities
{
    public class Modelo
    {
        public Int16 ModeloID { get; set; }

        [Display(Name = "Modelo")]
        [MaxLength(20, ErrorMessage = "El {0} campo no debe tener más de {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        public string ModeloElemento { get; set; }

        public ICollection<Elemento> Elementos { get; set; }
    }
}
