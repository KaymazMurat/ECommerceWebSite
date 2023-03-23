using MKaymaz_ECommerce.Model.Context;
using MKaymaz_ECommerce.Service.Repository.Base;
using EF = MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.Service.Repository.OrderDetail
{
    public class OrderDetailRepository :Repository<EF.OrderDetail>,IOrderDetailRepository
    {
        private readonly DataContext _context;

        public OrderDetailRepository(DataContext context):base(context)
        {
            _context=context;
        }
    }
}
