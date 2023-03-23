using MKaymaz_ECommerce.Model.Context;
using MKaymaz_ECommerce.Service.Repository.Base;
using EF = MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.Service.Repository.Location
{
    public class LocationRepository :Repository<EF.Location>,ILocationRepository
    {
        private readonly DataContext _context;

        public LocationRepository(DataContext context):base(context)
        {
            _context=context;
        }
    }
}
