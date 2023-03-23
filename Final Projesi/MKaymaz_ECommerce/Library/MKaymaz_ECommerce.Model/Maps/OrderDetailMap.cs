using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Core.Map;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Maps
{
    public class OrderDetailMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetails");

                entity.HasExtended();

                entity.Property(x =>x.VarValue).HasMaxLength(255).IsRequired(false);
                entity.Property(x =>x.VarKey).HasMaxLength(255).IsRequired(false);

                entity
                .HasOne(oa => oa.CreatedUserOrderDetail)
                .WithMany(u => u.CreatedUserOrderDetails)
                .HasForeignKey(oa => oa.CreatedUserId);

                entity
                .HasOne(oa => oa.ModifiedUserOrderDetail)
                .WithMany(u => u.ModifiedUserOrderDetails)
                .HasForeignKey(oa => oa.ModifiedUserId);
            });
        }
    }
}
