using Firefighters.Web.Data.Entities;
using Firefighters.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Firefighters.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context,
            IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            //cuando pase por aqui la BD este creada aunque este borrada
            await _context.Database.EnsureCreatedAsync();
            await CheckAreas();
            await CheckUbicaciones();
            await CheckMarcas();
            await CheckModelos();
            await CheckRoles();
            //Creo un Admin y un Bombero
            await CheckUserAsync("1010", "Pablo", "Piovano", "ppiova@cablasociados.com", "3493415005", "Fader 1740", "Admin");
            await CheckUserAsync("2030", "Pablo Angel", "Piova", "ppiova@hotmail.com", "34934150057", "Spilimbergo 581", "Bombero");
            await CheckUserAsync("2020", "Mauro", "Zambon", "mdzambon@gmail.com", "34934150057", "Alen 1980", "Bombero");
            await CheckLocalidades();

        }

       

        public async Task CheckModelos()
        {
            if (!_context.Modelos.Any())
            {
                _context.Modelos.Add(new Entities.Modelo { ModeloElemento = "Airboss Evolution" });
                _context.Modelos.Add(new Entities.Modelo { ModeloElemento = "FPS7000" });
                _context.Modelos.Add(new Entities.Modelo { ModeloElemento = "ASAP SORBER" });
                _context.Modelos.Add(new Entities.Modelo { ModeloElemento = "Elios" });
                _context.Modelos.Add(new Entities.Modelo { ModeloElemento = "Am´D" });
                _context.Modelos.Add(new Entities.Modelo { ModeloElemento = "Oxan" });
                _context.Modelos.Add(new Entities.Modelo { ModeloElemento = "William" });
                _context.Modelos.Add(new Entities.Modelo { ModeloElemento = "HTN9000D" });

                await _context.SaveChangesAsync();

            }
        }

        private async Task CheckMarcas()
        {
            if (!_context.Marcas.Any())
            {
                _context.Marcas.Add(new Entities.Marca { MarcaElemento = "MOTOROLA" });
                _context.Marcas.Add(new Entities.Marca { MarcaElemento = "Holmatro" });
                _context.Marcas.Add(new Entities.Marca { MarcaElemento = "Nacional" });
                _context.Marcas.Add(new Entities.Marca { MarcaElemento = "Genfor" });
                _context.Marcas.Add(new Entities.Marca { MarcaElemento = "FEMA" });
                _context.Marcas.Add(new Entities.Marca { MarcaElemento = "Gherardi" });
                _context.Marcas.Add(new Entities.Marca { MarcaElemento = "Scepter" });
                _context.Marcas.Add(new Entities.Marca { MarcaElemento = "EASTERN" });

                await _context.SaveChangesAsync();

            }
        }

        private async Task CheckAreas()
        {
            if (!_context.Areas.Any())
            {
                _context.Areas.Add(new Entities.Area { AreaName = "Alturas", LlevaInventario = true });
                _context.Areas.Add(new Entities.Area { AreaName = "Coc" , LlevaInventario = true });
                _context.Areas.Add(new Entities.Area { AreaName = "Comunicaciones", LlevaInventario = true });
                _context.Areas.Add(new Entities.Area { AreaName = "Drone", LlevaInventario = true });
                _context.Areas.Add(new Entities.Area { AreaName = "EPP" , LlevaInventario = true });
                _context.Areas.Add(new Entities.Area { AreaName = "Forestales" , LlevaInventario = true });
                _context.Areas.Add(new Entities.Area { AreaName = "Herramientas", LlevaInventario = true });
                _context.Areas.Add(new Entities.Area { AreaName = "Herramientas de Zapa" , LlevaInventario = true });
                _context.Areas.Add(new Entities.Area { AreaName = "Iluminación" ,LlevaInventario = true });
                _context.Areas.Add(new Entities.Area { AreaName = "Incendio", LlevaInventario = true });
                _context.Areas.Add(new Entities.Area { AreaName = "Indumentaria" , LlevaInventario = true });
                _context.Areas.Add(new Entities.Area { AreaName = "Mat-Pel" , LlevaInventario = true });
                _context.Areas.Add(new Entities.Area { AreaName = "Rescate Vehicular" , LlevaInventario = true });
                _context.Areas.Add(new Entities.Area { AreaName = "Señalización", LlevaInventario = true });
                _context.Areas.Add(new Entities.Area { AreaName = "Trauma", LlevaInventario = true });
                _context.Areas.Add(new Entities.Area { AreaName = "Vehículos", LlevaInventario = true });

                await _context.SaveChangesAsync();

            }

        }

        private async Task CheckUbicaciones()
        {
            if (!_context.Ubicaciones.Any())
            {
                _context.Ubicaciones.Add(new Entities.Ubicacion { UbicacionElemento = "Guardia" });
                _context.Ubicaciones.Add(new Entities.Ubicacion { UbicacionElemento = "Depósito" });
                _context.Ubicaciones.Add(new Entities.Ubicacion { UbicacionElemento = "Vestuarios" });
                _context.Ubicaciones.Add(new Entities.Ubicacion { UbicacionElemento = "U11" });
                _context.Ubicaciones.Add(new Entities.Ubicacion { UbicacionElemento = "U14" });
                _context.Ubicaciones.Add(new Entities.Ubicacion { UbicacionElemento = "U16" });
                _context.Ubicaciones.Add(new Entities.Ubicacion { UbicacionElemento = "U18" });
                _context.Ubicaciones.Add(new Entities.Ubicacion { UbicacionElemento = "U19" });
                _context.Ubicaciones.Add(new Entities.Ubicacion { UbicacionElemento = "U20" });
                _context.Ubicaciones.Add(new Entities.Ubicacion { UbicacionElemento = "U21" });
                _context.Ubicaciones.Add(new Entities.Ubicacion { UbicacionElemento = "U21F" });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Bombero");
        }

        private async Task<User> CheckUserAsync(string document, string firstName,
            string lastName, string email, string phone, string address, string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, role);

                //var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                //await _userHelper.ConfirmEmailAsync(user, token);
            }

            return user;
        }

        private async Task CheckLocalidades()
        {
            if (!_context.Localidades.Any())
            {
                _context.Localidades.Add(new Entities.Localidad { NombreLocalidad = "Sunchales" });
                _context.Localidades.Add(new Entities.Localidad { NombreLocalidad = "Tacural" });
                _context.Localidades.Add(new Entities.Localidad { NombreLocalidad = "Tacurales" });
                _context.Localidades.Add(new Entities.Localidad { NombreLocalidad = "Ataliva" });
                _context.Localidades.Add(new Entities.Localidad { NombreLocalidad = "Colonia Aldao" });
                _context.Localidades.Add(new Entities.Localidad { NombreLocalidad = "Virginia" });
                _context.Localidades.Add(new Entities.Localidad { NombreLocalidad = "Ramona" });
                _context.Localidades.Add(new Entities.Localidad { NombreLocalidad = "Raquel" });
                _context.Localidades.Add(new Entities.Localidad { NombreLocalidad = "Colonia Bicha" });
                _context.Localidades.Add(new Entities.Localidad { NombreLocalidad = "Colonia Bossi" });
                _context.Localidades.Add(new Entities.Localidad { NombreLocalidad = "Eusebia" });

                await _context.SaveChangesAsync();
            }
        }
    }
}
