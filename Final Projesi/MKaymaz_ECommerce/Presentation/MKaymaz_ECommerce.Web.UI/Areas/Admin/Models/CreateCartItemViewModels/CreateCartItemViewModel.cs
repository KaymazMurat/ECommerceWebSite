using MKaymaz_ECommerce.Common.Enums;
using System;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CreateCartItemViewModels
{
    public class CreateCartItemViewModel
    {
        public Status Status{ get; set; }
        public int ParentProductId { get; set; }
        public Decimal Quantity { get; set; }
        public int CategoryId { get; set; }
        public Guid ProductId { get; set; }
    }
}
