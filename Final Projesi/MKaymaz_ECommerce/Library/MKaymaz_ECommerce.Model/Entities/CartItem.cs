using MKaymaz_ECommerce.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Entities
{
    public class CartItem : CoreEntity
    {
        public int ParentProductId { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }

        public Cart Cart { get; set; }
        public Product Product { get; set; }

        public User CreatedUserCartItem { get; set; }
        public User ModifiedUserCartItem { get; set; }
    }
}
