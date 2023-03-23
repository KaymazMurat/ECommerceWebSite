using Microsoft.Extensions.Configuration;

namespace MKaymaz_ECommerce.Model.Services.ConfigurationService
{
    public interface IConfigurationService
    {
        IConfiguration GetConfiguration();
    }
}
