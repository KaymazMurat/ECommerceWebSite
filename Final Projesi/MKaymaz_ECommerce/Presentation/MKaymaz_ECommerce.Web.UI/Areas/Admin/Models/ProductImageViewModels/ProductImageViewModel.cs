using MKaymaz_ECommerce.Common.Enums;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.ProductViewModels;
using System;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.ProductImageViewModels
{
    public class ProductImageViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }

        public string Filename { get; set; }
        public string Extension { get; set; }
        public string DirectoryName { get; set; }
        public string Revision { get; set; }
        public int? SortOrder { get; set; }
        public string Attachment { get; set; }

        public Guid ProductId { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
