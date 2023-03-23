using MKaymaz_ECommerce.Common.Dtos.Base;
using MKaymaz_ECommerce.Common.Dtos.Brand;
using MKaymaz_ECommerce.Common.Dtos.CartItem;
using MKaymaz_ECommerce.Common.Dtos.Category;
using MKaymaz_ECommerce.Common.Dtos.Currency;
using MKaymaz_ECommerce.Common.Dtos.FavouritedProduct;
using MKaymaz_ECommerce.Common.Dtos.OrderItem;
using MKaymaz_ECommerce.Common.Dtos.ProductComment;
using MKaymaz_ECommerce.Common.Dtos.ProductImage;
using MKaymaz_ECommerce.Common.Dtos.ProductPrice;
using MKaymaz_ECommerce.Common.Dtos.User;
using System;
using System.Collections.Generic;

namespace MKaymaz_ECommerce.Common.Dtos.Product
{
    public class ProductResponseDto :BaseDto
    {
        public ProductResponseDto()
        {
            Parents = new HashSet<ProductResponseDto>();

            CartItems= new HashSet<CartItemResponseDto>();

            FavouritedProducts=new HashSet<FavouritedProductResponseDto>();

            OrderItems=new HashSet<OrderItemResponseDto>();

            ProductPrices=new HashSet<ProductPriceResponseDto>();

            ProductImages=new HashSet<ProductImageResponseDto>();

            ProductComments=new HashSet<ProductCommentResponseDto>();
        }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string FullName { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
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
        public Guid ParentId { get; set; }
        public Guid CurrencyId { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }

        public BrandResponseDto Brand { get; set; }
        public ProductResponseDto Parent { get; set; }
        public CurrencyResponseDto Currency { get; set; }
        public UserResponseDto User { get; set; }
        public CategoryResponseDto Category { get; set; }

        public ICollection<CartItemResponseDto> CartItems { get; set; }
        public ICollection<ProductResponseDto> Parents { get; set; }
        public ICollection<FavouritedProductResponseDto> FavouritedProducts { get; set; }
        public ICollection<OrderItemResponseDto> OrderItems { get; set; }
        public ICollection<ProductPriceResponseDto> ProductPrices { get; set; }
        public ICollection<ProductImageResponseDto> ProductImages { get; set; }
        public ICollection<ProductCommentResponseDto> ProductComments { get; set; }
    }
}
