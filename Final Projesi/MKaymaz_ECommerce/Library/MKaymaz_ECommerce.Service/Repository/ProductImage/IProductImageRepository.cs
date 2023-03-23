using MKaymaz_ECommerce.Core.Repository;
using EF = MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.Service.Repository.ProductImage
{
    public interface IProductImageRepository :IRepository<EF.ProductImage>
    {
    }
}
