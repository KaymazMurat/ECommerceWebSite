using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Core.Map;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Maps
{
    public class ShippingAddresMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<ShippingAddres>(entity =>
            {
                entity.ToTable("ShippingAddreses");

                entity.HasExtended();

                entity.Property(x => x.Firstname).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.Surname).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.Country).HasMaxLength(128).IsRequired(true);
                entity.Property(x => x.Location).HasMaxLength(128).IsRequired(true);
                entity.Property(x => x.SubLocation).HasMaxLength(128).IsRequired(false);
                entity.Property(x => x.Address).HasMaxLength(9999).IsRequired(true);
                entity.Property(x => x.PhoneNumber).HasMaxLength(32).IsRequired(false);
                entity.Property(x => x.PhoneNumber).HasMaxLength(32).IsRequired(true);


                entity.HasOne(l => l.CreatedUserShippingAddress)
               .WithMany(u => u.CreatedUserShippingAddresses)
               .HasForeignKey(l => l.CreatedUserId);

                entity.HasOne(l => l.ModifiedUserShippingAddress)
               .WithMany(u => u.ModifiedUserShippingAddresses)
               .HasForeignKey(l => l.ModifiedUserId);

            });

        }
    }
}
