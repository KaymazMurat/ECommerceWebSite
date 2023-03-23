using MKaymaz_ECommerce.Common.Dtos.Base;
using MKaymaz_ECommerce.Common.Dtos.Order;
using MKaymaz_ECommerce.Common.Dtos.Product;
using System;
using System.Collections.Generic;

namespace MKaymaz_ECommerce.Common.Dtos.OrderItem
{
    public class OrderItemResponseDto :BaseDto
    {
        public OrderItemResponseDto()
        {
            Orders=new HashSet<OrderResponseDto>();
        }
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
        public OrderResponseDto Order { get; set; }

        public Guid ProductId { get; set; }
        public ProductResponseDto Product { get; set; }

        public ICollection<OrderResponseDto> Orders { get; set; }
    }
}
