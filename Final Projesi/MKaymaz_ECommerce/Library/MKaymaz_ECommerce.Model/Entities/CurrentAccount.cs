using MKaymaz_ECommerce.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Entities
{
    public class CurrentAccount : CoreEntity
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int Balance { get; set; }
        public int RiskLimit { get; set; }

        public Guid MemberId { get; set; }
        public Member Member { get; set; }

        public User CreatedUserCurrentAccount { get; set; }
        public User ModifiedUserCurrentAccount { get; set; }
    }
}
