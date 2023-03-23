using MKaymaz_ECommerce.Model.Context;
using MKaymaz_ECommerce.Service.Repository.Base;
using EF = MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.Service.Repository.Product
{
    public class ProductRepository :Repository<EF.Product>,IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context):base(context)
        {
            _context=context;
        }
    }
}
