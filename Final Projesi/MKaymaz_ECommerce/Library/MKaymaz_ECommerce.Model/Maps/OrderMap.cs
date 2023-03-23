using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Core.Map;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Maps
{
    public class OrderMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Order>(entity =>
            {
                entity.ToTable("Oders");

                entity.HasExtended();

                entity.Property(x => x.CustomerFirstname).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.CustomerSurname).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.CustomerEmail).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.CustomerPhone).HasMaxLength(32).IsRequired(false);
                entity.Property(x => x.PaymentTypeName).HasMaxLength(128).IsRequired(false);
                entity.Property(x => x.PaymentProviderCode).HasMaxLength(128).IsRequired(false);
                entity.Property(x => x.PaymentProviderName).HasMaxLength(128).IsRequired(false);
                entity.Property(x => x.PaymentGatewayCode).HasMaxLength(128).IsRequired(false);
                entity.Property(x => x.PaymentGatewayName).HasMaxLength(128).IsRequired(false);
                entity.Property(x => x.ClientIp).HasMaxLength(32).IsRequired(false);
                entity.Property(x => x.UserAgent).HasMaxLength(1028).IsRequired(false);
                entity.Property(x => x.Currency).HasMaxLength(32).IsRequired(false);
                entity.Property(x => x.CurrencyRates).HasMaxLength(9999).IsRequired(false);
                entity.Property(x => x.Amount).IsRequired(false);
                entity.Property(x => x.CouponDiscount).IsRequired(false);
                entity.Property(x => x.TaxAmount).IsRequired(false);
                entity.Property(x => x.PromotionDiscount).IsRequired(false);
                entity.Property(x => x.GeneralAmount).IsRequired(false);
                entity.Property(x => x.ShippingAmount).IsRequired(false);
                entity.Property(x => x.AdditionalServiceAmount).IsRequired(false);
                entity.Property(x => x.FinalAmount).IsRequired(false);
                entity.Property(x => x.SumOfGainedPoints).IsRequired(false);
                entity.Property(x => x.Installment).IsRequired(false);
                entity.Property(x => x.InstallmentRate).IsRequired(false);
                entity.Property(x => x.ExtraInstallment).IsRequired(false);
                entity.Property(x => x.TransactionId).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.HasUserNote).IsRequired(false);
                entity.Property(x => x.PaymentStatus).IsRequired(false);
                entity.Property(x => x.ErrorMessage).HasMaxLength(9999).IsRequired(false);
                entity.Property(x => x.DeviceType).IsRequired(false);
                entity.Property(x => x.Referrer).HasMaxLength(9999).IsRequired(false);
                entity.Property(x => x.InvoicePrintCount).IsRequired(false);
                entity.Property(x => x.UseGiftPackage).HasMaxLength(9999).IsRequired(false);
                entity.Property(x => x.GiftNote).HasMaxLength(9999).IsRequired(false);
                entity.Property(x => x.MemberGroupName).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.UsePromotion).IsRequired(false);
                entity.Property(x => x.ShippingProviderCode).HasMaxLength(128).IsRequired(false);
                entity.Property(x => x.ShippingProviderName).HasMaxLength(128).IsRequired(false);
                entity.Property(x => x.ShippingCompanyName).HasMaxLength(128).IsRequired(false);
                entity.Property(x => x.ShippingPaymentType).IsRequired(false);
                entity.Property(x => x.Source).HasMaxLength(255).IsRequired(false);

                entity
                .HasOne(o => o.CreatedUserOrder)
                .WithMany(u => u.CreatedUserOrders)
                .HasForeignKey(o => o.CreatedUserId);

                entity
                .HasOne(o => o.ModifiedUserOrder)
                .WithMany(u => u.ModifiedUserOrders)
                .HasForeignKey(o => o.ModifiedUserId);

                entity
                .HasOne(o => o.User)
                .WithMany(m => m.Orders)
                .HasForeignKey(o => o.UserId);

                entity
                .HasOne(o => o.ShippingAddres)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.ShippingAddresId);


            });
        }
    }
}
