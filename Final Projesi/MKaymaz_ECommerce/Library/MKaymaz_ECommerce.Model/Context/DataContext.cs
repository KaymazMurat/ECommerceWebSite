﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MKaymaz_ECommerce.Core.Entity;
using MKaymaz_ECommerce.Core.Map;
using MKaymaz_ECommerce.Model.Entities;
using MKaymaz_ECommerce.Model.SeedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Model.Context
{
    public class DataContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DataContext(DbContextOptions<DataContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrentAccount> CurrentAccounts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FavouritedProduct> FavouritedProducts { get; set; }
        public DbSet<Maillist> Maillists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderAddress> OrderAddresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<ShippingAddres> ShippingAddreses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            RegisterMappings(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserSeedData());
        }

        private void RegisterMappings(ModelBuilder modelBuilder)
        {
            var typeToRegister = new List<Type>();
            var dataAssembly = Assembly.GetExecutingAssembly();

            typeToRegister.AddRange(dataAssembly.DefinedTypes.Select(x => x.AsType()));
            foreach (var buildertype in typeToRegister.Where(x => typeof(IEntityBuilder).IsAssignableFrom(x)))
            {
                if (buildertype != null && buildertype != typeof(IEntityBuilder))
                {
                    var builder = (IEntityBuilder)Activator.CreateInstance(buildertype);
                    builder.Build(modelBuilder);
                }
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var modifiedEntites //Değişiklik izleyici
                = ChangeTracker
                    .Entries()
                    .Where(
                    x =>
                    x.State == EntityState.Modified ||
                    x.State == EntityState.Added);

            var computerName = Dns.GetHostEntry(_httpContextAccessor.HttpContext.Connection.RemoteIpAddress).HostName; //ComputerName'i verecek
            var iPAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(); // RemoteIPAdesini verecek.

            foreach (var item in modifiedEntites)
            {
                CoreEntity entity = item.Entity as CoreEntity;
                if (item != null)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            entity.CreatedComputerName = computerName;
                            entity.CreatedIP = iPAddress;
                            entity.CreatedDate = DateTime.Now;
                            entity.CreatedUserId = GetUserId();
                            break;
                        case EntityState.Modified:
                            entity.ModifiedComputerName = computerName;
                            entity.ModifiedIP = iPAddress;
                            entity.ModifiedDate = DateTime.Now;
                            entity.ModifiedUserId = GetUserId();
                            break;
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        private Guid? GetUserId()
        {
            string userId = ""; 
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var claims = _httpContextAccessor.HttpContext.User.Claims.ToList();
                userId = claims?.FirstOrDefault(x => x.Type.Equals("jti", StringComparison.OrdinalIgnoreCase))?.Value;
            }

            if (!string.IsNullOrEmpty(userId))
                return Guid.Parse(userId);
            else
                return null;
        }
    }

}
// Projeyi API'den ayağa kaldırılacak...     1.)  appsettings.Development