using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Core.Map;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Model.Maps.Base;

namespace MKaymaz_ECommerce.Model.Maps
{
    public class UserMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity.HasExtended();

                entity.Property(x => x.FirstName).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.LastName).HasMaxLength(100).IsRequired(true);
                entity.Property(x => x.Title).HasMaxLength(100).IsRequired(false);
                entity.Property(x => x.ImageUrl).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.Email).HasMaxLength(100).IsRequired(true);
                entity.Property(x => x.Password).HasMaxLength(12).IsRequired(true);
                entity.Property(x => x.LastIPAddress).HasMaxLength(15).IsRequired(false);
                entity.Property(x => x.LastLogin).IsRequired(false);
                entity.Property(x => x.IsAdmin).IsRequired(false);

                entity
                   .HasOne(c => c.CreatedUser)
                   .WithMany(u => u.CreatedUsers)
                   .HasForeignKey(c => c.CreatedUserId);

                entity
                    .HasOne(c => c.ModifiedUser)
                    .WithMany(u => u.ModifiedUsers)
                    .HasForeignKey(c => c.ModifiedUserId);
            });
        }
    }
}
