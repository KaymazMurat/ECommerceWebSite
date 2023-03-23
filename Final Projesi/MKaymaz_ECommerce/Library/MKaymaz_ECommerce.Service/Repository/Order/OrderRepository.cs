using MKaymaz_ECommerce.Model.Context;
using MKaymaz_ECommerce.Service.Repository.Base;
using EF = MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.Service.Repository.Order
{
    public class OrderRepository :Repository<EF.Order>,IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context):base(context)
        {
            _context=context;
        }
    }
}
