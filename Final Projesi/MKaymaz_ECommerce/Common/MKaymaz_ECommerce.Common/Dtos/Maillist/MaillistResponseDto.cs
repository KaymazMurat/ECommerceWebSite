using MKaymaz_ECommerce.Common.Dtos.Base;
using MKaymaz_ECommerce.Common.Dtos.Order;
using System;
using System.Collections.Generic;

namespace MKaymaz_ECommerce.Common.Dtos.Maillist
{
    public class MaillistResponseDto :BaseDto
    {
        public MaillistResponseDto()
        {
            Orders=new HashSet<OrderResponseDto>();
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? LastMailSentDate { get; set; }
        public string CreatorIpAddres { get; set; }

        public ICollection<OrderResponseDto> Orders { get; set; }
    }
}
