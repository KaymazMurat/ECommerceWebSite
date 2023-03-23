using MKaymaz_ECommerce.Common.Enums;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CountryViewModels;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.MemberViewModels;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.TownViewModels;
using System;
using System.Collections.Generic;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.LocationViewModels
{
    public class LocationViewModel
    {
        public LocationViewModel()
        {
            Members=new HashSet<MemberViewModel>();

            Towns=new HashSet<TownViewModel>();
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; }
        public string Predefined { get; set; }

        public Guid CountryId { get; set; }
        public CountryViewModel Country { get; set; }
        public DateTime? CreatedDate { get; set; }

        public ICollection<MemberViewModel> Members { get; set; }
        public ICollection<TownViewModel> Towns { get; set; }
    }
}
