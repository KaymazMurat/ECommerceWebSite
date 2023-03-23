using Microsoft.EntityFrameworkCore.Design;
using System.IO;

namespace MKaymaz_ECommerce.Model.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var resolver = new DependencyResolver
            {
                CurrentDirectory = Path.Combine(Directory.GetCurrentDirectory(), "../MKaymaz_ECommerce.API")
            };
            return resolver.ServiceProvider.GetService(typeof(DataContext)) as DataContext;
        }
    }
}
