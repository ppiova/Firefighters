using Firefighters.Web.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Firefighters.Web.Models
{
    public class ElementoImageViewModel : ElementoImage
    {
        [Display(Name = "Imagen")]
        public IFormFile ImageFile { get; set; }
    }
}
