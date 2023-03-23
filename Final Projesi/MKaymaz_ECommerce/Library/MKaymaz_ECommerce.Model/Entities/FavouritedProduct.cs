using MKaymaz_ECommerce.Core.Entity;
using System;

namespace MKaymaz_ECommerce.Model.Entities
{
    public class FavouritedProduct :CoreEntity
    {
        public Guid MemberId { get; set; }
        public Guid ProductId { get; set; }

        public Member Member { get; set; }
        public Product Product { get; set; }

        public User CreatedUserFavouritedProduct { get; set; }
        public User ModifiedUserFavouritedProduct { get; set; }
    }
}
