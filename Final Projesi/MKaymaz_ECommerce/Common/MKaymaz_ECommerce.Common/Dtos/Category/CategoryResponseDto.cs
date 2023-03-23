using MKaymaz_ECommerce.Common.Dtos.Base;
using MKaymaz_ECommerce.Common.Dtos.Product;
using System.Collections.Generic;

namespace MKaymaz_ECommerce.Common.Dtos.Category
{
    public class CategoryResponseDto :BaseDto
    {
        public CategoryResponseDto()
        {
            Products=new HashSet<ProductResponseDto>();
        }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int SortOrder { get; set; }
        public string DistrbutorCode { get; set; }
        public decimal Percent { get; set; }
        public string ImageFile { get; set; }
        public string Distributor { get; set; }
        public int DisplayShowcaseContent { get; set; }
        public string ShowcaseContent { get; set; }
        public int ShowcaseContentDisplayType { get; set; }
        public int DisplayShowcaseFooterContent { get; set; }
        public string ShowcaseFooterContent { get; set; }
        public int ShowcaseFooterContentDisplayType { get; set; }
        public bool HasChildren { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string CanonicalUrl { get; set; }
        public string PageTitle { get; set; }
        public string Attachment { get; set; }

        public ICollection<ProductResponseDto> Products { get; set; }

    }
}
