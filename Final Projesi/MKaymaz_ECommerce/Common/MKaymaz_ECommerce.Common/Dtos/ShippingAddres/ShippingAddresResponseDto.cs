using MKaymaz_ECommerce.Common.Dtos.Base;
using MKaymaz_ECommerce.Common.Dtos.Order;
using System;
using System.Collections.Generic;

namespace MKaymaz_ECommerce.Common.Dtos.ShippingAddres
{
    public class ShippingAddresResponseDto :BaseDto
    {
        public ShippingAddresResponseDto()
        {
            Orders = new HashSet<OrderResponseDto>();
        }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string SubLocation { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }

        public Guid OrderId { get; set; }
        public OrderResponseDto Order { get; set; }

        public ICollection<OrderResponseDto> Orders { get; set; }
    }
}
