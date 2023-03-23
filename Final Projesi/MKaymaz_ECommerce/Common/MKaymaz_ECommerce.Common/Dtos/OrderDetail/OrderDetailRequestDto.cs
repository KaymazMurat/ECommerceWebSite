using MKaymaz_ECommerce.Common.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Common.Dtos.OrderDetail
{
    public class OrderDetailRequestDto :BaseDto
    {
        public string VarKey { get; set; }
        public string VarValue { get; set; }

        public Guid OrderId { get; set; }
    }
}
