using MKaymaz_ECommerce.Core.Entity;
using System.Collections.Generic;

namespace MKaymaz_ECommerce.Model.Entities
{
    public class Country :CoreEntity
    {
        public Country()
        {
            Locations=new HashSet<Location>();

            Members=new HashSet<Member>();
        }
        public string Name { get; set; }
        public string Code { get; set; }

        public User CreatedUserCountry { get; set; }
        public User ModifiedUserCountry { get; set; }

        public ICollection<Location> Locations { get; set; }
        public ICollection<Member> Members { get; set; }

    }
}
