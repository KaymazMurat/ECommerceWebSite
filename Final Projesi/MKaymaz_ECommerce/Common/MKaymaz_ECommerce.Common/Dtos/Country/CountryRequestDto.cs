using MKaymaz_ECommerce.Common.Dtos.Base;

namespace MKaymaz_ECommerce.Common.Dtos.Country
{
    public class CountryRequestDto :BaseDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
