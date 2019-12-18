using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Firefighters.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboAreas();
        IEnumerable<SelectListItem> GetComboEstadosElementos();
        IEnumerable<SelectListItem> GetComboLocalidades();
        IEnumerable<SelectListItem> GetComboMarcas();
        IEnumerable<SelectListItem> GetComboModelos();
        IEnumerable<SelectListItem> GetComboTitulares();
        IEnumerable<SelectListItem> GetComboUbicaciones();
       
        

    }
}