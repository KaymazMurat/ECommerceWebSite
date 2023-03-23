using MKaymaz_ECommerce.Model.Context;
using MKaymaz_ECommerce.Service.Repository.Base;
using EF = MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.Service.Repository.OrderAddress
{
    public class OrderAddressRepository :Repository<EF.OrderAddress>,IOrderAddressRepository
    {
        private readonly DataContext _context;

        public OrderAddressRepository(DataContext context):base(context)
        {
            _context=context;
        }
    }
}
