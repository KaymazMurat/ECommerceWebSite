using MKaymaz_ECommerce.Common.Enums;
using System;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.LocationViewModels
{
    public class CreateLocationViewModel
    {
        public Status Status { get; set; }
        public string Name { get; set; }
        public string Predefined { get; set; }

        public Guid CountryId { get; set; }
    }
}
