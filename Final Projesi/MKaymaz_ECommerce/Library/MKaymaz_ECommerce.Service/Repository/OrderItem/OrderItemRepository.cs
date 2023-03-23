using MKaymaz_ECommerce.Model.Context;
using MKaymaz_ECommerce.Service.Repository.Base;
using EF = MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.Service.Repository.OrderItem
{
    public class OrderItemRepository:Repository<EF.OrderItem>,IOrderItemRepository
    {
        private readonly DataContext _context;

        public OrderItemRepository(DataContext context):base(context)
        {
            _context=context;
        }
    }
}
