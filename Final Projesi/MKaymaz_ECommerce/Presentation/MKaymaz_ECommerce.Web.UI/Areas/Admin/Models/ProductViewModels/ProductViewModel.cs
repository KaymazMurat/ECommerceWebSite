using MKaymaz_ECommerce.Common.Enums;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.BrandViewModels;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CategoryViewModels;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CurrencyViewModels;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.UserViewModels;
using System;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.ProductViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string FullName { get; set; }
        public string Barcode { get; set; }
        public string Sku { get; set; }
        public Decimal Price1 { get; set; }
        public int? Warranty { get; set; }
        public int? Tax { get; set; }
        public Decimal? StockAmount { get; set; }
        public Decimal? VolumetricWeight { get; set; }
        public Decimal? BuyingPrice { get; set; }
        public string StockTypeLabel { get; set; }
        public Decimal? Discount { get; set; }
        public int? DiscountType { get; set; }
        public Decimal? MoneyOrderDiscount { get; set; }
        public bool? TaxIncluded { get; set; }
        public string Distributor { get; set; }
        public bool? IsGifted { get; set; }
        public string Gift { get; set; }
        public string CustomShippingDisabled { get; set; }
        public Decimal? CustomShippingCost { get; set; }
        public string MarketPriceDetail { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string CanonicalUrl { get; set; }
        public string PageTitle { get; set; }
        public string ShortDetails { get; set; }
        public string SearchKeywords { get; set; }
        public string InstallmentThreshold { get; set; }
        public int? HomeSortOrder { get; set; }
        public int? PopularSortOrder { get; set; }
        public int? BrandSortOrder { get; set; }
        public int? FeaturedSortOrder { get; set; }
        public int? CampaignedSortOrder { get; set; }
        public int? NewSortOrder { get; set; }
        public int? DiscountedSortOrder { get; set; }
        public int? ViewCount { get; set; }
        public Guid BrandId { get; set; }
        public Guid CurrencyId { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ParentId { get; set; }

        public DateTime? CreatedDate { get; set; }
        public UserViewModel User { get; set; }
        public ProductViewModel Parent { get; set; }
        public CategoryViewModel Category { get; set; }
        public CurrencyViewModel Currency { get; set; }
        public BrandViewModel Brand { get; set; }
    }
}
