using MKaymaz_ECommerce.Common.Dtos.Base;
using MKaymaz_ECommerce.Common.Dtos.Order;
using System;
using System.Collections.Generic;

namespace MKaymaz_ECommerce.Common.Dtos.OrderDetail
{
    public class OrderDetailResponseDto :BaseDto
    {
        public OrderDetailResponseDto()
        {
            Orders = new HashSet<OrderResponseDto>();
        }
        public string VarKey { get; set; }
        public string VarValue { get; set; }

        public Guid OrderId { get; set; }
        public OrderResponseDto Order { get; set; }

        public ICollection<OrderResponseDto> Orders { get; set; }
    }
}
