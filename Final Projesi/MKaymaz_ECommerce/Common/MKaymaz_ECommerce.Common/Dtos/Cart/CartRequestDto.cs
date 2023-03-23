using MKaymaz_ECommerce.Common.Dtos.Base;
using System;

namespace MKaymaz_ECommerce.Common.Dtos.Cart
{
    public class CartRequestDto :BaseDto
    {
        public Guid? SessionId { get; set; }
        public string Locked { get; set; }

        public Guid? UserId { get; set; }
    }
}
