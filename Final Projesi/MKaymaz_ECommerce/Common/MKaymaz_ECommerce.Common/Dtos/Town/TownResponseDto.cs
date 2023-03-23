using MKaymaz_ECommerce.Common.Dtos.Base;
using MKaymaz_ECommerce.Common.Dtos.Location;
using System;

namespace MKaymaz_ECommerce.Common.Dtos.Town
{
    public class TownResponseDto :BaseDto
    {
        public string Name { get; set; }

        public Guid LocationId { get; set; }
        public LocationResponseDto Location { get; set; }
    }
}
