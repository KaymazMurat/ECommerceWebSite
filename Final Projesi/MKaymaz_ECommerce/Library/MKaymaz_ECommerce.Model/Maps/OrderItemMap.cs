using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Core.Map;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Maps
{
    public class OrderItemMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItems");

                entity.HasExtended();

                entity.Property(x => x.ProductName).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.ProductSku).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.ProductBarcode).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.ProductPrice).IsRequired(true);
                entity.Property(x => x.ProductCurrency).HasMaxLength(32).IsRequired(false);
                entity.Property(x => x.ProductQuantity).IsRequired(true);
                entity.Property(x => x.ProductTax).IsRequired(true);
                entity.Property(x => x.ProductDiscount).IsRequired(false);
                entity.Property(x => x.ProductMoneyOrderDiscount).IsRequired(false);
                entity.Property(x => x.ProductWeight).IsRequired(true);
                entity.Property(x => x.ProductStockTypeLabel).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.Discount).IsRequired(true);

                entity
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

                entity
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);

                entity
                .HasOne(oi => oi.CreatedUserOrderItem)
                .WithMany(u => u.CreatedUserOrderItems)
                .HasForeignKey(oi => oi.CreatedUserId);

                entity
                .HasOne(oi => oi.ModifiedUserOrderItem)
                .WithMany(u => u.ModifiedUserOrderItems)
                .HasForeignKey(oi => oi.ModifiedUserId);
            });
        }
    }
}
