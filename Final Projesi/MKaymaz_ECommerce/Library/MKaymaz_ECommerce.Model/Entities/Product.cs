using MKaymaz_ECommerce.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Entities
{
    public class Product : CoreEntity
    {
        public Product()
        {
            Parents = new HashSet<Product>();

            CartItems= new HashSet<CartItem>();

            FavouritedProducts=new HashSet<FavouritedProduct>();

            OrderItems=new HashSet<OrderItem>();

            ProductPrices=new HashSet<ProductPrice>();

            ProductImages=new HashSet<ProductImage>();

            ProductComments=new HashSet<ProductComment>();
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
        public Guid? ParentId { get; set; }
        public Guid CurrencyId { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }

        public User User { get; set; }
        public Brand Brand { get; set; }
        public Product? Parent { get; set; }
        public Currency Currency { get; set; }
        public Category Category { get; set; }

        public User CreatedUserProduct { get; set; }
        public User ModifiedUserProduct { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<Product> Parents { get; set; }
        public ICollection<FavouritedProduct> FavouritedProducts { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<ProductPrice> ProductPrices { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<ProductComment> ProductComments { get; set; }

    }
}
