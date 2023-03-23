using Microsoft.EntityFrameworkCore;

namespace MKaymaz_ECommerce.Core.Map
{
    public interface IEntityBuilder
    {
        void Build(ModelBuilder builder);
    }
}
