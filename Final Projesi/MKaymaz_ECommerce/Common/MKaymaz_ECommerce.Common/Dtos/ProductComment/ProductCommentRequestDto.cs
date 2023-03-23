using MKaymaz_ECommerce.Common.Dtos.Base;
using System;

namespace MKaymaz_ECommerce.Common.Dtos.ProductComment
{
    public class ProductCommentRequestDto :BaseDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rank { get; set; }
        public string IsAnonymous { get; set; }

        public Guid MemberId { get; set; }

        public Guid ProductId { get; set; }
    }
}
