using MKaymaz_ECommerce.Model.Context;
using MKaymaz_ECommerce.Service.Repository.Base;
using EF = MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.Service.Repository.CurrentAccount
{
    public class CurrentAccountRepository :Repository<EF.CurrentAccount>,ICurrentAccountRepository
    {
        private readonly DataContext _context;

        public CurrentAccountRepository(DataContext context):base(context)
        {
            _context=context;
        }
    }
}
