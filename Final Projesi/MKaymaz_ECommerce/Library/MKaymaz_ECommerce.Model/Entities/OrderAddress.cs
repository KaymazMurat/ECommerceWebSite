using MKaymaz_ECommerce.Core.Entity;
using System;

namespace MKaymaz_ECommerce.Model.Entities
{
    public class OrderAddress :CoreEntity
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string SubLocation { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }

        public User CreatedUserOrderAddress { get; set; }
        public User ModifiedUserOrderAddress { get; set; }
    }
}
