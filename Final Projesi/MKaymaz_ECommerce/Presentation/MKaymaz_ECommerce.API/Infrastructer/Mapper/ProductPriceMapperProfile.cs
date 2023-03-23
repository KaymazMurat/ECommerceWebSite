using AutoMapper;
using MKaymaz_ECommerce.Common.Dtos.ProductPrice;
using MKaymaz_ECommerce.Common.Extensions;
using MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.API.Infrastructer.Mapper
{
    public class ProductPriceMapperProfile : Profile
    {
        public ProductPriceMapperProfile()
        {
            CreateMap<ProductPrice, ProductPriceRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ProductPrice, ProductPriceResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
