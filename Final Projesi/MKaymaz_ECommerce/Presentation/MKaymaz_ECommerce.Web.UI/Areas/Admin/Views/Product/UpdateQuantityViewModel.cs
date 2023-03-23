using System;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Views.Product
{
    public class UpdateQuantityViewModel
    {
        public Guid CartItemId { get; set; }
        public Decimal Quantity { get; set; }
    }
}
