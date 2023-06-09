﻿using MKaymaz_ECommerce.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Entities
{
    public class Location : CoreEntity
    {
        public Location()
        {
            Members=new HashSet<Member>();

            Towns=new HashSet<Town>();
        }
        public string Name { get; set; }
        public string Predefined { get; set; }

        public Guid CountryId { get; set; }
        public Country Country { get; set; }

        public User CreatedUserLocation { get; set; }
        public User ModifiedUserLocation { get; set; }

        public ICollection<Member> Members { get; set; }
        public ICollection<Town> Towns { get; set; }

    }
}
