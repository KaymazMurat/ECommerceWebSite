using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Core.Map;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Model.Maps.Base;

namespace MKaymaz_ECommerce.Model.Maps
{
    public class CartMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Cart>(entity =>
            {
                entity.ToTable("Carts");

                entity.HasExtended();

                entity.Property(x => x.SessionId).IsRequired().HasMaxLength(255);
                entity.Property(x => x.Locked).IsRequired();

                entity.HasOne(m => m.User)
                      .WithMany(c => c.Carts)
                      .HasForeignKey(c => c.UserId);

                entity.HasOne(u => u.CreatedUserCart)
                    .WithMany(c => c.CreatedUserCarts)
                    .HasForeignKey(c => c.CreatedUserId);

                entity.HasOne(u => u.ModifiedUserCart)
                    .WithMany(c => c.ModifiedUserCarts)
                    .HasForeignKey(c => c.ModifiedUserId);
            });
        }
    }
}
