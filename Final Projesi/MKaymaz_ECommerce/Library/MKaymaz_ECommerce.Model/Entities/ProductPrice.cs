using MKaymaz_ECommerce.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Entities
{
    public class ProductPrice :CoreEntity
    {
        public Decimal Value { get; set; }
        public int? Type { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public User CreatedUserProductPrice { get; set; }
        public User ModifiedUserProductPrice { get; set; }
    }
}
