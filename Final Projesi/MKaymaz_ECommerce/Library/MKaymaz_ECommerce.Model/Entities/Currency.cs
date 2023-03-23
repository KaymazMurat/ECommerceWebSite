using MKaymaz_ECommerce.Core.Entity;
using System.Collections.Generic;

namespace MKaymaz_ECommerce.Model.Entities
{
    public class Currency : CoreEntity
    {
        public Currency()
        {
            Products=new HashSet<Product>();
        }
        public string Label { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string Abbr { get; set; } // Kurun Kısaltması
        public string IsPrimary { get; set; }

        public User CreatedUserCurrency { get; set; }
        public User ModifiedUserCurrency { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
