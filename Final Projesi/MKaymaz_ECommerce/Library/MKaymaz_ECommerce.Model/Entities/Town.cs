using MKaymaz_ECommerce.Core.Entity;
using System;

namespace MKaymaz_ECommerce.Model.Entities
{
    public class Town : CoreEntity
    {
        public string Name { get; set; }

        public Guid LocationId { get; set; }
        public Location Location { get; set; }

        public User CreatedUserTown{ get; set; }
        public User ModifiedUserTown { get; set; }


    }
}
