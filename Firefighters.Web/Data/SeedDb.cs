using Firefighters.Web.Data.Entities;
using Firefighters.Web.Helpers;
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
            await CheckRoles();
            //Creo un Admin y un Bombero
            await CheckUserAsync("1010", "Pablo", "Piovano", "ppiova@cablasociados.com", "3493415005", "Fader 1740", "Admin");
            await CheckUserAsync("2020", "Pablo Angel", "Piova", "ppiova@hotmail.com", "34934150057", "Spilimbergo 581", "Bombero");

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

    }
}
