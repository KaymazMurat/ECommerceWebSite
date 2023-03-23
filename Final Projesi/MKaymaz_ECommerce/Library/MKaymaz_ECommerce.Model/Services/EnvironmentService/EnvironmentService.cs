using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Services.EnvironmentService
{
    public class EnvironmentService : IEnvironmentService
    {
        public EnvironmentService()
        {
            EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        }
        public string EnvironmentName { get; set; }
    }
}
