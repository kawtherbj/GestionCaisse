using GestionCaisseData.Models.ModelConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCaisseData.Models
{
   public class CaisseContext : DbContext
    {
        public  CaisseContext(DbContextOptions<CaisseContext> options) : base(options)
            {
            }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.ApplyConfiguration(new CaisseConfiguration());
            modelBuilder.ApplyConfiguration(new GerantConfiguration());
        }

        public DbSet<Vente> vente { get; set; }
        public DbSet<Gerant> gerant { get; set; }

    }
}
