using MKaymaz_ECommerce.Common.Dtos.Base;
using System;

namespace MKaymaz_ECommerce.Common.Dtos.Town
{
    public class TownRequestDto :BaseDto
    {
        public string Name { get; set; }

        public Guid LocationId { get; set; }
    }
}
