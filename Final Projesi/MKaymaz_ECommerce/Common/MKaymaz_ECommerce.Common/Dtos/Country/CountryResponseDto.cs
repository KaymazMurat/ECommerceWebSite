using MKaymaz_ECommerce.Common.Dtos.Base;
using MKaymaz_ECommerce.Common.Dtos.Location;
using MKaymaz_ECommerce.Common.Dtos.Member;
using System.Collections.Generic;

namespace MKaymaz_ECommerce.Common.Dtos.Country
{
    public class CountryResponseDto :BaseDto
    {
        public CountryResponseDto()
        {
            Locations=new HashSet<LocationResponseDto>();

            Members=new HashSet<MemberResponseDto>();
        }
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<LocationResponseDto> Locations { get; set; }
        public ICollection<MemberResponseDto> Members { get; set; }
    }
}
