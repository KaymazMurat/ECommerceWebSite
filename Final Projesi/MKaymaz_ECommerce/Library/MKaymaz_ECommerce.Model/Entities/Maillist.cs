using MKaymaz_ECommerce.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Entities
{
    public class Maillist :CoreEntity
    {
        public Maillist()
        {
            Orders=new HashSet<Order>();
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? LastMailSentDate { get; set; }
        public string CreatorIpAddres { get; set; }

        public User CreatedUserMaillist { get; set; }
        public User ModifiedUserMaillist { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
