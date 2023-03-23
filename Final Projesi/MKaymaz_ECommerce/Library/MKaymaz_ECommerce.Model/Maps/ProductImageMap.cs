using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Core.Map;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Maps
{
    public class ProductImageMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<ProductImage>(entity =>
            {
                entity.ToTable("ProductImages");

                entity.HasExtended();

                entity.Property(x => x.Filename).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.Extension).IsRequired(true);
                entity.Property(x => x.DirectoryName).HasMaxLength(10).IsRequired(true);
                entity.Property(x => x.Revision).HasMaxLength(30).IsRequired(false);
                entity.Property(x => x.SortOrder).IsRequired(false);
                entity.Property(x => x.Attachment).IsRequired(false);

                entity
                    .HasOne(pi => pi.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(pi => pi.ProductId);

                entity.HasOne(pi => pi.CreatedUserProductImage)
                   .WithMany(u => u.CreatedUserProductImages)
                   .HasForeignKey(pi => pi.CreatedUserId);

                entity.HasOne(pi => pi.ModifiedUserProductImage)
                    .WithMany(u => u.ModifiedUserProductImages)
                    .HasForeignKey(pi => pi.ModifiedUserId);

            });
        }
    }
}
