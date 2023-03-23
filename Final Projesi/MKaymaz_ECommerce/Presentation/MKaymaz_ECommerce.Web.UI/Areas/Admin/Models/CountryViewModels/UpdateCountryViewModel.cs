using MKaymaz_ECommerce.Common.Enums;
using System;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CountryViewModels
{
    public class UpdateCountryViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
