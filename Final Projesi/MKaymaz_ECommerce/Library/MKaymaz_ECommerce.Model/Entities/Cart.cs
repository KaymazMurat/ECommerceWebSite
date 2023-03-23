using MKaymaz_ECommerce.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Entities
{
    public class Cart : CoreEntity
    {
        public Cart()
        {
            Cartİtems=new HashSet<CartItem>();
        }
        public Guid? SessionId { get; set; }
        public string Locked { get; set; }

        public Guid? UserId { get; set; }
        public User User { get; set; }

        public User CreatedUserCart { get; set; }
        public User ModifiedUserCart { get; set; }
        public ICollection<CartItem> Cartİtems { get; set; }
    }
}
