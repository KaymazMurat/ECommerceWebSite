using MKaymaz_ECommerce.Model.Context;
using MKaymaz_ECommerce.Service.Repository.Base;
using EF = MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.Service.Repository.Town
{
    public class TownRepository :Repository<EF.Town>,ITownRepository
    {
        private readonly DataContext _context;

        public TownRepository(DataContext context):base(context)
        {
            _context=context;
        }
    }
}
