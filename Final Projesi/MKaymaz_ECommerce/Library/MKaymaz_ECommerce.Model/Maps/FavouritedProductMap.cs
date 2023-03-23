using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Core.Map;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Maps
{
    public class FavouritedProductMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<FavouritedProduct>(entity =>
            {
                entity.ToTable("FavouritedProducts");

                entity.HasExtended();

                entity
                    .HasOne(f => f.Member)
                    .WithMany(m => m.FavouritedProducts)
                    .HasForeignKey(f => f.MemberId);

                entity
                   .HasOne(f => f.Product)
                   .WithMany(m => m.FavouritedProducts)
                   .HasForeignKey(f => f.ProductId);
                
                entity
                  .HasOne(f => f.CreatedUserFavouritedProduct)
                  .WithMany(m => m.CreatedUserFavouritedProducts)
                  .HasForeignKey(f => f.CreatedUserId);

                entity
                  .HasOne(f => f.ModifiedUserFavouritedProduct)
                  .WithMany(m => m.ModifiedUserFavouritedProducts)
                  .HasForeignKey(f => f.ModifiedUserId);

            });
        }
    }
}
