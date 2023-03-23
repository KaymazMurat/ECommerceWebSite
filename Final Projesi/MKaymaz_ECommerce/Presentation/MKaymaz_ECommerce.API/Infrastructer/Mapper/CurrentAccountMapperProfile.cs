using AutoMapper;
using MKaymaz_ECommerce.Common.Dtos.CurrentAccount;
using MKaymaz_ECommerce.Common.Extensions;
using MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.API.Infrastructer.Mapper
{
    public class CurrentAccountMapperProfile : Profile
    {
        public CurrentAccountMapperProfile()
        {
            CreateMap<CurrentAccount, CurrentAccountRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CurrentAccount, CurrentAccountResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}

