using MKaymaz_ECommerce.Common.Enums;
using MKaymaz_ECommerce.Core.Entity;
using System;

namespace MKaymaz_ECommerce.Model.Entities
{
    public class ProductImage :CoreEntity
    {
        public string Filename { get; set; }
        public string Extension { get; set; }
        public string DirectoryName { get; set; }
        public string Revision { get; set; }
        public int? SortOrder { get; set; }
        public string Attachment { get; set; }


        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public User CreatedUserProductImage { get; set; }
        public User ModifiedUserProductImage { get; set; }
    }
}
