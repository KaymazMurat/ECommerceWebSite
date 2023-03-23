using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MKaymaz_ECommerce.API.Infrastructer.Helper;
using MKaymaz_ECommerce.Common.WorkContext;
using MKaymaz_ECommerce.Model.Context;
using MKaymaz_ECommerce.Service.Repository;
using MKaymaz_ECommerce.Service.Repository.Brand;
using MKaymaz_ECommerce.Service.Repository.Cart;
using MKaymaz_ECommerce.Service.Repository.CartItem;
using MKaymaz_ECommerce.Service.Repository.Category;
using MKaymaz_ECommerce.Service.Repository.Country;
using MKaymaz_ECommerce.Service.Repository.Currency;
using MKaymaz_ECommerce.Service.Repository.CurrentAccount;
using MKaymaz_ECommerce.Service.Repository.FavouritedProduct;
using MKaymaz_ECommerce.Service.Repository.Location;
using MKaymaz_ECommerce.Service.Repository.Maillist;
using MKaymaz_ECommerce.Service.Repository.Member;
using MKaymaz_ECommerce.Service.Repository.Order;
using MKaymaz_ECommerce.Service.Repository.OrderAddress;
using MKaymaz_ECommerce.Service.Repository.OrderDetail;
using MKaymaz_ECommerce.Service.Repository.OrderItem;
using MKaymaz_ECommerce.Service.Repository.Product;
using MKaymaz_ECommerce.Service.Repository.ProductComment;
using MKaymaz_ECommerce.Service.Repository.ProductImage;
using MKaymaz_ECommerce.Service.Repository.ProductPrice;
using MKaymaz_ECommerce.Service.Repository.ShippingAddress;
using MKaymaz_ECommerce.Service.Repository.Town;
using MKaymaz_ECommerce.Service.Repository.User;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.API
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", reloadOnChange: true, optional: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", reloadOnChange: true, optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);

            //API modülünü sürecimize ekliyoruz.
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(Configuration["ConnectionStrings:Conn"]);
            });

            //.Net Core yapýsý tamamiyle dependency Injection yapýsýyla çalýþtýðýndan Interface ile Service ve Repository classlarýnýn baðýmlýlýðýný tanýmlýyoruz.

            services.AddTransient<IWorkContext, ApiWorkContext>();
            services.AddHttpContextAccessor();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<ICartItemRepository, CartItemRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<ICurrentAccountRepository, CurrentAccountRepository>();
            services.AddTransient<IFavouritedProductRepository, FavouritedProductRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IMaillistRepository, MaillistRepository>();
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderAddressRepository, OrderAddressRepository>();
            services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductCommentRepository, ProductCommentRepository>();
            services.AddTransient<IProductImageRepository, ProductImageRepository>();
            services.AddTransient<IProductPriceRepository, ProductPriceRepository>();
            services.AddTransient<IShippingAddressRepository, ShippingAddressRepository>();
            services.AddTransient<ITownRepository, TownRepository>();
            services.AddTransient<IUserRepository, UserRepository>();



            //AutoMapper
            services.AddAutoMapper(typeof(Startup));
              
            //JWT Auth
            //use multiple authentication https://code-maze.com/dotnet-multiple-authentication-schemes/
            //[Authorize(Policy = "AdminJwtScheme")]
            //[Authorize(Policy = "UserJwtScheme")]
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    //using Microsoft.IdentityModel.Tokens
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = Configuration["Token:Issuer"],
                        ValidAudience = Configuration["Token:Audience"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:Key"]))
                    };
                });

            //Swagger
            services.AddSwaggerGen(c =>
            {
                //Microsoft.OpenApi.Models.
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Swagger on ASP.Net Core",
                    Version = "1.0.0",
                    Description = "Murat Kaymaz E-Ticaret Projesi(ASP.NET Core 3.1)",
                    TermsOfService = new Uri("http://swagger.io.terms")
                });
                 
                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "Mkaymaz ECommerce Core API Projesi JWT Authorization header (Bearer) kullanmaktadýr. Örnek: \"Authorization: Baarer {token}\"",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer"
                    });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Sadece Developmentta iken swaggerdan istek çekilmesi için yapýlan ayarlar...
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("../swagger/v1/swagger.json", "MY API V1");
                    c.RoutePrefix = "swagger";
                });
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
