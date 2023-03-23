using MKaymaz_ECommerce.Common.Dtos.Base;
using MKaymaz_ECommerce.Common.Dtos.Order;
using System;

namespace MKaymaz_ECommerce.Common.Dtos.OrderAddress
{
    public class OrderAddressResponseDto :BaseDto
    {
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
    }
}
