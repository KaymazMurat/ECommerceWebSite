using MKaymaz_ECommerce.Common.Dtos.Base;
using MKaymaz_ECommerce.Common.Dtos.Member;
using System;

namespace MKaymaz_ECommerce.Common.Dtos.CurrentAccount
{
    public class CurrentAccountResponseDto :BaseDto
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int Balance { get; set; }
        public int RiskLimit { get; set; }

        public Guid MemberId { get; set; }
        public MemberResponseDto Member { get; set; }
    }
}
