﻿using MKaymaz_ECommerce.Common.Dtos.Base;
using System;

namespace MKaymaz_ECommerce.Common.Dtos.CartItem
{
    public class CartItemRequestDto :BaseDto
    {
        public int ParentProductId { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
    }
}
