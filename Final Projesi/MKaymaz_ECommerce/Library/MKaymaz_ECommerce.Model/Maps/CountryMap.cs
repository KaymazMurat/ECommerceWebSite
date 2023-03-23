using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Core.Map;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Maps
{
    public class CountryMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Country>(entity =>
            {
                entity.ToTable("Countries");

                entity.HasExtended();

                entity.Property(x=>x.Name).HasMaxLength(256).IsRequired();
                entity.Property(x=>x.Code).HasMaxLength(256).IsRequired();

                entity.HasOne(c => c.CreatedUserCountry)
                .WithMany(u => u.CreatedUserCountries)
                .HasForeignKey(c => c.CreatedUserId);

                entity.HasOne(c => c.ModifiedUserCountry)
                .WithMany(u => u.ModifiedUserCountries)
                .HasForeignKey(c => c.ModifiedUserId);

            });
        }
    }
}
