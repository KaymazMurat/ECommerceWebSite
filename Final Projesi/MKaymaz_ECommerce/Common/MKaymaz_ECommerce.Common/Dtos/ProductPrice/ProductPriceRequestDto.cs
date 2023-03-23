using MKaymaz_ECommerce.Common.Dtos.Base;
using System;

namespace MKaymaz_ECommerce.Common.Dtos.ProductPrice
{
    public class ProductPriceRequestDto :BaseDto
    {
        public Decimal Value { get; set; }
        public int? Type { get; set; }

        public Guid ProductId { get; set; }
    }
}
