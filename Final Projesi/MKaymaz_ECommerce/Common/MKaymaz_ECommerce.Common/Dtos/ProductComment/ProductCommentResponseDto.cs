using MKaymaz_ECommerce.Common.Dtos.Base;
using MKaymaz_ECommerce.Common.Dtos.Member;
using MKaymaz_ECommerce.Common.Dtos.Product;
using System;

namespace MKaymaz_ECommerce.Common.Dtos.ProductComment
{
    public class ProductCommentResponseDto :BaseDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rank { get; set; }
        public string IsAnonymous { get; set; }

        public Guid MemberId { get; set; }
        public MemberResponseDto Member { get; set; }

        public Guid ProductId { get; set; }
        public ProductResponseDto Product { get; set; }
    }
}
