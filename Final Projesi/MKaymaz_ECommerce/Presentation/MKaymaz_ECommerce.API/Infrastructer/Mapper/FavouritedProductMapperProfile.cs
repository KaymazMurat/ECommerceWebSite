using AutoMapper;
using MKaymaz_ECommerce.Common.Dtos.FavouritedProduct;
using MKaymaz_ECommerce.Common.Extensions;
using MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.API.Infrastructer.Mapper
{
    public class FavouritedProductMapperProfile : Profile
    {
        public FavouritedProductMapperProfile()
        {
            CreateMap<FavouritedProduct, FavouritedProductRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<FavouritedProduct, FavouritedProductResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
