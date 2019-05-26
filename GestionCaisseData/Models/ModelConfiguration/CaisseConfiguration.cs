using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCaisseData.Models.ModelConfiguration
{
    public class CaisseConfiguration : IEntityTypeConfiguration<Vente>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Vente> builder)
        {
            builder.HasKey(prop => prop.idV);

            builder.Property(prop => prop.Numc);

            builder.Property(prop => prop.Nump);

            builder.Property(prop => prop.DateV);

        }
    }

   
}
