using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MKaymaz_ECommerce.Common.Enums;
using MKaymaz_ECommerce.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.SeedData
{
    public class UserSeedData : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Status = Status.Active,
                    Email = "admin@admin.com",
                    Password = "123",
                    FirstName = "admin",
                    LastName = "admin",
                    Title = "Admin",
                    ImageUrl = "/",
                    LastLogin = null,
                    LastIPAddress = "127.0.0.1",
                    IsAdmin=true
                });
        }
    }
}
