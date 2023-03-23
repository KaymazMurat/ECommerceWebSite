using MKaymaz_ECommerce.Common.Dtos.Base;
using MKaymaz_ECommerce.Common.Dtos.Product;
using System;

namespace MKaymaz_ECommerce.Common.Dtos.ProductPrice
{
    public class ProductPriceResponseDto :BaseDto
    {
        public Decimal Value { get; set; }
        public int? Type { get; set; }

        public Guid ProductId { get; set; }
        public ProductResponseDto Product { get; set; }
    }
}
