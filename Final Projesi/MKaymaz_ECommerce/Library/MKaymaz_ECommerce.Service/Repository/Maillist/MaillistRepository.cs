using MKaymaz_ECommerce.Model.Context;
using MKaymaz_ECommerce.Service.Repository.Base;
using EF = MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.Service.Repository.Maillist
{
    public class MaillistRepository : Repository<EF.Maillist>, IMaillistRepository
    {
        private readonly DataContext _context;

        public MaillistRepository(DataContext context) : base(context)
        {
            _context=context;
        }
    }
}
