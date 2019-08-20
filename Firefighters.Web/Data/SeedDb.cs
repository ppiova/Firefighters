using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firefighters.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            //cuando pase por aqui la BD este creada aunque este borrada
            await _context.Database.EnsureCreatedAsync();
            await CheckAreas();
            await CheckUbicaciones();

           
        }

        private async Task CheckAreas()
        {
            if (!_context.Areas.Any())
            {
                _context.Areas.Add(new Entities.Area { AreaName = "Acuatica" });
                _context.Areas.Add(new Entities.Area { AreaName = "Alturas" });
                _context.Areas.Add(new Entities.Area { AreaName = "Coc" });
                _context.Areas.Add(new Entities.Area { AreaName = "Comunicaciones" });
                _context.Areas.Add(new Entities.Area { AreaName = "Drone" });
                _context.Areas.Add(new Entities.Area { AreaName = "EPP" });
                _context.Areas.Add(new Entities.Area { AreaName = "Forestales" });
                _context.Areas.Add(new Entities.Area { AreaName = "Herramientas" });
                _context.Areas.Add(new Entities.Area { AreaName = "Herramientas de Zapa" });
                _context.Areas.Add(new Entities.Area { AreaName = "Iluminación" });
                _context.Areas.Add(new Entities.Area { AreaName = "Incendio" });
                _context.Areas.Add(new Entities.Area { AreaName = "Indumentaria" });
                _context.Areas.Add(new Entities.Area { AreaName = "Mat-Pel" });
                _context.Areas.Add(new Entities.Area { AreaName = "Rescate Vehicular" });
                _context.Areas.Add(new Entities.Area { AreaName = "Señalización" });
                _context.Areas.Add(new Entities.Area { AreaName = "Trauma" });
                _context.Areas.Add(new Entities.Area { AreaName = "Vehículos" });

                await _context.SaveChangesAsync();

            }
            
        }

        private async Task CheckUbicaciones()
        {
            _context.Ubicacions.Add(new Entities.Ubicacion { UbicacionElemento = "Guardia" });
            _context.Ubicacions.Add(new Entities.Ubicacion { UbicacionElemento = "Depósito" });
            _context.Ubicacions.Add(new Entities.Ubicacion { UbicacionElemento = "Vestuarios" });
            _context.Ubicacions.Add(new Entities.Ubicacion { UbicacionElemento = "U11" });
            _context.Ubicacions.Add(new Entities.Ubicacion { UbicacionElemento = "U14" });
            _context.Ubicacions.Add(new Entities.Ubicacion { UbicacionElemento = "U16" });
            _context.Ubicacions.Add(new Entities.Ubicacion { UbicacionElemento = "U18" });
            _context.Ubicacions.Add(new Entities.Ubicacion { UbicacionElemento = "U19" });
            _context.Ubicacions.Add(new Entities.Ubicacion { UbicacionElemento = "U20" });
            _context.Ubicacions.Add(new Entities.Ubicacion { UbicacionElemento = "U21" });
            _context.Ubicacions.Add(new Entities.Ubicacion { UbicacionElemento = "U21F" });

            await _context.SaveChangesAsync();
        }
    }
}
