using Firefighters.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Firefighters.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //Here save the Entities
      
        public DbSet<Area> Areas { get; set; }
        public DbSet<Elemento> Elementos { get; set; }
        public DbSet<ElementoComprobante> ElementoComprobantes { get; set; }
        public DbSet<ElementoImage>  ElementoImages { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Ubicacion> Ubicaciones { get; set; }

    }
}
