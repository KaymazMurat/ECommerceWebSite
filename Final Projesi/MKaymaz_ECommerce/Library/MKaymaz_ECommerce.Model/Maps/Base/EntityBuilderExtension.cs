using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MKaymaz_ECommerce.Core.Entity;
using MKaymaz_ECommerce.Common.Enums;

namespace MKaymaz_ECommerce.Model.Maps.Base
{
    public static class EntityBuilderExtension
    {
        public static void HasExtended<T>(this EntityTypeBuilder<T> entity) where T : CoreEntity
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();// otomotik sayı verme
            entity.Property(x=>x.Status).IsRequired(true);

            entity.Property(x=>x.CreatedDate).IsRequired(false);
            entity.Property(x => x.CreatedComputerName).HasMaxLength(255).IsRequired(false);
            entity.Property(x => x.CreatedIP).HasMaxLength(15).IsRequired(false);
            entity.Property(x => x.CreatedUserId).IsRequired(false);

            entity.Property(x => x.ModifiedDate).IsRequired(false);
            entity.Property(x => x.ModifiedComputerName).HasMaxLength(255).IsRequired(false);
            entity.Property(x => x.ModifiedIP).HasMaxLength(15).IsRequired(false);
            entity.Property(x => x.ModifiedUserId).IsRequired(false);
        }
    }
}
