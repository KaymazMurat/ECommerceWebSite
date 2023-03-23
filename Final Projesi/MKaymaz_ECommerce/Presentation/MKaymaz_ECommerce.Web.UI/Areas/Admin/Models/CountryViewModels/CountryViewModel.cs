using MKaymaz_ECommerce.Common.Enums;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.LocationViewModels;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.MemberViewModels;
using System;
using System.Collections.Generic;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CountryViewModels
{
    public class CountryViewModel
    {
        public CountryViewModel()
        {
            Locations=new HashSet<LocationViewModel>();

            Members=new HashSet<MemberViewModel>();
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime? CreatedDate { get; set; }

        public ICollection<LocationViewModel> Locations { get; set; }
        public ICollection<MemberViewModel> Members { get; set; }
    }
}
