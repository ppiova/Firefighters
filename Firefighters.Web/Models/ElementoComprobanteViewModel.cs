using Firefighters.Web.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Firefighters.Web.Models
{
    public class ElementoComprobanteViewModel : ElementoComprobante
    {
        [Display(Name = "Comprobante")]
        public IFormFile ComprobanteFile { get; set; }
    }
}
