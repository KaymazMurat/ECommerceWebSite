using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Core.Map;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Model.Maps.Base;

namespace MKaymaz_ECommerce.Model.Maps
{
    public class CartItemMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<CartItem>(entity =>
            {
                entity.ToTable("CartItems");

                entity.HasExtended();

                entity.Property(x => x.ParentProductId);
                entity.Property(x => x.Quantity).IsRequired();
                entity.Property(x => x.CategoryId);

                entity.HasOne(ci => ci.Cart)
                .WithMany(c => c.Cartİtems)
                .HasForeignKey(c => c.CartId);

                entity.HasOne(ci => ci.Product)
                .WithMany(u => u.CartItems)
                .HasForeignKey(ci => ci.ProductId);

                entity.HasOne(ci => ci.CreatedUserCartItem)
                .WithMany(u => u.CreatedUserCartItems)
                .HasForeignKey(ci => ci.CreatedUserId);

                entity.HasOne(ci => ci.ModifiedUserCartItem)
                .WithMany(u => u.ModifiedUserCartItems)
                .HasForeignKey(ci => ci.ModifiedUserId);
            });
        }
    }
}
