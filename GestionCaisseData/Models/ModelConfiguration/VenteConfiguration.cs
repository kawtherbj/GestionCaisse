using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCaisseData.Models.ModelConfiguration
{
    class VenteConfiguration : IEntityTypeConfiguration<Caisse>
    {
        public void Configure(EntityTypeBuilder<Caisse> builder)
        {
            builder.HasKey(prop => prop.Numero);
            builder.Property(prop => prop.Adresse);
            builder.Property(prop => prop.Magasin);

        }

    }
}
