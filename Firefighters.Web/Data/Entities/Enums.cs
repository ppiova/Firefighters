using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Firefighters.Web.Data.Entities
{
    public enum Estado
    {
        
        [Display(Name = "Bueno")]
        Bueno = 1,
        [Display(Name = "Malo")]
        Malo = 2,
        [Display(Name = "Muy Bueno")]
        Muy_Bueno = 3,
        [Display(Name = "Regular")]
        Regular = 4,
        [Display(Name = "Sin Estado")]
        Sin_Estado = 5,
        [Display(Name = "Sin Uso")]
        Sin_Uso = 6
    }
    public enum Titular
    {        
        [Display(Name = "Federación Santafesina")]
        Federeación = 1,
        [Display(Name = "Sunchales")]
        Sunchales = 2,
        [Display(Name = "Protección Civil")]
        Protección_Civil = 3
    }
}
