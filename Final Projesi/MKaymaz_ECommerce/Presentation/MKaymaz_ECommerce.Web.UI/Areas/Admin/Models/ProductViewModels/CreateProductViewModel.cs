using MKaymaz_ECommerce.Common.Enums;
using System;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.ProductViewModels
{
    public class CreateProductViewModel
    {
        public Status Status { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Barcode { get; set; }
        public string Sku { get; set; }
        public Decimal Price1 { get; set; }
        public string StockTypeLabel { get; set; }
        public bool? TaxIncluded { get; set; }
        public string MetaDescription { get; set; }
        public Guid BrandId { get; set; }
        public Guid CurrencyId { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
