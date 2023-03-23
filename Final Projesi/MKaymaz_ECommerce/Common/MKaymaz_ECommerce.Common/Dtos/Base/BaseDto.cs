using MKaymaz_ECommerce.Common.Enums;
using System;

namespace MKaymaz_ECommerce.Common.Dtos.Base
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
    }
}
