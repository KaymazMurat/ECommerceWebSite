using MKaymaz_ECommerce.Model.Context;
using MKaymaz_ECommerce.Service.Repository.Base;
using EF = MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.Service.Repository.User
{
    public class UserRepository :Repository<EF.User>,IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) :base(context)
        {
            _context=context;
        }
    }
}
