using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Core.Map;
using MKaymaz_ECommerce.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Maps
{
    public class CurrencyMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Currency>(entity =>
            {
                entity.Property(x => x.Label).HasMaxLength(50).IsRequired(false);
                entity.Property(x => x.BuyingPrice).IsRequired(true) ;
                entity.Property(x => x.SellingPrice).IsRequired(true);
                entity.Property(x=>x.Abbr).IsRequired(false).HasMaxLength(5);
                entity.Property(x=>x.IsPrimary).IsRequired(false);

                entity.HasOne(c => c.CreatedUserCurrency)
                .WithMany(u => u.CreatedUserCurrencies)
                .HasForeignKey(c => c.CreatedUserId);

                entity.HasOne(c => c.ModifiedUserCurrency)
                .WithMany(u => u.ModifiedUserCurrencies)
                .HasForeignKey(c => c.ModifiedUserId);
            });
        }
    }
}
