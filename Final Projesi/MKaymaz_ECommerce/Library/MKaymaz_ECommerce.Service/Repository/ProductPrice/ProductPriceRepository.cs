using MKaymaz_ECommerce.Model.Context;
using MKaymaz_ECommerce.Service.Repository.Base;
using EF = MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.Service.Repository.ProductPrice
{
    public class ProductPriceRepository :Repository<EF.ProductPrice>,IProductPriceRepository
    {
        private readonly DataContext _context;

        public ProductPriceRepository(DataContext context):base(context)
        {
            _context=context;
        }
    }
}
