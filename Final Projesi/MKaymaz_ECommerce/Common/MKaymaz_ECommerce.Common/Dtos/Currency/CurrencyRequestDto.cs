using MKaymaz_ECommerce.Common.Dtos.Base;

namespace MKaymaz_ECommerce.Common.Dtos.Currency
{
    public class CurrencyRequestDto :BaseDto
    {
        public string Label { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string Abbr { get; set; } // Kurun Kısaltması
        public string IsPrimary { get; set; }
    }
}
