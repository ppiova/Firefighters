using Firefighters.Web.Data;
using Firefighters.Web.Data.Entities;
using Firefighters.Web.Models;
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



        public async Task<Elemento> ToElementoAsync(ElementoViewModel view, bool isNew)
        {
            return new Elemento
            {
                ElementoID = isNew ? 0 : view.ElementoID,
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
                Estado = view.Estado,
                Titular = view.Titular,
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

                Estado = elemento.Estado,
                Estados = _combosHelper.GetComboEstadosElementos(),
                Titular = elemento.Titular,
                Titulares = _combosHelper.GetComboTitulares(),

                Areas = _combosHelper.GetComboAreas(),
                AreaId = elemento.Area.AreaID,
                Ubicaciones = _combosHelper.GetComboUbicaciones(),
                UbicacionId = elemento.Ubicacion.UbicacionID,
            };
        }
    }
}
