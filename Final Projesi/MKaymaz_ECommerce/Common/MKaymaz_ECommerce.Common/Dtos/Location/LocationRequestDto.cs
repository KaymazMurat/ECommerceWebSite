using MKaymaz_ECommerce.Common.Dtos.Base;
using System;

namespace MKaymaz_ECommerce.Common.Dtos.Location
{
    public class LocationRequestDto :BaseDto
    {
        public string Name { get; set; }
        public string Predefined { get; set; }

        public Guid CountryId { get; set; }

    }
}
