using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Core.Map;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Maps
{
    public class OrderAddressMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<OrderAddress>(entity =>
            {
                entity.ToTable("OrderAddresses");

                entity.HasExtended();

                entity.Property(x => x.Firstname).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.Surname).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.Country).HasMaxLength(128).IsRequired(true);
                entity.Property(x => x.Location).HasMaxLength(128).IsRequired(true);
                entity.Property(x => x.SubLocation).HasMaxLength(128).IsRequired(false);
                entity.Property(x => x.Address).HasMaxLength(9999).IsRequired(true);
                entity.Property(x => x.PhoneNumber).HasMaxLength(32).IsRequired(false);
                entity.Property(x => x.MobilePhoneNumber).HasMaxLength(32).IsRequired(true);

               
                entity
                .HasOne(oa => oa.CreatedUserOrderAddress)
                .WithMany(u => u.CreatedUserOrderAddresses)
                .HasForeignKey(oa => oa.CreatedUserId);

                entity
                .HasOne(oa => oa.ModifiedUserOrderAddress)
                .WithMany(u => u.ModifiedUserOrderAddresses)
                .HasForeignKey(oa => oa.ModifiedUserId);
            });
        }
    }
}
