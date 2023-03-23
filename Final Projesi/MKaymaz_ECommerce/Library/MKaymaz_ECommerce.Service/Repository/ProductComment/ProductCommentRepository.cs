using MKaymaz_ECommerce.Model.Context;
using MKaymaz_ECommerce.Service.Repository.Base;
using EF = MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.Service.Repository.ProductComment
{
    public class ProductCommentRepository :Repository<EF.ProductComment>,IProductCommentRepository
    {
        private readonly DataContext _context;

        public ProductCommentRepository(DataContext context):base(context)
        {
            _context=context;
        }
    }
}
