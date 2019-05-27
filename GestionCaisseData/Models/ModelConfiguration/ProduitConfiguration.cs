using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCaisseData.Models.ModelConfiguration
{
    class ProduitConfiguration : IEntityTypeConfiguration<Produit>
    {
        public void Configure(EntityTypeBuilder<Produit> builder)
        {
            builder.HasKey(prop => prop.idPrdt);
        
            builder.Property(prop => prop.Nom);
            builder.Property(prop => prop.Prix);
        }

    }
}
