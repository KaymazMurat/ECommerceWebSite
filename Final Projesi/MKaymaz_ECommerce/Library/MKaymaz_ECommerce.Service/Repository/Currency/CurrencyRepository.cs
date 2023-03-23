using MKaymaz_ECommerce.Model.Context;
using MKaymaz_ECommerce.Service.Repository.Base;
using EF = MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.Service.Repository.Currency
{
    public class CurrencyRepository :Repository<EF.Currency>,ICurrencyRepository
    {
        private readonly DataContext _context;

        public CurrencyRepository(DataContext context):base(context)
        {
            _context=context;
        }
    }
}
