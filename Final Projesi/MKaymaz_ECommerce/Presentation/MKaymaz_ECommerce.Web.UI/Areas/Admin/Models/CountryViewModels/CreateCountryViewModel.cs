using MKaymaz_ECommerce.Common.Enums;
using System;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CountryViewModels
{
    public class CreateCountryViewModel
    {
        public Status Status { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
