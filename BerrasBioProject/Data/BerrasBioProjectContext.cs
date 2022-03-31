#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BerrasBio.Models;

namespace BerrasBioProject.Data
{
    public class BerrasBioProjectContext : DbContext
    {
        public BerrasBioProjectContext (DbContextOptions<BerrasBioProjectContext> options)
            : base(options)
        {
        }

        public DbSet<BerrasBio.Models.Bookings> Bookings { get; set; }

        public DbSet<BerrasBio.Models.Movies> Movies { get; set; }

        public DbSet<BerrasBio.Models.Salons> Salons { get; set; }

        public DbSet<BerrasBio.Models.Shows> Shows { get; set; }



    }
}
