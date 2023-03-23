using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Core.Map;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Model.Maps.Base;

namespace MKaymaz_ECommerce.Model.Maps
{
    public class MaillistMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Maillist>(entity =>
            {
                entity.ToTable("Maillists");

                entity.HasExtended();

                entity.Property(x=>x.Name).HasMaxLength(255).IsRequired(true);
                entity.Property(x=>x.Email).HasMaxLength(255).IsRequired(true);
                entity.Property(x=>x.LastMailSentDate).IsRequired(false);
                entity.Property(x=>x.CreatorIpAddres).HasMaxLength(64).IsRequired(false);

                entity
                    .HasOne(m => m.CreatedUserMaillist)
                    .WithMany(u => u.CreatedUserMaillists)
                    .HasForeignKey(m => m.CreatedUserId);

                entity
                    .HasOne(m => m.ModifiedUserMaillist)
                    .WithMany(u => u.ModifiedUserMaillists)
                    .HasForeignKey(m => m.ModifiedUserId);
            });
        }
    }
}
