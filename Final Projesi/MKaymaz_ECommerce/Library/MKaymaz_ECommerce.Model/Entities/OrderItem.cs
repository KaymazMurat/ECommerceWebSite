using MKaymaz_ECommerce.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Entities
{
    public class OrderItem:CoreEntity
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
        public Order Order { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public User CreatedUserOrderItem { get; set; }
        public User ModifiedUserOrderItem { get; set; }

      
    }
}
