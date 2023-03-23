using MKaymaz_ECommerce.Model.Context;
using MKaymaz_ECommerce.Service.Repository.Base;
using EF = MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.Service.Repository.Cart
{
    public class CartRepository : Repository<EF.Cart>,ICartRepository
    {
        private readonly DataContext _context;

        public CartRepository(DataContext context) :base(context)
        {
            _context=context;
        }
    }
}
