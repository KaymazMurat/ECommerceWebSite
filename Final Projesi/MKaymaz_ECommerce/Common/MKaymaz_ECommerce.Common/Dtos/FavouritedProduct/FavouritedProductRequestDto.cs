using MKaymaz_ECommerce.Common.Dtos.Base;
using System;

namespace MKaymaz_ECommerce.Common.Dtos.FavouritedProduct
{
    public class FavouritedProductRequestDto :BaseDto
    {
        public Guid MemberId { get; set; }
        public Guid ProductId { get; set; }
    }
}
