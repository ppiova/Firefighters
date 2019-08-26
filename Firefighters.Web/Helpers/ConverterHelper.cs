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
        //Atributos privados para poder utilizarlos en toda la clase que no se me pierdan en el constructor
        private readonly DataContext _dataContext;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext dataContext, ICombosHelper combosHelper)
        {
            _dataContext = dataContext;
            _combosHelper = combosHelper;
        }

          

        public async Task<Elemento> ToElementoAsync(ElementoViewModel view)
        {
            return new Elemento
            {
                Descripcion = view.Descripcion,
                Modelo = view.Modelo,
                Marca = view.Marca,
                NroSerie = view.NroSerie,
                Codigo = view.Codigo,
                FabricacionFecha = view.FabricacionFecha,
                CompraFecha = view.CompraFecha,
                VencimientoFecha = view.VencimientoFecha,
                Observaciones = view.Observaciones,
                Activo = view.Activo,
                BajaFecha = view.BajaFecha,

                IdEstado = view.IdEstado,
                IdTitular = view.IdTitular,
                Area = await _dataContext.Areas.FindAsync(view.AreaId),
                Ubicacion = await _dataContext.Ubicaciones.FindAsync(view.UbicacionId)



            };
        }

        public ElementoViewModel ToElementoViewModel(Elemento elemento)
        {
            return new ElementoViewModel
            {
                ElementoID = elemento.ElementoID,
                Descripcion = elemento.Descripcion,
                Modelo = elemento.Modelo,
                Marca = elemento.Marca,
                NroSerie = elemento.NroSerie,
                Codigo = elemento.Codigo,
                FabricacionFecha = elemento.FabricacionFecha,
                CompraFecha = elemento.CompraFecha,
                VencimientoFecha = elemento.VencimientoFecha,
                Observaciones = elemento.Observaciones,
                Activo = elemento.Activo,
                BajaFecha = elemento.BajaFecha,

                IdEstado = elemento.IdEstado,
                Estados = _combosHelper.GetComboEstadosElementos(),
                IdTitular = elemento.IdTitular,
                Titulares = _combosHelper.GetComboTitulares(),

                Areas = _combosHelper.GetComboAreas(),
                AreaId = elemento.Area.AreaID,
                Ubicaciones = _combosHelper.GetComboUbicaciones(),
                UbicacionId = elemento.Ubicacion.UbicacionID,
            };
        }
    }
}
