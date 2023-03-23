using MKaymaz_ECommerce.Common.Dtos.Base;
using MKaymaz_ECommerce.Common.Dtos.CartItem;
using MKaymaz_ECommerce.Common.Dtos.Member;
using MKaymaz_ECommerce.Common.Dtos.User;
using System;
using System.Collections.Generic;

namespace MKaymaz_ECommerce.Common.Dtos.Cart
{
    public class CartResponseDto :BaseDto
    {
        public CartResponseDto()
        {
            Cartİtems=new HashSet<CartItemResponseDto>();
        }
        public Guid? SessionId { get; set; }
        public string Locked { get; set; }

        public Guid? UserId { get; set; }
        public UserResponseDto User { get; set; }

        public ICollection<CartItemResponseDto> Cartİtems { get; set; }
    }
}
