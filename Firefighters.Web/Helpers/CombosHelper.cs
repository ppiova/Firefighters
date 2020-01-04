using Firefighters.Web.Data;
using Firefighters.Web.Data.Entities;
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

        public IEnumerable<SelectListItem> GetComboAreas()
        {
            var list = _dataContext.Areas
                .Where(a => a.LlevaInventario == true)
                .Select(p => new SelectListItem
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

        public IEnumerable<SelectListItem> GetComboEmergencias()
        {
            var list = _dataContext.Emergencias
                .Select(p => new SelectListItem
                {
                    Text = p.TipoEmergencia,
                    Value = p.EmergenciaID.ToString()
                }).OrderBy(p => p.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione una Emergencia...)",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboEstadosElementos()
        {
            var estadosList = new List<SelectListItem>();

            foreach (Estado eVal in Enum.GetValues(typeof(Estado)))
            {               
                estadosList.Add(new SelectListItem { Text = Enum.GetName(typeof(Estado), eVal), Value = eVal.ToString()});
            }

            estadosList.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un Estado...)",
                Value = "0"
            });

            return estadosList;
        }

        public IEnumerable<SelectListItem> GetComboLocalidades()
        {
            var list = _dataContext.Localidades
                .Select(p => new SelectListItem
                {
                    Text = p.NombreLocalidad,
                    Value = p.LocalidadID.ToString()
                }).OrderBy(p => p.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione una Localidad...)",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboMarcas()
        {
            var list = _dataContext.Marcas

                .Select(p => new SelectListItem
                {
                    Text = p.MarcaElemento,
                    Value = p.MarcaID.ToString()
                }).OrderBy(p => p.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione una Marca...)",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboModelos()
        {
            var list = _dataContext.Modelos

                .Select(p => new SelectListItem
                {
                    Text = p.ModeloElemento,
                    Value = p.ModeloID.ToString()
                }).OrderBy(p => p.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un Modelo...)",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboTitulares()
        {
            var titularesList = new List<SelectListItem>();
            foreach (Titular eVal in Enum.GetValues(typeof(Titular)))
            {
                titularesList.Add(new SelectListItem { Text = Enum.GetName(typeof(Titular), eVal), Value = eVal.ToString() });
            }
            titularesList.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un Titular...)",
                Value = "0"
            });

            return titularesList;
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
