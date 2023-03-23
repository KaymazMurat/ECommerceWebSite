using MKaymaz_ECommerce.Model.Context;
using MKaymaz_ECommerce.Service.Repository.Base;
using EF = MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.Service.Repository.ShippingAddress
{
    public class ShippingAddressRepository :Repository<EF.ShippingAddres>,IShippingAddressRepository
    {
        private readonly DataContext _context;

        public ShippingAddressRepository(DataContext context):base(context)
        {
            _context=context;
        }
    }
}
