using MKaymaz_ECommerce.Model.Context;
using MKaymaz_ECommerce.Service.Repository.Base;
using EF = MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.Service.Repository.ProductImage
{
    public class ProductImageRepository : Repository<EF.ProductImage>,IProductImageRepository
    {
        private readonly DataContext _context;

        public ProductImageRepository(DataContext context):base(context)
        {
            _context=context;
        }
    }
}
