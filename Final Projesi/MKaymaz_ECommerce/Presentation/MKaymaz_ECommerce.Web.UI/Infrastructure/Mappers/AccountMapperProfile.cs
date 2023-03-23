using AutoMapper;
using MKaymaz_ECommerce.Common.Dtos.Login;
using MKaymaz_ECommerce.Common.Dtos.User;
using MKaymaz_ECommerce.Common.Extensions;
using MKaymaz_ECommerce.Web.UI.Models.AccountViewModels;

namespace MKaymaz_ECommerce.Web.UI.Infrastructure.Mappers
{
    public class AccountMapperProfile : Profile
    {
        public AccountMapperProfile()
        {
            CreateMap<LoginViewModel, LoginRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<LoginViewModel, UserResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
