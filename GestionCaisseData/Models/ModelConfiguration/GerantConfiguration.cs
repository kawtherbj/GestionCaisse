using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCaisseData.Models.ModelConfiguration
{
    public class GerantConfiguration : IEntityTypeConfiguration<Gerant>
    {
        public void Configure(EntityTypeBuilder<Gerant> builder)
        {
            builder.HasKey(prop => prop.idG);
            builder.Property(prop => prop.nom);
            builder.Property(prop => prop.prenom);
            builder.Property(prop => prop.email);
            builder.Property(prop => prop.password);
        }
    }

}
