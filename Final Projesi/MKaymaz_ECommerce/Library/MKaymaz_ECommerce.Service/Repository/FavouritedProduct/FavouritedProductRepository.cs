using MKaymaz_ECommerce.Model.Context;
using MKaymaz_ECommerce.Service.Repository.Base;
using EF = MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.Service.Repository.FavouritedProduct
{
    public class FavouritedProductRepository :Repository<EF.FavouritedProduct>,IFavouritedProductRepository
    {
        private readonly DataContext _context;

        public FavouritedProductRepository(DataContext context) :base(context)
        {
            _context=context;
        }
    }
}
