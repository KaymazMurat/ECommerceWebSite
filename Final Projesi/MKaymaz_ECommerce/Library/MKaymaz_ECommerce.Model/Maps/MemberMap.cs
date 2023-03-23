using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Core.Map;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Maps
{
    public class MemberMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Member>(entity =>
            {
                entity.ToTable("Members");

                entity.HasExtended();

                entity.Property(x=>x.FirstName).HasMaxLength(255).IsRequired(true);
                entity.Property(x=>x.SurName).HasMaxLength(255).IsRequired(true);
                entity.Property(x=>x.Email).HasMaxLength(255).IsRequired(true);
                entity.Property(x=>x.Gender).IsRequired(true);
                entity.Property(x=>x.BirthDate).IsRequired(false);
                entity.Property(x=>x.PhoneNumber).HasMaxLength(255).IsRequired(false);
                entity.Property(x=>x.MobilePhoneNumber).HasMaxLength(255).IsRequired(true);
                entity.Property(x=>x.OtherLocation).HasMaxLength(255).IsRequired(false);
                entity.Property(x=>x.Address).HasMaxLength(int.MaxValue).IsRequired(false);
                entity.Property(x=>x.TaxNumber).HasMaxLength(255).IsRequired(false);
                entity.Property(x=>x.TcId).HasMaxLength(255).IsRequired(false);
                entity.Property(x=>x.LastLoginDate).IsRequired(false);
                entity.Property(x=>x.ZipCode).HasMaxLength(50).IsRequired(false);
                entity.Property(x=>x.CommericalName).HasMaxLength(255).IsRequired(false);
                entity.Property(x=>x.TaxOffice).HasMaxLength(255).IsRequired(false);
                entity.Property(x=>x.GainedPointAmount).IsRequired(false);
                entity.Property(x=>x.SpentPointAmount).IsRequired(false);
                entity.Property(x=>x.AllowedToCampaigns).IsRequired(false);
                entity.Property(x=>x.District).HasMaxLength(255).IsRequired(false);
                entity.Property(x=>x.DeviceType).HasMaxLength(255).IsRequired(false);
                entity.Property(x=>x.DeviceInfo).HasMaxLength(255).IsRequired(false);
                entity.Property(x=>x.DeviceInfo).HasMaxLength(255).IsRequired(false);

                entity.HasOne(m => m.Country)
                .WithMany(c => c.Members)
                .HasForeignKey(m => m.CountryId);

                entity.HasOne(m => m.Location)
                .WithMany(l => l.Members)
                .HasForeignKey(m => m.LocationId);

                entity.HasOne(m => m.CreatedUserMember)
                .WithMany(u => u.CreatedUserMembers)
                .HasForeignKey(m => m.CreatedUserId);

                entity.HasOne(m => m.ModifiedUserMember)
               .WithMany(u => u.ModifiedUserMembers)
               .HasForeignKey(m => m.ModifiedUserId);
            });
        }
    }
}
