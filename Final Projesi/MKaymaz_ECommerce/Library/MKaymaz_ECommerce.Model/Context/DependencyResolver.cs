﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MKaymaz_ECommerce.Model.Services.ConfigurationService;
using MKaymaz_ECommerce.Model.Services.EnvironmentService;
using System;

namespace MKaymaz_ECommerce.Model.Context
{
    public class DependencyResolver
    {
        public IServiceProvider ServiceProvider { get; }

        public string CurrentDirectory { get; set; }

        public DependencyResolver()
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            //Register env and config services
            services.AddTransient<IEnvironmentService, EnvironmentService>();
            services.AddTransient<IConfigurationService, ConfigurationService>(provider =>
                new ConfigurationService(provider.GetService<IEnvironmentService>())
                {
                    CurrentDirectory = this.CurrentDirectory
                });

            //Register DataContext class
            services.AddTransient(provider =>
            {
                var optionBuilder = new DbContextOptionsBuilder<DataContext>();
                var configService = provider.GetService<IConfigurationService>();

                var connectionString = configService.GetConfiguration().GetConnectionString("Conn");
                optionBuilder.UseNpgsql(connectionString, builder => builder.MigrationsAssembly("MKaymaz_ECommerce.Model"));
                optionBuilder.EnableSensitiveDataLogging();

                IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
                return new DataContext(optionBuilder.Options, httpContextAccessor);
            });
        }
    }
}
