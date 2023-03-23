using MKaymaz_ECommerce.Common.Enums;
using System;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.TownViewModels
{
    public class UpdateTownViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid LocationId { get; set; }
    }
}
