using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Core.Map;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Maps
{
    public class TownMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Town>(entity =>
            {
                entity.ToTable("Towns");

                entity.HasExtended();

                entity.Property(x => x.Name).HasMaxLength(255).IsRequired(true);

                entity
                    .HasOne(t=>t.Location)
                    .WithMany(l=>l.Towns)
                    .HasForeignKey(t => t.LocationId);

                entity
                    .HasOne(b => b.CreatedUserTown)
                    .WithMany(u => u.CreatedUserTowns)
                    .HasForeignKey(b => b.CreatedUserId);

                entity
                    .HasOne(b => b.ModifiedUserTown)
                    .WithMany(u => u.ModifiedUserTowns)
                    .HasForeignKey(b => b.ModifiedUserId);
            });
        }
    }
}
