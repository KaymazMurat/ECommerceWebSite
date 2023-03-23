using MKaymaz_ECommerce.Model.Context;
using MKaymaz_ECommerce.Service.Repository.Base;
using EF = MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.Service.Repository.Category
{
    public class CategoryRepository :Repository<EF.Category>,ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context) :base(context)
        {
            _context=context;
        }
    }
}
