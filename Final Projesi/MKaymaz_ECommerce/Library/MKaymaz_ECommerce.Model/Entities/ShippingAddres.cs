using MKaymaz_ECommerce.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Entities
{
    public class ShippingAddres :CoreEntity
    {
        public ShippingAddres()
        {
            Orders = new HashSet<Order>();
        }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string SubLocation { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }

        public User CreatedUserShippingAddress { get; set; }
        public User ModifiedUserShippingAddress { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
