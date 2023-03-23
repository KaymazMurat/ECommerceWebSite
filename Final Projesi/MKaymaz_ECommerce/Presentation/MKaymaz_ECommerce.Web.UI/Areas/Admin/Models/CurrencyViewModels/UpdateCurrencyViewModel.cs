using MKaymaz_ECommerce.Common.Enums;
using System;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CurrencyViewModels
{
    public class UpdateCurrencyViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Label { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string Abbr { get; set; } // Kurun Kısaltması
        public string IsPrimary { get; set; }
    }
}
