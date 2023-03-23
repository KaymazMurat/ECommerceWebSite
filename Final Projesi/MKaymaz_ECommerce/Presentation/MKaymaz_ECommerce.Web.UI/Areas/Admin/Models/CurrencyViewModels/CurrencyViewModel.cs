using MKaymaz_ECommerce.Common.Enums;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.ProductViewModels;
using System;
using System.Collections.Generic;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CurrencyViewModels
{
    public class CurrencyViewModel
    {
        public CurrencyViewModel()
        {
            Products=new HashSet<ProductViewModel>();
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Label { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string Abbr { get; set; } // Kurun Kısaltması
        public string IsPrimary { get; set; }
        public DateTime? CreatedDate { get; set; }

        public ICollection<ProductViewModel> Products { get; set; }
    }
}
