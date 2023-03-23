using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Core.Map;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Maps
{
    public class CategoryMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");

                entity.HasExtended();//BaseMapleme için (EntityBuilderExtension)

                entity.Property(x => x.Name).HasMaxLength(255).IsRequired();
                entity.Property(x => x.Slug).HasMaxLength(255);
                entity.Property(x => x.SortOrder);
                entity.Property(x => x.DistrbutorCode).HasMaxLength(255);
                entity.Property(x => x.Percent);
                entity.Property(x => x.ImageFile).HasMaxLength(255);
                entity.Property(x => x.Distributor).HasMaxLength(128);
                entity.Property(x => x.DisplayShowcaseContent);
                entity.Property(x => x.ShowcaseContent).HasMaxLength(255);
                entity.Property(x => x.ShowcaseContentDisplayType);
                entity.Property(x => x.DisplayShowcaseFooterContent);
                entity.Property(x => x.ShowcaseFooterContent).HasMaxLength(999);
                entity.Property(x => x.ShowcaseFooterContentDisplayType);
                entity.Property(x => x.HasChildren);
                entity.Property(x => x.MetaKeywords).HasMaxLength(999);
                entity.Property(x => x.MetaDescription).HasMaxLength(999);
                entity.Property(x => x.CanonicalUrl).HasMaxLength(255);
                entity.Property(x => x.PageTitle).HasMaxLength(255);
                entity.Property(x => x.Attachment);

                entity
                    .HasOne(c=>c.CreatedUserCategory)
                    .WithMany(u=>u.CreatedUserCategories)
                    .HasForeignKey(c => c.CreatedUserId);

                entity.HasOne(c => c.ModifiedUserCategory)
                    .WithMany(u => u.ModifiedUserCategories)
                    .HasForeignKey(c => c.ModifiedUserId);


            });
        }
    }
}
