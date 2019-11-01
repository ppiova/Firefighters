using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Firefighters.Web.Data.Entities
{
    public class ElementoComprobante
    {
        public int ElementoComprobanteId { get; set; }

        [Display(Name = "Nombre Comprobante")]
        public string ComprobanteNombre { get; set; }

        [Display(Name = "Comprobante")]
        public string ComprobanteUrl { get; set; }

        // TODO: Change the path when publish
        public string ComprobanteFullPath => string.IsNullOrEmpty(ComprobanteUrl)
            ? null
              //: $"https://myleasing.azurewebsites.net{ImageUrl.Substring(1)}";
              : $"https://localhost:5001{ComprobanteUrl.Substring(1)}";

        public Elemento Elemento { get; set; }
    }
}
