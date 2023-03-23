using MKaymaz_ECommerce.Common.Dtos.Base;
using MKaymaz_ECommerce.Common.Dtos.Country;
using MKaymaz_ECommerce.Common.Dtos.Member;
using MKaymaz_ECommerce.Common.Dtos.Town;
using System;
using System.Collections.Generic;

namespace MKaymaz_ECommerce.Common.Dtos.Location
{
    public class LocationResponseDto :BaseDto
    {
        public LocationResponseDto()
        {
            Members=new HashSet<MemberResponseDto>();

            Towns=new HashSet<TownResponseDto>();
        }
        public string Name { get; set; }
        public string Predefined { get; set; }

        public Guid CountryId { get; set; }
        public CountryResponseDto Country { get; set; }

        public ICollection<MemberResponseDto> Members { get; set; }
        public ICollection<TownResponseDto> Towns { get; set; }
    }
}
