using MKaymaz_ECommerce.Common.Dtos.Base;
using MKaymaz_ECommerce.Common.Dtos.Product;
using System;

namespace MKaymaz_ECommerce.Common.Dtos.ProductImage
{
    public class ProductImageResponseDto :BaseDto
    {
        public string Filename { get; set; }
        public string Extension { get; set; }
        public string DirectoryName { get; set; }
        public string Revision { get; set; }
        public int? SortOrder { get; set; }
        public string Attachment { get; set; }

        public Guid ProductId { get; set; }
        public ProductResponseDto Product { get; set; }
    }
}
