using AutoMapper;
using MKaymaz_ECommerce.Common.Dtos.Product;
using MKaymaz_ECommerce.Common.Extensions;
using MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.API.Infrastructer.Mapper
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Product, ProductRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Product, ProductResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
