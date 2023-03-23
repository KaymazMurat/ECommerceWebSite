using MKaymaz_ECommerce.Common.Dtos.Base;
using MKaymaz_ECommerce.Common.Dtos.Product;
using System.Collections.Generic;

namespace MKaymaz_ECommerce.Common.Dtos.Currency
{
    public class CurrencyResponseDto :BaseDto
    {
        public CurrencyResponseDto()
        {
            Products=new HashSet<ProductResponseDto>();
        }
        public string Label { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string Abbr { get; set; } // Kurun Kısaltması
        public string IsPrimary { get; set; }

        public ICollection<ProductResponseDto> Products { get; set; }
    }
}
