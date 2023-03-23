using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Core.Map;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Maps
{
    public class ProductCommentMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<ProductComment>(entity =>
            {
                entity.ToTable("ProductComments");

                entity.HasExtended();

                entity.Property(x=>x.Title).HasMaxLength(255).IsRequired(true);
                entity.Property(x=>x.Content).HasMaxLength(9999).IsRequired(true);
                entity.Property(x=>x.Rank).IsRequired(true);
                entity.Property(x=>x.IsAnonymous).IsRequired(true);

                entity
                .HasOne(pm => pm.Member)
                .WithMany(m => m.ProductComments)
                .HasForeignKey(pm => pm.MemberId);

                entity
                .HasOne(pm => pm.Product)
                .WithMany(p => p.ProductComments)
                .HasForeignKey(pm => pm.ProductId);

                entity.HasOne(u => u.CreatedUserProductComment)
                    .WithMany(c => c.CreatedUserProductComments)
                    .HasForeignKey(c => c.CreatedUserId);

                entity.HasOne(u => u.ModifiedUserProductComment)
                    .WithMany(c => c.ModifiedUserProductComments)
                    .HasForeignKey(c => c.ModifiedUserId);
            });
        }
    }
}
