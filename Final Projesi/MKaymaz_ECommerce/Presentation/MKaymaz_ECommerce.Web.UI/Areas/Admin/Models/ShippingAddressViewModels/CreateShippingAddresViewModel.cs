using MKaymaz_ECommerce.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.ShippingAddressViewModels
{
    public class CreateShippingAddresViewModel
    {
        public Status Status { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string Country { get; set; }
        public string Location { get; set; }
        public string SubLocation { get; set; }
        [Required]
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }

        public Guid OrderId { get; set; }
    }
}
