using Firefighters.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firefighters.Web.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //Here save the Entities
        //public DbSet<Owner> Owners { get; set; }

        public DbSet<Area> Areas { get; set; }
    }
}
