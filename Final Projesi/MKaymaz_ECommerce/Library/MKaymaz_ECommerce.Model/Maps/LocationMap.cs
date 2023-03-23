using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Core.Map;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Maps
{
    public class LocationMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Location>(entity =>
            {
                entity.ToTable("Locations");

                entity.HasExtended();

                entity.Property(x=>x.Name).HasMaxLength(255).IsRequired(true);
                entity.Property(x=>x.Predefined).IsRequired(false);

                entity.HasOne(l => l.Country)
                .WithMany(c => c.Locations)
                .HasForeignKey(l => l.CountryId);

                entity.HasOne(l => l.CreatedUserLocation)
                .WithMany(u => u.CreatedUserLocations)
                .HasForeignKey(l => l.CreatedUserId);

                entity.HasOne(l => l.ModifiedUserLocation)
               .WithMany(u => u.ModifiedUserLocations)
               .HasForeignKey(l => l.ModifiedUserId);

            });
        }
    }
}
