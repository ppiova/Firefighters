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
                Marca = await _dataContext.Marcas.FindAsync(view.MarcaID),
                Modelo = await _dataContext.Modelos.FindAsync(view.ModeloID),
                NroSerie = view.NroSerie,
                FabricacionFecha = view.FabricacionFecha,
                CompraFecha = view.CompraFecha,
                VencimientoFecha = view.VencimientoFecha,
                Observaciones = view.Observaciones,
                Activo = true,
                BajaFecha = view.BajaFecha,
                Estado = view.Estado,
                Titular = view.Titular,
                Area = await _dataContext.Areas.FindAsync(view.AreaId),
                Ubicacion = await _dataContext.Ubicaciones.FindAsync(view.UbicacionId)



            };
        }

        public async Task<Siniestro> ToSiniestroAsync(SiniestroViewModel view, bool isNew)
        {
            return new Siniestro
            {
                SiniestroID = isNew ? 0 : view.SiniestroID,
                Denunciante = view.Denunciante,
                TelDeununciante = view.TelDeununciante,
                Damnificado = view.Damnificado,
                TelDamnificado = view.TelDamnificado,
                DirUbicación = view.DirUbicación,
                Localidad = await _dataContext.Localidades.FindAsync(view.LocalidadID),
                RutaKm = view.RutaKm,
                FechaSiniestro = view.FechaSiniestro,
                HoraSiniestro = view.HoraSiniestro,
                Emergencia =   await _dataContext.Emergencias.FindAsync(view.EmergenciaID),
                Observaciones = view.Observaciones

            };
        }


        public ElementoViewModel ToElementoViewModel(Elemento elemento)
        {
            return new ElementoViewModel
            {
                ElementoID = elemento.ElementoID,
                Descripcion = elemento.Descripcion,
                
                Marcas = _combosHelper.GetComboMarcas(),
                MarcaID = elemento.Marca.MarcaID,
               
                Modelos = _combosHelper.GetComboModelos(),
                ModeloID = elemento.Modelo.ModeloID,
                NroSerie = elemento.NroSerie,
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

        public SiniestroViewModel ToSiniestroViewModel(Siniestro siniestro)
        {
            return new SiniestroViewModel
            {
                SiniestroID = siniestro.SiniestroID,
                FechaSiniestro = siniestro.FechaSiniestro,
                HoraSiniestro = siniestro.HoraSiniestro,
                Denunciante = siniestro.Denunciante,
                TelDeununciante = siniestro.TelDeununciante,
                Damnificado = siniestro.Damnificado,
                TelDamnificado = siniestro.TelDamnificado,
                DirUbicación = siniestro.DirUbicación,
                RutaKm = siniestro.RutaKm,
                Observaciones = siniestro.Observaciones,

                Emergencias = _combosHelper.GetComboEmergencias(),
                EmergenciaID = siniestro.Emergencia.EmergenciaID,
                Localidades = _combosHelper.GetComboLocalidades(),
                LocalidadID = siniestro.Localidad.LocalidadID
                             
            };
        }
    }
}
