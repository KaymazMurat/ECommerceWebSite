using MKaymaz_ECommerce.Model.Context;
using MKaymaz_ECommerce.Service.Repository.Base;
using EF = MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.Service.Repository.Member
{
    public class MemberRepository : Repository<EF.Member>,IMemberRepository
    {
        private readonly DataContext _context;

        public MemberRepository(DataContext context):base(context)
        {
            _context=context;
        }
    }
}
