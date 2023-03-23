using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Core.Map;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Maps
{
    public class ProductMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");

                entity.HasExtended();

                entity.Property(p => p.Name).HasMaxLength(255).IsRequired(true);
                entity.Property(p => p.Slug).HasMaxLength(255).IsRequired(false);
                entity.Property(p => p.FullName).HasMaxLength(255).IsRequired(true);
                entity.Property(p => p.Sku).HasMaxLength(255).IsRequired(true);
                entity.Property(p => p.Barcode).HasMaxLength(255).IsRequired(false);
                entity.Property(p => p.Price1).IsRequired(true);
                entity.Property(p => p.Warranty).IsRequired(false);
                entity.Property(p => p.Tax).IsRequired(false);
                entity.Property(p => p.StockAmount).IsRequired(false);
                entity.Property(p => p.VolumetricWeight).IsRequired(false);
                entity.Property(p => p.StockTypeLabel).IsRequired(true);
                entity.Property(p => p.DiscountType).IsRequired(false);
                entity.Property(p => p.MoneyOrderDiscount).IsRequired(false);
                entity.Property(p => p.TaxIncluded).IsRequired(false);
                entity.Property(p => p.Distributor).IsRequired(false);
                entity.Property(p => p.IsGifted).IsRequired(false);
                entity.Property(p => p.Gift).HasMaxLength(255).IsRequired(false);
                entity.Property(p => p.CustomShippingCost).IsRequired(false);
                entity.Property(p => p.MarketPriceDetail).HasMaxLength(255).IsRequired(false);
                entity.Property(p => p.MetaKeywords).HasMaxLength(999).IsRequired(false);
                entity.Property(p => p.MetaDescription).HasMaxLength(999).IsRequired(false);
                entity.Property(p => p.CanonicalUrl).HasMaxLength(255).IsRequired(false);
                entity.Property(p => p.PageTitle).HasMaxLength(255).IsRequired(false);
                entity.Property(p => p.ShortDetails).HasMaxLength(512).IsRequired(false);
                entity.Property(p => p.SearchKeywords).HasMaxLength(255).IsRequired(false);
                entity.Property(p => p.InstallmentThreshold).HasMaxLength(10).IsRequired(false);
                entity.Property(p => p.InstallmentThreshold).HasMaxLength(10).IsRequired(false);
                entity.Property(p => p.HomeSortOrder).IsRequired(false);
                entity.Property(p => p.PopularSortOrder).IsRequired(false);
                entity.Property(p => p.BrandSortOrder).IsRequired(false);
                entity.Property(p => p.FeaturedSortOrder).IsRequired(false);
                entity.Property(p => p.CampaignedSortOrder).IsRequired(false);
                entity.Property(p => p.NewSortOrder).IsRequired(false);
                entity.Property(p => p.DiscountedSortOrder).IsRequired(false);
                entity.Property(p => p.ViewCount).IsRequired(false);
                entity.Property(p => p.ParentId).IsRequired(false);

                entity
                    .HasOne(p => p.Brand)
                    .WithMany(b => b.Products)
                    .HasForeignKey(b => b.BrandId);

                entity
                   .HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId);

                entity
                   .HasOne(p => p.User)
                   .WithMany(u => u.Products)
                   .HasForeignKey(p => p.UserId);

                entity
                    .HasOne(P => P.Parent)
                    .WithMany(p => p.Parents)
                    .HasForeignKey(p => p.ParentId);

                entity
                    .HasOne(p => p.Currency)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CurrencyId);

                entity
                    .HasOne(c => c.CreatedUserProduct)
                    .WithMany(u => u.CreatedUserProducts)
                    .HasForeignKey(c => c.CreatedUserId);

                entity.HasOne(c => c.ModifiedUserProduct)
                    .WithMany(u => u.ModifiedUserProducts)
                    .HasForeignKey(c => c.ModifiedUserId);
            });
        }
    }
}
