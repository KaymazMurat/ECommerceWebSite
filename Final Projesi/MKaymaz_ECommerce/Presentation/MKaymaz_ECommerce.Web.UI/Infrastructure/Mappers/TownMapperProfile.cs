using AutoMapper;
using MKaymaz_ECommerce.Common.Dtos.Town;
using MKaymaz_ECommerce.Common.Extensions;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.TownViewModels;

namespace MKaymaz_ECommerce.Web.UI.Infrastructure.Mappers
{
    public class TownMapperProfile : Profile
    {
        public TownMapperProfile()
        {
            CreateMap<TownViewModel, TownRequestDto>()
               .ReverseMap()
               .IgnoreAllNonExisting()
               .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<TownViewModel, TownResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateTownViewModel, TownRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateTownViewModel, TownResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateTownViewModel, TownRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateTownViewModel, TownResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}

