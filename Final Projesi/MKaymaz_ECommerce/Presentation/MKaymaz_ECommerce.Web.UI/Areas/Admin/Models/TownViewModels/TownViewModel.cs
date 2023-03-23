using MKaymaz_ECommerce.Common.Enums;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.LocationViewModels;
using System;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.TownViewModels
{
    public class TownViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid LocationId { get; set; }
        public LocationViewModel Location { get; set; }
    }
}
