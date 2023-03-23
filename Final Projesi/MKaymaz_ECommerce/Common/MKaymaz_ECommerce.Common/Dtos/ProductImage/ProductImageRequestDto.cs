using MKaymaz_ECommerce.Common.Dtos.Base;
using System;

namespace MKaymaz_ECommerce.Common.Dtos.ProductImage
{
    public class ProductImageRequestDto :BaseDto
    {
        public string Filename { get; set; }
        public string Extension { get; set; }
        public string DirectoryName { get; set; }
        public string Revision { get; set; }
        public int? SortOrder { get; set; }
        public string Attachment { get; set; }

        public Guid ProductId { get; set; }
    }
}
