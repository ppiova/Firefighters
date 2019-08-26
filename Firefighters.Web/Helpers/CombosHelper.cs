using Firefighters.Web.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firefighters.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContext;

        public CombosHelper(DataContext dataContext)
        {
            _dataContext = dataContext;

        }

        public IEnumerable<SelectListItem> GetComboEstadosElementos()
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "(Seleccione un Estado...)" },
                new SelectListItem { Value = "1", Text = "SinEstado" },
                new SelectListItem { Value = "2", Text = "Bueno" },
                new SelectListItem { Value = "3", Text = "Malo" },
                new SelectListItem { Value = "4", Text = "MuyBueno" },
                new SelectListItem { Value = "5", Text = "Regular" },
                new SelectListItem { Value = "6", Text = "SinUso" }

            };

            return list;
        }

        public IEnumerable<SelectListItem> GetComboTitulares()
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "(Seleccione un Titular...)" },
                new SelectListItem { Value = "1", Text = "S" },
                new SelectListItem { Value = "2", Text = "F" },
                new SelectListItem { Value = "3", Text = "PC" }


            };

            return list;
        }

        public IEnumerable<SelectListItem> GetComboAreas()
        {
            var list = _dataContext.Areas.Select(p => new SelectListItem
            {
                Text = p.AreaName,
                Value = p.AreaID.ToString()
            }).OrderBy(p => p.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un Area...)",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboUbicaciones()
        {
            var list = _dataContext.Ubicaciones.Select(p => new SelectListItem
            {
                Text = p.UbicacionElemento,
                Value = p.UbicacionID.ToString()
            }).OrderBy(p => p.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione una Ubicación...)",
                Value = "0"
            });

            return list;
        }
    }
}
