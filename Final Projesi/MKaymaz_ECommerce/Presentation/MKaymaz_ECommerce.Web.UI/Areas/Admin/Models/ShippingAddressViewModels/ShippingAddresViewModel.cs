using MKaymaz_ECommerce.Common.Enums;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CreateCartItemViewModels;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.OrderViewModels;
using System;
using System.Collections.Generic;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.ShippingAddressViewModels
{
    public class ShippingAddresViewModel
    {
        public ShippingAddresViewModel()
        {
            Orders = new HashSet<OrderViewModel>();
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }

        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string SubLocation { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }

        public Guid OrderId { get; set; }
        public OrderViewModel Order { get; set; }

        public ICollection<OrderViewModel> Orders { get; set; }

        public DateTime? CreatedDate { get; set; }
        public List<CartItemViewModel> CartItems { get; internal set; }
    }
}
