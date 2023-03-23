using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.OrderViewModels;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.ProductViewModels;
using System;
using System.Collections.Generic;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.OrderItemViewModels
{
    public class OrderItemViewModel
    {
      
        public string ProductName { get; set; }
        public string ProductSku { get; set; }
        public string ProductBarcode { get; set; }
        public Decimal? ProductPrice { get; set; }
        public string ProductCurrency { get; set; }
        public Decimal? ProductQuantity { get; set; }
        public int ProductTax { get; set; }
        public Decimal? ProductDiscount { get; set; }
        public Decimal? ProductMoneyOrderDiscount { get; set; }
        public Decimal? ProductWeight { get; set; }
        public string ProductStockTypeLabel { get; set; }
        public Decimal? Discount { get; set; }

        public Guid OrderId { get; set; }
        public OrderViewModel Order { get; set; }

        public Guid ProductId { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
