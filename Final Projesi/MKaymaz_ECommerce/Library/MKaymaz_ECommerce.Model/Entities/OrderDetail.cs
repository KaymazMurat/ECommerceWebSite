using MKaymaz_ECommerce.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Entities
{
    public class OrderDetail :CoreEntity
    {
        public OrderDetail()
        {
            Orders = new HashSet<Order>();
        }
        public string VarKey { get; set; }
        public string VarValue { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public User CreatedUserOrderDetail { get; set; }
        public User ModifiedUserOrderDetail { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
