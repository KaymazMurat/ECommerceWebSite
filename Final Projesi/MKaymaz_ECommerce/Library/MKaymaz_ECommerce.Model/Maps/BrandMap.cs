using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Core.Map;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Model.Maps.Base;

namespace MKaymaz_ECommerce.Model.Maps
{
    public class BrandMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Brand>(entity =>
            {

                entity.ToTable("Brands");

                entity.HasExtended();

                entity.Property(x => x.Name).HasMaxLength(255).IsRequired();
                entity.Property(x => x.Slug).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.SortOrder).IsRequired();
                entity.Property(x => x.DistributorCode).HasMaxLength(255);
                entity.Property(x => x.Distributor).HasMaxLength(255);
                entity.Property(x => x.ImageFile).HasMaxLength(255);
                entity.Property(x => x.ShowcaseContent).HasMaxLength(int.MaxValue);
                entity.Property(x => x.DisplayShowcaseContent);
                entity.Property(x => x.MetaKeywords).HasMaxLength(int.MaxValue).IsRequired(false);
                entity.Property(x => x.MetaDescription).HasMaxLength(int.MaxValue).IsRequired(false);
                entity.Property(x => x.CanonicalUrl).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.PageTitle).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.Attachment).HasMaxLength(255).IsRequired(false);

                entity
                    .HasOne(b => b.CreatedUserBrand)
                    .WithMany(u => u.CreatedUserBrands)
                    .HasForeignKey(b => b.CreatedUserId);

                entity
                    .HasOne(b => b.ModifiedUserBrand)
                    .WithMany(u => u.ModifiedUserBrands)
                    .HasForeignKey(b => b.ModifiedUserId);

            });
        }
    }
}
