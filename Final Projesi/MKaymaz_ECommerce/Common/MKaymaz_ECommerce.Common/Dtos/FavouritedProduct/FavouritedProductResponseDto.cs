using MKaymaz_ECommerce.Common.Dtos.Base;
using MKaymaz_ECommerce.Common.Dtos.Member;
using MKaymaz_ECommerce.Common.Dtos.Product;
using System;

namespace MKaymaz_ECommerce.Common.Dtos.FavouritedProduct
{
    public class FavouritedProductResponseDto :BaseDto
    {
        public Guid MemberId { get; set; }
        public Guid ProductId { get; set; }

        public MemberResponseDto Member { get; set; }
        public ProductResponseDto Product { get; set; }
    }
}
