using MKaymaz_ECommerce.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CategoryViewModels
{
    public class UpdateCategoryViewModel
    {
        public Guid Id{ get; set; }
        public Status Status { get; set; }
        [Required]
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public string ImageFile { get; set; }
        public string MetaKeywords { get; set; }

        [Required]
        public string MetaDescription { get; set; }
        public string PageTitle { get; set; }
    }
}
