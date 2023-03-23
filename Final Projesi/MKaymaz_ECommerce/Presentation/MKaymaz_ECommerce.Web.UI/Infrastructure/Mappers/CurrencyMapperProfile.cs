using AutoMapper;
using MKaymaz_ECommerce.Common.Dtos.Currency;
using MKaymaz_ECommerce.Common.Extensions;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CurrencyViewModels;

namespace MKaymaz_ECommerce.Web.UI.Infrastructure.Mappers
{
    public class CurrencyMapperProfile : Profile
    {
        public CurrencyMapperProfile()
        {
            CreateMap<CurrencyViewModel, CurrencyRequestDto>()
               .ReverseMap()
               .IgnoreAllNonExisting()
               .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CurrencyViewModel, CurrencyResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateCurrencyViewModel, CurrencyRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateCurrencyViewModel, CurrencyResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateCurrencyViewModel, CurrencyRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateCurrencyViewModel, CurrencyResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
