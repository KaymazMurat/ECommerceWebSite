using MKaymaz_ECommerce.Common.Dtos.Base;

namespace MKaymaz_ECommerce.Common.Dtos.Brand
{
    public class BrandRequestDto :BaseDto
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public int SortOrder { get; set; }
        public string DistributorCode { get; set; }
        public string Distributor { get; set; }
        public string ImageFile { get; set; }
        public string ShowcaseContent { get; set; }
        public string DisplayShowcaseContent { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string CanonicalUrl { get; set; }
        public string PageTitle { get; set; }
        public string Attachment { get; set; }
    }
}
