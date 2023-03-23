using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Core.Map;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Maps
{
    public class ProductPriceMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<ProductPrice>(entity =>
            {
                entity.ToTable("ProductPrices");

                entity.HasExtended();

                entity.Property(x => x.Value).IsRequired(true);
                entity.Property(x => x.Type).IsRequired(false);

                entity
                   .HasOne(pi => pi.Product)
                   .WithMany(p => p.ProductPrices)
                   .HasForeignKey(pi => pi.ProductId);

                entity.HasOne(pi => pi.CreatedUserProductPrice)
                   .WithMany(u => u.CreatedUserProductPrices)
                   .HasForeignKey(pi => pi.CreatedUserId);

                entity.HasOne(pi => pi.ModifiedUserProductPrice)
                    .WithMany(u => u.ModifiedUserProductPrices)
                    .HasForeignKey(pi => pi.ModifiedUserId);

            });
        }
    }
}
