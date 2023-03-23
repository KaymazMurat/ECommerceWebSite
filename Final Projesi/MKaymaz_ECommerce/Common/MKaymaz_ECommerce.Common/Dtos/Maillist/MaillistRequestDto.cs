using MKaymaz_ECommerce.Common.Dtos.Base;
using System;

namespace MKaymaz_ECommerce.Common.Dtos.Maillist
{
    public class MaillistRequestDto :BaseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? LastMailSentDate { get; set; }
        public string CreatorIpAddres { get; set; }
    }
}
