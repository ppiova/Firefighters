using Firefighters.Web.Data;
using Firefighters.Web.Data.Entities;
using Firefighters.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firefighters.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _dataContext;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext dataContext, ICombosHelper combosHelper)
        {
            _dataContext = dataContext;
            _combosHelper = combosHelper;
        }


        public ElementoViewModel ToElementoViewModel(Elemento elemento)
        {
            return new ElementoViewModel
            {
                Id = elemento.Id,
                AreaId = elemento.Area.Id,
                Areas = _combosHelper.GetComboAreas(),
                UbicacionId = elemento.Ubicacion.Id,
                Ubicaciones = _combosHelper.GetComboUbicaciones(),
                CompraFecha = elemento.CompraFecha,
                FabricacionFecha = elemento.FabricacionFecha,
                VencimientoFecha = elemento.VencimientoFecha,
                IdEstado = elemento.IdEstado,
                Estados = _combosHelper.GetComboEstadosElementos(),
                IdTitular = elemento.IdTitular,
                Titulares = _combosHelper.GetComboTitulares(),
                Activo = elemento.Activo,
                BajaFecha = elemento.BajaFecha

            };
        }
    }
}
