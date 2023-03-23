using MKaymaz_ECommerce.Model.Context;
using MKaymaz_ECommerce.Service.Repository.Base;
using EF = MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.Service.Repository.CartItem
{
    public class CartItemRepository :Repository<EF.CartItem>,ICartItemRepository
    {
        private readonly DataContext _context;
        public CartItemRepository(DataContext context) :base(context)
        {
            _context=context;
        }
    }
}
