using MKaymaz_ECommerce.Common.Enums;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.ProductViewModels;
using System;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CreateCartItemViewModels
{
    public class CartItemViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public int ParentProductId { get; set; }
        public Decimal Quantity { get; set; }
        public int CategoryId { get; set; }
        public Guid ProductId { get; set; }
        public Guid CartId { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
