using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Core.Map;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Maps
{
    public class CurrentAccountMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<CurrentAccount>(entity =>
            {
                entity.ToTable("CurrentAccounts");

                entity.HasExtended();

                entity.Property(x => x.Code).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.Title).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.Balance);
                entity.Property(x => x.RiskLimit);

                entity.HasOne(c => c.Member)
                .WithMany(m => m.CurrentAccounts)
                .HasForeignKey(c => c.MemberId);

                entity.HasOne(c => c.CreatedUserCurrentAccount)
                .WithMany(u => u.CreatedUserCurrentAccounts)
                .HasForeignKey(c => c.CreatedUserId);

                entity.HasOne(c => c.ModifiedUserCurrentAccount)
               .WithMany(u => u.ModifiedUserCurrentAccounts)
               .HasForeignKey(c => c.ModifiedUserId);
            });
        }
    }
}
