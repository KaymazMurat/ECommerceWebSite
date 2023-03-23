using MKaymaz_ECommerce.Common.Dtos.Base;
using MKaymaz_ECommerce.Common.Dtos.Cart;
using MKaymaz_ECommerce.Common.Dtos.Product;
using System;

namespace MKaymaz_ECommerce.Common.Dtos.CartItem
{
    public class CartItemResponseDto :BaseDto
    {
        public int ParentProductId { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }

        public CartResponseDto Cart { get; set; }
        public ProductResponseDto Product { get; set; }
    }
}
